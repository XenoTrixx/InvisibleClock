using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;
using InvisibleClock.ApplicationSettings;

namespace InvisibleClock
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App Application;
        public static ClockWindow Clock;
        public static NotifyIcon NotifyIcon;
        public static Settings Settings;
        public static string SettingsPath = Path.GetFullPath("assets/settings.json");


        void App_Startup(object sender, StartupEventArgs e)
        {
            Application = this;

            GetConfig();

            Clock = new ClockWindow();
            NotifyIcon = new NotifyIcon();

            NotifyIcon.Show();
            Clock.Show();
        }

        public static void ReloadClock()
        {
            Settings = null;
            GetConfig();

            Clock.Close();
            Clock = new ClockWindow();
            Clock.Show();
        }
        public static void SaveSettings()
        {
            using (FileStream fs = File.Create(SettingsPath))
            {
                JsonSerializer.SerializeAsync<Settings>(fs, Settings);
            }
        }


        /// <summary>
        /// Checks if the config exists
        /// if not it will create a new one
        /// </summary>
        /// <returns></returns>
        private static void GetConfig()
        {
            if (System.IO.File.Exists(@"./assets/settings.json"))
            {
                try
                {
                    Settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText(SettingsPath));
                }
                catch (Exception)
                {
                    CreateNewSettingsFile();
                }
            } 
            else
            {
                CreateNewSettingsFile();
            }
        }

        private static void CreateNewSettingsFile()
        {
            Settings = new Settings();

            Settings.Window = new ApplicationSettings.Window();
            Settings.Window.TransparentBackground = true;
            Settings.Window.BackgroundColor = "#AAAAAA";
            Settings.Window.IsForeGround = true;
            Settings.Window.Width = 235;
            Settings.Window.Height = 90;

            Settings.Position = new ApplicationSettings.Position();
            Settings.Position.Standard = true;
            Settings.Position.Top = 800;
            Settings.Position.Left = 1000;

            Settings.Font = new ApplicationSettings.Font();
            Settings.Font.Color = "#FFFFFF";
            Settings.Font.Size = 50;
            Settings.Font.Family = "Arial";

            Settings.Time = new ApplicationSettings.Time();
            Settings.Time.Interval = 1000;
            Settings.Time.Format = "HH:mm:ss";

            SaveSettings();
        }
    }
}
