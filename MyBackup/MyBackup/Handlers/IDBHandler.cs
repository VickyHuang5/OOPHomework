using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// 資料庫處理器介面
    /// </summary>
    public interface IDBHandler
    {
        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        byte[] Perform(Candidate candidate, byte[] target);

        /// <summary>
        /// 寫入資料庫
        /// </summary>
        /// <param name="sql">SQL指令</param>
        void InsertDB(string sql);
    }
}