using Newtonsoft.Json.Linq;
using System.IO;

namespace MyBackup
{
    /// <summary>
    /// JSON物件管理
    /// </summary>
    public abstract class JsonManager
    {
        /// <summary>
        /// 處理JSON設定檔
        /// </summary>
        public abstract void ProcessJsonConfig();

        /// <summary>
        /// 取得JSON物件
        /// </summary>
        /// <param name="path">檔案路徑</param>
        /// <returns>JObject</returns>
        protected JObject GetJsonObject(string path)
        {
            return JObject.Parse(File.ReadAllText(path));
        }
    }
}