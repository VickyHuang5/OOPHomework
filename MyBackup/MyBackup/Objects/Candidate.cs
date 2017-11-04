namespace MyBackup
{
    /// <summary>
    /// 描述待處理檔案的資訊
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">設定檔物件</param>
        /// <param name="fileDateTime">檔案的日期與時間</param>
        /// <param name="name">檔案名稱</param>
        /// <param name="processName">處理方式</param>
        /// <param name="size">檔案大小</param>
        public Candidate(
            Config config,
            string fileDateTime,
            string name,
            string processName,
            string size)
        {
            this.Config = config;
            this.FileDateTime = fileDateTime;
            this.Name = name;
            this.ProcessName = processName;
            this.Size = size;
        }

        /// <summary>
        /// 設定檔物件
        /// </summary>
        public Config Config { get; set; }

        /// <summary>
        /// 檔案的日期與時間
        /// </summary>
        public string FileDateTime { get; set; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 處理方式
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 檔案大小
        /// </summary>
        public string Size { get; set; }
    }
}