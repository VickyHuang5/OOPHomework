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
        /// schedule.json檔路徑
        /// </summary>
        private const string Path = @"../../Configs/schedule.json";

        /// <summary>
        /// 排程
        /// </summary>
        private List<Schedule> schedules;

        /// <summary>
        /// 索引子
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>排程物件</returns>
        public Schedule this[int index]
        {
            get
            {
                return this.schedules[index];
            }
        }

        /// <summary>
        /// 筆數
        /// </summary>
        /// <returns>排程筆數</returns>
        public override int Count()
        {
            return this.schedules.Count;
        }

        /// <summary>
        /// 處理JSON設定檔
        /// </summary>
        public override void ProcessJsonConfig()
        {
            JObject configObject = this.GetJsonObject(Path);
            JArray scheduleDataArray = (JArray)configObject["schedules"];
            this.schedules = scheduleDataArray.ToObject<List<Schedule>>();
        }
    }
}