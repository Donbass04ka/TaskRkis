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
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            User profileUser = new User();
            profileUser = Helper.userSession;
            DataContext = profileUser;
        }
       
        private void ProfilesBtn_Click(object sender, RoutedEventArgs e)
        {
            new ProfilesWindow().Show();
            this.Close();
        }
        private void HistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            new HistoryWindow().Show();
            this.Close();
        }
        private void AccessBtn_Click(object sender, RoutedEventArgs e)
        {
            new AccessWindow().Show();
            this.Close();
        }

 
        
    }
}
