using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MyBackup
{
    /// <summary>
    /// 設定管理
    /// </summary>
    public class ConfigManager : JsonManager
    {
        /// <summary>
        /// config.json檔路徑
        /// </summary>
        private const string path = @"../../Configs/config.json";

        /// <summary>
        /// 設定清單
        /// </summary>
        private List<Config> configs;

        /// <summary>
        /// 索引子
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public Config this[int index]
        {
            get
            {
                return configs[index];
            }
        }

        /// <summary>
        /// 筆數
        /// </summary>
        /// <returns>設定筆數</returns>
        public int Count()
        {
            return configs.Count;
        }

        /// <summary>
        /// 處理JSON設定檔
        /// </summary>
        public override void ProcessJsonConfig()
        {
            JObject configObject = this.GetJsonObject(path);
            JArray configDataArray = (JArray)configObject["configs"];
            this.configs = configDataArray.ToObject<List<Config>>();
        }
    }
}