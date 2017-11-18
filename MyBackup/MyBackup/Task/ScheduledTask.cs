using MyBackupCandidate;
using System;

namespace MyBackup
{
    /// <summary>
    /// 排程任務
    /// </summary>
    public class ScheduledTask : AbstractTask
    {
        /// <summary>
        /// 覆寫執行
        /// </summary>
        /// <param name="config">設定檔物件</param>
        /// <param name="schedule">排程檔物件</param>
        public override void Execute(Config config, Schedule schedule)
        {
            base.Execute(config, schedule);
            bool isEveryDay = schedule.Interval == "Everyday";
            bool isTheDayOfWeek = schedule.Interval == DateTime.Now.DayOfWeek.ToString();
            bool isTheTime = schedule.Time == DateTime.Now.ToString("HH:mm");
            if ((isEveryDay || isTheDayOfWeek) && isTheTime)
            {
                foreach (Candidate candidate in this.fileFinder)
                {
                    this.BroadcastToHandlers(candidate);
                }
            }
        }
    }
}