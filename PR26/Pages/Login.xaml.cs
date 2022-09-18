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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PR26.Extensions;
using ModelDB.Core;
using System.IO;

namespace PR26.Pages
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Auth(TextBoxLogin.Text, Password.Password);
        }

        public bool Auth(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!");
                return false;
            }
            using (var db = new DataContext())
            {
                password = GetHashSHA.GetHash(password);
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == login 
                            && u.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return false;
                }

                MessageBox.Show("Пользователь успешно найден!");
                TextBoxLogin.Clear();
                Password.Clear();

                //Переход на страницу меню для определенной роли пользователя
                switch (user.UserRole)
                {
                    case ModelDB.Core.Enum.Role.Admin:
                        NavigationService?.Navigate(new Admin());
                        break;
                    case ModelDB.Core.Enum.Role.Accountant:
                        NavigationService?.Navigate(new Accountant());
                        break;
                    case ModelDB.Core.Enum.Role.Cashier:
                        NavigationService?.Navigate(new Cashier());
                        break;
                }
                return true;
            }
        }

        private void TextBoxLogin_Changed(object sender, RoutedEventArgs e)
        {
            txtHintTextBoxLogin.Visibility = Visibility.Visible;
            if (TextBoxLogin.Text.Length > 0)
            {
                txtHintTextBoxLogin.Visibility = Visibility.Hidden;
            }
        }
    }
}
