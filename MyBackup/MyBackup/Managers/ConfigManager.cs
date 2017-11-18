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
        /// 設定清單
        /// </summary>
        public List<Config> Configs = new List<Config>();

        /// <summary>
        /// config.json檔路徑
        /// </summary>
        private const string Path = @"../../Configs/config.json";

        /// <summary>
        /// 索引子
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns>設定物件</returns>
        public Config this[int index]
        {
            get
            {
                return this.Configs[index];
            }
        }

        /// <summary>
        /// 覆寫筆數
        /// </summary>
        /// <returns>設定筆數</returns>
        public override int Count()
        {
            return this.Configs.Count;
        }

        /// <summary>
        /// 覆寫處理JSON設定檔
        /// </summary>
        public override void ProcessJsonConfig()
        {
            JObject configObject = this.GetJsonObject(Path);
            JArray configDataArray = (JArray)configObject["configs"];
            this.Configs = configDataArray.ToObject<List<Config>>();
        }
    }
}