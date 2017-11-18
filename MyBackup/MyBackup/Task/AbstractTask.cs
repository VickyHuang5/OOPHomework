using MyBackupCandidate;
using System;
using System.Collections.Generic;

namespace MyBackup
{
    /// <summary>
    /// 抽象任務
    /// </summary>
    public abstract class AbstractTask : ITask
    {
        /// <summary>
        /// 檔案搜尋器
        /// </summary>
        protected IFileFinder fileFinder;

        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="config">設定檔物件</param>
        /// <param name="schedule">排程檔物件</param>
        public virtual void Execute(Config config, Schedule schedule)
        {
            this.fileFinder = FileFinderFactory.Create("file", config);
        }

        /// <summary>
        /// 轉發Handler
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        protected void BroadcastToHandlers(Candidate candidate)
        {
            byte[] target = null;
            List<IHandler> handlers = this.FindHandlers(candidate);
            foreach (IHandler handler in handlers)
            {
                target = handler.Perform(candidate, target);
            }

            Console.WriteLine("BroadcastToHandlers done.");
        }

        /// <summary>
        /// 搜尋處理器
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <returns>處理器清單</returns>
        protected List<IHandler> FindHandlers(Candidate candidate)
        {
            List<IHandler> handlers = new List<IHandler>();
            handlers.Add(HandlerFactory.Create("file"));

            foreach (string handler in candidate.Config.Handlers)
            {
                handlers.Add(HandlerFactory.Create(handler));
            }

            handlers.Add(HandlerFactory.Create(candidate.Config.Destination));
            Console.WriteLine("FindHandlers done.");
            return handlers;
        }
    }
}