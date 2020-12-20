using AccessWorkshop.Classes;
using AccessWorkshop.Context;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AccessWorkshop.Views.Pages.Start
{
    /// <summary>
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
            LoadDataFromDB.dbRefresh(dbDataView);
            LoadDataFromDB.LoadWorkshop(cmb_WorkShop);
        }

        private void cmb_WorkShop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dbDataView.ItemsSource = dbContext.db.Students.Where(item => item.WorkShop.Compitation == cmb_WorkShop.SelectedItem.ToString()).ToList();
        }

        private void btn_ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            LoadDataFromDB.dbRefresh(dbDataView);
        }

        private void txb_Searh_TextChanged(object sender, TextChangedEventArgs e)
        {
            dbDataView.ItemsSource = dbContext.db.Students.Where(Item => Item.FirstName.Contains(txb_Searh.Text) || Item.LastName.Contains(txb_Searh.Text) ||
            Item.Patronymic.Contains(txb_Searh.Text) || Item.Phone.Contains(txb_Searh.Text) || Item.Group.GroupID.ToString().Contains(txb_Searh.Text)).ToList();
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            Export.Print(dbDataView, "Данные студентов");
        }

        private void btn_GetAccess_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ExportTXT_Click(object sender, RoutedEventArgs e)
        {
            Export.ExportToTXT(dbDataView);
        }
    }
}
