using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using PluginManager;
using System.Windows.Forms;
using System.IO;

namespace ColourPicker
{
    public partial class GUI : Form
    {
        IPluginFunctions IDEFunctions;
        string colourpicked = "none :P";

        public GUI(IPluginFunctions functions)
        {
            IDEFunctions = functions;
            InitializeComponent();
        }

        private void b_colour_Click(object sender, EventArgs e)
        {
            if (cd_main.ShowDialog() == DialogResult.OK)
            {
                pb_preview.BackColor = cd_main.Color;
            }
        }

        private void t_ref_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ') e.Handled = true;
        }

        public static string ToRGBA(string ARGB)
        {
            char[] arr = ARGB.ToCharArray();
            string str = null;
            for (int i = 2; i < 8; i++) str = str + arr[i];
            str = str + arr[0] + arr[1];
            return str;
        }

        private void b_paste_Click(object sender, EventArgs e)
        {
            colourpicked = "0x" + ToRGBA(string.Format("{0:X8}", pb_preview.BackColor.ToArgb()));
            IDEFunctions.InsertText(colourpicked);
        }

        private void b_tng_Click(object sender, EventArgs e)
        {
            colourpicked = "0x" + string.Format("{0:X8}", pb_preview.BackColor.ToArgb());
            if (t_ref.Text == "") return;
            else IDEFunctions.InsertText("#define " + t_ref.Text + " " + colourpicked);
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            StreamReader sr;
            try { sr = new StreamReader("colourpick.cfg"); }
            catch (IOException) { return; }
            string conf = sr.ReadToEnd();
            this.BackColor = Color.FromArgb(Int32.Parse(conf.Split('=')[1]));
        }

        private void trb_alpha_Scroll(object sender, EventArgs e)
        {
            pb_preview.BackColor = System.Drawing.Color.FromArgb(trb_alpha.Value, pb_preview.BackColor);
        }
    }
}
