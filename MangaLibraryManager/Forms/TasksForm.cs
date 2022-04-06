using MangaLibraryManager.Core.Data;
using MangaLibraryManager.Core.Utilities;
using MetroFramework.Components;
using MetroFramework.Controls;
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
    public partial class TasksForm : MetroForm
    {
        public TasksForm(MetroStyleManager man)
        {
            InitializeComponent();

            this.metroStyleManager1.Style = man.Style;
            this.metroStyleManager1.Theme = man.Theme;
            TasksFactory.Current.TaskAdded += TasksFactory_TaskAdded;
            TasksFactory.Current.TaskProgress += Current_TaskProgress;
        }

        private void Current_TaskProgress(object sender, TaskProgressArgs e)
        {
            Control[] lc =  this.listPanel.Controls.Find(e.Book.Name, false);
            if (lc.Length > 0)
            {
                Panel p = lc[0] as Panel;
                Action action1 = () => (p.Controls[2] as Label).Text = e.Text.Substring(2);
                Action action2 = () => (p.Controls[1] as MetroProgressBar).Value = e.Percentage;
                

                (p.Controls[1] as MetroProgressBar).Invoke(action1);
                (p.Controls[2] as Label).Invoke(action2);
                
                
                if(e.Percentage == 100)
                {
                    Action action3 = () => listPanel.Controls.Remove(lc[0]);
                    this.listPanel.Invoke(action3);
                }

                

            }


            Action action4 = () =>
            {
                this.lblTachesRestantes.Text = $"Tâches restantes : {TasksFactory.Current.currentTasks.Count(a=>a.Percentage < 100)}";
            };
            this.lblTachesRestantes.Invoke(action4);
        }

        private void TasksFactory_TaskAdded(object sender, EventArgs e)
        {
            AddTaskItemToList(sender as TaskItem);
        }

        private void Tasks_Load(object sender, EventArgs e)
        {
            
        }

        private void AddTaskItemToList(TaskItem item)
        {
            Panel TaskPanel = new Panel();
            TaskPanel.Name = (item.TaskData as CBZArchive).Name;
            TaskPanel.Size = new System.Drawing.Size(480, 20);
            TaskPanel.Location = new System.Drawing.Point(3, 3);
            

            MetroProgressBar TaskBar = new MetroProgressBar();
            TaskBar.Location = new System.Drawing.Point(242, 3);
            TaskBar.Size = new System.Drawing.Size(235, 20);
            TaskBar.HideProgressText = false;
            TaskBar.Text = "En attente";
            TaskBar.Value = item.Percentage;
            TaskBar.FontSize = MetroFramework.MetroProgressBarSize.Small;

            MetroLabel TaskLabel = new MetroLabel();
            TaskLabel.Location = new System.Drawing.Point(0, 4);
            TaskLabel.AutoSize = false;
            TaskLabel.Size = new System.Drawing.Size(236, 20);
            TaskLabel.Text = item.TaskName;
            TaskLabel.FontSize = MetroFramework.MetroLabelSize.Small;

            Label TaskBarLabel = new Label();
            TaskBarLabel.Location = new System.Drawing.Point(242, 3);
            TaskBarLabel.Size = new System.Drawing.Size(235, 20);
            TaskBarLabel.Text = "...";
                

            TaskPanel.Controls.Add(TaskLabel);
            TaskPanel.Controls.Add(TaskBar);
            TaskPanel.Controls.Add(TaskBarLabel);

            this.listPanel.Controls.Add(TaskPanel);

            this.lblTachesRestantes.Text = $"Tâches restantes : {TasksFactory.Current.currentTasks.Count(a => a.Percentage < 100)}";

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            List<Panel> panelToRemove = new List<Panel>();
            foreach(Panel p in this.listPanel.Controls)
            {
                if((p.Controls[1] as MetroProgressBar).Value == 100)
                {
                    panelToRemove.Add(p);
                }
            }
            panelToRemove.ForEach(a => this.listPanel.Controls.Remove(a));

        }
    }
}
