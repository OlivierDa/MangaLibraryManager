using ImageProcessor;
using iTextSharp.text.pdf;
using MangaLibraryManager.Core.Utilities;
using Medallion.Shell;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MangaLibraryManager.Core.Data
{
    public class CBZCompressProgressEventArgs : EventArgs
    {
        public string Name, Text;
        public int Percentage = 0;
        public CBZCompressProgressEventArgs(string name, string text, int percent )
        {
            Name = name;
            Text = text;
            Percentage = percent;
        }
    }

    public class CBZArchive
    {
        public bool Compressed = false;
        public string Name;
        public double Size;
        public string Format;
        public int AvWidth;
        public int AvHeight;
        public string filePath;
        private string filePathTemp;
        public Image Cover;
        public int PageCount;
        public static event EventHandler<CBZCompressProgressEventArgs> OnCompressProgress;
          
        private void GetPreview(bool loadCover=true)
        {
            MemoryStream ms = new MemoryStream();
            int pageCount = 0;
            switch (this.Format)
            {
                case "ZIP":
                case "CBZ":

                    using (ZipArchive archivebook = ZipArchive.Open(this.filePathTemp, new ReaderOptions() { LookForHeader = false, DisableCheckIncomplete = true}))
                    {
                        this.Compressed = archivebook.Entries.Any(a => a.Key == ".mlmzip");
                        archivebook.Entries.First(a => !a.IsDirectory
                                    && (
                                        Path.GetExtension(a.Key) == ".jpg"
                                        || Path.GetExtension(a.Key) == ".jpeg"
                                        || Path.GetExtension(a.Key) == ".png"
                                        || Path.GetExtension(a.Key) == ".webm")).WriteTo(ms);

                        pageCount = archivebook.Entries.Count(a => !a.IsDirectory
                                      && (
                                          Path.GetExtension(a.Key) == ".jpg"
                                          || Path.GetExtension(a.Key) == ".jpeg"
                                          || Path.GetExtension(a.Key) == ".png"
                                          || Path.GetExtension(a.Key) == ".webm"));



                    }
                    break;
                case "RAR":
                case "CBR":
                    using (RarArchive archivebook = RarArchive.Open(this.filePathTemp, new ReaderOptions() { LookForHeader = false, DisableCheckIncomplete = true }))
                    {
                        archivebook.Entries.First(a => !a.IsDirectory
                                    && (
                                        Path.GetExtension(a.Key) == ".jpg"
                                        || Path.GetExtension(a.Key) == ".jpeg"
                                        || Path.GetExtension(a.Key) == ".png"
                                        || Path.GetExtension(a.Key) == ".webm")).WriteTo(ms);
                        pageCount = archivebook.Entries.Count(a => !a.IsDirectory
                                      && (                                          
                                          Path.GetExtension(a.Key) == ".jpg"
                                          || Path.GetExtension(a.Key) == ".jpeg"
                                          || Path.GetExtension(a.Key) == ".png"
                                          || Path.GetExtension(a.Key) == ".webm"));
                    }
                    break;

            }
            if (ms != null)
            {
                ms.Seek(0, SeekOrigin.Begin);
                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false, false))
                {
                    imageFactory.Load(ms);
                    this.AvWidth = imageFactory.Image.Width;
                    this.AvHeight = imageFactory.Image.Height;
                    this.PageCount = pageCount;
                    imageFactory.Resize(new System.Drawing.Size(200, 280));
                    if (loadCover == false) {
                        ms.Dispose();
                    }
                    else
                    {
                        ms = new MemoryStream();
                        imageFactory.Save(ms);
                        this.Cover = Image.FromStream(ms);
                    }
                }

                
            }
            return;
        }

        public CBZArchive(string filepath)
        {
            FileInfo fi = new FileInfo(filepath);
            this.Name = Path.GetFileNameWithoutExtension(filepath);
            this.Size = fi.Length;
            this.Format = Path.GetExtension(filepath).Trim('.').ToUpper();
            this.filePath = filepath;
            this.filePathTemp = filepath;
            this.GetPreview(true);

            

        }

        public string CompressAsync()
        {
            if (ConfigurationFactory.ARCHIVE_SAME_OUTPUT_AS_SOURCE)
            {
                ConfigurationFactory.ARCHIVE_OUTPUT = Path.GetDirectoryName(this.filePath);
            }
            string outputFileName = string.Format(@"{0}\{1}.{2}", ConfigurationFactory.ARCHIVE_OUTPUT, this.Name, ConfigurationFactory.ARCHIVE_OUTPUT_FORMAT.ToLower());


            if (Directory.Exists(ConfigurationFactory.ARCHIVE_OUTPUT) == false)
            {
                Directory.CreateDirectory(ConfigurationFactory.ARCHIVE_OUTPUT);
            }

            string temp2 = TempFactory.Current.GetTempFolder();
            Directory.CreateDirectory(temp2);
            try
            {
                this.extractAndCompressArchiveImages(temp2);
                string archiveChemin = writeArchive(temp2, outputFileName);
                if (ConfigurationFactory.ARCHIVE_OVERWRITE_SOURCE && archiveChemin != this.filePath)
                {
                    File.Delete(this.filePath);
                }
                return archiveChemin;
            }
            catch(Exception err)
            {
                throw;
            }
            finally
            {
                Directory.Delete(temp2, true);
                if (this.filePath != this.filePathTemp)
                {
                    File.Delete(this.filePathTemp);
                }
               
            }

        }
        private void RunProcess(string ApplicationName, IEnumerable<string> Arguments )
        {
            var command = Command.Run(
                   Path.Combine(Environment.CurrentDirectory, "imagemagick", ConfigurationFactory.IMAGE_MAGICK_VERSION, "magick.exe"),
                   Arguments);
            command.Wait();
        }
        
        private void compressImages(string dossier, string output)
        {
            string firstImage = Directory.GetFiles(dossier, "*.jpg").FirstOrDefault();
            if(firstImage == default(string)) firstImage = Directory.GetFiles(dossier, "*.jpeg").FirstOrDefault();
            if (firstImage == default(string)) firstImage = Directory.GetFiles(dossier, "*.png").FirstOrDefault();

            byte[] coverByte = null;
            if (firstImage != default(string))
            {
                coverByte = File.ReadAllBytes(firstImage);
                File.Delete(firstImage);
            }

            var param = ConfigurationFactory.IMAGE_MAGICK_OPTIONS.Split(' ');

            // Compression des images
            
            foreach (string ext in new List<string>() { "*.jpg", "*.jpeg", "*.png" }) {


                var cmdParam = new List<string>();
                cmdParam.Add("mogrify");
                cmdParam.Add("-monitor");
                cmdParam.Add("-format");
                cmdParam.Add("jpg");
                cmdParam.Add("-quality");
                cmdParam.Add(ConfigurationFactory.IMAGE_QUALITY.ToString());
                cmdParam.Add("-resize");
                cmdParam.Add(ConfigurationFactory.IMAGE_WIDTH + "x" + ConfigurationFactory.IMAGE_HEIGHT + ">");
                cmdParam.Add("-colorspace");
                cmdParam.Add(ConfigurationFactory.IMAGE_MAGICK_COLORS);
                cmdParam.AddRange(param);
                cmdParam.Add(Path.Combine(dossier, ext));

                RunProcess(Path.Combine(Environment.CurrentDirectory, "imagemagick", ConfigurationFactory.IMAGE_MAGICK_VERSION, "magick.exe"), cmdParam);


            }
            if (firstImage != default(string))
            {
                File.WriteAllBytes(firstImage, coverByte);

                var cmdParam = new List<string>();
                cmdParam.Add("mogrify");
                cmdParam.Add("-monitor");
                cmdParam.Add("-format");
                cmdParam.Add("jpg");
                cmdParam.Add("-quality");
                cmdParam.Add(ConfigurationFactory.IMAGE_QUALITY.ToString());
                cmdParam.Add("-resize");
                cmdParam.Add(ConfigurationFactory.IMAGE_WIDTH + "x" + ConfigurationFactory.IMAGE_HEIGHT + ">");
                cmdParam.Add("-colorspace");
                cmdParam.Add("RGB");
                cmdParam.AddRange(param);
                cmdParam.Add(firstImage);

       
                RunProcess(Path.Combine(Environment.CurrentDirectory, "imagemagick", ConfigurationFactory.IMAGE_MAGICK_VERSION, "magick.exe"), cmdParam);


            }

            var files = Directory.GetFiles(dossier, "*.jpg");
            
            foreach (string sFile in files)
            {
                File.Move(sFile, Path.Combine(output, Path.GetFileName(sFile)));
            }


        }

        
        private bool checkForCancellation(BackgroundWorker bgWorker)
        {
            if (bgWorker.CancellationPending)
            {
                bgWorker.ReportProgress(100, "9");
                return true;
            }
            return false;
        }


        private void extractImagesFromPDF(string sourcePdf, string outputPath)
        {
            // NOTE:  This will only get the first image it finds per page.
            PdfReader pdf = new PdfReader(sourcePdf);
            RandomAccessFileOrArray raf = new iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdf);

            try
            {
                for (int pageNumber = 1; pageNumber <= pdf.NumberOfPages; pageNumber++)
                {
                    PdfDictionary pg = pdf.GetPageN(pageNumber);

                    // recursively search pages, forms and groups for images.
                    List<PdfObject> objs = this.findImagesInPDFDictionary(pg);
                    for (int iObj = 0; iObj < objs.Count; iObj++)
                    {
                        try
                        {
                            PdfObject obj = objs[iObj];
                            if (obj != null)
                            {

                                int XrefIndex = Convert.ToInt32(((PRIndirectReference)obj).Number.ToString(System.Globalization.CultureInfo.InvariantCulture));
                                PdfObject pdfObj = pdf.GetPdfObject(XrefIndex);
                                PdfStream pdfStrem = (PdfStream)pdfObj;
                                byte[] bytes = PdfReader.GetStreamBytesRaw((PRStream)pdfStrem);
                                if ((bytes != null))
                                {
                                    using (System.IO.MemoryStream memStream = new System.IO.MemoryStream(bytes))
                                    {
                                        memStream.Position = 0;
                                        System.Drawing.Image img = System.Drawing.Image.FromStream(memStream);
                                        // must save the file while stream is open.
                                        if (!Directory.Exists(outputPath))
                                            Directory.CreateDirectory(outputPath);

                                        string path = Path.Combine(outputPath, String.Format(@"{0}-{1}.jpg", pageNumber, iObj));
                                        System.Drawing.Imaging.EncoderParameters parms = new System.Drawing.Imaging.EncoderParameters(1);
                                        parms.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 0);
                                        System.Drawing.Imaging.ImageCodecInfo jpegEncoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);// ImageCodecInfo.;
                                        //bgw.ReportProgress((pageNumber * 100) / pdf.NumberOfPages, "1.Extraction de la page " + pageNumber + "/" + pdf.NumberOfPages);
                                        OnCompressProgress(this, new CBZCompressProgressEventArgs(this.Name, "1.Extraction de la page " + pageNumber + "/" + pdf.NumberOfPages, (pageNumber * 100) / pdf.NumberOfPages));
                                        img.Save(path, jpegEncoder, parms);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lecture impossible de l'image");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                pdf.Close();
                raf.Close();
            }


        }

        private List<PdfObject> findImagesInPDFDictionary(PdfDictionary pg)
        {
            List<PdfObject> objects = new List<PdfObject>();
            PdfDictionary res =
                (PdfDictionary)PdfReader.GetPdfObject(pg.Get(PdfName.RESOURCES));


            PdfDictionary xobj =
              (PdfDictionary)PdfReader.GetPdfObject(res.Get(PdfName.XOBJECT));
            if (xobj != null)
            {
                foreach (PdfName name in xobj.Keys)
                {

                    PdfObject obj = xobj.Get(name);
                    if (obj.IsIndirect())
                    {
                        PdfDictionary tg = (PdfDictionary)PdfReader.GetPdfObject(obj);

                        PdfName type =
                          (PdfName)PdfReader.GetPdfObject(tg.Get(PdfName.SUBTYPE));

                        //image at the root of the pdf
                        if (PdfName.IMAGE.Equals(type))
                        {
                            objects.Add(obj);
                        }// image inside a form
                        else if (PdfName.FORM.Equals(type))
                        {
                            this.findImagesInPDFDictionary(tg);
                        } //image inside a group
                        else if (PdfName.GROUP.Equals(type))
                        {
                            this.findImagesInPDFDictionary(tg);
                        }

                    }
                }
            }
            objects = objects.OrderBy(a => (a as dynamic).Number).ToList() ;
            return objects;

        }

        public void extractAndCompressArchiveImages(string dataFolderDestination, bool firstTry = true)
        {
            try
            {
                string temp = TempFactory.Current.GetTempFolder();
                Directory.CreateDirectory(temp);

                switch (this.Format)
                {
                    case "CBZ":
                        using (ZipArchive archivebook = ZipArchive.Open(this.filePathTemp))
                        {

                            if(archivebook.Entries.Count== 0 && firstTry)
                            {
                                // Potentiellement : rar renommé
                                this.Format = "CBR";
                                this.extractAndCompressArchiveImages(dataFolderDestination, false);
                                return;
                            }
                            int total = archivebook.Entries.Where(entry =>
                                            !entry.IsDirectory
                                            && (Path.GetExtension(entry.Key) == ".jpg" || Path.GetExtension(entry.Key) == ".jpeg" ||
                                                Path.GetExtension(entry.Key) == ".png" || Path.GetExtension(entry.Key) == ".webm")).Count();
                            int i = 0;

                            using (IReader reader = archivebook.ExtractAllEntries())
                            {
                                while (reader.MoveToNextEntry())
                                {
                                    i++;
                                    if (
                                        !reader.Entry.IsDirectory
                                        && (
                                            Path.GetExtension(reader.Entry.Key) == ".jpg"
                                            || Path.GetExtension(reader.Entry.Key) == ".jpeg"
                                            || Path.GetExtension(reader.Entry.Key) == ".png"
                                            || Path.GetExtension(reader.Entry.Key) == ".webm"))
                                    {
                                        reader.WriteEntryToFile(Path.Combine(temp, reader.Entry.Key.Replace("/", "_") + Path.GetExtension(reader.Entry.Key)), new ExtractionOptions() { ExtractFullPath = false, Overwrite = true, PreserveAttributes = false, PreserveFileTime = false }) ;
                                    }
                                    OnCompressProgress(this, new CBZCompressProgressEventArgs(
                                        Name, 
                                        "1.Extraction de la page " + i + "/" + total, 
                                        ((100 * i) / total)/3));
                                }
                            }

                        }
                        break;
                    case "CBR":
                        using (RarArchive archivebook = RarArchive.Open(this.filePathTemp))
                        {

                            if (archivebook.Entries.Count == 0 && firstTry)
                            {
                                // Potentiellement : ziprenommé
                                this.Format = "CBZ";
                                this.extractAndCompressArchiveImages(dataFolderDestination, false);
                                return;
                            }
                            int total = archivebook.Entries.Where(entry =>
                                            !entry.IsDirectory
                                            && (Path.GetExtension(entry.Key) == ".jpg" || Path.GetExtension(entry.Key) == ".jpeg" ||
                                                Path.GetExtension(entry.Key) == ".png" || Path.GetExtension(entry.Key) == ".webm")).Count();
                            int i = 0;

                            using (IReader reader = archivebook.ExtractAllEntries())
                            {
                                while (reader.MoveToNextEntry())
                                {
                                    //if (this.checkForCancellation(bgw))
                                    //{
                                    //    return;
                                    //}
                                    i++;
                                    if (
                                        !reader.Entry.IsDirectory
                                        && (
                                            Path.GetExtension(reader.Entry.Key) == ".jpg"
                                            || Path.GetExtension(reader.Entry.Key) == ".jpeg"
                                            || Path.GetExtension(reader.Entry.Key) == ".png"
                                            || Path.GetExtension(reader.Entry.Key) == ".webm"))
                                    {
                                        reader.WriteEntryToFile(Path.Combine(temp, i.ToString("D4")+ Path.GetExtension(reader.Entry.Key)), new ExtractionOptions() { ExtractFullPath = false, Overwrite = true, PreserveAttributes = false, PreserveFileTime = false });
                                    }
                                    OnCompressProgress(this, new CBZCompressProgressEventArgs(Name, "1.Extraction de la page " + i + "/" + total, ((100 * i) / total)/3));
                                }
                            }

                        }
                        break;
                    case "PDF":

                        this.extractImagesFromPDF(this.filePathTemp, temp);

                        //Fusion des images verticales d'une même page
                        string[] fichiers = Directory.GetFiles(temp);
                        int pages = fichiers.Select(a => Path.GetFileName(a).Split('-')[0]).Distinct().Count();

                        for (int iPage = 1; iPage <= pages + 1; iPage++)
                        {
                            string[] imageParts = fichiers.Where(a => Path.GetFileName(a).StartsWith(iPage + "-")).ToArray();
                            if (imageParts.Length > 1)
                            {
                                Image[] parties = imageParts.Select(a => Image.FromFile(a)).ToArray();

                                // cas vertical
                                if (parties[0].Width > parties[0].Height)
                                {
                                    using (Bitmap bmp = new Bitmap(parties[0].Width, parties.Sum(a => a.Height)))
                                    {
                                        using (var canvas = Graphics.FromImage(bmp))
                                        {
                                            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                            int currentHeight = 0;
                                            int width = parties[0].Width;
                                            foreach (Image frame in parties)
                                            {
                                                canvas.DrawImage(frame,
                                                    new Rectangle(0,
                                                                currentHeight,
                                                                width,
                                                                frame.Height),
                                                    new Rectangle(0,
                                                                0,
                                                                frame.Width,
                                                                frame.Height),
                                                    GraphicsUnit.Pixel);
                                                currentHeight += frame.Height;
                                            }
                                            bmp.Save(Path.Combine(temp, iPage + Path.GetExtension(imageParts[0])), System.Drawing.Imaging.ImageFormat.Jpeg);

                                        }

                                    }
                                }

                                // cas horizontal
                                if (parties[0].Width < parties[0].Height)
                                {
                                    using (Bitmap bmp = new Bitmap(parties[0].Width, parties.Sum(a => a.Height)))
                                    {
                                        using (var canvas = Graphics.FromImage(bmp))
                                        {
                                            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                            int currentWith = 0;
                                            int height = parties[0].Height;
                                            foreach (Image frame in parties)
                                            {
                                                canvas.DrawImage(frame,
                                                    new Rectangle(currentWith,
                                                                0,
                                                                frame.Width,
                                                                height),
                                                    new Rectangle(0,
                                                                0,
                                                                frame.Width,
                                                                frame.Height),
                                                    GraphicsUnit.Pixel);
                                                currentWith += frame.Width;
                                            }
                                            bmp.Save(Path.Combine(temp, iPage + Path.GetExtension(imageParts[0])), System.Drawing.Imaging.ImageFormat.Jpeg);

                                        }

                                    }
                                }

                                foreach (Image img in parties)
                                {
                                    img.Dispose();
                                }
                                foreach (string sPath in imageParts)
                                {
                                    File.Delete(sPath);
                                }
                            }
                        }

                        break;
                }

                #region Compression des images
                // Zippage des images
                OnCompressProgress(this, new CBZCompressProgressEventArgs(Name, "2.Compression des images ...", 33));
                this.compressImages(temp, dataFolderDestination);
                OnCompressProgress(this, new CBZCompressProgressEventArgs(Name, "2.Compression des images ...", 90));
                #endregion

            }
            catch (Exception err)
            {
                throw;
            }
            
        }

        public string writeArchive(string temp2,string fileName)
        {
            #region Ecriture de l'archive
            switch (ConfigurationFactory.ARCHIVE_OUTPUT_FORMAT.ToUpper())
            {
                case "CBZ":

                    using (ZipArchive archive = ZipArchive.Create())
                    {
                        //Renommage des fichiers 
                        string[] files = Directory.GetFiles(temp2);
                        for(int i=0;i < files.Length; i++)
                        {
                            File.Move(
                                files[i],
                                Path.Combine(Path.GetDirectoryName(files[i]), i.ToString("D4") + Path.GetExtension(files[i]))
                                );
                        }
                        archive.AddEntry(".mlmzip", Stream.Null);
                        archive.AddAllFromDirectory(temp2);
                        archive.DeflateCompressionLevel = SharpCompress.Compressors.Deflate.CompressionLevel.BestCompression;
                        OnCompressProgress(this, new CBZCompressProgressEventArgs(Name, "3.Compression ZIP.", 90));


                        if (!ConfigurationFactory.ARCHIVE_OVERWRITE_SOURCE)
                        {
                            if (File.Exists(fileName))
                            {
                                fileName = string.Format(@"{0}\{1} ({3}).{2}", ConfigurationFactory.ARCHIVE_OUTPUT, Path.GetFileNameWithoutExtension(fileName), ConfigurationFactory.ARCHIVE_OUTPUT_FORMAT.ToLower(), DateTime.Now.ToString("yyyyMMddHHmmss"));
                            }
                        }
                        else
                        {
                            if (File.Exists(fileName))
                            {
                                File.Delete(fileName);
                            }
                        }

                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (FileStream fs = new FileStream(fileName, FileMode.CreateNew))
                            {
                                archive.SaveTo(ms, CompressionType.Deflate);
                                ms.Seek(0, SeekOrigin.Begin);
                                //Ecriture du le disque
                                OnCompressProgress(this, new CBZCompressProgressEventArgs(Name, "3.Ecriture du fichier CBZ...", 90));

                                byte[] buffer = new byte[1024 * 1024];
                                int read;
                                int count = 0;
                                long total_count = ms.Length / (1024 * 1024);
                                long totalSize = (ms.Length / 1024 / 1024);
                                DateTime dtStart = DateTime.Now;
                                while ((read = ms.Read(buffer, 0, buffer.Length)) > 0)
                                {

                                    fs.Write(buffer, 0, read);
                                    count++;
                                    // report progress back
                                    long progress = (count * 100 / total_count);
                                    long done = progress > 0 ? totalSize / 100 * progress : 0;
                                    double mos = (done / (DateTime.Now.Subtract(dtStart).TotalSeconds));
                                    if (progress % 10 == 0)
                                    {
                                        OnCompressProgress(this, new CBZCompressProgressEventArgs(Name, "3.Ecriture du fichier CBZ...", ((Convert.ToInt32(progress)/10)+90)));
                                    }
                                }
                                OnCompressProgress(this, new CBZCompressProgressEventArgs(Name, "3.Terminé", 100));

                                

                            }

                        }


                    }


                    break;

            }
            #endregion
           
            return fileName;
        }


        
    }

}