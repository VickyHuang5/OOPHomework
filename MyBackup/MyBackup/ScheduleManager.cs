using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace MyBackup
{
    internal class ScheduleManager
    {
        /// <summary>
        /// 排程
        /// </summary>
        private List<Schedule> schedules;

        public Schedule this[int index]
        {
            get
            {
                return schedules[index];
            }
        }

        /// <summary>
        /// 筆數
        /// </summary>
        /// <returns>排程筆數</returns>
        public int Count()
        {
            return schedules.Count;
        }

        public void ProcessSchedules()
        {
            JObject scheduleData = JObject.Parse(File.ReadAllText("schedule.json"));
            JArray scheduleDataArray = (JArray)scheduleData["schedules"];
            this.schedules = scheduleDataArray.ToObject<List<Schedule>>();
        }
    }
}