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
        /// 取得子目錄檔案
        /// </summary>
        /// <param name="config">設定</param>
        /// <returns>子目錄檔案</returns>
        private string[] GetSubDirectoryFiles(Config config)
        {
            return Directory.GetFiles(config.Location);
        }

        /// <summary>
        /// 建立待處理檔案的資訊
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        /// <returns>待處理檔案的資訊</returns>
        protected override Candidate CreateCandidate(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            Candidate candidate = new Candidate(config);
            candidate.FileDateTime = fileInfo.CreationTime.ToString();
            candidate.Name = fileInfo.Name;
            candidate.Size = fileInfo.Length.ToString();
            return candidate;
        }
    }
}