using MyBackupCandidate;
using System.IO;

namespace MyBackup
{
    /// <summary>
    /// 本機檔案搜尋
    /// </summary>
    public class LocalFileFinder : AbstractFileFinder
    {
        /// <summary>
        /// 建構子
        /// </summary>
        public LocalFileFinder()
        {
        }

        /// <summary>
        /// 多載建構子
        /// </summary>
        /// <param name="config">設定</param>
        public LocalFileFinder(Config config) : base(config)
        {
            if (config.SubDirectory)
            {
                this.files = this.GetSubDirectoryFiles(config);
            }
            else
            {
                this.files = Directory.GetFiles(config.Location, "*." + config.Ext);
            }
        }

        /// <summary>
        /// 覆寫建立待處理檔案資訊
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        /// <returns>待處理檔案資訊</returns>
        protected override Candidate CreateCandidate(string fileName)
        {
            FileInfo fileInfo;
            Candidate candidate = null;
            if (File.Exists(fileName))
            {
                fileInfo = new FileInfo(fileName);
                candidate = CandidateFactory.Create(this.config, fileName, fileInfo.CreationTime, fileInfo.Length);
            }

            return candidate;
        }

        /// <summary>
        /// 取得子目錄檔案
        /// </summary>
        /// <param name="config">設定</param>
        /// <returns>子目錄檔案</returns>
        private string[] GetSubDirectoryFiles(Config config)
        {
            return Directory.GetFiles(config.Location);
        }
    }
}