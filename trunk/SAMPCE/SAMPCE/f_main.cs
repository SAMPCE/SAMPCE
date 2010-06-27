using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using newPT;

namespace SAMPCE
{
    public partial class f_main : Form
    {
        internal Parser prs;
        //public c_parser prs;
        //Hashtable tts = new Hashtable();
        Dictionary<TabPage, CodeDocument> CodeTabs = new Dictionary<TabPage, CodeDocument>();
        //int tid = 0;
        int cur_tbs = -1, hParam;
        int gmn = 0, fsn = 0, etcn = 0;
        public CodeDocument cur_cd;
        Functions func = new Functions();
        /// <summary>
        /// The current function AutoComplete is showing :)
        /// </summary>
        c_function cfs;

        public f_main(string[] args)
        {
            InitializeComponent();
            Thread th = new Thread(new ThreadStart(LoadSplash));
            th.Start();
            LoadPrerequisite();
            TabDragger td = new TabDragger(tc_main, this);
            if (args.Length == 0) NewScintillaInstance("new", "New Blank File", null);
            else NewScintillaInstance("open", Path.GetFileName(args[0]), args[0]);
            cur_cd = CodeTabs[tc_main.SelectedTab];
            th.Abort();
            Thread.Sleep(2000);
            this.Focus();
        }

        private void LoadSplash()
        {
            f_splash sp = new f_splash();
            sp.ShowDialog();
        }

        private void LoadPrerequisite()
        {
            prs = new Parser();
            ImageList il = new ImageList();
            il.Images.Add(SAMPCE.Properties.Resources.VSProject_genericfile);
            il.Images.Add(SAMPCE.Properties.Resources.VSObject_Method);
            il.Images.Add(SAMPCE.Properties.Resources.VSObject_Constant);
            il.Images.Add(SAMPCE.Properties.Resources.VSObject_Field);
            tv_func.ImageList = il;
            tv_lf.ImageList = il;
            il = new ImageList();
            il.Images.Add(SAMPCE.Properties.Resources.Error);
            il.Images.Add(SAMPCE.Properties.Resources.Warning);
            lv_err.SmallImageList = il;
            func.LoadPlugins(this);
            FindIncludeFunc();
        }

        public void AddToolStripMenuItem(ToolStripMenuItem tsmi)
        {
            pluginsToolStripMenuItem.DropDownItems.Add(tsmi);
        }

        private void FindIncludeFunc()
        {
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\include");
            if (di.Exists == false)
            {
                try { di.Create(); }
                catch (IOException) { MessageBox.Show("Please create an \'include\' folder in " + di.Parent, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            prs.incarry = new c_FileFnc[di.GetFiles("*.inc").Length];
            foreach (FileInfo fi in di.GetFiles("*.inc"))
            {
                StreamReader sr = new StreamReader(fi.FullName);
                prs.CodeParser(fi.Name, sr.ReadToEnd(), true, Properties.Settings.Default.fd);
            }
            tv_func.Nodes.Clear();
            foreach (c_FileFnc fifnc in prs.incarry)
            {
                TreeNode[] tnca = new TreeNode[fifnc.functions.Count + fifnc.constants.Count];
                int b = 0, c = 0;
                foreach (c_function cfs in fifnc.constants.Values)
                {
                    tnca[b] = new TreeNode(cfs.fName);
                    tnca[b].ImageIndex = 2;
                    tnca[b].SelectedImageIndex = 2;
                    b++;
                }

                foreach (c_function cfs in fifnc.functions.Values)
                {
                    func.AddFunction(cfs.fName);
                    tnca[fifnc.constants.Count + c] = new TreeNode(cfs.fName);
                    tnca[fifnc.constants.Count + c].ImageIndex = 1;
                    tnca[fifnc.constants.Count + c].SelectedImageIndex = 1;
                    c++;
                }
                Array.Sort(tnca, delegate(TreeNode tn1, TreeNode tn2)
                {
                    return tn1.Text.CompareTo(tn2.Text);
                });
                TreeNode tn = new TreeNode(fifnc.FileName, tnca);
                tn.ImageIndex = 0;
                tv_func.Nodes.Add(tn);
            }
        }

        private void FindLocalFunc(string cd, bool refresh)
        {
            if (cur_cd.lv == null || refresh == true)
            {
                prs.CodeParser("null", cd, false, Properties.Settings.Default.fd);
                cur_cd.lv = prs.curFile;
            }
            else prs.curFile = cur_cd.lv;

            tv_lf.Nodes.Clear();

            foreach (c_function fnc in cur_cd.lv.functions.Values)
            {
                TreeNode tn = new TreeNode(fnc.fName);
                tn.ImageIndex = 1;
                tn.SelectedImageIndex = 1;
                tv_lf.Nodes.Add(tn);
            }

            foreach (c_function fnc in cur_cd.lv.constants.Values)
            {
                TreeNode tn = new TreeNode(fnc.fName);
                tn.ImageIndex = 2;
                tn.SelectedImageIndex = 2;
                tv_lf.Nodes.Add(tn); ;
            }

            foreach (c_function fnc in cur_cd.lv.variables.Values)
            {
                TreeNode tn = new TreeNode(fnc.fName);
                tn.ImageIndex = 3;
                tn.SelectedImageIndex = 3;
                tv_lf.Nodes.Add(tn);
            }
            tv_lf.Sort();
        }

        private void f_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TabPage tp in tc_main.TabPages)
            {
                if (!CodeTabs.ContainsKey(tp)) continue;
                CodeDocument tbp_cd = CodeTabs[tp];
                if (tbp_cd.IsEdited == true)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save changes made to  " + tbp_cd.FileName + "?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            save_tbcm_Click(sender, e);
                            break;

                        case DialogResult.No:
                            break;

                        case DialogResult.Cancel: return;
                    }
                }
            }
            for (int i = 0; i <  tc_main.TabPages.Count; i++)
            {
                
            }
            
        }

        /// <summary>
        /// Creates a new code tab window thingy.
        /// </summary>
        /// <param name="type">Either "new" or "open", no excuses</param>
        /// <param name="FileName">The safe file name or null, if new</param>
        /// <param name="FilePath">The FilePath or null, if new</param>
        private void NewScintillaInstance(string type, string FileName, string FilePath)
        {
            TabPage tb = null;
            ScintillaNet.Scintilla pgsc = new ScintillaNet.Scintilla();
            tb = new TabPage(FileName);
            if (type == "new_gm") pgsc = func.InitSC(Properties.Resources.newPWN);
            else if (type == "new_fs") pgsc = func.InitSC(Properties.Resources.newFS);
            else if (type == "new") pgsc = func.InitSC("");
            else if (type == "open")
            {
                StreamReader sr = new StreamReader(FilePath);
                pgsc = func.InitSC(sr.ReadToEnd());
                sr.Close();
            }
            pgsc.TextChanged += new EventHandler<EventArgs>(pgsc_TextChanged);
            pgsc.CharAdded += new EventHandler<ScintillaNet.CharAddedEventArgs>(pgsc_CharAdded);
            pgsc.TextDeleted += new EventHandler<ScintillaNet.TextModifiedEventArgs>(pgsc_TextDeleted);
            pgsc.SelectionChanged += new EventHandler(pgsc_SelectionChanged);
            pgsc.KeyUp += new KeyEventHandler(pgsc_KeyUp);
            tb.Controls.Add(pgsc);
            tc_main.TabPages.Add(tb);
            CodeDocument cd = new CodeDocument(pgsc, FileName, FilePath);
            CodeTabs.Add(tc_main.TabPages[tc_main.TabPages.Count - 1], cd);
            tc_main.SelectedIndex = tc_main.TabPages.Count - 1;
        }

        private void DestroyScintillaInstance(TabPage inst)
        {
            CodeTabs.Remove(inst);
            if (tc_main.TabPages.Count == 1) NewScintillaInstance("new", "New Blank File", null);
                /*
            else
            {
                for (int i = inst; i < tts.Count; i++)
                {
                    tts.Add(i, tts[i + 1]);
                    tts.Remove(i + 1);
                }
            }
                 */
            tc_main.TabPages.Remove(inst);
        }

        private void SaveScintillaDoc(CodeDocument cd, int inst, string FileName, string FilePath)
        {
            try
            {
                StreamWriter sw = new StreamWriter(FilePath);
                sw.Write(cd.Interface.Text);
                sw.Flush();
                sw.Close();
            }
            catch (IOException ex) { MessageBox.Show("I/O Error! " + ex.Message); }
            if (cd.FilePath == null)
            {
                cd.FileName = FileName;
                cd.FilePath = FilePath;
            }

            if (inst != -1) tc_main.TabPages[inst].Text = FileName;
            else tc_main.SelectedTab.Text = FileName;
            cd.IsEdited = false;
        }

        private void DiscChanger()
        {
            if (cur_cd.Interface.UndoRedo.CanUndo == false)
            {
                undoToolStripButton.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
            }
            else
            {
                undoToolStripButton.Enabled = true;
                undoToolStripMenuItem.Enabled = true;
            }
            if (cur_cd.Interface.UndoRedo.CanRedo == true)
            {
                redoToolStripButton.Enabled = true;
                redoToolStripMenuItem.Enabled = true;
            }
            else
            {
                redoToolStripButton.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
            }

            if (cur_cd.IsEdited == false)
            {
                save_tbcm.Enabled = false;
                saveToolStripButton.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
            }
            else
            {
                save_tbcm.Enabled = true;
                saveToolStripButton.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Parses errors from PAWN and keeps it
        /// </summary>
        /// <param name="errq">The error, in its full glory</param>
        private void DispErr(string errq)
        {
            foreach (Error erl in cur_cd.Errors.Values) cur_cd.Interface.Lines[erl.Line - 1].Range.ClearIndicator(0);
            cur_cd.Errors.Clear();
            string terr = (errq.IndexOf("Compilation") != -1) ? errq.Remove(errq.IndexOf("Compilation")) : errq;
            terr = terr.Trim();
            string[] errors = terr.Split('\n');
            foreach (string error in errors)
            {
                Error err_elems = newPT.ErrorParser.ParseCompilerError(error);
                cur_cd.Errors.Add(LoadErrorsIntoList(err_elems), err_elems);
            }
        }

        public ListViewItem LoadErrorsIntoList(Error err)
        {
            ListViewItem.ListViewSubItem[] lvsi_err = new ListViewItem.ListViewSubItem[5];
            lvsi_err[0] = new ListViewItem.ListViewSubItem();
            int ii = (int)err.Type;
            lvsi_err[0].Text = ii.ToString();
            for (int i = 1; i < lvsi_err.Length; i++) lvsi_err[i] = new ListViewItem.ListViewSubItem();
            lvsi_err[1].Text = err.ID.ToString();
            lvsi_err[2].Text = err.Description;
            lvsi_err[3].Text = cur_cd.FileName;
            lvsi_err[4].Text = err.Line.ToString();
            cur_cd.Interface.Lines[err.Line - 1].Range.SetIndicator(0);
            ListViewItem lvi_err = new ListViewItem(lvsi_err, (int)err.Type);
            lv_err.Items.Add(lvi_err);
            return lvi_err;
        }

        private void tc_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Error erl in cur_cd.Errors.Values) cur_cd.Interface.Lines[erl.Line - 1].Range.ClearIndicator(0);
            if (cur_cd.Interface.FindReplace.Window.Visible == true) cur_cd.Interface.FindReplace.Window.Close();
            cur_cd = CodeTabs[tc_main.SelectedTab];
            tv_lf.Nodes.Clear();
            lv_err.Items.Clear();
            FindLocalFunc(cur_cd.Interface.Text, false);
            foreach (Error fileerr in cur_cd.Errors.Values) LoadErrorsIntoList(fileerr);
            DiscChanger();
        }

        void pgsc_TextChanged(object sender, EventArgs e)
        {
            if (cur_cd.Initial == true)
            {
                cur_cd.Initial = false;
                cur_cd.Interface.UndoRedo.EmptyUndoBuffer();
            }
            else if (cur_cd.IsEdited == false)
            {
                cur_cd.IsEdited = true;
                tc_main.SelectedTab.Text = cur_cd.FileName + "*";
            }
            DiscChanger();
        }

        void pgsc_TextDeleted(object sender, ScintillaNet.TextModifiedEventArgs e)
        {
            ScintillaNet.Scintilla s_tmp = (ScintillaNet.Scintilla)sender;
            if (e.Length == 1)
            {
                if (e.Text == "," && s_tmp.CallTip.IsActive == true)
                {
                    if (hParam == 0)
                    {
                        s_tmp.CallTip.Hide();
                        return;
                    }
                    if (hParam >= cfs.fParams.Length)
                    {
                        hParam--;
                        s_tmp.CallTip.HighlightStart -= 50;
                        s_tmp.CallTip.HighlightEnd -= 50;
                        return;
                    }
                    else
                    {
                        hParam--;
                        s_tmp.CallTip.HighlightStart -= cfs.fParams[hParam].Length + 1;
                        s_tmp.CallTip.HighlightEnd -= cfs.fParams[hParam + 1].Length + 1;
                    }
                }
            }
        }

        void pgsc_KeyUp(object sender, KeyEventArgs e)
        {
            tssl_insmode.Text = (cur_cd.Interface.OverType == true) ? "OVR" : "INS";
        }

        void pgsc_SelectionChanged(object sender, EventArgs e)
        {
            tssl_line.Text = "Ln " + (cur_cd.Interface.Lines.Current.VisibleLineNumber + 1);
            tssl_chr.Text = "Ch " + (cur_cd.Interface.Selection.Start - cur_cd.Interface.Lines.Current.StartPosition + 1);
        }

        private void gamemodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewScintillaInstance("new_gm", "New Gamemode (" + gmn + ")", null);
            gmn++;
        }

        private void filterscriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewScintillaInstance("new_fs", "New Filterscript (" + fsn + ")", null);
            fsn++;
        }

        private void includesEtcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewScintillaInstance("new", "New PAWN Script (" + etcn + ")", null);
            etcn++;
        }

        void pgsc_CharAdded(object sender, ScintillaNet.CharAddedEventArgs e)
        {
            ScintillaNet.Scintilla s_tmp = (ScintillaNet.Scintilla)sender;
            switch (e.Ch)
            {
                case '(':
                    string test = s_tmp.Lines.Current.Text.Trim();
                    //test = test.Split(' ').Last<String>();
                    test = test.TrimEnd('(');
                    cfs = prs.SearchForFunc(test);
                    if (cfs != null)
                    {
                        hParam = 0;
                        string PartA = cfs.fReturn + ":" + cfs.fName + "(";
                        string PartB = string.Join(",", cfs.fParams) + ")";
                        s_tmp.CallTip.Message = PartA + PartB;
                        s_tmp.CallTip.HighlightStart = PartA.Length;
                        s_tmp.CallTip.HighlightEnd = PartA.Length + cfs.fParams[0].Length;
                        s_tmp.CallTip.Show(PartA.Length, PartA.Length + cfs.fParams[0].Length);
                    }
                    break;

                case ',':
                    if (s_tmp.CallTip.IsActive == true)
                    {
                        if (hParam >= cfs.fParams.Length - 1)
                        {
                            hParam++;
                            s_tmp.CallTip.HighlightStart += 50;
                            s_tmp.CallTip.HighlightEnd += 50;
                            break;
                        }
                        s_tmp.CallTip.HighlightStart += cfs.fParams[hParam].Length + 1;
                        hParam++;
                        s_tmp.CallTip.HighlightEnd += cfs.fParams[hParam].Length + 1;
                    }
                    break;

                case ')':
                    if (s_tmp.CallTip.IsActive == true) s_tmp.CallTip.Hide();
                    break;
            }
        }

        private void tv_func_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            TreeView tvt = (TreeView)sender;
            tt_durai.Hide(tvt);
            if (e.Node.Parent != null && e.Node.ImageIndex == 1)
            {
                c_function cftemp = prs.SearchForFunc(e.Node.Text);
                string fStr = cftemp.fReturn + ":" + cftemp.fName + "(" + string.Join(",", cftemp.fParams) + ")";
                //Point realpos = new Point(Cursor.Position.x - tvt.Location.x, Cursor.Position.y - tvt.Location.y
                tt_durai.Show(fStr, tvt);
            }
        }

        private void tv_func_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView tvt = (TreeView)sender;
            if (e.Node.Parent != null && e.Node.ImageIndex == 1) cur_cd.Interface.InsertText(e.Node.Text);
        }

        private void tv_lf_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeView tvt = (TreeView)sender;
            c_function tmp = new c_function();
            switch (e.Node.ImageIndex)
            {
                case 1:
                    tmp = prs.curFile.functions[e.Node.Text];
                    break;
                    
                case 2:
                    tmp = prs.curFile.constants[e.Node.Text];
                    break;

                case 3:
                    tmp = prs.curFile.variables[e.Node.Text];
                    break;
            }
            cur_cd.Interface.GoTo.Line(tmp.fLn);
            cur_cd.Interface.Lines.Current.Select();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if (cur_cd.Interface.Selection.Text == "") return;
            Clipboard.SetText(cur_cd.Interface.Selection.Text);
            cur_cd.Interface.Selection.Clear();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            if (cur_cd.Interface.Selection.Text == "") return;
            Clipboard.SetText(cur_cd.Interface.Selection.Text);
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            if (cur_cd.Interface.Selection.Text != "")
            {
                cur_cd.Interface.Selection.Text = Clipboard.GetText();
                return;
            }
            cur_cd.Interface.InsertText(Clipboard.GetText());
        }

        private void undoToolStripButton_Click(object sender, EventArgs e)
        {
            cur_cd.Interface.UndoRedo.Undo();
            DiscChanger();
        }

        private void redoToolStripButton_Click(object sender, EventArgs e)
        {
            cur_cd.Interface.UndoRedo.Redo();
            DiscChanger();
        }

        private void compileStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripButton_Click(sender, e);
            lv_err.Items.Clear();
            if (cur_cd.FilePath == null) return;
            System.Diagnostics.Process pcmp = new System.Diagnostics.Process();
            pcmp.StartInfo.UseShellExecute = false;
            pcmp.StartInfo.RedirectStandardOutput = true;
            pcmp.StartInfo.RedirectStandardError = true;
            pcmp.StartInfo.CreateNoWindow = true;
            MessageBox.Show(SAMPCE.Properties.Settings.Default.cpath);
            pcmp.StartInfo.FileName = SAMPCE.Properties.Settings.Default.cpath;
            pcmp.StartInfo.Arguments = SAMPCE.Properties.Settings.Default.cargs + " \"" + cur_cd.FilePath + "\"";
            t_cout.Text += "\r\n=== BEGIN OUTPUT FOR " + cur_cd.FileName + " ===\r\n";
            pcmp.Start();
            string output = pcmp.StandardOutput.ReadToEnd();
            string err = pcmp.StandardError.ReadToEnd();
            pcmp.WaitForExit();
            pcmp.Close();
            t_cout.Text += output + "\r\n=== END OUTPUT FOR " + cur_cd.FileName + " ===\r\n";
            t_cout.SelectionStart = t_cout.Text.Length;
            t_cout.ScrollToCaret();
            if (err != "") DispErr(err);
            if (!lv_err.Items.ContainsKey(((int)ErrorType.Error).ToString()))
            {
                FileInfo fi = new FileInfo(Path.GetFileNameWithoutExtension(cur_cd.FileName) + ".amx");
                if (SAMPCE.Properties.Settings.Default.afl == "pwn" )
                {
                    try { fi.MoveTo(cur_cd.FilePath); }
                    catch (Exception ex) { MessageBox.Show("Could not move resulting amx file! Reason: " + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else if (SAMPCE.Properties.Settings.Default.afl == "custom" & SAMPCE.Properties.Settings.Default.aflcustom != "")
                {
                    try { fi.MoveTo(SAMPCE.Properties.Settings.Default.aflcustom); }
                    catch (Exception ex) { MessageBox.Show("Could not move resulting amx file! Reason: " + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }

            }
        }

        private void findStripMenuItem_Click(object sender, EventArgs e) { cur_cd.Interface.FindReplace.ShowFind(); }

        private void replaceStripMenuItem_Click(object sender, EventArgs e) { cur_cd.Interface.FindReplace.ShowReplace(); }

        private void goToStripMenuItem_Click(object sender, EventArgs e) { cur_cd.Interface.GoTo.ShowGoToDialog(); }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (opf_main.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < opf_main.FileNames.Length; i++) NewScintillaInstance("open", opf_main.SafeFileNames[i], opf_main.FileNames[i]);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (cur_cd.FilePath != null) SaveScintillaDoc(cur_cd, -1, cur_cd.FileName, cur_cd.FilePath);
            else
            {
                if (spf_main.ShowDialog() == DialogResult.OK) SaveScintillaDoc(cur_cd, -1, Path.GetFileName(spf_main.FileName), spf_main.FileName);
                else return;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (spf_main.ShowDialog() == DialogResult.OK) SaveScintillaDoc(cur_cd, -1, Path.GetFileName(spf_main.FileName), spf_main.FileName);
            else return;
        }

        private void save_tbcm_Click(object sender, EventArgs e)
        {
            CodeDocument sel_cd = CodeTabs[tc_main.TabPages[cur_tbs]];
            if (sel_cd.FilePath != null) SaveScintillaDoc(sel_cd, cur_tbs, sel_cd.FileName, sel_cd.FilePath);
            else
            {
                if (spf_main.ShowDialog() == DialogResult.OK) SaveScintillaDoc(cur_cd, cur_tbs, Path.GetFileName(spf_main.FileName), spf_main.FileName);
                else return;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cur_cd.Interface.Selection.SelectAll();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_about aboutBx = new f_about();
            aboutBx.ShowDialog();
        }

        private void close_tbcm_Click(object sender, EventArgs e)
        {
            if (cur_tbs == -1) return;
            CodeDocument sel_cd = CodeTabs[tc_main.TabPages[cur_tbs]];
            if (sel_cd.IsEdited == true)
            {
                DialogResult dr = MessageBox.Show("Do you want to save changes made to this file?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case DialogResult.Yes:
                        save_tbcm_Click(sender, e);
                        break;
                        
                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel: return;
                }
            }
            DestroyScintillaInstance(tc_main.TabPages[cur_tbs]);
        }

        #region Komponen TabDragger

        internal class TabDragger
        {
            public TabDragger(TabControl tabControl, f_main parent)
                : base()
            {
                prt = parent;
                this.tabControl = tabControl;
                tabControl.MouseDown += new MouseEventHandler(tabControl_MouseDown);
                tabControl.MouseMove += new MouseEventHandler(tabControl_MouseMove);
                tabControl.DoubleClick += new EventHandler(tabControl_DoubleClick);
            }

            public TabDragger(TabControl tabControl, TabDragBehavior behavior, f_main parat)
                : this(tabControl, parat)
            {
                this.dragBehavior = behavior;
            }

            private f_main prt;
            private TabControl tabControl;
            private TabPage dragTab = null;
            private TabDragBehavior dragBehavior = TabDragBehavior.TabDragArrange;

            private TabDragBehavior DragBehavior
            {
                get
                {
                    if (!tabControl.Multiline)
                        return dragBehavior;
                    return TabDragBehavior.None;
                }
            }

            private void tabControl_MouseDown(object sender, MouseEventArgs e)
            {
                dragTab = TabUnderMouse();
            }

            private void tabControl_MouseMove(object sender, MouseEventArgs e)
            {
                if (DragBehavior == TabDragBehavior.None)
                    return;

                if (e.Button == MouseButtons.Left)
                {
                    if (dragTab != null)
                    {
                        if (tabControl.TabPages.Contains(dragTab))
                        {
                            if (PointInTabStrip(e.Location))
                            {
                                TabPage hotTab = TabUnderMouse();
                                if (hotTab != dragTab && hotTab != null)
                                {
                                    int id1 = tabControl.TabPages.IndexOf(dragTab);
                                    int id2 = tabControl.TabPages.IndexOf(hotTab);
                                    if (id1 > id2)
                                    {
                                        for (int id = id2; id <= id1; id++)
                                        {
                                            SwapTabPages(id1, id);
                                        }
                                    }
                                    else
                                    {
                                        for (int id = id2; id > id1; id--)
                                        {
                                            SwapTabPages(id1, id);
                                        }
                                    }
                                    tabControl.SelectedTab = dragTab;
                                }
                            }
                            else
                            {
                                if (this.dragBehavior == TabDragBehavior.TabDragOut)
                                {
                                    if (dragTab.Tag != null)
                                    {
                                        ((TabForm)dragTab.Tag).Dispose();
                                        dragTab.Tag = null;
                                    }
                                    else
                                    {
                                        TabForm frm = new TabForm(dragTab);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private void tabControl_DoubleClick(object sender, EventArgs e)
            {
                if (this.DragBehavior == TabDragBehavior.TabDragOut)
                {
                    TabForm frm = new TabForm(dragTab);
                }
            }

            #region Private Methods

            private TabPage TabUnderMouse()
            {
                NativeMethods.TCHITTESTINFO HTI = new NativeMethods.TCHITTESTINFO(tabControl.PointToClient(Cursor.Position));
                int tabID = NativeMethods.SendMessage(tabControl.Handle, NativeMethods.TCM_HITTEST, IntPtr.Zero, ref HTI);
                return tabID == -1 ? null : tabControl.TabPages[tabID];
            }

            private bool PointInTabStrip(Point point)
            {
                Rectangle tabBounds = Rectangle.Empty;
                Rectangle displayRC = tabControl.DisplayRectangle; ;

                switch (tabControl.Alignment)
                {
                    case TabAlignment.Bottom:
                        tabBounds.Location = new Point(0, displayRC.Bottom);
                        tabBounds.Size = new Size(tabControl.Width, tabControl.Height - displayRC.Height);
                        break;

                    case TabAlignment.Left:
                        tabBounds.Size = new Size(displayRC.Left, tabControl.Height);
                        break;

                    case TabAlignment.Right:
                        tabBounds.Location = new Point(displayRC.Right, 0);
                        tabBounds.Size = new Size(tabControl.Width - displayRC.Width, tabControl.Height);
                        break;

                    default:
                        tabBounds.Size = new Size(tabControl.Width, displayRC.Top);
                        break;
                }
                tabBounds.Inflate(-3, -3);
                return tabBounds.Contains(point);
            }

            private void SwapTabPages(int index1, int index2)
            {
                if ((index1 | index2) != -1)
                {
                    TabPage tab1 = tabControl.TabPages[index1];
                    TabPage tab2 = tabControl.TabPages[index2];
                    tabControl.TabPages[index1] = tab2;
                    tabControl.TabPages[index2] = tab1;
                    /*
                    if (tabControl.Name == "tc_main")
                    {
                        CodeDocument cd1 = (CodeDocument)prt.tts[index1];
                        CodeDocument cd2 = (CodeDocument)prt.tts[index2];
                        prt.tts[index1] = cd2;
                        prt.tts[index2] = cd1;
                    }
                     */
                }
            }

            #endregion

        }

        internal class TabForm : Form
        {
            public TabForm(TabPage tabPage)
                : base()
            {
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.StartPosition = FormStartPosition.Manual;
                this.MinimizeBox = false;
                this.MaximizeBox = false;
                this.tabPage = tabPage;
                tabPage.Tag = this;
                this.tabControl = (TabControl)tabPage.Parent;
                this.tabID = tabControl.TabPages.IndexOf(tabPage);
                this.ClientSize = tabPage.Size;
                this.Location = tabControl.PointToScreen(new Point(tabPage.Left, tabControl.PointToClient(Cursor.Position).Y - SystemInformation.ToolWindowCaptionHeight / 2));
                this.Text = tabPage.Text;
                UnDockFromTab();
                this.dragOffset = tabControl.PointToScreen(Cursor.Position);
                this.dragOffset.X -= this.Location.X;
                this.dragOffset.Y -= this.Location.Y;
            }

            private TabPage tabPage;
            private TabControl tabControl;
            private int tabID;
            private Point dragOffset;

            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);
                DockToTab();
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == NativeMethods.WM_MOVING)
                {
                    NativeMethods.RECT rc = (NativeMethods.RECT)m.GetLParam(typeof(NativeMethods.RECT));
                    Point pt = tabControl.PointToClient(Cursor.Position);
                    Rectangle pageRect = tabControl.DisplayRectangle;
                    Rectangle tabsRect = Rectangle.Empty;
                    switch (tabControl.Alignment)
                    {
                        case TabAlignment.Left:
                            tabsRect.Size = new Size(pageRect.Left, tabControl.Height);
                            break;

                        case TabAlignment.Bottom:
                            tabsRect.Location = new Point(0, pageRect.Bottom);
                            tabsRect.Size = new Size(tabControl.Width, tabControl.Bottom - pageRect.Bottom);
                            break;

                        case TabAlignment.Right:
                            tabsRect.Location = new Point(pageRect.Right, 0);
                            tabsRect.Size = new Size(tabControl.Right - pageRect.Right, tabControl.Height);
                            break;

                        default:
                            tabsRect.Size = new Size(tabControl.Width, pageRect.Top);
                            break;

                    }
                    if (tabsRect.Contains(pt))
                        DockToTab();
                    else
                        UnDockFromTab();
                }

                base.WndProc(ref m);

                switch (m.Msg)
                {
                    case NativeMethods.WM_NCLBUTTONDBLCLK:
                        this.Close();
                        break;

                    case NativeMethods.WM_EXITSIZEMOVE:
                        if (!this.Visible)
                            this.Close();
                        break;

                    case NativeMethods.WM_MOUSEMOVE:
                        if (m.WParam.ToInt32() == 1)
                        {
                            if (!captured)
                            {
                                Point pt = tabControl.PointToScreen((Cursor.Position));
                                Point newPosition = new Point(pt.X - dragOffset.X, pt.Y - dragOffset.Y);
                                this.Location = newPosition;
                            }
                            NativeMethods.RECT rc = new NativeMethods.RECT(this.Bounds);
                            IntPtr lParam = Marshal.AllocHGlobal(Marshal.SizeOf(rc));
                            Marshal.StructureToPtr(rc, lParam, true);
                            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_MOVING, IntPtr.Zero, lParam);
                            Marshal.FreeHGlobal(lParam);
                        }
                        break;

                    case NativeMethods.WM_SETCURSOR:
                        captured = true;
                        break;

                    default:
                        break;
                }

            }

            private bool captured;

            private void DockToTab()
            {
                if (!tabControl.TabPages.Contains(tabPage))
                {
                    for (int id = this.Controls.Count - 1; id >= 0; id--)
                    {
                        tabPage.Controls.Add(this.Controls[0]);
                    }
                    tabControl.TabPages.Insert(tabID, tabPage);
                    tabControl.SelectedTab = tabPage;

                    tabControl.Capture = true;
                    this.Close();
                }
            }

            private void UnDockFromTab()
            {
                if (this.Visible || this.IsDisposed)
                    return;
                for (int id = tabPage.Controls.Count - 1; id >= 0; id--)
                {
                    this.Controls.Add(tabPage.Controls[0]);
                }

                tabControl.TabPages.Remove(tabPage);
                this.Capture = true;
                this.Show();
            }

        }

        internal sealed class NativeMethods
        {

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left, Top, Right, Bottom;
                public RECT(Rectangle bounds)
                {
                    this.Left = bounds.Left;
                    this.Top = bounds.Top;
                    this.Right = bounds.Right;
                    this.Bottom = bounds.Bottom;
                }
                public override string ToString()
                {
                    return String.Format("{0}, {1}, {2}, {3}", Left, Top, Right, Bottom);
                }
            }

            public const int WM_NCLBUTTONDBLCLK = 0xA3;

            public const int WM_SETCURSOR = 0x20;

            public const int WM_NCHITTEST = 0x84;

            public const int WM_MOUSEMOVE = 0x200;
            public const int WM_MOVING = 0x216;
            public const int WM_EXITSIZEMOVE = 0x232;

            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref TCHITTESTINFO lParam);

            [StructLayout(LayoutKind.Sequential)]
            public struct TCHITTESTINFO
            {
                public Point pt;
                public TCHITTESTFLAGS flags;
                public TCHITTESTINFO(Point point)
                {
                    pt = point;
                    flags = TCHITTESTFLAGS.TCHT_ONITEM;
                }
            }

            [Flags()]
            public enum TCHITTESTFLAGS
            {
                TCHT_NOWHERE = 1,
                TCHT_ONITEMICON = 2,
                TCHT_ONITEMLABEL = 4,
                TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
            }

            public const int TCM_HITTEST = 0x130D;

        }

        public enum TabDragBehavior
        { None, TabDragArrange, TabDragOut }

        #endregion

        private int TUM(TabControl tcm)
        {
            NativeMethods.TCHITTESTINFO HTI = new NativeMethods.TCHITTESTINFO(tcm.PointToClient(Cursor.Position));
            int tabID = NativeMethods.SendMessage(tcm.Handle, NativeMethods.TCM_HITTEST, IntPtr.Zero, ref HTI);
            return tabID == -1 ? -1 : tabID;
        }

        private void tc_main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int tbm = TUM((TabControl)sender);
                if (tbm != -1)
                {
                    cur_tbs = tbm;
                }
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_config hDlg = new f_config(func, 0);
            hDlg.ShowDialog();
        }

        private void pluginSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_config hDlg = new f_config(func, 3);
            hDlg.ShowDialog();

        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_config hDlg = new f_config(func, 4);
            hDlg.ShowDialog();
            hDlg.tc_option.TabIndex = 4;
        }

        private void f_main_Resize(object sender, EventArgs e)
        {
            double lv_wdth = lv_err.Width - 40;
            lvch_id.Width = (Int32)(lv_wdth * 0.1);
            lvch_desc.Width = (Int32)(lv_wdth * 0.6);
            lvch_file.Width = (Int32)(lv_wdth * 0.2);
            lvch_line.Width = (Int32)(lv_wdth * 0.1);
        }

        private void lv_err_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_err.SelectedItems.Count == 0) return;
            int ln = Int32.Parse(lv_err.SelectedItems[0].SubItems[4].Text) - 1;
            cur_cd.Interface.GoTo.Line(ln);
            cur_cd.Interface.Lines.Current.Select();
        }

        private void refreshLFStripButton_Click(object sender, EventArgs e)
        {
            FindLocalFunc(cur_cd.Interface.Text, true);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void lv_err_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lv_err.SelectedItems.Count == 1)
            {
                cm_err.Show(MousePosition);
            }
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No help currently!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cm_err_Help_Click(object sender, EventArgs e)
        {
            tt_errhelp.Show(ErrorParser.GetErrorHelp(cur_cd.Errors[lv_err.SelectedItems[0]]), this, lv_err.Location.X, lv_err.Location.Y);
        }
    }
}
