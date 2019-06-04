using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CQ.Note.Core.Providers.Impl
{
    public class FileProvider : IFileProvider
    {

        private readonly IGenerateProvider _generateProvider;
        private readonly ICollection<IFilePathProvider> _filePathProviders;

        public FileProvider(IGenerateProvider generateProvider, ICollection<IFilePathProvider> filePathProviders)
        {
            _generateProvider = generateProvider;
            _filePathProviders = filePathProviders;
        }



        public FileInfo Save(string fileName, byte[] data, FilePathGenerateType type)
        {
            StringBuilder sb = new StringBuilder();
            string ext = fileName.Split('.')[1];
            string newFileName = $"{ _generateProvider.Generate.ToString("N") }.{ ext }";
            IFilePathProvider filePathProvider = _filePathProviders.First(m => m.Type == type);
            string filePath = Path.Combine(filePathProvider.Src, newFileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileStream.Write(data, 0, data.Length);

                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(fileStream);
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
            }

            return new FileInfo(newFileName, filePath, sb.ToString());
        }
    }
}
