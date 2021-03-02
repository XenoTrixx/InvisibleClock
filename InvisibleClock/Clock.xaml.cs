using InvisibleClock.ApplicationSettings;
using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace InvisibleClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClockWindow : System.Windows.Window
    {
        public ClockWindow()
        {
            InitializeComponent();

            if (App.Settings.Position.Standard == true)
            {
                this.Left = (SystemParameters.PrimaryScreenWidth / 2) - App.Settings.Window.Width;
                this.Top = (SystemParameters.PrimaryScreenHeight / 2) - App.Settings.Window.Height;
            } else
            {
                this.Left = App.Settings.Position.Left;
                this.Top = App.Settings.Position.Top;
            }

            this.timeLable.FontSize = App.Settings.Font.Size;
            this.timeLable.FontFamily = new FontFamily(App.Settings.Font.Family);
            this.timeLable.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(App.Settings.Font.Color));

            if (App.Settings.Window.TransparentBackground == true)
            {
                this.Background = Brushes.Transparent;
            } else
            {
                this.timeLable.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(App.Settings.Window.BackgroundColor));
            }

            this.Topmost = App.Settings.Window.IsForeGround;
            this.Width = App.Settings.Window.Width;
            this.Height = App.Settings.Window.Height;

            Timer timer = new Timer(App.Settings.Time.Interval);
            timer.Elapsed += Update_Clock;
            timer.AutoReset = true;
            timer.Start();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Update_Clock (Object obj, ElapsedEventArgs elapsedEventArgs)
        {
            //Dispatcher.Invoke((Action)delegate () {
            //    this.timeLable.Content = DateTime.Now.ToString(App.Settings.Time.Format);
            //});

            System.Windows.Application.Current.Dispatcher.Invoke(delegate {
                this.timeLable.Content = DateTime.Now.ToString(App.Settings.Time.Format);
            });
        }
    }
}
