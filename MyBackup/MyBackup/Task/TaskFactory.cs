namespace MyBackup
{
    /// <summary>
    /// 任務工廠
    /// </summary>
    public static class TaskFactory
    {
        /// <summary>
        /// 建立
        /// </summary>
        /// <param name="task">任務類型</param>
        /// <returns>任務</returns>
        public static ITask Create(string task)
        {
            switch (task)
            {
                case "simple":
                    return new SimpleTask();

                case "scheduled":
                    return new ScheduledTask();

                default:
                    return null;
            }
        }
    }
}