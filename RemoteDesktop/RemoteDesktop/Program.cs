using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktop
{
    class Program
    {
        // regedit
        // \HKEY_CURRENT_USER\Software\Classes\

        const string UriScheme = "RemoteDesktopProtocol";
        const string path = "C:\\Windows\\system32\\mstsc.exe";

        static void Main(string[] args)
        {
            RegisterURLProtocol(UriScheme, path);
        }

        public static void RegisterURLProtocol(string protocolName, string applicationPath)
        {
            try
            {
                var KeyTest = Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey("Classes", true);
                RegistryKey key = KeyTest.CreateSubKey(protocolName);
                key.SetValue("URL Protocol", protocolName);
                key.CreateSubKey(@"shell\open\command").SetValue("", "\"" + applicationPath + "\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
