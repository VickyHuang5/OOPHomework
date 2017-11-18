using MyBackupCandidate;
using System;
using System.Collections.Generic;

namespace MyBackup.Services
{
    /// <summary>
    /// 備份服務
    /// </summary>
    public class MyBackupService
    {
        /// <summary>
        /// JSON物件管理清單
        /// </summary>
        private List<JsonManager> managers = new List<JsonManager>();

        /// <summary>
        /// 任務分配器
        /// </summary>
        private TaskDispatcher taskDispatcher;

        /// <summary>
        /// Constructor
        /// </summary>
        public MyBackupService()
        {
            this.managers.Add(new ConfigManager());
            this.managers.Add(new ScheduleManager());
            this.taskDispatcher = new TaskDispatcher();
            this.Init();
        }

        /// <summary>
        /// 簡單備份
        /// </summary>
        public void SimpleBackup()
        {
            this.taskDispatcher.SimpleTask(this.managers);
        }

        /// <summary>
        /// 排程備份
        /// </summary>
        public void ScheduledBackup()
        {
            this.taskDispatcher.ScheduledTask(this.managers);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            this.ProcessJsonConfigs();
        }

        /// <summary>
        /// 處理JSON設定檔
        /// </summary>
        private void ProcessJsonConfigs()
        {
            for (int i = 0; i < this.managers.Count; i++)
            {
                this.managers[i].ProcessJsonConfig();
            }

            Console.WriteLine("ProcessJsonConfigs done.");
        }

        /// <summary>
        /// 搜尋檔案
        /// </summary>
        /// <returns>Candidate清單</returns>
        private List<Candidate> FindFiles()
        {
            // Homework 4
            List<Candidate> fileList = new List<Candidate>();
            Console.WriteLine("FindFiles done.");
            return fileList;
        }
    }
}