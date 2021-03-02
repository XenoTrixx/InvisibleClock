using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace InvisibleClock
{
    /// <summary>
    /// Interaktionslogik für NotifyIcon.xaml
    /// </summary>
    public partial class NotifyIcon : Window
    {
        public NotifyIcon()
        {
            InitializeComponent();
        }

        private void EndApplication_Click(object sender, RoutedEventArgs e)
        {
            App.Application.Shutdown();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe",  Path.GetFullPath("assets/settings.json"));
        }

        private void LoadSettings_Click(object sender, RoutedEventArgs e)
        {
            App.ReloadClock();
        }
        
        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            App.Settings.Position.Standard = false;
            App.Settings.Position.Top = (int)App.Clock.Top;
            App.Settings.Position.Left = (int)App.Clock.Left;
            App.SaveSettings();
        }
    }
}
