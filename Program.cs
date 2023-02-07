using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OpenWebsiteInGoogleChrome
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;

        static void Main(string[] args)
        {
            // URL of the website you want to open
            string websiteUrl = "https://www.google.com";

            // Check if Google Chrome is already open
            Process[] processes = Process.GetProcessesByName("chrome");
            if (processes.Length > 0)
            {
                // If Google Chrome is open, open the website in a new tab
                Process.Start("chrome.exe", "--new-tab " + websiteUrl);
            }
            else
            {
                // If Google Chrome is not open, open the browser and the website
                Process.Start("chrome.exe", websiteUrl);
            }

            // Hide the console window
            IntPtr hWnd = GetConsoleWindow();
            ShowWindow(hWnd, SW_HIDE);
        }
    }
}
