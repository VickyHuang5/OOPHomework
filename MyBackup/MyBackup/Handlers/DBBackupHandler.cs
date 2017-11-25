using MyBackupCandidate;
using System;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 資料庫備份處理器
    /// </summary>
    public class DBBackupHandler : AbstractDBHandler
    {
        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            Console.WriteLine("Perform DBBackup.");
            return target;
        }
    }
}