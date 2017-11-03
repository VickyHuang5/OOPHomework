﻿using System.Collections.Generic;

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
            List<Candidate> Candidates = this.FindFiles();
            foreach (Candidate Candidate in Candidates)
            {
                this.BroadcastToHandlers(Candidate);
            }
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

        /// <summary>
        /// 轉發Handler
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        private void BroadcastToHandlers(Candidate candidate)
        {
            byte[] target = null;
            List<IHandler> handlers = this.FindHandlers(candidate);
            foreach (IHandler handler in handlers)
            {
                target = handler.Perform(candidate, target);
            }
        }

        /// <summary>
        /// 搜尋檔案
        /// </summary>
        /// <returns>Candidate清單</returns>
        private List<Candidate> FindFiles()
        {
            // Homework 4
            List<Candidate> fileList = new List<Candidate>();

            return fileList;
        }

        /// <summary>
        /// 搜尋處理器
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <returns>處理器清單</returns>
        private List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handlers = new List<IHandler>();
            handlers.Add(HandlerFactory.Create("file"));

            foreach (string handler in candidate.Config.Handlers)
            {
                handlers.Add(HandlerFactory.Create(handler));
            }

            handlers.Add(HandlerFactory.Create(candidate.Config.Destination));
            return handlers;
        }
    }
}