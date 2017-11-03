namespace MyBackup.Handlers
{
    /// <summary>
    /// 目錄處理器
    /// </summary>
    public class DirectoryHandler : AbstractHandler
    {
        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = target;
            base.Perform(candidate, target);
            if (target != null)
            {
                result = this.CopyToDirectory(candidate, target);
            }

            return result;
        }

        /// <summary>
        /// 複製至目錄
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        private byte[] CopyToDirectory(Candidate candidate, byte[] target)
        {
            // TODO:實作
            return target;
        }
    }
}