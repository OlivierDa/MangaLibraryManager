using MangaLibraryManager.Core.Controls;
using System.Drawing;

namespace MangaLibraryManager
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirUneLibrairieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sériesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUneSérieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerSériesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tâchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bgReadMangaDirectory = new System.ComponentModel.BackgroundWorker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bgCompressBooks = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelMetadata = new MetroFramework.Controls.MetroPanel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSerie = new MetroFramework.Controls.MetroLabel();
            this.tvExplorer = new System.Windows.Forms.TreeView();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.pLoad = new MetroFramework.Controls.MetroPanel();
            this.lblTemps = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pBarVolume = new MetroFramework.Controls.MetroProgressBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTasks = new MetroFramework.Controls.MetroPanel();
            this.lblNbTaches = new MetroFramework.Controls.MetroLabel();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.btCompressAll = new MetroFramework.Controls.MetroButton();
            this.btAddVolumes = new MetroFramework.Controls.MetroButton();
            this.btCompressSelection = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btNormalizeNames = new MetroFramework.Controls.MetroButton();
            this.btRemoveVolumes = new MetroFramework.Controls.MetroButton();
            this.apercuTitle = new MetroFramework.Controls.MetroTile();
            this.labelTitre = new MetroFramework.Controls.MetroLabel();
            this.lblSize = new MetroFramework.Controls.MetroLabel();
            this.lblResolution = new MetroFramework.Controls.MetroLabel();
            this.lblPages = new MetroFramework.Controls.MetroLabel();
            this.lvBooks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsAddSerie = new System.Windows.Forms.ToolStripMenuItem();
            this.tsRenommerSerie = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.panelMetadata.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.apercuTitle.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.sériesToolStripMenuItem,
            this.outilsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1240, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirUneLibrairieToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // ouvrirUneLibrairieToolStripMenuItem
            // 
            this.ouvrirUneLibrairieToolStripMenuItem.Name = "ouvrirUneLibrairieToolStripMenuItem";
            this.ouvrirUneLibrairieToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ouvrirUneLibrairieToolStripMenuItem.Text = "Ouvrir une librairie";
            this.ouvrirUneLibrairieToolStripMenuItem.Click += new System.EventHandler(this.OnMenuOuvrirLibrairieClick);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // sériesToolStripMenuItem
            // 
            this.sériesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUneSérieToolStripMenuItem,
            this.supprimerSériesToolStripMenuItem});
            this.sériesToolStripMenuItem.Name = "sériesToolStripMenuItem";
            this.sériesToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sériesToolStripMenuItem.Text = "Séries";
            // 
            // ajouterUneSérieToolStripMenuItem
            // 
            this.ajouterUneSérieToolStripMenuItem.Name = "ajouterUneSérieToolStripMenuItem";
            this.ajouterUneSérieToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.ajouterUneSérieToolStripMenuItem.Text = "Ajouter une nouvelle série";
            this.ajouterUneSérieToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneSérieToolStripMenuItem_Click);
            // 
            // supprimerSériesToolStripMenuItem
            // 
            this.supprimerSériesToolStripMenuItem.Name = "supprimerSériesToolStripMenuItem";
            this.supprimerSériesToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.supprimerSériesToolStripMenuItem.Text = "Supprimer les séries sélectionnées";
            this.supprimerSériesToolStripMenuItem.Click += new System.EventHandler(this.supprimerSériesToolStripMenuItem_Click);
            // 
            // outilsToolStripMenuItem
            // 
            this.outilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paramètresToolStripMenuItem,
            this.tâchesToolStripMenuItem});
            this.outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            this.outilsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.outilsToolStripMenuItem.Text = "Outils";
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            this.paramètresToolStripMenuItem.Click += new System.EventHandler(this.OnMenuParametreClick);
            // 
            // tâchesToolStripMenuItem
            // 
            this.tâchesToolStripMenuItem.Name = "tâchesToolStripMenuItem";
            this.tâchesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.tâchesToolStripMenuItem.Text = "Tâches";
            this.tâchesToolStripMenuItem.Click += new System.EventHandler(this.tâchesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // bgReadMangaDirectory
            // 
            this.bgReadMangaDirectory.WorkerReportsProgress = true;
            this.bgReadMangaDirectory.WorkerSupportsCancellation = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "books-stack-of-three.png");
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Purple;
            // 
            // bgCompressBooks
            // 
            this.bgCompressBooks.WorkerReportsProgress = true;
            this.bgCompressBooks.WorkerSupportsCancellation = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archives Mangas|*.cbz;*cbr;*.zip;*.rar";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // panelMetadata
            // 
            this.panelMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMetadata.Controls.Add(this.metroButton1);
            this.panelMetadata.HorizontalScrollbarBarColor = true;
            this.panelMetadata.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMetadata.HorizontalScrollbarSize = 10;
            this.panelMetadata.Location = new System.Drawing.Point(927, 83);
            this.panelMetadata.Name = "panelMetadata";
            this.panelMetadata.Size = new System.Drawing.Size(109, 25);
            this.panelMetadata.TabIndex = 3;
            this.panelMetadata.VerticalScrollbarBarColor = true;
            this.panelMetadata.VerticalScrollbarHighlightOnWheel = false;
            this.panelMetadata.VerticalScrollbarSize = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(34, 0);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "⭯ Rafraichir";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel1.Controls.Add(this.lbSerie, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tvExplorer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvBooks, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 84);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1240, 616);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbSerie
            // 
            this.lbSerie.BackColor = System.Drawing.Color.Transparent;
            this.lbSerie.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lbSerie.Location = new System.Drawing.Point(250, 0);
            this.lbSerie.Name = "lbSerie";
            this.lbSerie.Size = new System.Drawing.Size(651, 22);
            this.lbSerie.TabIndex = 18;
            this.lbSerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbSerie.UseStyleColors = true;
            // 
            // tvExplorer
            // 
            this.tvExplorer.AllowDrop = true;
            this.tvExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvExplorer.ImageIndex = 0;
            this.tvExplorer.ImageList = this.imageList1;
            this.tvExplorer.LabelEdit = true;
            this.tvExplorer.Location = new System.Drawing.Point(3, 3);
            this.tvExplorer.Name = "tvExplorer";
            this.tableLayoutPanel1.SetRowSpan(this.tvExplorer, 3);
            this.tvExplorer.SelectedImageIndex = 0;
            this.tvExplorer.ShowLines = false;
            this.tvExplorer.Size = new System.Drawing.Size(241, 610);
            this.tvExplorer.TabIndex = 0;
            this.tvExplorer.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.OnSerieEdit);
            this.tvExplorer.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.OnSerieItemDrag);
            this.tvExplorer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSerieSelectionnee);
            this.tvExplorer.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnSerieClick);
            this.tvExplorer.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnSerieDoubleClick);
            this.tvExplorer.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnSerieDragDrop);
            this.tvExplorer.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnSerieDragEnter);
            this.tvExplorer.DragOver += new System.Windows.Forms.DragEventHandler(this.OnSerieDragOver);
            this.tvExplorer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnSerieKeyUp);
            this.tvExplorer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnSerieKeyPress);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "d0111eb2b1c4d4dab794d030108dbeec.png");
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.Location = new System.Drawing.Point(98, 253);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(302, 23);
            this.metroProgressBar1.TabIndex = 0;
            // 
            // pLoad
            // 
            this.pLoad.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.pLoad.Controls.Add(this.lblTemps);
            this.pLoad.Controls.Add(this.metroLabel1);
            this.pLoad.Controls.Add(this.pBarVolume);
            this.pLoad.HorizontalScrollbarBarColor = true;
            this.pLoad.HorizontalScrollbarHighlightOnWheel = false;
            this.pLoad.HorizontalScrollbarSize = 10;
            this.pLoad.Location = new System.Drawing.Point(423, 338);
            this.pLoad.Name = "pLoad";
            this.pLoad.Size = new System.Drawing.Size(459, 100);
            this.pLoad.TabIndex = 4;
            this.pLoad.VerticalScrollbarBarColor = true;
            this.pLoad.VerticalScrollbarHighlightOnWheel = false;
            this.pLoad.VerticalScrollbarSize = 10;
            this.pLoad.Visible = false;
            // 
            // lblTemps
            // 
            this.lblTemps.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblTemps.Location = new System.Drawing.Point(352, 22);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(59, 22);
            this.lblTemps.TabIndex = 4;
            this.lblTemps.Text = "00:00";
            this.lblTemps.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(55, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(217, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Chargement de la liste des volumes";
            // 
            // pBarVolume
            // 
            this.pBarVolume.FontSize = MetroFramework.MetroProgressBarSize.Small;
            this.pBarVolume.HideProgressText = false;
            this.pBarVolume.Location = new System.Drawing.Point(55, 47);
            this.pBarVolume.Name = "pBarVolume";
            this.pBarVolume.Size = new System.Drawing.Size(356, 23);
            this.pBarVolume.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MangaLibraryManager.Properties.Resources._275692__Personnalisé_;
            this.pictureBox2.Location = new System.Drawing.Point(22, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.White;
            this.metroPanel1.BackgroundImage = global::MangaLibraryManager.Properties.Resources.wp7310059;
            this.metroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.metroPanel1.Controls.Add(this.panel1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(1016, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.metroPanel1, 3);
            this.metroPanel1.Size = new System.Drawing.Size(221, 610);
            this.metroPanel1.TabIndex = 3;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.panelTasks);
            this.panel1.Controls.Add(this.btCompressAll);
            this.panel1.Controls.Add(this.btAddVolumes);
            this.panel1.Controls.Add(this.btCompressSelection);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btNormalizeNames);
            this.panel1.Controls.Add(this.btRemoveVolumes);
            this.panel1.Controls.Add(this.apercuTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 610);
            this.panel1.TabIndex = 18;
            // 
            // panelTasks
            // 
            this.panelTasks.Controls.Add(this.lblNbTaches);
            this.panelTasks.Controls.Add(this.metroProgressSpinner1);
            this.panelTasks.HorizontalScrollbarBarColor = true;
            this.panelTasks.HorizontalScrollbarHighlightOnWheel = false;
            this.panelTasks.HorizontalScrollbarSize = 10;
            this.panelTasks.Location = new System.Drawing.Point(8, 323);
            this.panelTasks.Name = "panelTasks";
            this.panelTasks.Size = new System.Drawing.Size(210, 41);
            this.panelTasks.TabIndex = 21;
            this.panelTasks.VerticalScrollbarBarColor = true;
            this.panelTasks.VerticalScrollbarHighlightOnWheel = false;
            this.panelTasks.VerticalScrollbarSize = 10;
            this.panelTasks.Visible = false;
            // 
            // lblNbTaches
            // 
            this.lblNbTaches.AutoSize = true;
            this.lblNbTaches.Location = new System.Drawing.Point(37, 9);
            this.lblNbTaches.Name = "lblNbTaches";
            this.lblNbTaches.Size = new System.Drawing.Size(109, 19);
            this.lblNbTaches.TabIndex = 21;
            this.lblNbTaches.Text = "0 tâches en cours";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(3, 3);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(32, 32);
            this.metroProgressSpinner1.TabIndex = 20;
            // 
            // btCompressAll
            // 
            this.btCompressAll.Enabled = false;
            this.btCompressAll.Highlight = true;
            this.btCompressAll.Location = new System.Drawing.Point(6, 41);
            this.btCompressAll.Name = "btCompressAll";
            this.btCompressAll.Size = new System.Drawing.Size(212, 23);
            this.btCompressAll.TabIndex = 17;
            this.btCompressAll.Text = "Optimiser toute la série";
            this.btCompressAll.Click += new System.EventHandler(this.btCompressAll_Click);
            // 
            // btAddVolumes
            // 
            this.btAddVolumes.Enabled = false;
            this.btAddVolumes.Location = new System.Drawing.Point(6, 128);
            this.btAddVolumes.Name = "btAddVolumes";
            this.btAddVolumes.Size = new System.Drawing.Size(212, 23);
            this.btAddVolumes.TabIndex = 16;
            this.btAddVolumes.Text = "Ajouter des volumes à la série";
            this.btAddVolumes.Click += new System.EventHandler(this.btAddVolumes_Click);
            // 
            // btCompressSelection
            // 
            this.btCompressSelection.Enabled = false;
            this.btCompressSelection.Highlight = true;
            this.btCompressSelection.Location = new System.Drawing.Point(6, 15);
            this.btCompressSelection.Name = "btCompressSelection";
            this.btCompressSelection.Size = new System.Drawing.Size(212, 23);
            this.btCompressSelection.TabIndex = 13;
            this.btCompressSelection.Text = "Optimiser les volumes sélectionnés";
            this.btCompressSelection.Click += new System.EventHandler(this.btCompressSelection_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(14, 410);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btNormalizeNames
            // 
            this.btNormalizeNames.Enabled = false;
            this.btNormalizeNames.Highlight = true;
            this.btNormalizeNames.Location = new System.Drawing.Point(6, 70);
            this.btNormalizeNames.Name = "btNormalizeNames";
            this.btNormalizeNames.Size = new System.Drawing.Size(212, 23);
            this.btNormalizeNames.TabIndex = 15;
            this.btNormalizeNames.Text = "Renommage en masse";
            this.btNormalizeNames.Click += new System.EventHandler(this.btNormalizeNames_Click);
            // 
            // btRemoveVolumes
            // 
            this.btRemoveVolumes.Enabled = false;
            this.btRemoveVolumes.Location = new System.Drawing.Point(6, 99);
            this.btRemoveVolumes.Name = "btRemoveVolumes";
            this.btRemoveVolumes.Size = new System.Drawing.Size(212, 23);
            this.btRemoveVolumes.TabIndex = 14;
            this.btRemoveVolumes.Text = "Supprimer le(s) volume(s)";
            this.btRemoveVolumes.Click += new System.EventHandler(this.btRemoveVolumes_Click);
            // 
            // apercuTitle
            // 
            this.apercuTitle.Controls.Add(this.labelTitre);
            this.apercuTitle.Controls.Add(this.lblSize);
            this.apercuTitle.Controls.Add(this.lblResolution);
            this.apercuTitle.Controls.Add(this.lblPages);
            this.apercuTitle.Location = new System.Drawing.Point(6, 370);
            this.apercuTitle.Name = "apercuTitle";
            this.apercuTitle.Size = new System.Drawing.Size(212, 237);
            this.apercuTitle.TabIndex = 19;
            this.apercuTitle.Text = "Aperçu";
            this.apercuTitle.Visible = false;
            // 
            // labelTitre
            // 
            this.labelTitre.BackColor = System.Drawing.Color.Transparent;
            this.labelTitre.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.labelTitre.Location = new System.Drawing.Point(9, 9);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(193, 28);
            this.labelTitre.TabIndex = 18;
            this.labelTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitre.UseStyleColors = true;
            // 
            // lblSize
            // 
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblSize.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSize.Location = new System.Drawing.Point(124, 57);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(85, 15);
            this.lblSize.TabIndex = 10;
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSize.UseStyleColors = true;
            // 
            // lblResolution
            // 
            this.lblResolution.BackColor = System.Drawing.Color.Transparent;
            this.lblResolution.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblResolution.Location = new System.Drawing.Point(124, 72);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(84, 42);
            this.lblResolution.TabIndex = 11;
            this.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPages
            // 
            this.lblPages.BackColor = System.Drawing.Color.Transparent;
            this.lblPages.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblPages.Location = new System.Drawing.Point(123, 114);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(85, 23);
            this.lblPages.TabIndex = 9;
            this.lblPages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvBooks
            // 
            this.lvBooks.BackColor = System.Drawing.Color.White;
            this.lvBooks.BackgroundImage = global::MangaLibraryManager.Properties.Resources.internal1;
            this.lvBooks.BackgroundImageTiled = true;
            this.lvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvBooks.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvBooks.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBooks.HideSelection = false;
            this.lvBooks.LabelWrap = false;
            this.lvBooks.Location = new System.Drawing.Point(250, 28);
            this.lvBooks.Name = "lvBooks";
            this.tableLayoutPanel1.SetRowSpan(this.lvBooks, 2);
            this.lvBooks.Size = new System.Drawing.Size(760, 582);
            this.lvBooks.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvBooks.TabIndex = 3;
            this.lvBooks.TileSize = new System.Drawing.Size(240, 180);
            this.lvBooks.UseCompatibleStateImageBehavior = false;
            this.lvBooks.View = System.Windows.Forms.View.Tile;
            this.lvBooks.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OnVolumeChecked);
            this.lvBooks.SelectedIndexChanged += new System.EventHandler(this.OnVolumeSelectionneChanged);
            this.lvBooks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnVolumeDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAddSerie,
            this.tsRenommerSerie,
            this.tsDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // tsAddSerie
            // 
            this.tsAddSerie.Name = "tsAddSerie";
            this.tsAddSerie.Size = new System.Drawing.Size(180, 22);
            this.tsAddSerie.Text = "Ajouter une série";
            this.tsAddSerie.Click += new System.EventHandler(this.tsAddSerie_Click);
            // 
            // tsRenommerSerie
            // 
            this.tsRenommerSerie.Name = "tsRenommerSerie";
            this.tsRenommerSerie.Size = new System.Drawing.Size(180, 22);
            this.tsRenommerSerie.Text = "Renommer";
            this.tsRenommerSerie.Click += new System.EventHandler(this.tsRenommerSerie_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(180, 22);
            this.tsDelete.Text = "Supprimer la série";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pLoad);
            this.Controls.Add(this.panelMetadata);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "     Mangas Library Manager";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.panelMetadata.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pLoad.ResumeLayout(false);
            this.pLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelTasks.ResumeLayout(false);
            this.panelTasks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.apercuTitle.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outilsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView tvExplorer;
        private System.Windows.Forms.ListView lvBooks;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.ToolStripMenuItem ouvrirUneLibrairieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel lblResolution;
        private MetroFramework.Controls.MetroLabel lblSize;
        private MetroFramework.Controls.MetroLabel lblPages;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btCompressSelection;
        private MetroFramework.Controls.MetroButton btRemoveVolumes;
        private MetroFramework.Controls.MetroButton btNormalizeNames;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MetroFramework.Controls.MetroButton btAddVolumes;
        private System.Windows.Forms.Panel panel1;
        public System.ComponentModel.BackgroundWorker bgReadMangaDirectory;
        private MetroFramework.Controls.MetroButton btCompressAll;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel lbSerie;
        private MetroFramework.Controls.MetroLabel labelTitre;
        private System.Windows.Forms.ImageList imageList1;
        private MetroFramework.Controls.MetroTile apercuTitle;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.ComponentModel.BackgroundWorker bgCompressBooks;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroPanel panelMetadata;
        private System.Windows.Forms.ToolStripMenuItem sériesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneSérieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerSériesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tâchesToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel panelTasks;
        private MetroFramework.Controls.MetroLabel lblNbTaches;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.ImageList imageList2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.Panel pLoading;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroPanel pLoad;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroProgressBar pBarVolume;
        private MetroFramework.Controls.MetroLabel lblTemps;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsAddSerie;
        private System.Windows.Forms.ToolStripMenuItem tsRenommerSerie;
        private System.Windows.Forms.ToolStripMenuItem tsDelete;
    }
}

