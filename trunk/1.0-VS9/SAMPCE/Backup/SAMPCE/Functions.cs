using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.IO;
using PluginManager;
using System.Reflection;
using newPT;

namespace SAMPCE
{
    public class CodeDocument
    {
        public string FileName;
        public Dictionary<ListViewItem, Error> Errors = new Dictionary<ListViewItem, Error>();
        public ScintillaNet.Scintilla Interface;
        public bool IsEdited = false;
        public bool Initial = true; //Initial is there for a reason!
        public string FilePath;
        public c_FileFnc lv;

        public CodeDocument(ScintillaNet.Scintilla sc, string sfn, string sfp)
        {
            FilePath = sfp;
            Interface = sc;
            FileName = sfn;
        }
    }

    public class PluginFunctions : IPluginFunctions
    {
        f_main parent;

        public string CurrentDocFilePath
        {
            get { return parent.cur_cd.FilePath; }
        }

        public string CurrentDocFileName
        {
            get { return Path.GetFileName(parent.cur_cd.FilePath); }
        }

        public string GetHighlightedText
        {
            get { return parent.cur_cd.Interface.Selection.Text; }
        }

        public PluginFunctions(f_main prt)
        {
            parent = prt;
        }

        public bool InsertText(string Text)
        {
            if (parent.cur_cd.Interface.Selection.Text != "")
            {
                parent.cur_cd.Interface.Selection.Text = Text;
                return true;
            }
            parent.cur_cd.Interface.InsertText(Text);
            return true;
        }

        public bool InsertText(string Text, int linenum)
        {
            if (linenum < 0 && linenum > parent.cur_cd.Interface.Lines.Count) return false;
            parent.cur_cd.Interface.GoTo.Line(linenum - 1);
            return InsertText(Text);
        }

        public string GetTextFromLine(int linenum)
        {
            return parent.cur_cd.Interface.Lines[linenum - 1].Text;
        }

        public int GetInstancesOfFunction(string function)
        {
            return Parser.GetFunctionsInCode(parent.cur_cd.Interface.Text, function);
        }
    }

    /// <summary>
    /// Functions used in f_main, mostly Scintilla stuff.
    /// </summary>
    public class Functions
    {
        public PluginFunctions pf;

        public List<IPlugin> plugins = new List<IPlugin>();
        List<string> lst, lite;
        System.Windows.Forms.ImageList ico = new System.Windows.Forms.ImageList();
        //string mig = "static char *_____________[] = {\"16 11 73 1\",\"  c #712472\",\". c #752775\",\"X c #7A2B7B\",\"o c #7C2D7D\",\"O c #7C2E7C\",\"+ c #7E2E7E\",\"@ c #7E307F\",\"# c #7F3080\",\"$ c #8D358E\",\"% c #953896\",\"& c #9C3C9D\",\"* c #9F3C9F\",\"= c #8E468F\",\"- c #904E91\",\"; c #965297\",\": c #A74FA8\",\"> c #A650A7\",\", c #A850A9\",\"< c #A950AA\",\"1 c #A952AA\",\"2 c #BB6FBC\",\"3 c #BC70BD\",\"4 c #CB67CC\",\"5 c #D16AD2\",\"6 c #D26BD3\",\"7 c #D16DD2\",\"8 c #D36ED4\",\"9 c #D56FD5\",\"0 c #8A99AE\",\"q c #98A4AE\",\"w c #9CA7AE\",\"e c #ACB5AD\",\"r c #ACB4AE\",\"t c #B5BBAD\",\"y c #C1C4AC\",\"u c #CCCEAC\",\"i c #D5D5AC\",\"p c #E5E2AB\",\"a c #E9E5AB\",\"s c #F7F0AB\",\"d c #CF88CF\",\"f c #DD98DE\",\"g c #E698E7\",\"h c #E990EA\",\"j c #EB91EC\",\"k c #EE9DEF\",\"l c #FA98FB\",\"z c #FA99FB\",\"x c #FA9BFB\",\"c c #FA9FFB\",\"v c #E3ACE3\",\"b c #E2AFE2\",\"n c #EEA5EF\",\"m c #EEBEEE\",\"M c #FAABFB\",\"N c #FAAEFB\",\"B c #E4CAE4\",\"V c #E6CCE6\",\"C c #E8D1E8\",\"Z c #EBD1EB\",\"A c #ECD2EC\",\"S c #EDD8ED\",\"D c #F0D4F0\",\"F c #F0D5F0\",\"G c #F2DBF2\",\"H c #F0E3F0\",\"J c #F2E0F3\",\"K c #F3E3F3\",\"L c #F4E6F4\",\"P c #F9F7F9\",\"I c gray98\",\"U c gray99\",\"Y c gray100\",\"YYYYYYYYGdHYYYYY\",\"YYYYYYYGdbdKYYYY\",\"YYYYYYAdmMjdHYYY\",\"Ysir0YdbMllhdLYY\",\"YYYYYY:2nlllg-UY\",\"aiyrqY:73nck;oIY\",\"YYYYYY1593f=&oIY\",\"sputwYB178#*$oPY\",\"YYYYYYYC14o%XDYY\",\"YYYYYYYYS,#.AYYY\",\"YYYYYYYYYA VYYYY\"};";
        public Functions()
        {
            ico.Images.Add(SAMPCE.Properties.Resources.VSObject_MethodW);
            ico.Images.Add(SAMPCE.Properties.Resources.VSObject_Type);
            lst = new List<string>();
            lite = new List<string>();
        }

        public bool AddFunction(string func)
        {
            lite.Add(func);
            lst.Add(func + "?0");
            return true;
        }

        public void LoadPlugins(f_main parent)
        {
            pf = new PluginFunctions(parent);
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\plugins");
            if (di.Exists == false)
            {
                try { di.Create(); }
                catch (IOException) { MessageBox.Show("Please create a \'plugins\' folder in " + di.Parent, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            }
            foreach (FileInfo f in di.GetFiles("*.dll"))
            {
                Assembly asm = Assembly.LoadFile(f.FullName);
                foreach (Type type in asm.GetTypes())
                {
                    if (type.GetInterface("IPlugin") != null)
                    {
                        IPlugin inst = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(inst);
                        System.Windows.Forms.ToolStripMenuItem tsmi = new ToolStripMenuItem(inst.Name);
                        tsmi.Click += new EventHandler(inst.LoadPluginGUI);
                        parent.AddToolStripMenuItem(tsmi);
                        inst.parent = pf;
                    }
                }
            }
        }

        #region Scintilla Initialization stuff
        public ScintillaNet.Scintilla InitSC(string InitialText)
        {
            ScintillaNet.Scintilla sc = new ScintillaNet.Scintilla();
            sc.ConfigurationManager.CustomLocation = "cpp.xml";
            sc.ConfigurationManager.Language = "cpp";
            sc.Dock = System.Windows.Forms.DockStyle.Fill;
            sc.Font = SAMPCE.Properties.Settings.Default.font;
            sc.Indentation.ShowGuides = true;
            sc.Indentation.SmartIndentType = ScintillaNet.SmartIndent.CPP2;
            sc.Indentation.TabWidth = 5;
            sc.IsBraceMatching = true;
            sc.Lexing.Lexer = ScintillaNet.Lexer.Cpp;
            sc.Lexing.SetKeywords(1, lst.ToString());
            sc.Lexing.LexerName = "cpp";
            sc.Lexing.LineCommentPrefix = "";
            sc.Lexing.StreamCommentPrefix = "";
            sc.Lexing.StreamCommentSufix = "";
            sc.Location = new System.Drawing.Point(0, 0);
            sc.Margins.Margin0.Width = 30;
            sc.Margins.Margin2.Width = 15;
            sc.Text = InitialText;
            sc.Scrolling.HorizontalWidth = 480;
            sc.Size = new System.Drawing.Size(624, 371);
            sc.Styles.BraceBad.FontName = "Verdana";
            sc.Styles.BraceLight.FontName = "Verdana";
            sc.Styles.ControlChar.FontName = "Verdana";
            sc.Styles.Default.FontName = "Verdana";
            sc.Styles.IndentGuide.FontName = "Verdana";
            sc.Styles.LastPredefined.FontName = "Verdana";
            sc.Styles.LineNumber.FontName = "Verdana";
            sc.Styles.Max.FontName = "Verdana";
            sc.Lexing.SetKeywords(1,string.Join(" ",lite.ToArray()));
            lst.Sort();
            sc.AutoComplete.List.AddRange(lst);
            sc.AutoComplete.RegisterImages(ico);
            sc.AutoComplete.AutomaticLengthEntered = true;
            sc.AutoComplete.DropRestOfWord = true;
            sc.AutoComplete.AutoHide = false;
            sc.Indicators[0].Color = Color.Red;
            return sc;
        }
        #endregion
    }
}
