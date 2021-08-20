using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.DateTime manufacturingDate;
//using System.DateTime expirationDate;

namespace power_gym.gym_PL
{
    public partial class CON_Member : UserControl
    {
        gym_BL.CLS_Members mem = new gym_BL.CLS_Members();
        int id=new int();
        public CON_Member()
        {
            InitializeComponent();
            DateTime d =enddate.Value;
            enddate.Text = d.AddDays(30).ToString();
            //اظهار الداتا في الداتا جريد فيو
            this.dataGridView1.DataSource = mem.getallmember();
            dataGridView1.Columns[0].Visible = false;
            //اظهار الاشتراك في الكومبو بوكس
            combobook.DataSource = mem.getbook();
            combobook.DisplayMember = "id_booking";
            combobook.ValueMember = "id_booking";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtaddress.Clear();
            txtphone.Clear();
            txtserch.Clear();
        }

        //زرار عملية الاضافه
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtname.Text.ToString() == String.Empty )
            {
                MessageBox.Show("من فضلك اكتب الاسم يابرنس", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show("هل تريد اضافة هذا المشترك ", " عملية الاضافة ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                mem.add(txtname.Text, txtaddress.Text, txtphone.Text, Convert.ToDateTime(startdate.Text), Convert.ToDateTime(enddate.Text), Convert.ToInt32(combobook.SelectedValue));
               // MessageBox.Show("تمت عملية الاضافة بنجاح ", " عملية اضافة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtname.Clear();
                txtphone.Clear();
                txtaddress.Clear();
                
            }

            this.dataGridView1.DataSource = mem.getallmember();         
        }

        //زرار عملية التعديل
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtname.Text.ToString() == String.Empty)
            {
                MessageBox.Show("من فضلك ادخل البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show("هل تريد تعديل بيانات هذا المشترك ", " عملية التعديل ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                mem.editmember(txtname.Text, txtaddress.Text, txtphone.Text, Convert.ToDateTime(startdate.Text), Convert.ToDateTime(enddate.Text), Convert.ToInt32(combobook.SelectedValue), id);
                txtname.Clear();
                txtphone.Clear();
                txtaddress.Clear();
            }

            this.dataGridView1.DataSource = mem.getallmember();
        }

        //زرار عملية البحث
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = mem.serchname(Convert.ToString(txtserch.Text));
            this.dataGridView1.DataSource = dt;
        }

        //زرار عملية الحذف
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtname.Text.ToString() == String.Empty)
            {
                MessageBox.Show("من فضلك ادخل البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }   
            else if (MessageBox.Show("هل تريد حذف المشترك ", " عملية الحذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                mem.delete_mem(id);
                txtname.Clear();
                txtphone.Clear();
                txtaddress.Clear();
            }
            this.dataGridView1.DataSource = mem.getallmember();
        }

        //عندالضغط دبل كليك ع اسم من المشتركين
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                this.txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                this.txtaddress.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.txtphone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                this.startdate.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                this.enddate.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                this.combobook.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch { return; }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
