using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_Functionality
{
    public class dbClasses
    {
        public static void QuerySelect(string connStr, string table, DataGridView dgv1)
        {
            string sql = $"SELECT * FROM {table}";
            SqlConnection connection = new SqlConnection(connStr);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, $"{table}");
            connection.Close();
            dgv1.DataSource = ds;
            dgv1.DataMember = $"{table}";
        }

        public static void QueryInser(string connStr, string command)
        {
            using (var conn = new SqlConnection(connStr))
            using (var Command = new SqlCommand(command))
            {
                Command.Connection = conn;
                conn.Open();
                Command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static int checkIsExistEntry(string table, string connStr, string idInTable, string checkId)
        {
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT COUNT(*) FROM {table} WHERE {idInTable}='{checkId}'", connStr);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "0")
            {
                return 0;
            }
            else
                return 1;
        }

        public static int getIdByCellValue(string id, string table, string tableValue, string checkValue, string connStr)
        {
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT {id} FROM {table} WHERE {tableValue}='{checkValue}'", connStr);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count <= 0)
                return 0;
            int ID = Int32.Parse(dt.Rows[0][0].ToString());
            return ID;
        }

        public static string getValueById(string value, string table, string id, string checkid, string connStr)
        {
            SqlDataAdapter sda = new SqlDataAdapter($"SELECT {value} FROM {table} WHERE {id}='{checkid}'", connStr);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count <= 0)
                return "0";
            string resultValue =dt.Rows[0][0].ToString();
            return resultValue;
        }
    }
}
