using MyBackupCandidate;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 資料庫轉換器
    /// </summary>
    public class DBAdapter : AbstractHandler
    {
        /// <summary>
        /// 資料庫備份處理器
        /// </summary>
        private IDBHandler backupHandler = new DBBackupHandler();

        /// <summary>
        /// 資料庫紀錄處理器
        /// </summary>
        private IDBHandler logHandler = new DBLogHandler();

        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        public override byte[] Perform(Candidate candidate,byte[] target)
        {
            base.Perform(candidate, target);
            this.SaveBackupToDB(candidate, target);
            this.SaveLogToDB(candidate, target);
            return target;
        }

        /// <summary>
        /// 儲存備份至資料庫
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <param name="target">處理目標</param>
        private void SaveBackupToDB(Candidate candidate, byte[] target)
        {
            this.backupHandler.OpenConnection();
            this.backupHandler.Perform(candidate, target);
            this.backupHandler.CloseConnection();
        }

        /// <summary>
        /// 儲存紀錄至資料庫
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <param name="target">處理目標</param>
        private void SaveLogToDB(Candidate candidate, byte[] target)
        {
            this.logHandler.OpenConnection();
            this.logHandler.Perform(candidate, target);
            this.logHandler.CloseConnection();
}
    }