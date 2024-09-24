using DATA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Data
{
   public class Gbackup
   {
        public DataTable GetNameDatabase()
        {
            using (SqlConnection con = new SqlConnection(Connexion.Cn.ConnectionString))
            {
                string SQL = @"select database_id, [name] database_name  from master.sys.databases WHERE state <> 6 AND database_id > 4 AND HAS_DBACCESS([name]) = 1 ";
                con.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(SQL, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public void VerifyExisting()
        {
            using (SqlConnection conn = new SqlConnection(Connexion.Cn.ConnectionString))
            {
                string SQL = (@"SELECT 1 FROM sys.procedures  WHERE Name = 'sp_BackupDatabases'");
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    var isExist = cmd.ExecuteScalar() == null ? 0 : 1;
                    conn.Close();
                    if (isExist == 0)
                    {
                        string data = System.IO.File.ReadAllText("procBackup.sql");
                        conn.Open();
                        using (SqlCommand cmd1 = conn.CreateCommand())
                        {
                            cmd1.CommandText = data;
                            cmd1.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
            }

        }
    }
}


