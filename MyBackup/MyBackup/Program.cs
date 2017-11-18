using MyBackup.Services;
using System;

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

            // 簡單備份
            backupService.SimpleBackup();

            // 排程備份
            backupService.ScheduledBackup();
            Console.WriteLine("任意鍵離開.");
            Console.ReadKey();
        }
    }
}