using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace sisTask
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public HistoryWindow()
        {
            InitializeComponent();
            History();
        }
        public void History()
        {
            HistoryGrid.ItemsSource = Helper.db.Tasks.Where(q => q.IdWorker == Helper.userSession.Id && q.IdStatus == 1 || q.IdStatus == 3).Include(t => t.IdStatusNavigation).Include(t => t.IdAuthorNavigation).ToList();
        }
        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            new HomeWindow().Show();
            this.Close();
        }

        private void ProfilesBtn_Click(object sender, RoutedEventArgs e)
        {
            new ProfilesWindow().Show();
            this.Close();
        }

        private void AccessBtn_Click(object sender, RoutedEventArgs e)
        {
            new AccessWindow().Show();
            this.Close();
        }

        private void HistoryGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Task selectedTask = HistoryGrid.SelectedItem as Task;
            Helper.task = selectedTask;
            new HistoryTaskWindow(selectedTask).Show();
            this.Close();
        }

       
    }
}
