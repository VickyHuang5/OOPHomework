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
        /// Constructor
        /// </summary>
        public MyBackupService()
        {
            this.managers.Add(new ConfigManager());
            this.managers.Add(new ScheduleManager());
        }

        /// <summary>
        /// 備份
        /// </summary>
        public void DoBackup()
        {
            int i = 1;
            foreach (JsonManager manager in this.managers)
            {
                Console.WriteLine($"Manager{i}設定個數:{manager.Count().ToString()}");
                i++;
            }

            Console.WriteLine("任意鍵離開.");
            Console.ReadKey();
        }

        /// <summary>
        /// 處理JSON設定檔
        /// </summary>
        public void ProcessJsonConfigs()
        {
            for (int i = 0; i < this.managers.Count; i++)
            {
                this.managers[i].ProcessJsonConfig();
            }
        }
    }
}