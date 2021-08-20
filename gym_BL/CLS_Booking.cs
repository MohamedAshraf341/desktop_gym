using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace power_gym.gym_BL
{
    class CLS_Booking
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
        //دالةاظهار محموع الاشتراكات
        public DataTable sumbook()
        {
            gym_DAL.dal dal = new gym_DAL.dal();
            DataTable dt = new DataTable();
            dt = dal.selectdata("subooking", null);
            dal.close();
            return dt;
        }
        //دالة ادخال بييانات الاعضاء
        public void addbook(int d)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = d;

            DAL.excutedcomand("insert_booking", param);
            DAL.close();
        }
        //دالة تعديل بييانات الاعضاء
        public void editbook(int d)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = d;

            DAL.excutedcomand("update_booking", param);
            DAL.close();
        }
        //دالة الحذف
        public void deletebook(int d)
        {
            gym_DAL.dal DAL = new gym_DAL.dal();
            DAL.open();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idbooking", SqlDbType.Int);
            param[0].Value = d;

            DAL.excutedcomand("delete_booking", param);
            DAL.close();
        }
    }
}
