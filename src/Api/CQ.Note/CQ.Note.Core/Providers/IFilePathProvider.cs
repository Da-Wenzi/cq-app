namespace CQ.Note.Core.Providers
{
    public interface IFilePathProvider
    {

        FilePathGenerateType Type { get; }

        string Src { get; }
    }


    public enum FilePathGenerateType
    {
        /// <summary>
        /// 年月日 C:/upload/2019/1/1
        /// </summary>
        Date
    }
}
