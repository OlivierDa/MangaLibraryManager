using MetroFramework.Components;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MangaLibraryManager.Forms
{
    public partial class ConfirmForm : MetroForm
    {

        public ConfirmForm(MetroStyleManager man, string pMessage)
        {
            InitializeComponent();
            this.metroStyleManager1.Style = man.Style;
            this.metroStyleManager1.Theme = man.Theme;
            this.metroLabel1.Text = pMessage;

        }

        private void ConfirmForm_Load(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
