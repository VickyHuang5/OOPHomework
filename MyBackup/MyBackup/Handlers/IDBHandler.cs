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
        /// 開啟資料庫連線
        /// </summary>
        void OpenConnection();

        /// <summary>
        /// 關閉資料庫連線
        /// </summary>
        void CloseConnection();
    }
}