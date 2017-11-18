using MyBackupCandidate;

namespace MyBackup
{
    /// <summary>
    /// 抽象處理器
    /// </summary>
    public abstract class AbstractHandler
    {
        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        public virtual byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}