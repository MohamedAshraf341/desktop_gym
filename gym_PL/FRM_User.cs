using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace power_gym.gym_PL
{
    public partial class FRM_User : Form
    {
        gym_BL.CLS_User usercls = new gym_BL.CLS_User();
        public FRM_User()
        {
            InitializeComponent();
            //اظهار الداتا في الداتا جريدفيو
            this.dataGriduser.DataSource = usercls.getalluser();

        }

        //زرار غلق الفورم
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        //زرار اضافة المستخدمين
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnameuser.Text == String.Empty || txtpswuser.Text == String.Empty)
                {
                    MessageBox.Show("من فضلك ادخل البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (MessageBox.Show("هل تريد اضافة هذا المستخدم ", " عملية الاضافة ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    usercls.add_user(txtnameuser.Text, txtpswuser.Text, combtype.Text);
                    txtnameuser.Clear();
                    txtpswuser.Clear();
                    txtnameuser.Focus();
                }

            }
            catch { return;  }

            this.dataGriduser.DataSource = usercls.getalluser();
        }

        private void txtnameuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //زرار تعديل المستخدمين
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtnameuser.Text == String.Empty || txtpswuser.Text == String.Empty)
                {
                    MessageBox.Show("من فضلك ادخل البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (MessageBox.Show("هل تريد تعديل بيانات هذا المستخدم ", " عملية تعديل ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    usercls.add_user(txtnameuser.Text, txtpswuser.Text, combtype.Text);
                    txtnameuser.Clear();
                    txtpswuser.Clear();
                    txtnameuser.Focus();
                }
            }
            catch { return; }

            this.dataGriduser.DataSource = usercls.getalluser();
        }

        //زرار حذف المستخدمين
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnameuser.Text == String.Empty || txtpswuser.Text == String.Empty)
            {
                MessageBox.Show("من فضلك ادخل البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show("هل تريد حذف هذا المستخدم ", " عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                usercls.delete_mem(txtnameuser.Text);
                txtnameuser.Clear();
                txtpswuser.Clear();
                txtnameuser.Focus();
            }
            this.dataGriduser.DataSource = usercls.getalluser();

        }
        //عند الضغطدبل كليك ع المستخد
        private void dataGriduser_DoubleClick(object sender, EventArgs e)
        {
            txtnameuser.Text=dataGriduser.CurrentRow.Cells[0].Value.ToString();
            txtpswuser.Text=dataGriduser.CurrentRow.Cells[1].Value.ToString();
            combtype.Text=dataGriduser.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
