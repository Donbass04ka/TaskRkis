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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTBox.Text == "" || PasswordPBox.Password == "")
            {
                MessageBox.Show("Введите логин и пароль");
            }
            else
            {
                User user = Helper.db.Users.FirstOrDefault(q => q.Login == LoginTBox.Text && q.Password == PasswordPBox.Password);
                if (user != null)
                {
                    Helper.userSession = user;
                    new AccessWindow().Show(); //Открытие авторизации
                    this.Close();

                    Helper.userSession = user;
                }
                else
                {
                    MessageBox.Show("Неправильные логин или пароль");
                }
            }
        }
        private void RegInBtn_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationWindow().Show();
            this.Close();
        }
    }
}
