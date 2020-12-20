using AccessWorkshop.Views.Pages.Start;
using System;
using System.Windows;
using System.Windows.Threading;

namespace AccessWorkshop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new InfoPage());

            DispatcherTimer LiveTimer = new DispatcherTimer();
            LiveTimer.Interval = TimeSpan.FromSeconds(1);
            LiveTimer.Tick += LiveTimer_Tick;
            LiveTimer.Start();
        }

        private void LiveTimer_Tick(object sender, EventArgs e)
        {
            txb_Time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
