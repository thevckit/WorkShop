using AccessWorkshop.Context;
using System.Linq;
using System.Windows.Controls;

namespace AccessWorkshop.Classes
{
    public static class LoadDataFromDB
    {
        public static void LoadWorkshop(ComboBox comboBox)
        {
            var query = dbContext.db.WorkShops.Select(item => new
            {
                Title = item.Compitation
            });
            var collection = from item in query select item.Title;
            comboBox.ItemsSource = collection.ToList();
        }
        public static void dbRefresh(DataGrid dataGrid)
        {
            dataGrid.ItemsSource = dbContext.db.Students.ToList();
        }
    }
}
