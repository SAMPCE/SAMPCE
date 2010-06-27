Colour Picker Plug-in
version 1.0 by Skaty
=====================
Description: This is just to demonstrate how to use the in built
plugin system bundled with new SAM[P]CE.
=====================

---------------------
How to hook up to the IDE
---------------------
You should reference the file "PluginManager.dll" before getting started. This may be found in the folder where you can find newPAWN.exe.
This will add a namespace called PluginManager, reference that in your main class file.

Also, please note that the main function (entry) must inherit IPlugin like so:
public class <whatever> : IPlugin

Also click on "IPlugin" and hover around until you see a rectangle. Click on it, and select "Implement interface IPlugin".
If you cannot do that, use the ColourPicker's Main.cs and edit the file to your liking!

There is also an IPluginFunction called parent, which will provide you with a bunch of functions
for you to further access the IDE. This would be useful if you need to know the location of the current PAWN script, insert
a text into the editor or even provide further functionality!

To find out more, contact your local IntelliSense or your local Object Browser or directly view the PluginManager's Interfaces.cs source code.

---------------------
GUI
---------------------
The plugin system allows a GUI to be hooked up once a user opens your plugin in the IDE.
The included GUI.cs is basically a Form that you would usually build if "SAM[P]CE" does not exist!

To do this, just add relevant code to the LoadPluginGUI() function.
Make sure that the GUI is able to use IPluginFunction, so that you can fully use the IDE's plugin system!

---------------------
Config
---------------------
Just to mention. Plugins can have a small settings page, which is compulsory by passing a UserControl to the LoadPluginSettings() function.
Please note, you will have to find a way to save those settings, sorry. Also, your current directory is not plugins, but the .exe directory.

---------------------
Notes
---------------------
Any questions? Don't ask on the thread, it would not be seen anyways. Click on the link in my signature to find support.
Any ideas, suggestions? Say it on the thread.

Thank you for supporting my big and nice app! :)