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
    public partial class FRM_Main : Form
    {
        private static FRM_Main frm;


        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_Main getmainform
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_Main();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }

        public FRM_Main()
        {
            InitializeComponent();
            gym_PL.CON_Cover cover = new CON_Cover();
            ShowControl(cover);

            if (frm == null)
                frm = this;
            this.استعادةنسخهمحفوظهToolStripMenuItem.Enabled=false;
            this.انشاءنسخةاحتياطيهToolStripMenuItem.Enabled = false;
            this.المستخدمونToolStripMenuItem.Enabled = false;
            this.الأعضاءToolStripMenuItem.Enabled = false;
            this.الاشتراتToolStripMenuItem.Enabled = false;
            this.اغلاقToolStripMenuItem.Enabled = false;

        }
        public void ShowControl(Control con)
        {
            con.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            con.BringToFront();
            con.Focus();
            panel2.Controls.Add(con);

        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void الاشتراتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_booking book = new FRM_booking();
            book.ShowDialog();
        }

        private void الأعضاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gym_PL.CON_Member us = new CON_Member();
            ShowControl(us);
        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_Login frm = new FRM_Login();
            frm.ShowDialog();
        }

        private void اضافةمستخدمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gym_PL.CON_Cover cover = new CON_Cover();
            ShowControl(cover);
            this.استعادةنسخهمحفوظهToolStripMenuItem.Enabled = false;
            this.انشاءنسخةاحتياطيهToolStripMenuItem.Enabled = false;
            this.المستخدمونToolStripMenuItem.Enabled = false;
            this.الأعضاءToolStripMenuItem.Enabled = false;
            this.الاشتراتToolStripMenuItem.Enabled = false;
            this.اغلاقToolStripMenuItem.Enabled = false;
        }

        private void المستخدمونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_User frm = new FRM_User();
            frm.ShowDialog();

        }

        private void اغلاقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CON_Cover cov = new CON_Cover();
            ShowControl(cov);
        }
    }
}
