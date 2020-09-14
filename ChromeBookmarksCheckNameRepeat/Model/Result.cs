using System.ComponentModel;

namespace ChromeBookmarksCheck.Model
{
    public class Result
    {
        [DisplayName("路徑")]
        public string FolderPath { get; set; }
        [DisplayName("名稱")]
        public string Name { get; set; }
        [DisplayName("網址")]
        public string Url { get; set; }
        [DisplayName("錯誤訊息")]
        public string ErrMsg { get; set; }
    }
}
