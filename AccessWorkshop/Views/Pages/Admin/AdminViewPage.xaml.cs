using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccessWorkshop.Views.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminViewPage.xaml
    /// </summary>
    public partial class AdminViewPage : Page
    {
        public AdminViewPage()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти из режима Администратора?", "Пожалуйста подтвердите свои действия.", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                NavigationService.GoBack();
        }
    }
}
