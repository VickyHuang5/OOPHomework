using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyBackup
{
    /// <summary>
    /// 處理器工廠
    /// </summary>
    public class HandlerFactory
    {
        /// <summary>
        /// 處理器字典
        /// </summary>
        private static Dictionary<string, string> handlerDictionary;

        /// <summary>
        /// 建構子
        /// </summary>
        static HandlerFactory()
        {
            string jsonString = File.ReadAllText(@"../../Configs/handler_mapping.json");
            HandlerFactory.handlerDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
        }

        /// <summary>
        /// 建立
        /// </summary>
        /// <param name="key">關鍵字</param>
        /// <returns>處理器</returns>
        public static IHandler Create(string key)
        {
            return (IHandler)Activator.CreateInstance("MyBackupService", HandlerFactory.handlerDictionary[key]).Unwrap();
        }
    }
}