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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            
        }
        private void RegIBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTBox.Text !="" && PasswordPBox.Password != "" && SecondNameBox.Text != "" && NameBox.Text != "" && PatricBox.Text != "" && NumberBx.Text.Length == 10)
            {
                //Регистрация выполнена успешно
                User users = new User()
                {
                    SecondName = SecondNameBox.Text,
                    Name = NameBox.Text,
                    Patric = PatricBox.Text,
                    Login = LoginTBox.Text,
                    Password = PasswordPBox.Password,
                    NumberPhone = NumberBx.Text
                };
                Helper.db.Users.Add(users);
                Helper.db.SaveChanges();
                MessageBox.Show("Регистрация завершена");
                new AccessWindow().Show();
                this.Close();
            }
            else MessageBox.Show("Ошибка в ведённых данных");
        }
    }
}
