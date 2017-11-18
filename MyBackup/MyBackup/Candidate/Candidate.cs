using MyBackup;
using System;

namespace MyBackupCandidate
{
    /// <summary>
    /// 待處理檔案資訊
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// 多載建構子
        /// </summary>
        /// <param name="config">設定檔物件</param>
        /// <param name="name">檔案名稱</param>
        /// <param name="fileDateTime">檔案建立時間</param>
        /// <param name="size">檔案大小</param>
        internal Candidate(
            Config config,
            string name,
            DateTime fileDateTime,
            long size)
        {
            this.Config = config;
            this.Name = name;
            this.FileDateTime = fileDateTime;
            this.Size = size;
        }

        /// <summary>
        /// 建構子
        /// </summary>
        internal Candidate()
        {
        }

        /// <summary>
        /// 設定檔物件
        /// </summary>
        public Config Config { get; private set; }

        /// <summary>
        /// 檔案建立時間
        /// </summary>
        public DateTime FileDateTime { get; private set; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 處理方式
        /// </summary>
        public string ProcessName { get; private set; }

        /// <summary>
        /// 檔案大小
        /// </summary>
        public long Size { get; private set; }
    }
}