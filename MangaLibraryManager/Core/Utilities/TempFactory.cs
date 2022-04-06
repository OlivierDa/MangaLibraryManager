using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MangaLibraryManager.Core.Utilities
{
    public class TempFactory : IDisposable
    {
        private string fTempRoot = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "temp_files");
        private static TempFactory fFactory =null;
        public static TempFactory Current {
            get
            {
                if(TempFactory.fFactory == null)
                {
                    TempFactory.fFactory = new TempFactory();
                }
                return TempFactory.fFactory;
            }
        }
        private TempFactory()
        {

        }
        

        public void Dispose()
        {
            TempFactory.fFactory = null;
            if (Directory.Exists(this.fTempRoot))
            {
                Directory.GetFiles(this.fTempRoot).ToList().ForEach(a => File.Delete(a));
                Directory.Delete(this.fTempRoot, true);
            }
        }

        public string GetTempFolder()
        {
            return Directory.CreateDirectory(Path.Combine(this.fTempRoot,Guid.NewGuid().ToString())).FullName;
        }

    }
}
