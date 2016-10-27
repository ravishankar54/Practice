using System;
using System.Net;
using System.Threading;
using System.Windows;

namespace ReliableWPFApplication
{
    public partial class MainWindow : Window
    {
        private int count = 1;
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
        }

        private void RssButton_Click(object sender, RoutedEventArgs e)
        {
            BusyIndicator.Visibility = Visibility.Visible;

            RssButton.IsEnabled = false;

            var client = new WebClient();
            
            client.DownloadStringAsync(new Uri("http://www.filipekberg.se/rss/"));

            client.DownloadStringCompleted += Client_DownloadStringCompleted;
        }

        private void Client_DownloadStringCompleted(object sender, 
            DownloadStringCompletedEventArgs e)
        {
            RssText.Text = e.Result;

            BusyIndicator.Visibility = Visibility.Hidden;

            RssButton.IsEnabled = true;
        }

        private void CounterButton_Click(object sender, RoutedEventArgs e)
        {
            CounterText.Text = $"Counter: {count++}";
        }
    }
}
