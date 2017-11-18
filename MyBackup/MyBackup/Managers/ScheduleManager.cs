using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MyBackup
{
    /// <summary>
    /// 排程管理
    /// </summary>
    internal class ScheduleManager : JsonManager
    {
        /// <summary>
        /// 排程
        /// </summary>
        public List<Schedule> Schedules;

        /// <summary>
        /// schedule.json檔路徑
        /// </summary>
        private const string Path = @"../../Configs/schedule.json";

        /// <summary>
        /// 索引子
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>排程物件</returns>
        public Schedule this[int index]
        {
            get
            {
                return this.Schedules[index];
            }
        }

        /// <summary>
        /// 覆寫筆數
        /// </summary>
        /// <returns>排程筆數</returns>
        public override int Count()
        {
            return this.Schedules.Count;
        }

        /// <summary>
        /// 覆寫處理JSON設定檔
        /// </summary>
        public override void ProcessJsonConfig()
        {
            JObject configObject = this.GetJsonObject(Path);
            JArray scheduleDataArray = (JArray)configObject["schedules"];
            this.Schedules = scheduleDataArray.ToObject<List<Schedule>>();
        }
    }
}