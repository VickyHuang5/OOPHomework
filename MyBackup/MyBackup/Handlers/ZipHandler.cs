using MyBackupCandidate;
using System.IO;
using System.IO.Compression;

namespace MyBackup.Handlers
{
    /// <summary>
    /// 壓縮處理器
    /// </summary>
    public class ZipHandler : AbstractHandler
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
            if (target != null)
            {
                result = this.ZipData(candidate, target);
            }

            return result;
        }

        /// <summary>
        /// 壓縮資料
        /// </summary>
        /// <param name="candidate">描述待處理檔案的資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        private byte[] ZipData(Candidate candidate, byte[] target)
        {
            MemoryStream result = new MemoryStream();
            using (DeflateStream deflateStream = new DeflateStream(result, CompressionMode.Compress))
            {
                deflateStream.Write(target, 0, target.Length);
            }

            return result.ToArray();
        }
    }
}