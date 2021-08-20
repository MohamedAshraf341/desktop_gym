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
    public partial class FRM_Login : Form
    {
        gym_BL.CLS_User log = new gym_BL.CLS_User();
        public FRM_Login()
        {
            InitializeComponent();
            txtname.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = log.login(txtname.Text, txtpsw.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][2].ToString() == "admin")
                {
                    FRM_Main.getmainform.استعادةنسخهمحفوظهToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.انشاءنسخةاحتياطيهToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.المستخدمونToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.الأعضاءToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.الاشتراتToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.اغلاقToolStripMenuItem.Enabled = true;

                    this.Close();
                }
                else if (dt.Rows[0][2].ToString() == "normal user")
                {
                    FRM_Main.getmainform.استعادةنسخهمحفوظهToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.انشاءنسخةاحتياطيهToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.المستخدمونToolStripMenuItem.Visible = false;
                    FRM_Main.getmainform.الأعضاءToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.الاشتراتToolStripMenuItem.Enabled = true;
                    FRM_Main.getmainform.اغلاقToolStripMenuItem.Enabled = true;

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show(" login failed !");

            }
        }
    }
}
