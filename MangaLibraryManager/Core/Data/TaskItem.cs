using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaLibraryManager.Core.Data
{
    public enum enTaskType
    {
        Compress,
        Read,
        Rename
    }
    public class TaskItem
    {
        public string TaskName;
        public enTaskType TaskType;
        public object TaskData;
        public int Percentage = 0;
        public bool Started = false;
        public bool Completed= false;
        public TaskItem(string Name, enTaskType Type, object Data = null)
        {
            this.TaskName = Name;
            this.TaskType = Type;
            this.TaskData = Data;
        }

    }
}
