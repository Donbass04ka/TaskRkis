using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace sisTask
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public TaskWindow(Task selectedTask)
        {
            InitializeComponent();
            selectedTask = Helper.task;
            DataContext = selectedTask;
        }
 

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Task addTask = new Task();
            addTask = Helper.task;
            DataContext = addTask;
            addTask.IdStatus = 3;
            addTask.IdWorker = Helper.userSession.Id;
            Helper.db.SaveChanges();
            MessageBox.Show("Задание добавлено в вашу историю");
            new AccessWindow().Show();
            this.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new AccessWindow().Show();
            this.Close();
        }
    }
}
