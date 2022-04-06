using MangaLibraryManager.Core.Data;
using MangaLibraryManager.Core.Utilities;
using MangaLibraryManager.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MangaLibraryManager.Forms.RenameForm;

namespace MangaLibraryManager
{
    public partial class MainForm : MetroForm
    {
        #region Variables de la fenêtre
        public List<CBZArchive> listeVolumesSerie = new List<CBZArchive>();
        CBZArchive volumeSelection = null;
        public DateTime Start;
        private object fLock = new object();
        DirectoryInfo directorySerie;
        TasksForm tasks = null;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            // Chargement de la config
            ConfigurationFactory.Load();

            this.FormClosing += delegate
            {
                TempFactory.Current.Dispose();
            };
            //this.pLoading.BackColor = System.Drawing.Color.FromArgb(25, Color.White);



        }

        #region Gestion des forms
        protected void OpenSettings()
        {
            SettingsForm settingsForm = new SettingsForm(this.metroStyleManager1);
            settingsForm.Show();

        }
        protected void OpenTasks()
        {
            if (tasks == null)
            {
                tasks = new TasksForm(this.metroStyleManager1);
                tasks.Show();
                tasks.FormClosed += delegate { tasks = null; };
            }
            else
            {
                if(tasks.Visible == false)
                {
                    tasks.Show();
                    tasks.Refresh();
                }
                tasks.BringToFront();
            }

        }
        protected void OpenRenameTool(IEnumerable<CBZArchive> archives)
        {
            RenameForm renForm = new RenameForm(this.metroStyleManager1);
            renForm.RenameItemCompleted += onItemRenamed;
            renForm.RenameCompleted += delegate
            {
                this.refreshListVolumes();
            };
            renForm.ShowDialog(archives);
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            this.chargerListeSeries();

            // Gestion des background worker
            this.bgReadMangaDirectory.DoWork += new DoWorkEventHandler(this.backgroundLancerLectureDossier);
            this.bgReadMangaDirectory.ProgressChanged += OnProgressLectureDossier;

            this.bgCompressBooks.RunWorkerCompleted += (worker, arg) =>
            {
                this.btCompressAll.Enabled = this.btCompressSelection.Enabled = true;
              
                //On actualise la liste des volumes
                this.refreshListVolumes();
            };
            bgReadMangaDirectory.RunWorkerCompleted += delegate
            {
                this.pLoad.Visible = false;
                this.lvBooks.Enabled = true;

            };


            // Mise en place d'un double buffer sur les listes afin d'eviter les phénomenes de sintillement
            var doubleBufferPropertyInfo = this.lvBooks.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(this.lvBooks, true, null);

            TasksFactory.Current.TaskProgress += (s, args) =>
             {
                 int iCount = TasksFactory.Current.currentTasks.Count(a => a.Percentage < 100);
                 this.panelTasks.Invoke((Action)(() => this.panelTasks.Visible = iCount > 0));
                 this.lblNbTaches.Invoke((Action)(() => this.lblNbTaches.Text = $"{iCount} tâches en cours..."));

             };
        }
        
        #region Gestion des volumes de séries
        private void OnVolumeSelection(object sender, EventArgs e)
        {

            if (this.lvBooks.SelectedItems.Count == 1
                && this.listeVolumesSerie.Any(a => a.Name == this.lvBooks.SelectedItems[0].Text))
            {
                this.volumeSelection = this.listeVolumesSerie.Find(a => a.Name == this.lvBooks.SelectedItems[0].Text);
                this.afficherApercu(this.volumeSelection);
            }
            else this.cacherApercu();

            this.btCompressSelection.Enabled = this.lvBooks.SelectedItems.Count > 0;

        }
        private void OnVolumeChecked(object sender, ItemCheckEventArgs e)
        {
            OnVolumeSelection(sender, e);
        }
        private void OnVolumeSelectionneChanged(object sender, EventArgs e)
        {
            OnVolumeSelection(sender, e);
        }
        private void OnVolumeDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.volumeSelection != null)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = this.volumeSelection.filePath;
                Process.Start(startInfo);
            }
        }
        private void ajouterVolumeAListe(CBZArchive archi)
        {
            ListViewItem item = new ListViewItem(archi.Name);
            lvBooks.LargeImageList.Images.Add(archi.Cover);
            item.ImageIndex = lvBooks.LargeImageList.Images.Count - 1;
            item.SubItems.Add($"{archi.AvWidth.ToString()}x{archi.AvHeight} / {Math.Round(archi.Size / 1024 / 1024).ToString()}mo");

            ListViewItem.ListViewSubItem listSub = new ListViewItem.ListViewSubItem();
            listSub.Font = new Font(Font.OriginalFontName, 12, FontStyle.Bold);
            if (archi.Compressed)
            {
                listSub.Text += "🗜 Compressé ";
            }
            if(archi.Format.Equals("CBR",StringComparison.OrdinalIgnoreCase)) {
                listSub.Text += "(CBR) ";
            }
            if (archi.Format.Equals("PDF", StringComparison.OrdinalIgnoreCase))
            {
                listSub.Text += "(PDF) ";
            }

            item.SubItems.Add(listSub);
            item.StateImageIndex = 0;
            lock (this.fLock)
            {
                this.lvBooks.Items.Add(item);
            }
        }

        #endregion

        #region Gestion du menu.
        private void OnMenuParametreClick(object sender, EventArgs e)
        {
            OpenSettings();
        }
        private void OnMenuOuvrirLibrairieClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConfigurationFactory.SOURCE_FOLDER) && Directory.Exists(ConfigurationFactory.SOURCE_FOLDER))
            {
                this.folderBrowserDialog1.SelectedPath = ConfigurationFactory.SOURCE_FOLDER;
            }
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ConfigurationFactory.SOURCE_FOLDER = this.folderBrowserDialog1.SelectedPath;
                ConfigurationFactory.Save();

                listeVolumesSerie = new List<CBZArchive>();
                this.volumeSelection = null;
                this.lvBooks.Items.Clear();
                this.tvExplorer.Nodes.Clear();

                chargerListeSeries();

            }
        }

        private void ajouterUneSérieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.addSerie();
        }
        private void addSerie()
        {
            Directory.CreateDirectory(Path.Combine(ConfigurationFactory.SOURCE_FOLDER, "Nouvelle série"));
            this.directorySerie = new DirectoryInfo(Path.Combine(ConfigurationFactory.SOURCE_FOLDER, "Nouvelle série"));
            tvExplorer.Nodes[0].Nodes.Add(Path.Combine(ConfigurationFactory.SOURCE_FOLDER, "Nouvelle série"), "Nouvelle série").BeginEdit();
        }
        private void deleteSerie()
        {
            string path = this.tvExplorer.SelectedNode.FullPath;
            string name = this.tvExplorer.SelectedNode.Text;
            if(new ConfirmForm(this.metroStyleManager1, $"Vous vous apprêtez à supprimer la série {name}... Êtes vous sur?").ShowDialog() == DialogResult.OK)
            {
                Directory.Delete(path, true);
                this.tvExplorer.Nodes.Remove(this.tvExplorer.SelectedNode);
            }
        }

        private void tâchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTasks();
        }
        #endregion

        #region Gestion de l'explorateur de séries
        private void OnSerieKeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void tsAddSerie_Click(object sender, EventArgs e)
        {
            this.addSerie();
        }

        private void supprimerSériesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteSerie();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {
            this.deleteSerie();
        }

        private void tsRenommerSerie_Click(object sender, EventArgs e)
        {
            this.tvExplorer.SelectedNode.BeginEdit();
        }
        private void OnSerieKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                this.tvExplorer.SelectedNode.BeginEdit();
            }
        }
        private void OnSerieSelectionnee(object sender, TreeViewEventArgs e)
        {
            this.bgReadMangaDirectory.CancelAsync();
            while (this.bgReadMangaDirectory.IsBusy)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }

            if (e.Node.Nodes.Count == 0)
            {
                var nodes = parcourirRepertoire(e.Node.FullPath.ToString());
                foreach (TreeNode node in nodes.Nodes)
                {
                    e.Node.Nodes.Add(node);
                }
                e.Node.Expand();

                this.volumeSelection = null;
                OnVolumeSelection(null, null);
                // VIdage de la liste
                List<ListViewItem> toDel = new List<ListViewItem>();
                foreach (ListViewItem li in this.lvBooks.Items)
                {
                    CBZArchive comic = this.listeVolumesSerie.FirstOrDefault(a => a.Name == li.Text);
                    this.listeVolumesSerie.Remove(comic);
                    toDel.Add(li);
                }
                toDel.ForEach(a => this.lvBooks.Items.Remove(a));

                // Récupération des archives...
                directorySerie = new DirectoryInfo(e.Node.FullPath);
                List<string> files = new List<string>();
                var fichiers = directorySerie.GetFiles();
                foreach (var file in fichiers)
                {
                    if (
                        Path.GetExtension(file.FullName.ToLower()) == ".cbz"
                        || Path.GetExtension(file.FullName.ToLower()) == ".zip"
                        || Path.GetExtension(file.FullName.ToLower()) == ".cbr"
                        || Path.GetExtension(file.FullName.ToLower()) == ".rar"
                        || Path.GetExtension(file.FullName.ToLower()) == ".pdf"
                        )
                    {
                        files.Add(file.FullName);
                    }
                }
                long size = 0;
                files.ForEach(a => size += new FileInfo(a).Length);
                this.lbSerie.Text = e.Node.Text + "  (" + files.Count + " volumes, " + (size / 1024 / 1024) + " Mo(s))";
                lvBooks.LargeImageList = new ImageList();
                lvBooks.LargeImageList.ImageSize = new Size(100, 150);
                lvBooks.LargeImageList.ColorDepth = ColorDepth.Depth24Bit;
                this.pBarVolume.Value = 0;
                this.pBarVolume.Maximum = files.Count;
                this.bgReadMangaDirectory.RunWorkerAsync(files.ToArray());
                
                this.btCompressAll.Enabled = files.Count > 0;
                this.btNormalizeNames.Enabled = files.Count > 0;



            }
            else
            {
                this.lbSerie.Text = "";
                this.btCompressAll.Enabled = false;
                this.btNormalizeNames.Enabled = false;
            }
        }
        private void chargerListeSeries()
        {
            if (string.IsNullOrEmpty(ConfigurationFactory.SOURCE_FOLDER))
            {
                ConfigurationFactory.SOURCE_FOLDER = @"C:\";
            }
            int iIndex = this.tvExplorer.Nodes.Add(parcourirRepertoire(ConfigurationFactory.SOURCE_FOLDER));
            this.tvExplorer.Nodes[iIndex].Expand();
        }
        private TreeNode parcourirRepertoire(string path)
        {
            TreeNode result = new TreeNode(path);
            try
            {
                foreach (var subdirectory in Directory.GetDirectories(path))
                {

                    if (Path.GetFileName(subdirectory).StartsWith("$") == false)
                    {

                        result.Nodes.Add(subdirectory, Path.GetFileName(subdirectory));

                    }
                }
            }
            catch (Exception)
            {

            }

            return result;
        }
        private void OnSerieDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }
        private void OnSerieEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                string newName = e.Label;
                e.Node.Text = e.Label;
                this.directorySerie.MoveTo(Path.Combine(this.directorySerie.Parent.FullName, newName));
                e.Node.EndEdit(false);
                refreshListVolumes(e.Node);
            } else e.Node.EndEdit(false);

        }
        private void OnSerieItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.  
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.  
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }
        private void OnSerieDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }
        private void OnSerieDragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            Point targetPoint = tvExplorer.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.  
            tvExplorer.SelectedNode = tvExplorer.GetNodeAt(targetPoint);
        }
        private void OnSerieDragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client tvExplorer of the drop location.  
            Point targetPoint = tvExplorer.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.  
            TreeNode targetNode = tvExplorer.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.  
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not   
            // the dragged node or a descendant of the dragged node.  
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current   
                // location and add it to the node at the drop location.  
                if (e.Effect == DragDropEffects.Move)
                {
                    // Move the linked folder
                    Directory.Move(draggedNode.FullPath, Path.Combine(targetNode.FullPath, draggedNode.Text));
                    tvExplorer.Sort();

                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                    
                }

                // Expand the node at the location   
                // to show the dropped node.  
                targetNode.Expand();
            }

        }
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.  
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node,   
            // call the ContainsNode method recursively using the parent of   
            // the second node.  
            return ContainsNode(node1, node2.Parent);
        }
        private void OnSerieClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.btAddVolumes.Enabled = this.tvExplorer.SelectedNode != null;
            this.btRemoveVolumes.Enabled = this.tvExplorer.SelectedNode != null;
            this.btNormalizeNames.Enabled = this.tvExplorer.SelectedNode != null;
            this.btCompressAll.Enabled = this.tvExplorer.SelectedNode != null;
        }
        private void refreshListVolumes(TreeNode e = null)
        {

            this.OnSerieSelectionnee(this, new TreeViewEventArgs(e != null ? e : this.tvExplorer.SelectedNode));
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.refreshListVolumes();
        }
        #endregion

        #region Gestion du background worker pour les séries
        private void backgroundLancerLectureDossier(object sender, DoWorkEventArgs e)
        {
            string[] files = e.Argument as string[];
            this.pLoad.Invoke((Action)(() => { this.pLoad.Visible = true; lvBooks.Enabled = false; })) ;
            DateTime dtStart = DateTime.Now;
            this.bgReadMangaDirectory.ReportProgress(0, "R");
            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    if (bgReadMangaDirectory.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    string f = files[i];
                    if (Path.GetExtension(f).ToLower() == ".cbr" || Path.GetExtension(f).ToLower() == ".cbz" || Path.GetExtension(f).ToLower() == ".pdf" || Path.GetExtension(f).ToLower() == ".zip" || Path.GetExtension(f).ToLower() == ".rar")
                    {
                        CBZArchive book = new CBZArchive(f);

                        this.pBarVolume.Invoke((Action)(() => { 
                            this.pBarVolume.Value++;
                            int percent = pBarVolume.Value * 100 / pBarVolume.Maximum;
                            double elapsedSeconds = DateTime.Now.Subtract(dtStart).TotalSeconds;
                            double remainingSeconds = ((elapsedSeconds) / percent) * (100 - percent);
                            if (double.IsInfinity(remainingSeconds) == false)
                            {
                                this.lblTemps.Text = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(remainingSeconds).ToString())).ToString();
                            }else
                            {
                                this.lblTemps.Text = "...";
                            }
                        }));

                        this.bgReadMangaDirectory.ReportProgress(((i + 1) * 100) / files.Length, book);
                    }
                    else
                    {
                        this.bgReadMangaDirectory.ReportProgress(((i + 1) * 100) / files.Length);
                    }
                }
                catch (SharpCompress.Common.ArchiveException)
                {
                    continue;
                }
                catch (Exception eX)
                {

                    throw;
                }
            }
        }
        private void OnProgressLectureDossier(object sender, ProgressChangedEventArgs e)
        {
                if (e.UserState is CBZArchive)
                {
                    this.listeVolumesSerie.Add(e.UserState as CBZArchive);
                    this.ajouterVolumeAListe(e.UserState as CBZArchive);
                }
        }

        #endregion

        #region Gestion de l'apercu de volume
        private void cacherApercu()
        {
            this.volumeSelection = null;
            this.pictureBox1.Image = null;
            this.lblResolution.Text = this.lblSize.Text = this.lblPages.Text = this.labelTitre.Text = "";
            this.pictureBox1.Visible = apercuTitle.Visible = false;
        }
        private void afficherApercu(CBZArchive volume)
        {
            this.labelTitre.Text = Path.GetFileNameWithoutExtension(volume.Name);
            this.lblPages.Text = volume.PageCount + " pages";
            this.lblSize.Text = Math.Round(volume.Size / 1024 / 1024) + " Mo";
            this.lblResolution.Text = volume.AvWidth + " px X " + volume.AvHeight + " px";
            this.pictureBox1.Image = volume.Cover;
            this.pictureBox1.Visible = apercuTitle.Visible = true;
        }
        #endregion

        #region Gestion de la compression
        private void btCompressSelection_Click(object sender, EventArgs e)
        {


            List<CBZArchive> ls = new List<CBZArchive>();
            if (this.lvBooks.SelectedItems.Count > 0)
            {
                foreach (ListViewItem li in this.lvBooks.SelectedItems)
                {
                    CBZArchive comic = this.listeVolumesSerie.FirstOrDefault(a => a.Name == li.Text && li.StateImageIndex == 0);
                    if (comic != default(CBZArchive))
                    {
                        //ls.Add(comic);
                        OpenTasks();
                        TasksFactory.Current.AddTaskCompression(comic);
                    }
                }
                
            }

        }

        public class ProcessBooksArgs
        {
            public List<CBZArchive> Books = new List<CBZArchive>();
            public List<ListViewItem> Items = new List<ListViewItem>();
            public ProcessBooksArgs(List<CBZArchive> Books, List<ListViewItem> Items)
            {
                this.Books = Books;
                this.Items = Items;
            }
        }

        private void btCompressAll_Click(object sender, EventArgs e)
        {
            if (this.listeVolumesSerie.Count > 0)
            {
                OpenTasks();
                this.listeVolumesSerie.ForEach(c => TasksFactory.Current.AddTaskCompression(c));
                
            }
        }
        #endregion

        #region Gestion du renommage en masse
        private void btNormalizeNames_Click(object sender, EventArgs e)
        {
            OpenRenameTool(this.listeVolumesSerie);

        }
        #endregion

        #region Gestion de l'ajout / suppression de volumes
        private void btRemoveVolumes_Click(object sender, EventArgs e)
        {
            if (
                this.lvBooks.SelectedItems.Count > 0
                && new ConfirmForm(this.metroStyleManager1, "Vous vous apprêtez à supprimer "+this.lvBooks.SelectedItems.Count+" livres. Êtes-vous sûr?").ShowDialog() == DialogResult.OK)
            {
                List<CBZArchive> ls = new List<CBZArchive>();
                foreach (ListViewItem li in this.lvBooks.SelectedItems)
                {
                    CBZArchive comic = this.listeVolumesSerie.FirstOrDefault(a => a.Name == li.Text && li.StateImageIndex == 0);
                    if (comic != default(CBZArchive))
                    {
                        ls.Add(comic);
                    }
                }
                ls.ForEach(f => File.Delete(f.filePath));
                this.refreshListVolumes();
            }
        }

        private void btAddVolumes_Click(object sender, EventArgs e)
        {
            if(this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach(string s in this.openFileDialog1.FileNames)
                {
                    File.Copy(s, Path.Combine(tvExplorer.SelectedNode.Name, Path.GetFileName(s)));
                }
                this.refreshListVolumes();
            }

        }
        #endregion

        #region Métadonnées
      
        private void onItemRenamed(object sender, RenameItemEventArgs e)
        {
        }




        #endregion

        
    }
}
