namespace CQ.Note.Core.Providers
{
    public interface IFileProvider
    {

        FileInfo Save(string fileName, byte[] data, FilePathGenerateType type);
    }


    public class FileInfo
    {
        public FileInfo(string newFileName, string filePath, string md5)
        {
            FileName = newFileName;
            FilePath = filePath;
            Md5 = md5;
        }

        public string FileName { get; private set; }

        public string FilePath { get; private set; }


        public string Md5 { get; private set; }
    }
}
