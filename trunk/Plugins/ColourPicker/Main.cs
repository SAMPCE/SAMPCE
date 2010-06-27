using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PluginManager;
using System.Windows.Forms;

namespace ColourPicker
{
    public class Main : IPlugin
    {
        IPluginFunctions main;

        public string Name
        {
            get { return "Colour Picker"; }
        }

        public string Version
        {
            get { return "1.0.0.1"; }
        }

        public string Author
        {
            get { return "Skaty"; }
        }

        public string Desc
        {
            get { return "This plugin allows you to choose your colours and insert them into your code! Very spiffy!"; }
        }

        public void LoadPlugin()
        {
            throw new NotImplementedException();
        }

        public void LoadPluginGUI(object obj, EventArgs e)
        {
            GUI gui = new GUI(main);
            gui.ShowDialog();
            return;
        }

        public UserControl LoadPluginSettings()
        {
            Config config = new Config();
            return config;
        }

        public void UnloadPlugin()
        {
            throw new NotImplementedException();
        }

        public IPluginFunctions parent
        {
            get
            {
                return main;
            }
            set
            {
                main = value;
            }
        }
    }
}
