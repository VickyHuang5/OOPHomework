using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// 抽象處理器
    /// </summary>
    public abstract class AbstractDBHandler: IDBHandler
    {
        /// <summary>
        /// 關閉資料庫連線
        /// </summary>
        public virtual void CloseConnection()
        {
        }

        /// <summary>
        /// 開啟資料庫連線
        /// </summary>
        public virtual void OpenConnection()
        {
        }

        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        public virtual byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}