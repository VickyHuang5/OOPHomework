using System;

namespace MyBackup
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            ConfigManager configManager = new ConfigManager();
            configManager.ProcessConfigs();

            Console.WriteLine("Config:");
            for (int i = 0; i < configManager.Count(); i++)
            {
                Config config = configManager[i];
                Console.WriteLine(configManager[i].Ext);
            }

            ScheduleManager scheduleManager = new ScheduleManager();
            scheduleManager.ProcessSchedules();

            Console.WriteLine("Schedule:");
            for (int i = 0; i < scheduleManager.Count(); i++)
            {
                Schedule config = scheduleManager[i];
                Console.WriteLine(scheduleManager[i].Ext);
            }

            Console.WriteLine("任意鍵離開.");
            Console.ReadKey();
        }
    }
}