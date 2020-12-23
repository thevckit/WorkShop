using System.Windows.Controls;

namespace AccessWorkshop.Classes
{
    public static class HelperObject
    {
        public static void RememberMe(CheckBox checkBox, TextBox textBox)
        {
            if (checkBox.IsChecked == true)
            {
                Properties.Settings.Default.EventTask = textBox.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.EventTask = "";
                Properties.Settings.Default.Save();
            }
        }
    }
}
