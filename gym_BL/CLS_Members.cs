using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using power_gym.gym_PL;

namespace power_gym.gym_BL
{
    class CLS_Members
    {
        //دالة تنفذ اظهار الشتراكات في الكومبوبوكس
        public DataTable getbook()
        {
            gym_DAL.dal dal = new gym_DAL.dal();
            DataTable dt = new DataTable();
            dt = dal.selectdata("get_booking", null);
            dal.close();
            return dt;
        }

        //دالة ادخال بييانات الاعضاء
        public void add(string name_member,string adress_member,string phone,DateTime start,DateTime end,int id_booking)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@name", SqlDbType.VarChar,50);
            param[0].Value=name_member;

            param[1] = new SqlParameter("@adress", SqlDbType.VarChar,50);
            param[1].Value=adress_member;

            param[2] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[2].Value=phone;

            param[3] = new SqlParameter("@bookstart", SqlDbType.DateTime);
            param[3].Value=start;

            param[4] = new SqlParameter("@bookend", SqlDbType.DateTime);
            param[4].Value=end;

            param[5] = new SqlParameter("@idbooking", SqlDbType.Int);
            param[5].Value=id_booking;

            DAL.excutedcomand("insert_member", param);
            DAL.close();
        }
        //دالة تعديل بييانات الاعضاء
        public void editmember(string name_member, string adress_member, string phone, DateTime start, DateTime end, int id_booking, int id)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name_member;

            param[1] = new SqlParameter("@adress", SqlDbType.VarChar, 50);
            param[1].Value = adress_member;

            param[2] = new SqlParameter("@phone", SqlDbType.VarChar, 50);
            param[2].Value = phone;

            param[3] = new SqlParameter("@bookstart", SqlDbType.DateTime);
            param[3].Value = start;

            param[4] = new SqlParameter("@bookend", SqlDbType.DateTime);
            param[4].Value = end;

            param[5] = new SqlParameter("@idbook", SqlDbType.Int);
            param[5].Value = id_booking;

            param[6] = new SqlParameter("@id", SqlDbType.Int);
            param[6].Value = id;

            DAL.excutedcomand("update_member", param);
            DAL.close();
        }
        ////دالة عرض البيانات في الدتا جريد فيو
        public DataTable getallmember()
        {
            gym_DAL.dal dal = new gym_DAL.dal();
            DataTable dt = new DataTable();
            dt = dal.selectdata("select_member", null);
            dal.close();
            return dt;
        }
        //دالة البحث
        public DataTable serchname(string name)
        {
            gym_DAL.dal d = new gym_DAL.dal();
            DataTable dt = new DataTable();
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            p[0].Value=name;
            dt = d.selectdata("search_member", p);
            d.close();
            return dt;
        }

        //دالة الحذف
        public void delete_mem(int d)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = d;

            DAL.excutedcomand("d_member", param);
            DAL.close();
        }



    }
}
