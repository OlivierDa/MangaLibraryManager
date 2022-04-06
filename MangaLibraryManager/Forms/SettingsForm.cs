using MangaLibraryManager.Core.Data;
using MangaLibraryManager.Core.Utilities;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaLibraryManager.Forms
{
    public partial class SettingsForm : MetroForm
    {
        public List<EbookReader> Readers = new List<EbookReader>()
        {
            new EbookReader("",1080,1440,300),
            new EbookReader("Amazon.com Kindle Oasis 6in",1080,1440,300),
            new EbookReader("Amazon.com Kindle Oasis 7in",1264,1680,300),
            new EbookReader("Amazon.com Kindle Paperwhite (3rd generation) Wi-Fi/3G",1080,1430,300),
            new EbookReader("Amazon.com Kindle Voyage",1080,1430,300),
            new EbookReader("Amazon.com Kindle (7th generation)",600,800,167),
            new EbookReader("Barnes & Noble Nook Simple Touch with GlowLight",600,800,167),
            new EbookReader("Barnes & Noble Nook GlowLight",758,1024,212),
            new EbookReader("Barnes & Noble Nook GlowLight Plus",1080,1430,300),
            new EbookReader("Barnes & Noble Nook Glowlight 3",1072,1448,300),
            new EbookReader("Barnes & Noble Nook GlowLight Plus 7.8",1404,1872,300),
            new EbookReader("Bookeen Cybook Odyssey HD FrontLight",758,1024,212),
            new EbookReader("Bookeen Cybook Odyssey",600,800,167),
            new EbookReader("Bookeen Cybook Orizon",600,800,167),
            new EbookReader("Bookeen Cybook Muse HD",1072,1448,300),
            new EbookReader("Boyue T62+",758,1024,212),
            new EbookReader("bq Movistar ebook",600,800,167),
            new EbookReader("Tolino tolino shine 3",768,1024,212),
            new EbookReader("Tolino tolino page 2",1072,1448,300),
            new EbookReader("Tolino tolino vision 5",1264,1680,300),
            new EbookReader("Tolino tolino epos 2",1440,1920,300),
            new EbookReader("Elonex 621EB",600,800,167),
            new EbookReader("Icarus Reader Icarus Excel",825,1200,150),
            new EbookReader("Icarus Reader Icarus 8",768,1024,160),
            new EbookReader("Icarus Reader Icarus Essence",600,800,167),
            new EbookReader("Icarus Reader Icarus Sense G2",600,800,167),
            new EbookReader("Icarus Reader Illumina Pro",825,1200,150),
            new EbookReader("Iriver Iriver Story HD",768,1024,213),
            new EbookReader("JinKe Hanlin V5",600,800,200),
            new EbookReader("Boyue Boyue Likebook Plus",1404,1872,300),
            new EbookReader("Icarus Icarus Illumina XL HD",1404,1872,300),
            new EbookReader("Kobo Inc. Kobo Forma",1440,1920,300),
            new EbookReader("Kobo Inc. Kobo Libra H2O",1680,1264,300),
            new EbookReader("Kobo Inc. Kobo Nia",1024,758,212),
            new EbookReader("Kobo Inc. Kobo Clara HD",1072,1448,300),
            new EbookReader("Kobo Inc. Kobo Aura One",1404,1872,300),
            new EbookReader("Kobo Inc. Kobo Aura Edition 2",768,1024,212),
            new EbookReader("Kobo Inc. Kobo Touch 2.0",600,800,167),
            new EbookReader("Kobo Inc. Kobo Glo HD",1072,1448,300),
            new EbookReader("Kobo Inc. Kobo Aura H2O",1080,1430,265),
            new EbookReader("Kobo Inc. Kobo Aura HD",1080,1440,265),
            new EbookReader("Kobo Inc. Kobo Aura",758,1024,212),
            new EbookReader("Kolporter eClicto",600,800,167),
            new EbookReader("Manta Ebook04",600,800,167),
            new EbookReader("Onyx Inc. BOOX C65 Storia",758,1024,212),
            new EbookReader("Onyx Inc. BOOX C65 AfterGlow",758,1024,212),
            new EbookReader("Onyx Inc. BOOX M92/92S Black Pearl",825,1200,150),
            new EbookReader("Onyx Inc. BOOX M96",825,1200,150),
            new EbookReader("Onyx Inc. BOOX T68 Lynx",1080,1440,265),
            new EbookReader("Onyx Inc. BOOX N96",825,1200,150),
            new EbookReader("Onyx Inc. BOOX Max",1200,1600,150),
            new EbookReader("Onyx Inc. BOOX Max Carta",1650,2200,207),
            new EbookReader("PocketBook PocketBook Aqua 2",758,1024,167),
            new EbookReader("PocketBook PocketBook InkPad 3",1404,1872,300),
            new EbookReader("PocketBook PocketBook InkPad 3 Pro",1404,1872,300),
            new EbookReader("PocketBook PocketBook InkPad X",1404,1872,300),
            new EbookReader("PocketBook PocketBook Touch HD 3",1072,1448,300),
            new EbookReader("PocketBook PocketBook CAD Reader",1200,1600,150),
            new EbookReader("PocketBook PocketBook CAD Reader Flex",1200,1600,150),
            new EbookReader("PocketBook PocketBook 360 Plus",600,800,200),
            new EbookReader("PocketBook PocketBook Pro 912",825,1200,150),
            new EbookReader("PocketBook PocketBook Touch",600,800,167),
            new EbookReader("PocketBook PocketBook Touch Lux 4",758,1024,300),
            new EbookReader("PocketBook PocketBook Basic 3",600,800,167),
            new EbookReader("PocketBook PocketBook Basic Lux 2",758,1024,167),
            new EbookReader("reMarkable reMarkable[3]",1404,1872,226),
            new EbookReader("Sony DPT-RP1[4]",1650,2200,207),
            new EbookReader("TrekStor Pyrus[5]",600,800,167),
            new EbookReader("TrekStor Pyrus 2 LED[6]",600,800,167),
            new EbookReader("TrekStor Pyrus mini[7]",600,800,233),
            new EbookReader("txtr beagle",600,800,200),
            new EbookReader("Fidibook Hannah F1 Wi-Fi",1024,758,212)
        };
        public SettingsForm(MetroStyleManager man)
        {
            InitializeComponent();

            this.metroStyleManager1.Style = man.Style;
            this.metroStyleManager1.Theme = man.Theme;


            this.cbPreConfLiseuses.DataSource = this.Readers.Select(a => a.Name).ToList();
            this.cbPreConfLiseuses.SelectedItem = this.cbPreConfLiseuses.Items[ConfigurationFactory.DEVICE];
            this.cbPreConfLiseuses.SelectedIndexChanged += new System.EventHandler(this.cbPreConfLiseuses_SelectedIndexChanged);

            this.cbTasks.SelectedIndex = ConfigurationFactory.ADVANCED_COMPRESS_TASKS - 1;

            int iIndex = 0;
            for (int i = 0; i < this.cbPreConfLiseuses.Items.Count; i++)
            {
                if (this.cbPreConfLiseuses.Items[i].ToString() == ConfigurationFactory.IMAGE_MAGICK_COLORS)
                {
                    iIndex = i;
                    break;
                }
            }
            this.cbColors.SelectedIndex = iIndex;



        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.cbLocalCopy.Checked = ConfigurationFactory.ADVANCED_COPIELOCALE;
            this.cbOverwrite.Checked = ConfigurationFactory.ARCHIVE_OVERWRITE_SOURCE;

            this.tbHauteur.Text= ConfigurationFactory.IMAGE_HEIGHT.ToString();
            this.tbLargeur.Text= ConfigurationFactory.IMAGE_WIDTH.ToString();
            this.tbQualiteJpg.Text = ConfigurationFactory.IMAGE_QUALITY.ToString();
            this.tbVersionIM.Text = ConfigurationFactory.IMAGE_MAGICK_VERSION;
            this.tbOptionsIM.Text = ConfigurationFactory.IMAGE_MAGICK_OPTIONS;
            this.tbFolderLibray.Text = ConfigurationFactory.SOURCE_FOLDER;
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }
        private void cbPreConfLiseuses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbLargeur.Text= this.Readers[this.cbPreConfLiseuses.SelectedIndex].Width.ToString();
            this.tbHauteur.Text= this.Readers[this.cbPreConfLiseuses.SelectedIndex].Height.ToString();
            ConfigurationFactory.DEVICE = this.cbPreConfLiseuses.SelectedIndex;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ConfigurationFactory.DEVICE = this.cbPreConfLiseuses.SelectedIndex;
            ConfigurationFactory.IMAGE_WIDTH = Convert.ToInt32(this.tbLargeur.Text);
            ConfigurationFactory.IMAGE_HEIGHT = Convert.ToInt32(this.tbHauteur.Text);
            ConfigurationFactory.IMAGE_QUALITY = Convert.ToInt32(this.tbQualiteJpg.Text);
            ConfigurationFactory.ARCHIVE_OVERWRITE_SOURCE = this.cbOverwrite.Checked;
            ConfigurationFactory.ADVANCED_COPIELOCALE = this.cbLocalCopy.Checked;
            ConfigurationFactory.SOURCE_FOLDER = this.tbFolderLibray.Text ;
            ConfigurationFactory.ADVANCED_COMPRESS_TASKS = this.cbTasks.SelectedIndex + 1;

            ConfigurationFactory.Save();
            Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btFolderLibray_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ConfigurationFactory.SOURCE_FOLDER) && Directory.Exists(ConfigurationFactory.SOURCE_FOLDER))
            {
                this.folderBrowserDialog1.SelectedPath = ConfigurationFactory.SOURCE_FOLDER;
            }
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.tbFolderLibray.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void cbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
