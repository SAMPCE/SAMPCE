namespace SAMPCE
{
    partial class f_config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_config));
            this.tc_option = new System.Windows.Forms.TabControl();
            this.tp_gen = new System.Windows.Forms.TabPage();
            this.gb_fd = new System.Windows.Forms.GroupBox();
            this.rb_fd_backward = new System.Windows.Forms.RadioButton();
            this.rb_fd_pawno = new System.Windows.Forms.RadioButton();
            this.rb_fd_default = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tp_viz = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_font = new System.Windows.Forms.Button();
            this.tp_compiler = new System.Windows.Forms.TabPage();
            this.gb_afl = new System.Windows.Forms.GroupBox();
            this.b_aflbrws = new System.Windows.Forms.Button();
            this.t_afl = new System.Windows.Forms.TextBox();
            this.rb_afl_custom = new System.Windows.Forms.RadioButton();
            this.rb_afl_pwn = new System.Windows.Forms.RadioButton();
            this.rb_afl_default = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.t_cargs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_cpathbrws = new System.Windows.Forms.Button();
            this.t_cpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tp_plugins = new System.Windows.Forms.TabPage();
            this.pnl_plug = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.b_loadplug = new System.Windows.Forms.Button();
            this.cbx_plugins = new System.Windows.Forms.ComboBox();
            this.tp_update = new System.Windows.Forms.TabPage();
            this.l_verconclusion = new System.Windows.Forms.Label();
            this.l_curver = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.t_changelog = new System.Windows.Forms.TextBox();
            this.l_status = new System.Windows.Forms.Label();
            this.b_upd = new System.Windows.Forms.Button();
            this.b_accept = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.fpf_main = new System.Windows.Forms.FontDialog();
            this.tt_durai = new System.Windows.Forms.ToolTip(this.components);
            this.opf_main = new System.Windows.Forms.OpenFileDialog();
            this.fbd_main = new System.Windows.Forms.FolderBrowserDialog();
            this.b_associate = new System.Windows.Forms.Button();
            this.tc_option.SuspendLayout();
            this.tp_gen.SuspendLayout();
            this.gb_fd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tp_viz.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tp_compiler.SuspendLayout();
            this.gb_afl.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tp_plugins.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tp_update.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_option
            // 
            this.tc_option.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_option.Controls.Add(this.tp_gen);
            this.tc_option.Controls.Add(this.tp_viz);
            this.tc_option.Controls.Add(this.tp_compiler);
            this.tc_option.Controls.Add(this.tp_plugins);
            this.tc_option.Controls.Add(this.tp_update);
            this.tc_option.Location = new System.Drawing.Point(12, 12);
            this.tc_option.Name = "tc_option";
            this.tc_option.SelectedIndex = 0;
            this.tc_option.Size = new System.Drawing.Size(408, 315);
            this.tc_option.TabIndex = 0;
            // 
            // tp_gen
            // 
            this.tp_gen.Controls.Add(this.gb_fd);
            this.tp_gen.Controls.Add(this.groupBox3);
            this.tp_gen.Controls.Add(this.label1);
            this.tp_gen.Controls.Add(this.groupBox1);
            this.tp_gen.Location = new System.Drawing.Point(4, 22);
            this.tp_gen.Name = "tp_gen";
            this.tp_gen.Padding = new System.Windows.Forms.Padding(3);
            this.tp_gen.Size = new System.Drawing.Size(400, 289);
            this.tp_gen.TabIndex = 0;
            this.tp_gen.Text = "General";
            this.tp_gen.UseVisualStyleBackColor = true;
            // 
            // gb_fd
            // 
            this.gb_fd.Controls.Add(this.rb_fd_backward);
            this.gb_fd.Controls.Add(this.rb_fd_pawno);
            this.gb_fd.Controls.Add(this.rb_fd_default);
            this.gb_fd.Location = new System.Drawing.Point(6, 97);
            this.gb_fd.Name = "gb_fd";
            this.gb_fd.Size = new System.Drawing.Size(388, 100);
            this.gb_fd.TabIndex = 3;
            this.gb_fd.TabStop = false;
            this.gb_fd.Text = "Function detection";
            // 
            // rb_fd_backward
            // 
            this.rb_fd_backward.AutoSize = true;
            this.rb_fd_backward.Location = new System.Drawing.Point(6, 65);
            this.rb_fd_backward.Name = "rb_fd_backward";
            this.rb_fd_backward.Size = new System.Drawing.Size(195, 17);
            this.rb_fd_backward.TabIndex = 2;
            this.rb_fd_backward.TabStop = true;
            this.rb_fd_backward.Text = "Use backward compatible detection";
            this.rb_fd_backward.UseVisualStyleBackColor = true;
            this.rb_fd_backward.CheckedChanged += new System.EventHandler(this.RCheckChanged);
            // 
            // rb_fd_pawno
            // 
            this.rb_fd_pawno.AutoSize = true;
            this.rb_fd_pawno.Location = new System.Drawing.Point(6, 42);
            this.rb_fd_pawno.Name = "rb_fd_pawno";
            this.rb_fd_pawno.Size = new System.Drawing.Size(202, 17);
            this.rb_fd_pawno.TabIndex = 1;
            this.rb_fd_pawno.TabStop = true;
            this.rb_fd_pawno.Text = "Use PAWNO-style detection [natives]";
            this.rb_fd_pawno.UseVisualStyleBackColor = true;
            this.rb_fd_pawno.CheckedChanged += new System.EventHandler(this.RCheckChanged);
            // 
            // rb_fd_default
            // 
            this.rb_fd_default.AutoSize = true;
            this.rb_fd_default.Location = new System.Drawing.Point(6, 19);
            this.rb_fd_default.Name = "rb_fd_default";
            this.rb_fd_default.Size = new System.Drawing.Size(203, 17);
            this.rb_fd_default.TabIndex = 0;
            this.rb_fd_default.TabStop = true;
            this.rb_fd_default.Text = "Default (commented lines are ignored)";
            this.rb_fd_default.UseVisualStyleBackColor = true;
            this.rb_fd_default.CheckedChanged += new System.EventHandler(this.RCheckChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(6, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 67);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code Editor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "[E] denotes EXPERIMENTAL, use at risk";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_associate);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // tp_viz
            // 
            this.tp_viz.Controls.Add(this.groupBox2);
            this.tp_viz.Location = new System.Drawing.Point(4, 22);
            this.tp_viz.Name = "tp_viz";
            this.tp_viz.Padding = new System.Windows.Forms.Padding(3);
            this.tp_viz.Size = new System.Drawing.Size(400, 289);
            this.tp_viz.TabIndex = 1;
            this.tp_viz.Text = "Visual/Text";
            this.tp_viz.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_font);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 45);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Font";
            // 
            // b_font
            // 
            this.b_font.Location = new System.Drawing.Point(6, 16);
            this.b_font.Name = "b_font";
            this.b_font.Size = new System.Drawing.Size(376, 23);
            this.b_font.TabIndex = 0;
            this.b_font.Text = "Click here to change the Code Editor\'s Font";
            this.b_font.UseVisualStyleBackColor = true;
            this.b_font.Click += new System.EventHandler(this.b_font_Click);
            // 
            // tp_compiler
            // 
            this.tp_compiler.Controls.Add(this.gb_afl);
            this.tp_compiler.Controls.Add(this.groupBox4);
            this.tp_compiler.Location = new System.Drawing.Point(4, 22);
            this.tp_compiler.Name = "tp_compiler";
            this.tp_compiler.Padding = new System.Windows.Forms.Padding(3);
            this.tp_compiler.Size = new System.Drawing.Size(400, 289);
            this.tp_compiler.TabIndex = 2;
            this.tp_compiler.Text = "Compiler";
            this.tp_compiler.UseVisualStyleBackColor = true;
            // 
            // gb_afl
            // 
            this.gb_afl.Controls.Add(this.b_aflbrws);
            this.gb_afl.Controls.Add(this.t_afl);
            this.gb_afl.Controls.Add(this.rb_afl_custom);
            this.gb_afl.Controls.Add(this.rb_afl_pwn);
            this.gb_afl.Controls.Add(this.rb_afl_default);
            this.gb_afl.Location = new System.Drawing.Point(9, 86);
            this.gb_afl.Name = "gb_afl";
            this.gb_afl.Size = new System.Drawing.Size(379, 71);
            this.gb_afl.TabIndex = 2;
            this.gb_afl.TabStop = false;
            this.gb_afl.Text = "Place .amx file in...";
            // 
            // b_aflbrws
            // 
            this.b_aflbrws.Location = new System.Drawing.Point(296, 39);
            this.b_aflbrws.Name = "b_aflbrws";
            this.b_aflbrws.Size = new System.Drawing.Size(75, 23);
            this.b_aflbrws.TabIndex = 6;
            this.b_aflbrws.Text = "Browse...";
            this.b_aflbrws.UseVisualStyleBackColor = true;
            this.b_aflbrws.Click += new System.EventHandler(this.b_aflbrws_Click);
            // 
            // t_afl
            // 
            this.t_afl.Location = new System.Drawing.Point(78, 41);
            this.t_afl.Name = "t_afl";
            this.t_afl.ReadOnly = true;
            this.t_afl.Size = new System.Drawing.Size(212, 20);
            this.t_afl.TabIndex = 6;
            // 
            // rb_afl_custom
            // 
            this.rb_afl_custom.AutoSize = true;
            this.rb_afl_custom.Location = new System.Drawing.Point(9, 42);
            this.rb_afl_custom.Name = "rb_afl_custom";
            this.rb_afl_custom.Size = new System.Drawing.Size(63, 17);
            this.rb_afl_custom.TabIndex = 2;
            this.rb_afl_custom.TabStop = true;
            this.rb_afl_custom.Text = "Custom:";
            this.rb_afl_custom.UseVisualStyleBackColor = true;
            this.rb_afl_custom.CheckedChanged += new System.EventHandler(this.RCheckChanged);
            // 
            // rb_afl_pwn
            // 
            this.rb_afl_pwn.AutoSize = true;
            this.rb_afl_pwn.Location = new System.Drawing.Point(193, 19);
            this.rb_afl_pwn.Name = "rb_afl_pwn";
            this.rb_afl_pwn.Size = new System.Drawing.Size(142, 17);
            this.rb_afl_pwn.TabIndex = 1;
            this.rb_afl_pwn.TabStop = true;
            this.rb_afl_pwn.Text = "Together with PAWN file";
            this.rb_afl_pwn.UseVisualStyleBackColor = true;
            this.rb_afl_pwn.CheckedChanged += new System.EventHandler(this.RCheckChanged);
            // 
            // rb_afl_default
            // 
            this.rb_afl_default.AutoSize = true;
            this.rb_afl_default.Location = new System.Drawing.Point(9, 19);
            this.rb_afl_default.Name = "rb_afl_default";
            this.rb_afl_default.Size = new System.Drawing.Size(178, 17);
            this.rb_afl_default.TabIndex = 0;
            this.rb_afl_default.TabStop = true;
            this.rb_afl_default.Text = "Default (location of pawncc.exe)";
            this.rb_afl_default.UseVisualStyleBackColor = true;
            this.rb_afl_default.CheckedChanged += new System.EventHandler(this.RCheckChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.t_cargs);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.b_cpathbrws);
            this.groupBox4.Controls.Add(this.t_cpath);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(9, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(385, 74);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(366, 48);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(13, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // t_cargs
            // 
            this.t_cargs.Location = new System.Drawing.Point(86, 45);
            this.t_cargs.Name = "t_cargs";
            this.t_cargs.Size = new System.Drawing.Size(274, 20);
            this.t_cargs.TabIndex = 4;
            this.t_cargs.Leave += new System.EventHandler(this.t_cargs_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Compiler args:";
            // 
            // b_cpathbrws
            // 
            this.b_cpathbrws.Location = new System.Drawing.Point(304, 17);
            this.b_cpathbrws.Name = "b_cpathbrws";
            this.b_cpathbrws.Size = new System.Drawing.Size(75, 23);
            this.b_cpathbrws.TabIndex = 2;
            this.b_cpathbrws.Text = "Browse...";
            this.b_cpathbrws.UseVisualStyleBackColor = true;
            this.b_cpathbrws.Click += new System.EventHandler(this.b_cpathbrws_Click);
            // 
            // t_cpath
            // 
            this.t_cpath.Location = new System.Drawing.Point(86, 19);
            this.t_cpath.Name = "t_cpath";
            this.t_cpath.ReadOnly = true;
            this.t_cpath.Size = new System.Drawing.Size(212, 20);
            this.t_cpath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Compiler path:";
            // 
            // tp_plugins
            // 
            this.tp_plugins.Controls.Add(this.pnl_plug);
            this.tp_plugins.Controls.Add(this.groupBox6);
            this.tp_plugins.Location = new System.Drawing.Point(4, 22);
            this.tp_plugins.Name = "tp_plugins";
            this.tp_plugins.Padding = new System.Windows.Forms.Padding(3);
            this.tp_plugins.Size = new System.Drawing.Size(400, 289);
            this.tp_plugins.TabIndex = 3;
            this.tp_plugins.Text = "Plugins";
            this.tp_plugins.UseVisualStyleBackColor = true;
            // 
            // pnl_plug
            // 
            this.pnl_plug.Location = new System.Drawing.Point(6, 88);
            this.pnl_plug.Name = "pnl_plug";
            this.pnl_plug.Size = new System.Drawing.Size(388, 195);
            this.pnl_plug.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.b_loadplug);
            this.groupBox6.Controls.Add(this.cbx_plugins);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(388, 76);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Select Plugin";
            // 
            // b_loadplug
            // 
            this.b_loadplug.Location = new System.Drawing.Point(6, 46);
            this.b_loadplug.Name = "b_loadplug";
            this.b_loadplug.Size = new System.Drawing.Size(376, 23);
            this.b_loadplug.TabIndex = 1;
            this.b_loadplug.Text = "Load Plugin\'s Config";
            this.b_loadplug.UseVisualStyleBackColor = true;
            this.b_loadplug.Click += new System.EventHandler(this.b_loadplug_Click);
            // 
            // cbx_plugins
            // 
            this.cbx_plugins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_plugins.FormattingEnabled = true;
            this.cbx_plugins.Items.AddRange(new object[] {
            ""});
            this.cbx_plugins.Location = new System.Drawing.Point(6, 19);
            this.cbx_plugins.Name = "cbx_plugins";
            this.cbx_plugins.Size = new System.Drawing.Size(376, 21);
            this.cbx_plugins.TabIndex = 0;
            // 
            // tp_update
            // 
            this.tp_update.Controls.Add(this.l_verconclusion);
            this.tp_update.Controls.Add(this.l_curver);
            this.tp_update.Controls.Add(this.label4);
            this.tp_update.Controls.Add(this.t_changelog);
            this.tp_update.Controls.Add(this.l_status);
            this.tp_update.Controls.Add(this.b_upd);
            this.tp_update.Location = new System.Drawing.Point(4, 22);
            this.tp_update.Name = "tp_update";
            this.tp_update.Padding = new System.Windows.Forms.Padding(3);
            this.tp_update.Size = new System.Drawing.Size(400, 289);
            this.tp_update.TabIndex = 4;
            this.tp_update.Text = "Updater";
            this.tp_update.UseVisualStyleBackColor = true;
            // 
            // l_verconclusion
            // 
            this.l_verconclusion.AutoSize = true;
            this.l_verconclusion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_verconclusion.Location = new System.Drawing.Point(6, 72);
            this.l_verconclusion.Name = "l_verconclusion";
            this.l_verconclusion.Size = new System.Drawing.Size(34, 20);
            this.l_verconclusion.TabIndex = 6;
            this.l_verconclusion.Text = ".....";
            // 
            // l_curver
            // 
            this.l_curver.AutoSize = true;
            this.l_curver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_curver.Location = new System.Drawing.Point(6, 32);
            this.l_curver.Name = "l_curver";
            this.l_curver.Size = new System.Drawing.Size(258, 20);
            this.l_curver.TabIndex = 5;
            this.l_curver.Text = "Current running version: HHOO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Changelog for latest version:";
            // 
            // t_changelog
            // 
            this.t_changelog.Location = new System.Drawing.Point(6, 129);
            this.t_changelog.Multiline = true;
            this.t_changelog.Name = "t_changelog";
            this.t_changelog.ReadOnly = true;
            this.t_changelog.Size = new System.Drawing.Size(388, 154);
            this.t_changelog.TabIndex = 3;
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_status.Location = new System.Drawing.Point(6, 52);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(34, 20);
            this.l_status.TabIndex = 2;
            this.l_status.Text = ".....";
            // 
            // b_upd
            // 
            this.b_upd.Location = new System.Drawing.Point(6, 6);
            this.b_upd.Name = "b_upd";
            this.b_upd.Size = new System.Drawing.Size(388, 23);
            this.b_upd.TabIndex = 1;
            this.b_upd.Text = "Check for Updates...";
            this.b_upd.UseVisualStyleBackColor = true;
            this.b_upd.Click += new System.EventHandler(this.b_upd_Click);
            // 
            // b_accept
            // 
            this.b_accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_accept.Location = new System.Drawing.Point(264, 333);
            this.b_accept.Name = "b_accept";
            this.b_accept.Size = new System.Drawing.Size(75, 23);
            this.b_accept.TabIndex = 1;
            this.b_accept.Text = "OK";
            this.b_accept.UseVisualStyleBackColor = true;
            this.b_accept.Click += new System.EventHandler(this.b_accept_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_cancel.Location = new System.Drawing.Point(345, 333);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(75, 23);
            this.b_cancel.TabIndex = 2;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // tt_durai
            // 
            this.tt_durai.ToolTipTitle = "It\'s a Tip! :)";
            // 
            // opf_main
            // 
            this.opf_main.DefaultExt = "exe";
            this.opf_main.Filter = "PAWN Compiler|*.exe";
            this.opf_main.Title = "Select the compiler";
            // 
            // b_associate
            // 
            this.b_associate.Location = new System.Drawing.Point(6, 19);
            this.b_associate.Name = "b_associate";
            this.b_associate.Size = new System.Drawing.Size(376, 23);
            this.b_associate.TabIndex = 0;
            this.b_associate.Text = "Click here to associate PAWN files with SAMPCE";
            this.b_associate.UseVisualStyleBackColor = true;
            this.b_associate.Click += new System.EventHandler(this.b_associate_Click);
            // 
            // f_config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 368);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_accept);
            this.Controls.Add(this.tc_option);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "f_config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SAM[P]CE Options";
            this.Load += new System.EventHandler(this.f_config_Load);
            this.tc_option.ResumeLayout(false);
            this.tp_gen.ResumeLayout(false);
            this.tp_gen.PerformLayout();
            this.gb_fd.ResumeLayout(false);
            this.gb_fd.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tp_viz.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tp_compiler.ResumeLayout(false);
            this.gb_afl.ResumeLayout(false);
            this.gb_afl.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tp_plugins.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tp_update.ResumeLayout(false);
            this.tp_update.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tp_gen;
        private System.Windows.Forms.TabPage tp_viz;
        private System.Windows.Forms.Button b_accept;
        private System.Windows.Forms.TabPage tp_compiler;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FontDialog fpf_main;
        private System.Windows.Forms.Button b_font;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button b_cpathbrws;
        private System.Windows.Forms.TextBox t_cpath;
        private System.Windows.Forms.TextBox t_cargs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip tt_durai;
        private System.Windows.Forms.RadioButton rb_afl_custom;
        private System.Windows.Forms.RadioButton rb_afl_pwn;
        private System.Windows.Forms.RadioButton rb_afl_default;
        private System.Windows.Forms.OpenFileDialog opf_main;
        private System.Windows.Forms.Button b_aflbrws;
        private System.Windows.Forms.TextBox t_afl;
        private System.Windows.Forms.TabPage tp_plugins;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel pnl_plug;
        private System.Windows.Forms.ComboBox cbx_plugins;
        private System.Windows.Forms.Button b_loadplug;
        private System.Windows.Forms.TabPage tp_update;
        internal System.Windows.Forms.TabControl tc_option;
        private System.Windows.Forms.Button b_upd;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.TextBox t_changelog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label l_curver;
        private System.Windows.Forms.Label l_verconclusion;
        private System.Windows.Forms.GroupBox gb_fd;
        private System.Windows.Forms.RadioButton rb_fd_default;
        private System.Windows.Forms.RadioButton rb_fd_backward;
        private System.Windows.Forms.RadioButton rb_fd_pawno;
        private System.Windows.Forms.FolderBrowserDialog fbd_main;
        internal System.Windows.Forms.GroupBox gb_afl;
        private System.Windows.Forms.Button b_associate;
    }
}