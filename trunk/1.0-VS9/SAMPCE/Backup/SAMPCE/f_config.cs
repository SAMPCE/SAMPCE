using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace SAMPCE
{
    public partial class f_config : Form
    {

        Functions func;
        public f_config(Functions pf, int tab)
        {
            func = pf;
            InitializeComponent();
            tc_option.SelectedIndex = tab;
        }

        private void b_font_Click(object sender, EventArgs e)
        {
            if (fpf_main.ShowDialog() == DialogResult.OK)
            {
                SAMPCE.Properties.Settings.Default.font = fpf_main.Font;
            }
        }

        private void b_accept_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            MessageBox.Show("Some changes will not take effect immediately. Please reload SAM[P]CE.");
            this.Close();
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            Properties.Settings.Default[chk.Name.Split('_')[1]] = chk.Checked;
        }

        private void RCheckChanged(object sender, EventArgs e)
        {
            RadioButton chk = (RadioButton)sender;
            if (chk.Checked == true)
            {
                Properties.Settings.Default[chk.Name.Split('_')[1]] = chk.Name.Split('_')[2];
                if (chk.Name.Split('_')[2] == "custom")
                {
                    string obj = "t_" + chk.Name.Split('_')[1];
                    if (chk.Parent.Controls.ContainsKey(obj)) Properties.Settings.Default[chk.Name.Split('_')[1] + "custom"] = this.Controls[obj].Text;
                }
            }
        }

        private void b_aflbrws_Click(object sender, EventArgs e)
        {
            if (fbd_main.ShowDialog() == DialogResult.OK)
            {
                if (rb_afl_custom.Checked) Properties.Settings.Default["aflcustom"] = fbd_main.SelectedPath;
                t_afl.Text = fbd_main.SelectedPath;
            }
        }

        private void f_config_Load(object sender, EventArgs e)
        {
            foreach (PluginManager.IPlugin plugin in func.plugins) cbx_plugins.Items.Add(plugin.Name + " by " + plugin.Author);
            l_curver.Text = "Current running version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            RBLoad("afl", Properties.Settings.Default["afl"].ToString(), "tp_compiler");
            RBLoad("fd", Properties.Settings.Default["fd"].ToString(), "tp_gen");
            t_cpath.Text = Properties.Settings.Default.cpath;
            UAC.SetShieldIcon(b_associate);
        }

        private void RBLoad(string type, string val, string tabpage)
        {
            TabPage tp_rbs = tc_option.TabPages[tabpage];
            if (tp_rbs.Controls.ContainsKey("gb_" + type))
            {
                GroupBox gb = (GroupBox)tp_rbs.Controls["gb_" + type];
                if (gb.Controls.ContainsKey("rb_" + type + "_" + val))
                {
                    RadioButton rb = (RadioButton)gb.Controls["rb_" + type + "_" + val];
                    rb.Checked = true;
                    if (val == "custom") gb.Controls["rb_" + type + "_" + val].Text = Properties.Settings.Default[val + "custom"].ToString();
                }
            }
        }

        private void b_cpathbrws_Click(object sender, EventArgs e)
        {
            if (opf_main.ShowDialog() == DialogResult.OK)
            {
                if (FileVersionInfo.GetVersionInfo(opf_main.FileName).ProductName != "libpawnc")
                {
                    MessageBox.Show("This is not a valid compiler. Are you trying to trick me?");
                    return;
                }
                if (opf_main.FileName.Remove(opf_main.FileName.IndexOf(opf_main.SafeFileName)).TrimEnd('\\') == Directory.GetCurrentDirectory()) t_cpath.Text = "pawncc.exe";
                else t_cpath.Text = opf_main.FileName;
                Properties.Settings.Default.cpath = t_cpath.Text;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("RTFM!! Well, coming soon...");
        }

        private void t_cargs_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.cargs = t_cargs.Text;
        }

        private void b_loadplug_Click(object sender, EventArgs e)
        {
            if (cbx_plugins.SelectedIndex > 0)
            {
                pnl_plug.Controls.Clear();
                pnl_plug.Controls.Add(func.plugins[cbx_plugins.SelectedIndex - 1].LoadPluginSettings());
                pnl_plug.Controls[0].Dock = DockStyle.Fill;
            }
        }

        private void b_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_upd_Click(object sender, EventArgs e)
        {
            string result = null;
            WebResponse response = null;
            StreamReader reader = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.syedabdullah.net/newPAWN/update.php");
                request.Method = "GET";
                response = request.GetResponse();
                reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                result = reader.ReadToEnd();
            }
            catch (Exception) { l_status.Text = "Error while contacting server!"; return; }
            finally
            {
                if (reader != null) reader.Dispose();
                if (response != null) response.Close();
            }

            string[] sa = { "[STARTCL]" };
            l_status.Text = "The latest version is: " + result.Split(sa, StringSplitOptions.None)[0];
            if (result.StartsWith(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()))
            {
                l_verconclusion.ForeColor = Color.Green;
                l_verconclusion.Text = "No update required!";
            }
            else
            {
                l_verconclusion.ForeColor = Color.Red;
                l_verconclusion.Text = "Update required. See changelog.";
            }
            t_changelog.Text = result.Split(sa, StringSplitOptions.None)[1].Replace("\\r\\n", "\r\n") ;
        }

        private void b_associate_Click(object sender, EventArgs e)
        {
            if (!File.Exists(@Environment.CurrentDirectory + "/file.ico"))
            {
                MessageBox.Show("Please put the soap back to its holder. I mean, please don't remove that file.ico file");
                return;
            }

            if (UAC.IsElevated())
            {
                Associations.AF_FileAssociator afa = new Associations.AF_FileAssociator(".pwn");
                afa.Create("SAMPCE", "PAWN Source Code", new Associations.ProgramIcon(@Environment.CurrentDirectory + "/file.ico"), new Associations.ExecApplication(@Application.ExecutablePath), new Associations.OpenWithList(new string[] { "SAMPCE" }));
            }
            else
            {
                MessageBox.Show("SAM[P]CE needs administrator rights to set file associations.");
                UAC.RunElevated();
            }
        }
    }

    public class UAC
    {
        [DllImport("user32")]
        public static extern UInt32 SendMessage
            (IntPtr hWnd, UInt32 msg, UInt32 wParam, UInt32 lParam);

        internal const int SHIELD = (0x1600 + 0x000C);

        static internal bool IsElevated()
        {
            WindowsPrincipal p = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static internal void SetShieldIcon(Button b)
        {
            if (IsElevated()) return;
            b.FlatStyle = FlatStyle.System;
            SendMessage(b.Handle, SHIELD, 0, 0xFFFFFFFF);
        }

        internal static void RunElevated()
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.WorkingDirectory = Environment.CurrentDirectory;
            psi.FileName = Application.ExecutablePath;
            psi.Verb = "runas";
            try { Process p = Process.Start(psi); }
            catch (System.ComponentModel.Win32Exception) // cancel
            {
                return;
            }

            Application.Exit();
        }
    }
}
