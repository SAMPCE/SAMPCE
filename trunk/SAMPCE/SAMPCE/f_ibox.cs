using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAMPCE
{
    public partial class f_ibox : Form
    {
        bool num;
        string res;
        public f_ibox(string title, string msg, bool numOnly)
        {
            InitializeComponent();
            this.CenterToParent();
            this.Text = title;
            l_msg.Text = msg;
            num = numOnly;
        }

        public string Result()
        {
            return res;
        }

        private void b_ok_Click(object sender, EventArgs e)
        {
            res = t_res.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void b_cncl_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void t_res_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }
    }
}
