using MyBackup;
using System;

namespace MyBackupCandidate
{
    /// <summary>
    /// 待處理檔案資訊工廠
    /// </summary>
    public class CandidateFactory
    {
        /// <summary>
        /// 建立
        /// </summary>
        /// <param name="config">設定檔物件</param>
        /// <param name="name">檔案名稱</param>
        /// <param name="fileDateTime">檔案建立時間</param>
        /// <param name="size">檔案大小</param>
        /// <returns>待處理檔案資訊</returns>
        public static Candidate Create(Config config, string name, DateTime fileDateTime, long size)
        {
            return new Candidate(config, name, fileDateTime, size);
        }
    }
}