using MangaLibraryManager.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MangaLibraryManager.Core.Utilities
{
    public class ProcessBooksArgs
    {
        public CBZArchive Book ;
        public ProcessBooksArgs(CBZArchive Books)
        {
            this.Book = Books;

        }
    }
    public class TaskProgressArgs
    {
        public CBZArchive Book;
        public int Percentage;
        public string Text;
        public TaskProgressArgs(CBZArchive Book, int Progress, string Text)
        {
            this.Book = Book;
            this.Percentage = Progress;
            this.Text = Text;
        }
    }
    public class Duple<T, U>
    {
        public T A;
        public U B;
        public Duple(T first, U second)
        {
            this.A = first;
            this.B = second;
        }
    }


    public class TasksFactory
    {
        public int MaxBgWorker = 3;
        private static TasksFactory _cur = null;
        public static TasksFactory Current {
            get
            {
                if(_cur == null)
                {
                    _cur = new TasksFactory();
                    _cur.Initialize();
                }
                return _cur;
            }
        }
        public List<TaskItem> currentTasks = new List<TaskItem>();
        public event EventHandler<EventArgs> TaskAdded;
        public event EventHandler<EventArgs> TaskBusy;
        public event EventHandler<TaskProgressArgs> TaskProgress;

        protected List<Duple<BackgroundWorker,CBZArchive>> bgCompressBooks = new List<Duple<BackgroundWorker,CBZArchive>>();
        protected Timer timer = new Timer();

        public TasksFactory()
        {
            for (int i = 0; i < ConfigurationFactory.ADVANCED_COMPRESS_TASKS; i++)
            {
                bgCompressBooks.Add(new Duple<BackgroundWorker, CBZArchive>(new BackgroundWorker(), null));
                bgCompressBooks[i].A.WorkerReportsProgress = true;
                bgCompressBooks[i].A.WorkerSupportsCancellation = true;
                bgCompressBooks[i].A.ProgressChanged += OnProgressCompressionVolumes;
                bgCompressBooks[i].A.DoWork += BgCompressBooks_DoWorkAsync;
            }
        }

        private void BgCompressBooks_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            
            CBZArchive archive = (e.Argument as ProcessBooksArgs).Book; ;
            string fichier = archive.CompressAsync();
            setMetadataCompressed(new CBZArchive(fichier), true);
        }

      

        protected void Initialize()
        {
            //Current = new TasksFactory();
            timer.Interval = 1000;
            timer.Elapsed += Current.Timer_Elapsed;
            timer.Enabled = true;
            timer.Start();

            CBZArchive.OnCompressProgress += CBZArchive_OnCompressProgress;
        }

        private static void CBZArchive_OnCompressProgress(object sender, CBZCompressProgressEventArgs e)
        {
            object[] args = new object[2];
            args[0] = sender as CBZArchive;
            args[1] = e.Text;
            var indexOfWorker = Current.bgCompressBooks.FindIndex(w => w.A.IsBusy && w.B == sender);
            if(indexOfWorker != -1) Current.bgCompressBooks[indexOfWorker].A.ReportProgress(e.Percentage, args);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (bgCompressBooks.Any(a=>!a.A.IsBusy))
            {
                int iIndex = getTaskAvailable();
                int iWorkerIndex = getWorkerAvailable();
                if (iIndex != -1 && iWorkerIndex != -1)
                {
                    currentTasks[iIndex].Started = true;
                    bgCompressBooks[iWorkerIndex].B = currentTasks[iIndex].TaskData as CBZArchive;
                    bgCompressBooks[iWorkerIndex].A.RunWorkerAsync(new ProcessBooksArgs(currentTasks[iIndex].TaskData as CBZArchive)); 
                }
            }
        }

        public void AddTaskCompression(CBZArchive book)
        {
            if (!this.currentTasks.Any(a => a.Percentage < 100 && a.Completed == false && book.filePath == (a.TaskData as CBZArchive).filePath))
            {
                var task = new TaskItem($"{book.Name}", enTaskType.Compress, book);
                currentTasks.Add(task);
                if (TaskAdded != null) TaskAdded.Invoke(task, new EventArgs());
            }
        }

        private int getTaskAvailable()
        {
            return currentTasks.FindIndex(t => !t.Started && !t.Completed);
        }
        private int getWorkerAvailable()
        {
            return bgCompressBooks.FindIndex(t => !t.A.IsBusy);
        }

        private void OnProgressCompressionVolumes(object sender, ProgressChangedEventArgs e)
        {
            CBZArchive book = (e.UserState as object[])[0] as CBZArchive;
            string text = (e.UserState as object[])[1] as string;

            int iIndex = currentTasks.FindIndex(a => a.TaskData == book);
            currentTasks[iIndex].Percentage = e.ProgressPercentage;

            if (this.TaskProgress != null) this.TaskProgress.Invoke(sender, new TaskProgressArgs(book, e.ProgressPercentage, text));

        }
        private void setMetadataCompressed(CBZArchive volume, bool zipStatus)
        {
            string name = Path.GetFileName(volume.filePath);
            if (zipStatus && !MetadataFactory.COMPRESSED.Contains(name.ToLower()))
            {
                MetadataFactory.COMPRESSED.Add(name.ToLower());
                MetadataFactory.Save();
            }
            else if (!zipStatus && !MetadataFactory.COMPRESSED.Contains(name.ToLower()))
            {
                MetadataFactory.COMPRESSED.Remove(name.ToLower());
                MetadataFactory.Save();
            }
        }

    }
}
