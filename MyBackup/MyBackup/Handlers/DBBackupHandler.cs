using MyBackupCandidate;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 資料庫備份處理器
    /// </summary>
    public class DBBackupHandler: AbstractDBHandler
    {
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}