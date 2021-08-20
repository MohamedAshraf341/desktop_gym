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
    public partial class FRM_booking : Form
    {
        gym_BL.CLS_Members mem = new gym_BL.CLS_Members();
        gym_BL.CLS_Booking boo = new gym_BL.CLS_Booking();
        public FRM_booking()
        {
            InitializeComponent();
            //this.datasum.DataSource = boo.sumbook();
            DataTable dt = boo.sumbook();
            txt_n_m.Text = dt.Rows[0][1].ToString();
            txt_s_b.Text = dt.Rows[0][0].ToString();
           
            txtprice.Clear();
            //اظهار الاشتراك في الكومبو بوكس
            comboprice.DataSource = mem.getbook();
            comboprice.DisplayMember = "id_booking";
            comboprice.ValueMember = "id_booking";
            
            //اظهار مجموع الاشتراكات
            
           // this.txtsum.Text = boo.sumbook().ToString(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void combobooking_Click(object sender, EventArgs e)
        {
            //txtprice.Text = comboprice.SelectedValue.ToString();
        }

        private void comboprice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtprice.Text = comboprice.SelectedValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtprice.Text.ToString() == String.Empty)
                {
                    MessageBox.Show("من فضلك اكتب الاشتراك يابرنس", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (MessageBox.Show("هل تريد اضافة هذا الاشتراك ", " عملية الاضافة ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    boo.addbook(Convert.ToInt32(txtprice.Text));
                    txtprice.Clear();
                }
            }
            catch { return; }
            //اظهار الاشتراك في الكومبو بوكس
            comboprice.DataSource = mem.getbook();
            comboprice.DisplayMember = "id_booking";
            comboprice.ValueMember = "id_booking";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtprice.Text.ToString() == String.Empty)
                {
                    MessageBox.Show("من فضلك اكتب الاشتراك يابرنس", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (MessageBox.Show("هل تريد تعديل هذا الاشتراك ", " عملية تعديل ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    boo.editbook(Convert.ToInt32(txtprice.Text));
                    txtprice.Clear();
                }
            }
            catch { return; }
            //اظهار الاشتراك في الكومبو بوكس
            comboprice.DataSource = mem.getbook();
            comboprice.DisplayMember = "id_booking";
            comboprice.ValueMember = "id_booking";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtprice.Text.ToString() == String.Empty)
            {
                MessageBox.Show("من فضلك اكتب الاشتراك المراد حذفه يابرنس", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (MessageBox.Show("هل تريد حذف هذا الاشتراك ", " عملية حذف ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                boo.deletebook(Convert.ToInt32(txtprice.Text));
                txtprice.Clear();
            }
            //اظهار الاشتراك في الكومبو بوكس
            comboprice.DataSource = mem.getbook();
            comboprice.DisplayMember = "id_booking";
            comboprice.ValueMember = "id_booking";
        }

        private void datasum_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboprice_SelectedValueChanged(object sender, EventArgs e)
        {
            txtprice.Text = comboprice.SelectedValue.ToString();

        }
    }
}
