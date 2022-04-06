namespace MangaLibraryManager.Core.Data
{
    public class EbookReader
    {
        public string Name;
        public int Width;
        public int Height;
        public int PPI;
        public EbookReader(string Name, int Width, int Height, int PPI)
        {
            this.Name = Name;
            this.Width = Width;
            this.Height = Height;
            this.PPI = PPI;
        }
    }
}
