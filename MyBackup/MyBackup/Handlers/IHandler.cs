﻿using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// 處理器介面
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        byte[] Perform(Candidate candidate, byte[] target);
    }
}