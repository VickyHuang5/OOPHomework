namespace MyBackup
{
    /// <summary>
    /// 設定
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 資料庫連接字串
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// 儲存目的地
        /// </summary>
        public string Destination { get; private set; }

        /// <summary>
        /// 處理後的目錄
        /// </summary>
        public string Dir { get; private set; }

        /// <summary>
        /// 檔案格式
        /// </summary>
        public string Ext { get; private set; }

        /// <summary>
        /// 處理方式
        /// </summary>
        public string Handler { get; private set; }

        /// <summary>
        /// 備份檔案的目錄
        /// </summary>
        public string Location { get; private set; }

        /// <summary>
        /// 處理完是否刪除檔案
        /// </summary>
        public bool Remove { get; private set; }

        /// <summary>
        /// 是否處理子目錄
        /// </summary>
        public bool SubDirectory { get; private set; }

        /// <summary>
        /// 備份單位
        /// </summary>
        public string Unit { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ext">檔案格式</param>
        /// <param name="location">備份檔案的目錄</param>
        /// <param name="subDirectory">是否處理子目錄</param>
        /// <param name="unit">備份單位</param>
        /// <param name="remove">處理完是否刪除檔案</param>
        /// <param name="handler">處理方式</param>
        /// <param name="destination">儲存目的地</param>
        /// <param name="dir">處理後的目錄</param>
        /// <param name="connectionString">資料庫連接字串</param>
        public Config(string ext,
                      string location,
                      bool subDirectory,
                      string unit,
                      bool remove,
                      string handler,
                      string destination,
                      string dir,
                      string connectionString)
        {
            this.Ext = ext;
            this.Location = location;
            this.SubDirectory = subDirectory;
            this.Unit = unit;
            this.Remove = remove;
            this.Handler = handler;
            this.Destination = destination;
            this.Dir = dir;
            this.ConnectionString = connectionString;
        }
    }
}