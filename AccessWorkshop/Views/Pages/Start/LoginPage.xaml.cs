using AccessWorkshop.Context;
using AccessWorkshop.Model;
using AccessWorkshop.Views.Pages.Admin;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace AccessWorkshop.Views.Pages.Start
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
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
                            break;

                        case "H":

                            break;
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
