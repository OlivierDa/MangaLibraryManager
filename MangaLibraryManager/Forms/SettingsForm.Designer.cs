namespace MangaLibraryManager.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.btFolderLibray = new MetroFramework.Controls.MetroButton();
            this.tbFolderLibray = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.cbTasks = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.cbPreConfLiseuses = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.tbHauteur = new MetroFramework.Controls.MetroTextBox();
            this.tbLargeur = new MetroFramework.Controls.MetroTextBox();
            this.tbQualiteJpg = new MetroFramework.Controls.MetroTextBox();
            this.cbColors = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.cbLocalCopy = new MetroFramework.Controls.MetroCheckBox();
            this.cbOverwrite = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.tbOptionsIM = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.tbVersionIM = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.metroTabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.metroButton2);
            this.splitContainer1.Panel2.Controls.Add(this.metroButton1);
            this.splitContainer1.Size = new System.Drawing.Size(760, 403);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 0;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(760, 367);
            this.metroTabControl1.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.btFolderLibray);
            this.metroTabPage1.Controls.Add(this.tbFolderLibray);
            this.metroTabPage1.Controls.Add(this.metroLabel8);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(752, 328);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Général";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // btFolderLibray
            // 
            this.btFolderLibray.Location = new System.Drawing.Point(699, 26);
            this.btFolderLibray.Name = "btFolderLibray";
            this.btFolderLibray.Size = new System.Drawing.Size(50, 23);
            this.btFolderLibray.TabIndex = 12;
            this.btFolderLibray.Text = "...";
            this.btFolderLibray.Click += new System.EventHandler(this.btFolderLibray_Click);
            // 
            // tbFolderLibray
            // 
            this.tbFolderLibray.Location = new System.Drawing.Point(199, 26);
            this.tbFolderLibray.Name = "tbFolderLibray";
            this.tbFolderLibray.Size = new System.Drawing.Size(497, 23);
            this.tbFolderLibray.TabIndex = 11;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(3, 26);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(177, 19);
            this.metroLabel8.TabIndex = 10;
            this.metroLabel8.Text = "Emplacement de la librairie :";
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.cbTasks);
            this.metroTabPage2.Controls.Add(this.metroLabel12);
            this.metroTabPage2.Controls.Add(this.metroLabel11);
            this.metroTabPage2.Controls.Add(this.metroLabel10);
            this.metroTabPage2.Controls.Add(this.metroLabel9);
            this.metroTabPage2.Controls.Add(this.cbPreConfLiseuses);
            this.metroTabPage2.Controls.Add(this.metroLabel5);
            this.metroTabPage2.Controls.Add(this.tbHauteur);
            this.metroTabPage2.Controls.Add(this.tbLargeur);
            this.metroTabPage2.Controls.Add(this.tbQualiteJpg);
            this.metroTabPage2.Controls.Add(this.cbColors);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.cbLocalCopy);
            this.metroTabPage2.Controls.Add(this.cbOverwrite);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(752, 328);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Compression";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.Click += new System.EventHandler(this.metroTabPage2_Click);
            // 
            // cbTasks
            // 
            this.cbTasks.FormattingEnabled = true;
            this.cbTasks.ItemHeight = 23;
            this.cbTasks.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbTasks.Location = new System.Drawing.Point(253, 97);
            this.cbTasks.Name = "cbTasks";
            this.cbTasks.Size = new System.Drawing.Size(121, 29);
            this.cbTasks.TabIndex = 18;
            this.cbTasks.SelectedIndexChanged += new System.EventHandler(this.cbTasks_SelectedIndexChanged);
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(13, 107);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(159, 19);
            this.metroLabel12.TabIndex = 17;
            this.metroLabel12.Text = "Tâches de compressions : ";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(380, 196);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(23, 19);
            this.metroLabel11.TabIndex = 16;
            this.metroLabel11.Text = "px";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(380, 167);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(23, 19);
            this.metroLabel10.TabIndex = 15;
            this.metroLabel10.Text = "px";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(380, 139);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(20, 19);
            this.metroLabel9.TabIndex = 14;
            this.metroLabel9.Text = "%";
            // 
            // cbPreConfLiseuses
            // 
            this.cbPreConfLiseuses.FormattingEnabled = true;
            this.cbPreConfLiseuses.ItemHeight = 23;
            this.cbPreConfLiseuses.Items.AddRange(new object[] {
            "Gray",
            "RGB"});
            this.cbPreConfLiseuses.Location = new System.Drawing.Point(253, 28);
            this.cbPreConfLiseuses.Name = "cbPreConfLiseuses";
            this.cbPreConfLiseuses.Size = new System.Drawing.Size(306, 29);
            this.cbPreConfLiseuses.TabIndex = 13;
            // 
            // metroLabel5
            // 
            this.metroLabel5.Location = new System.Drawing.Point(13, 32);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(237, 19);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "Charger préconfiguration de liseuse :";
            // 
            // tbHauteur
            // 
            this.tbHauteur.Location = new System.Drawing.Point(253, 190);
            this.tbHauteur.Name = "tbHauteur";
            this.tbHauteur.Size = new System.Drawing.Size(121, 23);
            this.tbHauteur.TabIndex = 11;
            // 
            // tbLargeur
            // 
            this.tbLargeur.Location = new System.Drawing.Point(253, 161);
            this.tbLargeur.Name = "tbLargeur";
            this.tbLargeur.Size = new System.Drawing.Size(121, 23);
            this.tbLargeur.TabIndex = 10;
            // 
            // tbQualiteJpg
            // 
            this.tbQualiteJpg.Location = new System.Drawing.Point(253, 132);
            this.tbQualiteJpg.Name = "tbQualiteJpg";
            this.tbQualiteJpg.Size = new System.Drawing.Size(121, 23);
            this.tbQualiteJpg.TabIndex = 9;
            // 
            // cbColors
            // 
            this.cbColors.FormattingEnabled = true;
            this.cbColors.ItemHeight = 23;
            this.cbColors.Items.AddRange(new object[] {
            "Gray",
            "RGB"});
            this.cbColors.Location = new System.Drawing.Point(253, 220);
            this.cbColors.Name = "cbColors";
            this.cbColors.Size = new System.Drawing.Size(121, 29);
            this.cbColors.TabIndex = 8;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(13, 224);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(132, 19);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Schéma de couleur : ";
            // 
            // cbLocalCopy
            // 
            this.cbLocalCopy.AutoSize = true;
            this.cbLocalCopy.Location = new System.Drawing.Point(13, 295);
            this.cbLocalCopy.Name = "cbLocalCopy";
            this.cbLocalCopy.Size = new System.Drawing.Size(623, 15);
            this.cbLocalCopy.TabIndex = 6;
            this.cbLocalCopy.Text = "Copie locale temporaire (cocher lorsque les volumes sont stockés dans un emplacem" +
    "ent ou disque réseau distant)";
            this.cbLocalCopy.UseVisualStyleBackColor = true;
            // 
            // cbOverwrite
            // 
            this.cbOverwrite.AutoSize = true;
            this.cbOverwrite.Location = new System.Drawing.Point(13, 268);
            this.cbOverwrite.Name = "cbOverwrite";
            this.cbOverwrite.Size = new System.Drawing.Size(324, 15);
            this.cbOverwrite.TabIndex = 5;
            this.cbOverwrite.Text = "Ecraser les volumes existants par leur version compressée";
            this.cbOverwrite.UseVisualStyleBackColor = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(13, 193);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(123, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Hauteur maximale :";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(13, 164);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(126, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Largeur maximale : ";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(13, 136);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(132, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Qualité des images : ";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.tbOptionsIM);
            this.metroTabPage3.Controls.Add(this.metroLabel7);
            this.metroTabPage3.Controls.Add(this.tbVersionIM);
            this.metroTabPage3.Controls.Add(this.metroLabel6);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(752, 328);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Avancé";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // tbOptionsIM
            // 
            this.tbOptionsIM.Location = new System.Drawing.Point(3, 69);
            this.tbOptionsIM.Multiline = true;
            this.tbOptionsIM.Name = "tbOptionsIM";
            this.tbOptionsIM.Size = new System.Drawing.Size(746, 95);
            this.tbOptionsIM.TabIndex = 13;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(3, 47);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(274, 19);
            this.metroLabel7.TabIndex = 12;
            this.metroLabel7.Text = "Paramètres complémentaires ImageMagick : ";
            // 
            // tbVersionIM
            // 
            this.tbVersionIM.Location = new System.Drawing.Point(199, 5);
            this.tbVersionIM.Name = "tbVersionIM";
            this.tbVersionIM.Size = new System.Drawing.Size(190, 23);
            this.tbVersionIM.TabIndex = 11;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 9);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(145, 19);
            this.metroLabel6.TabIndex = 10;
            this.metroLabel6.Text = "Version ImageMagick : ";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(460, 6);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(106, 23);
            this.metroButton2.TabIndex = 1;
            this.metroButton2.Text = "Fermer";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(572, 6);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(188, 23);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Sauvegarder et Fermer";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Orange;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MangaLibraryManager.Properties.Resources._275692__Personnalisé_;
            this.pictureBox2.Location = new System.Drawing.Point(20, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "    Paramètres";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroCheckBox cbLocalCopy;
        private MetroFramework.Controls.MetroCheckBox cbOverwrite;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox cbColors;
        private MetroFramework.Controls.MetroComboBox cbPreConfLiseuses;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox tbHauteur;
        private MetroFramework.Controls.MetroTextBox tbLargeur;
        private MetroFramework.Controls.MetroTextBox tbQualiteJpg;
        private MetroFramework.Controls.MetroButton btFolderLibray;
        private MetroFramework.Controls.MetroTextBox tbFolderLibray;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox tbOptionsIM;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox tbVersionIM;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Controls.MetroComboBox cbTasks;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}