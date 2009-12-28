using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginManager
{
    public interface IPlugin
    {
        string Name { get; }
        string Version { get; }
        string Author { get; }
        string Desc { get; }
        IPluginFunctions parent { get; set; }

        void LoadPlugin();
        void LoadPluginGUI(object obj, EventArgs e);
        System.Windows.Forms.UserControl LoadPluginSettings();
        void UnloadPlugin();
    };

    public interface IPluginFunctions
    {
        /// <summary>
        /// This will retrieve the current file's path.
        /// </summary>
        string CurrentDocFilePath { get; }
        /// <summary>
        /// This will get any text which is highlighted!
        /// </summary>
        string GetHighlightedText { get; }

        /// <summary>
        /// Retrieves the text from a specific line.
        /// </summary>
        /// <param name="linenum">The line number. Minimum is 1.</param>
        /// <returns>The text, if available</returns>
        string GetTextFromLine(int linenum);
        /// <summary>
        /// Inserts text into current document at the cursor position.
        /// </summary>
        /// <param name="Text">Text you want to insert! Use \r\n for multiple lines.</param>
        /// <returns>true if succeed. false if you know what!</returns>
        bool InsertText(string Text);
        /// <summary>
        /// Inserts text into current document.
        /// </summary>
        /// <param name="Text">Text you want to insert! Use \r\n for multiple lines.</param>
        /// <param name="linenum">The line number in which to insert the text to!</param>
        /// <returns>true if succeed. false if you know what!</returns>
        bool InsertText(string Text, int linenum);
        /// <summary>
        /// Retrieves the number of times a function appears.
        /// </summary>
        /// <param name="function">The function to search</param>
        /// <returns>Number of occurences</returns>
        int GetInstancesOfFunction(string function);
    };
}
