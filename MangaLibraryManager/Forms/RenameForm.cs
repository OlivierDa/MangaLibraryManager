using MangaLibraryManager.Core.Data;
using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaLibraryManager.Forms
{
    public partial class RenameForm : MetroForm
    {
        public List<CBZArchive> Volumes = new List<CBZArchive>();
        private List<RenameData> Renommage = new List<RenameData>();
        private bool isAdvanced = false;
        public event EventHandler RenameCompleted;
        public event EventHandler<RenameItemEventArgs> RenameItemCompleted;

        public class RenameItemEventArgs:EventArgs {
            public string OldName;
            public string NewName;
            public RenameItemEventArgs(string oldName, string newName)
            {
                OldName = oldName;
                NewName = newName;
            }
        }

        public RenameForm(MetroStyleManager man)
        {
            InitializeComponent();

            this.metroStyleManager1.Style = man.Style;
            this.metroStyleManager1.Theme = man.Theme;

            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var data = row.DataBoundItem as RenameData;
                (row.Cells["NomOriginal"] as DataGridViewTextBoxCell).Value = data.NomOriginal;
                (row.Cells["NomNouveau"] as DataGridViewTextBoxCell).Value = data.NomNouveau;
                (row.Cells[0] as DataGridViewCheckBoxCell).Value = true;
            }
        }

        private void RenameForm_Load(object sender, EventArgs e)
        {
            this.cbPrefixVolume.SelectedIndex = 0;
            this.cbCompteur.SelectedIndex = this.Volumes.Count.ToString().Length -1;
            this.tbNomSerieAssist.Text = Path.GetFileName(Path.GetDirectoryName(Volumes.FirstOrDefault()?.filePath));
            RefreshDataSource();
        }
        public DialogResult ShowDialog(IEnumerable<CBZArchive> volumes)
        {
            this.Volumes = volumes.ToList();
            return this.ShowDialog();
        }

        private void TabSelectedIndexChanged(object sender, EventArgs e)
        {
            this.isAdvanced = this.metroTabControl1.SelectedIndex == 1;
        }

        public void RefreshDataSource()
        {
            Renommage = new List<RenameData>();
            this.Volumes.ForEach(v =>
            {
                if (this.isAdvanced == false)
                {
                    string iTomeNumber = "?";
                    string originalName = v.Name;
                    string currentName = this.tbNomSerieAssist.Text;
                    if (Regex.IsMatch(originalName, "[tomeTOME ]{5}[0-9]{1,4}")) iTomeNumber = Regex.Match(originalName, "[tomeTOME ]{5}[0-9]{1,4}").Value.Substring(5).Trim();
                    else if (Regex.IsMatch(originalName, "[tomeTOME]{4}[0-9]{1,4}")) iTomeNumber = Regex.Match(originalName, "[tomeTOME ]{4}[0-9]{1,4}").Value.Substring(4).Trim();
                    else if (Regex.IsMatch(originalName, "[volumeVOLUME ]{7}[0-9]{1,4}")) iTomeNumber = Regex.Match(originalName, "[volumeVOLUME ]{7}[0-9]{1,4}").Value.Substring(7).Trim();
                    else if (Regex.IsMatch(originalName, "[volumeVOLUME]{6}[0-9]{1,4}")) iTomeNumber = Regex.Match(originalName, "[volumeVOLUME ]{6}[0-9]{1,4}").Value.Substring(6).Trim();
                    else if (Regex.IsMatch(originalName, "[volVOL ]{4}[0-9]{1,4}")) iTomeNumber = Regex.Match(originalName, "[volVOL ]{4}[0-9]{1,4}").Value.Substring(4).Trim();
                    else if (Regex.IsMatch(originalName, "[volVOL ]{3}[0-9]{1,4}")) iTomeNumber = Regex.Match(originalName, "[volVOL ]{3}[0-9]{1,4}").Value.Substring(3).Trim();
                    else if (Regex.IsMatch(originalName, "[A-Za-z][0-9]{1,4}")) iTomeNumber = Regex.Match(originalName, "[A-Za-z][0-9]{1,4}").Value.Substring(1).Trim();
                    else if (Regex.IsMatch(originalName, "[0-9]{1,4}")) iTomeNumber = Regex.Match(originalName, "[0-9]{1,4}").Value.Trim();



                    int iDummyCount = -1;
                    if(int.TryParse(iTomeNumber, out iDummyCount))
                    {
                        string format = "D" + (this.cbCompteur.SelectedIndex + 1);
                        Renommage.Add(new RenameData(v.Name, currentName + " " + cbPrefixVolume.Text + iDummyCount.ToString(format), v));
                    }else
                    {
                        Renommage.Add(new RenameData(v.Name, currentName + " " + cbPrefixVolume.Text + iTomeNumber, v));
                    }
                    
                }
                else
                {

                }
            });

            this.dataGridView1.DataSource = Renommage;
        }


        public class RenameData
        {
            public string NomOriginal;
            public string NomNouveau;
            public CBZArchive Archive;
            public RenameData(string NomOriginal, string NomNouveau, CBZArchive Archive)
            {
                this.NomOriginal = NomOriginal;
                this.NomNouveau = NomNouveau;
                this.Archive = Archive;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbNomSerieAssist_Click(object sender, EventArgs e)
        {

        }

        private void onNomSerieAssistChanged(object sender, EventArgs e)
        {
            this.RefreshDataSource();
        }

        private void cbPrefixVolume_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshDataSource();
        }

        private void cbCompteur_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshDataSource();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            List<Tuple<string, string>> ls = new List<Tuple<string, string>>();
            foreach(DataGridViewRow r in this.dataGridView1.Rows)
            {
                if ((bool)r.Cells[0].Value)
                {
                    string sAncienNom = r.Cells[1].Value.ToString();
                    string sNouveauNom = r.Cells[2].Value.ToString();

                    //CBZArchive book = this.Volumes.Find(a => a.Name == sAncienNom);
                    //Renommage
                    //string newPath = Path.Combine(Path.GetDirectoryName(book.filePath), sNouveauNom + Path.GetExtension(book.filePath));
                    ls.Add(new Tuple<string,string>(sAncienNom, sNouveauNom));
                    //RenameItemCompleted.Invoke(this, new RenameItemEventArgs(sAncienNom,sNouveauNom));
                    
                }
            }
            backgroundWorker1.RunWorkerAsync(ls);
            backgroundWorker1.RunWorkerCompleted += delegate
            {
                this.RenameCompleted.Invoke(this, null);
                this.Hide();
            };
            
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var data = e.Argument as List<Tuple<string, string>>;
            foreach (var d in data)
            {
                foreach (DataGridViewRow r in this.dataGridView1.Rows)
                {
                    string sAncienNom = r.Cells[1].Value.ToString();
                    string sNouveauNom = r.Cells[2].Value.ToString();

                    if ((bool)r.Cells[0].Value && d.Item2 == sNouveauNom && d.Item1 == sAncienNom)
                    {
                        CBZArchive book = this.Volumes.Find(a => a.Name == sAncienNom);
                        string newPath = Path.Combine(Path.GetDirectoryName(book.filePath), sNouveauNom + Path.GetExtension(book.filePath));
                        File.Move(book.filePath, newPath);
                        dataGridView1.Invoke((Action)(() =>
                        {
                            foreach(DataGridViewCell cell in r.Cells)
                            {
                                cell.Style.BackColor = Color.Green;
                            }
                        }
                        ));
                    }
                }
            }
        }
    }
}
