using ModelDB.Core;
using ModelDB.Core.Enum;
using PR26.Extensions;
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

namespace PR26.Pages
{
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();

            using (var db = new DataContext())
            {
                foreach (Role item in (Role[])Enum.GetValues(typeof(Role)))
                {
                    TextBlock role = new TextBlock();
                    role.Text = item.ToString();
                    ComboBoxRole.Items.Add(role);
                    if (item.ToString() == "Cashier")
                    {
                        ComboBoxRole.SelectedItem = role;
                    }
                }
            }

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Reg(TextBoxLogin.Text, Password.Password, PasswordCopy.Password, ComboBoxRole.Text);
        }

        public bool Reg(string loginUser, string password, string passwordCopy, string role)
        {
            if (string.IsNullOrEmpty(loginUser.Replace(" ", ""))
                || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(passwordCopy))
            {
                MessageBox.Show("Введите все параметры!");
                return false;
            }
            else
            {
                using (var db = new DataContext())
                {
                    try
                    {
                        var login = db.Users.AsNoTracking()
                        .FirstOrDefault(u => u.Login == loginUser);

                        if (login != null)
                        {
                            MessageBox.Show("Логин занят!");
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Проверьте подключение к интернету!");
                        return false;
                    }


                    if (password != passwordCopy)
                    {
                        MessageBox.Show("Пароли не совпадают!");
                        return false;
                    }

                    if (password.Length >= 6)
                    {
                        bool letter = false;//буква
                        bool en = true; // английская раскладка
                        bool symbol = false; // символ
                        bool number = false; // цифра

                        for (int i = 0; i < password.Length; i++) // перебираем символы
                        {
                            if (password[i] >= 'A' && password[i] <= 'Z' || password[i] >= 'a' && password[i] <= 'z') letter = true; // если есть хотябы одна буква
                            if (password[i] >= 'А' && password[i] <= 'Я' || password[i] >= 'а' && password[i] <= 'я') en = false; // если русская раскладка
                            if (password[i] >= '0' && password[i] <= '9') number = true; // если цифры
                            if (password[i] == '_' || password[i] == '-' || password[i] == '!') symbol = true; // если символ
                        }

                        if (!en)
                        {
                            MessageBox.Show("Доступна только английская раскладка"); // выводим сообщение
                            return false;
                        }
                        else if (!letter)
                        {
                            MessageBox.Show("Добавьте хотя бы одну букву"); // выводим сообщение
                            return false;
                        }
                        else if (!symbol)
                        {
                            MessageBox.Show("Добавьте один из следующих символов: _ - !"); // выводим сообщение
                            return false;
                        }
                        else if (!number)
                        {
                            MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("пароль слишком короткий, минимум 6 символов");
                        return false;
                    }

                    User userObject = new User
                    {
                        UserId = Guid.NewGuid(),
                        Login = loginUser,
                        Password = GetHashSHA.GetHash(password.ToString()),
                        UserRole = (Role)Enum.Parse(typeof(Role), role)
                    };
                    db.Users.Add(userObject);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь зарегистрирован!");
                    TextBoxLogin.Clear();
                    Password.Clear();
                    PasswordCopy.Clear();
                    return true;
                }
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
