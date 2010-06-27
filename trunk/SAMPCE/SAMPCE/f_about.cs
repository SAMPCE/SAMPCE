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
    public partial class f_about : Form
    {
        public f_about()
        {
            InitializeComponent();
        }

        private void ll_ok_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void tm_scroller_Tick(object sender, EventArgs e)
        {
            char ch = l_credits.Text[0];
            l_credits.Text = l_credits.Text.TrimStart(ch);
            l_credits.Text += ch;
        }
    }
}
