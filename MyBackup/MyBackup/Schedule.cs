namespace MyBackup
{
    /// <summary>
    /// 排程
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// 排程所處理的檔案格式
        /// </summary>
        public string Ext { get; private set; }

        /// <summary>
        /// 排程執行的間隔
        /// </summary>
        public string Interval { get; private set; }

        /// <summary>
        /// 排程所處理的時間
        /// </summary>
        public string Time { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ext">排程所處理的檔案格式</param>
        /// <param name="time">排程所處理的時間</param>
        /// <param name="interval">排程執行的間隔</param>
        public Schedule(string ext,
                        string time,
                        string interval)
        {
            this.Ext = ext;
            this.Time = time;
            this.Interval = interval;
        }
    }
}