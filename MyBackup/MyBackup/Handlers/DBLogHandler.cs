using MyBackupCandidate;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 資料庫紀錄處理器
    /// </summary>
    public class DBLogHandler : AbstractDBHandler
    {
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}