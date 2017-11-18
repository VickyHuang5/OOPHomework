using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// 一般任務
    /// </summary>
    public class SimpleTask : AbstractTask
    {
        /// <summary>
        /// 覆寫執行
        /// </summary>
        /// <param name="config">設定檔物件</param>
        /// <param name="schedule">排程檔物件</param>
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);
            foreach (Candidate candidate in this.fileFinder)
            {
                this.BroadcastToHandlers(candidate);
            }
        }
    }
}