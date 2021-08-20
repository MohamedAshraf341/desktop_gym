using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace power_gym.gym_DAL
{
    class dal
    {
                SqlConnection sqlconect ;
        //this is constructor inisilaize connection object

        public dal()
        {
            sqlconect= new SqlConnection(@"server=DESKTOP-H4F6IAP\SQLEXPRESS ; database=gym ; integrated security=true");
       
        }

        //method to open connection
        public void open()
        {
            if (sqlconect.State != ConnectionState.Open)
            {
                sqlconect.Open();
            }
        }

        //method to close connection
        public void close()
        {
            if (sqlconect.State == ConnectionState.Open)
            {
                sqlconect.Close();
            }
        }

        //method to read data from database 
        public DataTable selectdata(string store_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = store_procedure;
            sqlcmd.Connection = sqlconect;
            
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        //method to insert, update and delete data 
        public void excutedcomand(string store_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = store_procedure;
            sqlcmd.Connection = sqlconect;

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();

        }
    }
}
