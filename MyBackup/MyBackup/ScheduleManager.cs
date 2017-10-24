using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MyBackup
{
    internal class ScheduleManager : JsonManager
    {
        private const string path = @"../../Configs/schedule.json";

        /// <summary>
        /// 排程
        /// </summary>
        private List<Schedule> schedules;

        /// <summary>
        /// 索引子
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
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

        /// <summary>
        /// 處理JSON設定檔
        /// </summary>
        public override void ProcessJsonConfig()
        {
            JObject configObject = this.GetJsonObject(path);
            JArray scheduleDataArray = (JArray)configObject["schedules"];
            this.schedules = scheduleDataArray.ToObject<List<Schedule>>();
        }
    }
}