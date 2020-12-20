using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccessWorkshop.Classes
{
    public static class Export
    {
        public static void Print(DataGrid dataGrid, string Title)
        {
            PrintDialog Printdlg = new PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                dataGrid.Measure(pageSize);
                dataGrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dataGrid, Title);
            }
        }

        public static void ExportToTXT(DataGrid dataGrid)
        {
            try
            {
                dataGrid.SelectAllCells();
                dataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
                ApplicationCommands.Copy.Execute(null, dataGrid);
                dataGrid.UnselectAllCells();

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "TXT (*.txt)|*.txt";
                save.FileName = "Data.txt";
                bool fileError = false;
                if (save.ShowDialog() == true)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            string path1 = save.FileName;
                            string result1 = (string)Clipboard.GetText(TextDataFormat.Text);
                            Clipboard.Clear();
                            StreamWriter stream = new StreamWriter(path1);
                            stream.WriteLine(result1);
                            stream.Close();
                            if (MessageBox.Show($"Сохранение данных прошла успешно! По этому пути {save.FileName}. Открыть ФАЙЛ?", "Сохранено!",
                                 MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                string path = Assembly.GetExecutingAssembly().Location;
                                Process.Start(save.FileName);
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }
    }
}
