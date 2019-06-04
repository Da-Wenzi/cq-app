using Microsoft.Extensions.Configuration;

namespace CQ.Note.Core.Config
{
    public class AppSetting
    {

        public AppSetting(IConfiguration configuration)
        {
            UploadFilePath = configuration.GetValue<string>(Constant.SETTING_KEY_UPLOAD_FILE_PATH);
        }


        public string UploadFilePath { get; private set; }
    }
}
