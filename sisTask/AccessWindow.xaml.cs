using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;


namespace sisTask
{
    /// <summary>
    /// Логика взаимодействия для AccessWindow.xaml
    /// </summary>
    public partial class AccessWindow : Window
    {
        public AccessWindow()
        {
            InitializeComponent();
            Task();
        }

        public void Task()
        {
            TaskGrid.ItemsSource = Helper.db.Tasks.Where(t => t.IdStatus == 2).Include(u => u.IdAuthorNavigation).ToList();
        }

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            new HomeWindow().Show();
            this.Close();
        }

        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            new HistoryWindow().Show();
            this.Close();
        }

        private void ProfilesBtn_Click(object sender, RoutedEventArgs e)
        {
            new ProfilesWindow().Show();
            this.Close();
        }

        private void TaskGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Task selectedTask = TaskGrid.SelectedItem as Task;
            Helper.task = selectedTask;
            new TaskWindow(selectedTask).Show();
            this.Close();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = Helper.db.Users.FirstOrDefault(q => q.Login == Search.Text);
            if (user != null)
            {
                Task taskSearch = Helper.db.Tasks.FirstOrDefault(q => q.IdAuthor == user.Id);
                Helper.task = taskSearch;
                new SearchWindow(taskSearch).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        public void Result()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "report";
            saveFile.Filter = "Excel files |*.xlsx|Docx files |*.docx|Pdfs files |*.pdf";
            if (saveFile.ShowDialog() == true)
            {
                switch (saveFile.FilterIndex)
                {
                    case 1:
                        Excel.Application app = new Excel.Application();
                        Excel.Workbook workbook = app.Workbooks.Add();
                        Excel.Worksheet worksheet = (Excel.Worksheet)app.Worksheets[1];
                        worksheet.Name = "Задания";
                        worksheet.Range["A1"].Value = "ID";
                        worksheet.Range["B1"].Value = "Название";
                        worksheet.Range["C1"].Value = "Описание";
                        worksheet.Range["D1"].Value = "Дата";
                        worksheet.Range["E1"].Value = "Выполнил";
                        worksheet.Range["F1"].Value = "Автор";
                        worksheet.Range["G1"].Value = "Статус";
                        List<Task> tasks = Helper.db.Tasks.ToList();
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            if (tasks[i] != null)
                            {
                                worksheet.Range[$"A{i + 2}"].Value = tasks[i].Id;
                                worksheet.Range[$"B{i + 2}"].Value = tasks[i].Title;
                                worksheet.Range[$"C{i + 2}"].Value = tasks[i].Writing;
                                worksheet.Range[$"D{i + 2}"].Value = tasks[i].Data;
                                worksheet.Range[$"E{i + 2}"].Value = tasks[i].IdWorkerNavigation.Login;
                                worksheet.Range[$"F{i + 2}"].Value = tasks[i].IdAuthorNavigation.Login;
                                worksheet.Range[$"G{i + 2}"].Value = tasks[i].IdStatusNavigation.Title;
                            }
                        }
                        workbook.SaveAs(saveFile.FileName);
                        workbook.Close();
                        app.Quit();
                        break;
                    case 2:
                    case 3:
                        Word.Application app1 = new Word.Application();
                        Word.Document document1 = app1.Documents.Add();
                        List<Task> tasks1 = Helper.db.Tasks.ToList();
                        Word.Paragraph paragraph1 = document1.Paragraphs.Add();
                        Word.Range range1 = paragraph1.Range;
                        Word.Table table1 = document1.Tables.Add(range1, tasks1.Count + 1, 7);
                        Word.Range cellRange1;
                        cellRange1 = table1.Cell(1, 1).Range;
                        cellRange1.Text = "Id";
                        cellRange1 = table1.Cell(1, 2).Range;
                        cellRange1.Text = "Название";
                        cellRange1 = table1.Cell(1, 3).Range;
                        cellRange1.Text = "Описание";
                        cellRange1 = table1.Cell(1, 4).Range;
                        cellRange1.Text = "Дата";
                        cellRange1 = table1.Cell(1, 5).Range;
                        cellRange1.Text = "Выполнил";
                        cellRange1 = table1.Cell(1, 6).Range;
                        cellRange1.Text = "Автор";
                        cellRange1 = table1.Cell(1, 7).Range;
                        cellRange1.Text = "Статус";

                        for (int i = 0; i < tasks1.Count; i++)
                        {
                            cellRange1 = table1.Cell(i + 2, 1).Range;
                            cellRange1.Text = tasks1[i].Id.ToString();
                            cellRange1 = table1.Cell(i + 2, 2).Range;
                            cellRange1.Text = tasks1[i].Title;
                            cellRange1 = table1.Cell(i + 2, 3).Range;
                            cellRange1.Text = tasks1[i].Writing;
                            cellRange1 = table1.Cell(i + 2, 4).Range;
                            cellRange1.Text = tasks1[i].Data.ToString();
                            cellRange1 = table1.Cell(i + 2, 5).Range;
                            cellRange1.Text = tasks1[i].IdWorkerNavigation.Login;
                            cellRange1 = table1.Cell(i + 2, 6).Range;
                            cellRange1.Text = tasks1[i].IdAuthorNavigation.Login;
                            cellRange1 = table1.Cell(i + 2, 7).Range;
                            cellRange1.Text = tasks1[i].IdStatusNavigation.Title;
                        }
                        if (saveFile.FilterIndex == 2)
                        {
                            document1.SaveAs2(saveFile.FileName);
                        }
                        else
                        {
                            document1.SaveAs2(saveFile.FileName, Word.WdSaveFormat.wdFormatPDF);
                        }
                        //document1.Close();
                        app1.Quit();
                        break;
                }
            }
        }
        private void ResulteBtn_Click(object sender, RoutedEventArgs e)
        {
            Result();
        }
    }
}
