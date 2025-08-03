using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace WebView2Launcher
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string url = null;
            string userDataFolder = null;
            string runtimePath = null;
            string iconArg = null;
            int width = 512;
            int height = 512;

            foreach (string arg in args)
            {
                if (arg.StartsWith("--url="))
                    url = arg.Substring("--url=".Length);
                else if (arg.StartsWith("--userdata="))
                    userDataFolder = arg.Substring("--userdata=".Length);
                else if (arg.StartsWith("--runtime="))
                    runtimePath = arg.Substring("--runtime=".Length);
                else if (arg.StartsWith("--icon="))
                    iconArg = arg.Substring("--icon=".Length);
                else if (arg.StartsWith("--width="))
                    int.TryParse(arg.Substring("--width=".Length), out width);
                else if (arg.StartsWith("--height="))
                    int.TryParse(arg.Substring("--height=".Length), out height);
            }

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            if (string.IsNullOrEmpty(url))
            {
                string htmlPath = Path.Combine(baseDir, "assets", "default.html");
                url = $"file:///{htmlPath.Replace("\\", "/")}";
            }

            string iconPath = string.IsNullOrEmpty(iconArg)
                ? Path.Combine(baseDir, "assets", "favicon.ico")
                : Path.IsPathRooted(iconArg)
                    ? iconArg
                    : Path.Combine(baseDir, iconArg);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form form = new Form
            {
                Width = width,
                Height = height,
                Text = "WebView2 Launcher"
            };

            try
            {
                form.Icon = new Icon(iconPath);
            }
            catch
            {
                MessageBox.Show("Could not load the icon: " + iconPath);
            }

            WebView2 webView = new WebView2 { Dock = DockStyle.Fill };
            form.Controls.Add(webView);

            form.Shown += async (sender, e) =>
            {
                CoreWebView2Environment env = null;

                if (!string.IsNullOrEmpty(runtimePath) || !string.IsNullOrEmpty(userDataFolder))
                {
                    env = await CoreWebView2Environment.CreateAsync(
                        browserExecutableFolder: runtimePath,
                        userDataFolder: userDataFolder
                    );
                }

                await webView.EnsureCoreWebView2Async(env);
                webView.CoreWebView2.Navigate(url);
            };

            Application.Run(form);
        }
    }
}