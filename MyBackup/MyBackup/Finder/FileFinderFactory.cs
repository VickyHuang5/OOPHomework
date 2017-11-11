namespace MyBackup
{
    /// <summary>
    /// 檔案搜尋工廠
    /// </summary>
    public static class FileFinderFactory
    {
        /// <summary>
        /// 建立
        /// </summary>
        /// <param name="finder">搜尋類型</param>
        /// <param name="config">設定</param>
        /// <returns>LocalFileFinder</returns>
        public static IFileFinder Create(string finder, Config config)
        {
            if (finder == "file")
            {
                return new LocalFileFinder(config);
            }   
            else
            {
                return null;
            }
        }
    }
}