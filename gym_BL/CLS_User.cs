using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace power_gym.gym_BL
{
    class CLS_User
    {
        public DataTable login(string username, string psw)
        {
            gym_DAL.dal dal = new gym_DAL.dal();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@username", SqlDbType.VarChar, 50);
            param[0].Value = username;

            param[1] = new SqlParameter("@psw", SqlDbType.VarChar, 50);
            param[1].Value = psw;

            dal.open();
            DataTable dt = new DataTable();
            dt = dal.selectdata("user_login", param);
            dal.close();
            return dt;
        }

        ////دالة عرض بيانات المستخدمين في الدتا جريد فيو
        public DataTable getalluser()
        {
            gym_DAL.dal dal = new gym_DAL.dal();
            DataTable dt = new DataTable();
            dt = dal.selectdata("select_user", null);
            dal.close();
            return dt;
        }

        //دالة ادخال بييانات المستخدمين
        public void add_user(string name,string psw,string type)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@psw", SqlDbType.VarChar, 50);
            param[1].Value = psw;

            param[2] = new SqlParameter("@usertype", SqlDbType.VarChar, 50);
            param[2].Value = type;


            DAL.excutedcomand("add_user", param);
            DAL.close();
        }
        //دالةتعديل بيانات المستخدم
        public void edituseer(string username, string psw, string type)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@username", SqlDbType.VarChar, 50);
            param[0].Value = username;

            param[1] = new SqlParameter("@psw", SqlDbType.VarChar, 50);
            param[1].Value = psw;

            param[2] = new SqlParameter("@type", SqlDbType.VarChar, 50);
            param[2].Value = type;

            DAL.excutedcomand("update_user", param);
            DAL.close();
        }
        //دالة الحذف
        public void delete_mem(string username)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@username", SqlDbType.VarChar,50);
            param[0].Value = username;

            DAL.excutedcomand("delete_user", param);
            DAL.close();
        }
    }
}
