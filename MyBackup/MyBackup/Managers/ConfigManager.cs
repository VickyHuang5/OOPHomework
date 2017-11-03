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
        private const string Path = @"../../Configs/config.json";

        /// <summary>
        /// 設定清單
        /// </summary>
        private List<Config> configs;

        /// <summary>
        /// 索引子
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>設定物件</returns>
        public Config this[int index]
        {
            get
            {
                return this.configs[index];
            }
        }

        /// <summary>
        /// 筆數
        /// </summary>
        /// <returns>設定筆數</returns>
        public override int Count()
        {
            return this.configs.Count;
        }

        /// <summary>
        /// 處理JSON設定檔
        /// </summary>
        public override void ProcessJsonConfig()
        {
            JObject configObject = this.GetJsonObject(Path);
            JArray configDataArray = (JArray)configObject["configs"];
            this.configs = configDataArray.ToObject<List<Config>>();
        }
    }
}