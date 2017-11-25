using MyBackupCandidate;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace MyBackup
{
    /// <summary>
    /// 抽象處理器
    /// </summary>
    public abstract class AbstractDBHandler : IDBHandler
    {
        /// <summary>
        /// 寫入資料庫
        /// </summary>
        /// <param name="sql">SQL指令</param>
        public virtual void InsertDB(string sql)
        {
            string connectionString = string.Empty;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.ExecuteNonQuery();
            }

            Console.WriteLine("InsertDB done.");
        }

        /// <summary>
        /// 執行
        /// </summary>
        /// <param name="candidate">待處理檔案資訊</param>
        /// <param name="target">處理目標</param>
        /// <returns>byte陣列</returns>
        public virtual byte[] Perform(Candidate candidate, byte[] target)
        {
            return target;
        }
    }
}