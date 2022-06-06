using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace sisTask
{
    /// <summary>
    /// Логика взаимодействия для HistoryTaskWindow.xaml
    /// </summary>
    public partial class HistoryTaskWindow : Window
    {
        public HistoryTaskWindow(Task selectedTask)
        {
            InitializeComponent();
            Task addTask = new Task();
            addTask = Helper.task;
            DataContext = addTask;
        }

        private void phonesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;    
        }

        private void AccessBtn_Click(object sender, RoutedEventArgs e)
        {
            if(phonesList.Text == "Готово")
            {
                Helper.task.IdStatus = 1;
            }
            else if (phonesList.Text == "Свободно")
            {
                Helper.task.IdStatus = 2;
            }
            else if (phonesList.Text == "Выполняется")
            {
                Helper.task.IdStatus = 3;
            }
            Helper.db.SaveChanges();
            MessageBox.Show("Статус изменён");
            new HistoryWindow().Show();
            this.Close();

        }
       

    }
}
