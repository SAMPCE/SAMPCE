using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ColourPicker
{
    public partial class Config : UserControl
    {
        public Config()
        {
            InitializeComponent();
        }

        private void b_bgcolour_Click(object sender, EventArgs e)
        {
            if (cd_main.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter("colourpick.cfg");
                sw.Write("background=" + cd_main.Color.ToArgb());
                sw.Flush();
                sw.Close();
            }
        }
    }
}
