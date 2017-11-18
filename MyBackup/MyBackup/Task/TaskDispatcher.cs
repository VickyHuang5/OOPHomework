using MyBackupCandidate;
using System;
using System.Collections.Generic;

namespace MyBackup
{
    /// <summary>
    /// 任務分配器
    /// </summary>
    public class TaskDispatcher
    {
        /// <summary>
        /// 任務
        /// </summary>
        private ITask task;

        /// <summary>
        /// 一般任務
        /// </summary>
        /// <param name="managers">管理物件</param>
        public void SimpleTask(List<JsonManager> managers)
        {
            ConfigManager configManager = managers[0] as ConfigManager;
            this.ExecuteTask("simple", configManager, null);
            Console.WriteLine("simple task done.");
        }

        /// <summary>
        /// 排程任務
        /// </summary>
        /// <param name="managers">管理物件</param>
        public void ScheduledTask(List<JsonManager> managers)
        {
            ConfigManager configManager = managers[0] as ConfigManager;
            ScheduleManager scheduleManager = managers[1] as ScheduleManager;
            foreach (var schedule in scheduleManager.Schedules)
            {
                this.ExecuteTask("scheduled", configManager, schedule);
            }

            Console.WriteLine("scheduled task done.");
        }

        /// <summary>
        /// 執行任務
        /// </summary>
        /// <param name="taskType">任務類型</param>
        /// <param name="configManager">設定管理物件</param>
        /// <param name="schedule">排程管理物件</param>
        private void ExecuteTask(string taskType, ConfigManager configManager, Schedule schedule)
        {
            foreach (var config in configManager.Configs)
            {
                IFileFinder fileFinder = FileFinderFactory.Create("file", config);
                if (schedule == null || schedule.Ext == config.Ext)
                {
                    foreach (Candidate candidate in fileFinder)
                    {
                        this.task = TaskFactory.Create(taskType);
                        this.task.Execute(config, schedule);
                    }
                }
            }
        }
    }
}