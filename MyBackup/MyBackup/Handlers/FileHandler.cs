using MyBackupCandidate;
using System.IO;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 檔案處理器
    /// </summary>
    public class FileHandler : AbstractHandler
    {
        /// <summary>
        /// 覆寫執行
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        public override byte[] Perform(Candidate candidate, byte[] target)
        {
            byte[] result = target;
            base.Perform(candidate, target);
            if (target == null)
            {
                result = this.ConvertFileToByteArray(candidate);
            }
            else
            {
                this.ConvertByteArrayToFile(candidate, target);
            }

            return result;
        }

        /// <summary>
        /// 轉換Byte陣列為檔案
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">處理目標</param>
        private void ConvertByteArrayToFile(Candidate candidate, byte[] target)
        {
            using (FileStream fileStream = new FileStream(candidate.Name, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(target, 0, target.Length);
            }
        }

        /// <summary>
        /// 轉換檔案至Byte陣列
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <returns>byte陣列</returns>
        private byte[] ConvertFileToByteArray(Candidate candidate)
        {
            return File.ReadAllBytes(candidate.Name);
        }
    }
}