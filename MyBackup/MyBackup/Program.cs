using MyBackup.Services;

namespace MyBackup
{
    /// <summary>
    /// 我的備份程式
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 備份主程式
        /// </summary>
        /// <param name="args">執行參數</param>
        private static void Main(string[] args)
        {
            MyBackupService backupService = new MyBackupService();
            backupService.ProcessJsonConfigs();
            backupService.DoBackup();
        }
    }
}