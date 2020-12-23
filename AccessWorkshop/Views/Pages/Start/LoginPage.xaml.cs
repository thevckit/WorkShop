using AccessWorkshop.Classes;
using AccessWorkshop.Context;
using AccessWorkshop.Views.Pages.Admin;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace AccessWorkshop.Views.Pages.Start
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private static int ErrorCount = 3;
        private static int Time = 30;
        private DispatcherTimer BlockTimer = new DispatcherTimer();
        public LoginPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.EventTask != string.Empty)
                txb_Username.Text = Properties.Settings.Default.EventTask;
            BlockTimer.Tick += BlockTimer_Tick;

            if ((DateTime.Now - Properties.Settings.Default.BlockTimer).Ticks < new TimeSpan(0, 0, Time).Ticks)
            {
                this.IsEnabled = false;
                BlockTimer.Start();
            }
        }

        private void BlockTimer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - Properties.Settings.Default.BlockTimer).Ticks > new TimeSpan(0, 0, Time).Ticks)
            {
                this.IsEnabled = true;
                ErrorCount = 3;
                BlockTimer.Stop();
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var CurrentLoginUser = dbContext.db.Users.FirstOrDefault(item => item.Email == txb_Username.Text &&
                item.Password == psb_Password.Password);
                if (CurrentLoginUser != null)
                {
                    switch (CurrentLoginUser.IDRole)
                    {
                        case "A":
                            MessageBox.Show($"Добро пожаловать в систему {CurrentLoginUser.FirstName} {CurrentLoginUser.LastName}!",
                                "Авторизация прошла успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new AdminViewPage());
                            HelperObject.RememberMe(chk_RememberMe, txb_Username);
                            break;

                        case "H":

                            break;
                    }
                }
                else
                {
                    ErrorCount--;
                    if (ErrorCount == 0)
                    {
                        MessageBox.Show($"Извините, но введённые вами данные являются неверными. Пожалуйста повторите попыткую через {Time} секунд, у вас осталось {ErrorCount} попыток.",
                            "Ошибка при Авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.IsEnabled = false;
                        Properties.Settings.Default.BlockTimer = DateTime.Now;
                        Properties.Settings.Default.Save();
                        BlockTimer.Start();
                    }
                    else
                    {
                        throw new Exception($"Извините, но введённые вами данные являются неверными. Пожалуйста повторите попыткую. Имейти ввиду, что количество попыток ограничено, у вас осталось {ErrorCount} попыток.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
