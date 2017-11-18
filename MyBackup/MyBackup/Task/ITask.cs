namespace MyBackup
{
    /// <summary>
    /// 任務介面
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="config">設定檔物件</param>
        /// <param name="shedule">排程檔物件</param>
        void Execute(Config config, Schedule shedule);
    }
}