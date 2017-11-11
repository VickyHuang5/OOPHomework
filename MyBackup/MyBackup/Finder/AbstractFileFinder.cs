using System.Collections;
using System.Linq;

namespace MyBackup
{
    /// <summary>
    /// 抽象檔案搜尋
    /// </summary>
    public abstract class AbstractFileFinder : IFileFinder
    {
        /// <summary>
        /// 設定
        /// </summary>
        protected Config config;

        /// <summary>
        /// 檔案
        /// </summary>
        protected string[] files;

        /// <summary>
        /// 索引
        /// </summary>
        protected int index = -1;

        /// <summary>
        /// 建構子
        /// </summary>
        protected AbstractFileFinder()
        {
        }

        /// <summary>
        /// 多載建構子
        /// </summary>
        /// <param name="config">設定</param>
        protected AbstractFileFinder(Config config)
        {
            if (config != null)
            {
                this.config = config;
            }
        }

        /// <summary>
        /// IEnumerator
        /// </summary>
        public object Current => this.CreateCandidate(this.files[this.index]);

        /// <summary>
        /// IEnumerator
        /// </summary>
        /// <returns>是否移至下一個</returns>
        public bool MoveNext()
        {
            this.index++;
            return (this.index < this.files.Count());
        }

        /// <summary>
        /// IEnumerable
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        /// <summary>
        /// IEnumerator
        /// </summary>
        public void Reset()
        {
            this.index = -1;
        }

        /// <summary>
        /// 建立待處理檔案的資訊
        /// </summary>
        /// <param name="fileName">檔名</param>
        /// <returns>待處理檔案的資訊</returns>
        protected abstract Candidate CreateCandidate(string fileName);
    }
}