using CRUDWPF.Context;
using CRUDWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CRUDWPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private MyContext _context = new MyContext();
        Regex emailRegex = new Regex("(^[^0-9]+[a-zA-Z0-9])+(@gmail.com|@yahoo.com|hotmail.com|@gmail.co.id)");
        Regex passRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");

        protected bool emailAlreadyExist(string username)
        {
            try
            {
                var exist = _context.Logins.Where(u => u.Email == username).First();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        protected bool passwordCheck(string password)
        {
            return passRegex.IsMatch(password);
        }

        void Validate()
        {
            submitButton.IsEnabled = !emailAlreadyExist(userBox.Text) && passwordCheck(passBox.Password) &&
                                     (passBox.Password == repassBox.Password) && emailRegex.IsMatch(userBox.Text);
        }

        public Register()
        {
            InitializeComponent();
            submitButton.IsEnabled = false;
            repassBox.IsEnabled = false;
            emailLabel.Visibility = Visibility.Visible;
            warningEmail.Visibility = Visibility.Hidden;
            warningPass.Visibility = Visibility.Hidden;
            warningPassre.Visibility = Visibility.Hidden;
        }

        private void UserBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(userBox.Text))
            {
                emailLabel.Visibility = Visibility.Visible;
                warningEmail.Visibility = Visibility.Hidden;
                warningEmail.Text = "Wrong Email Format";
            
            }
            else if (!emailRegex.IsMatch(userBox.Text))
            {
                emailLabel.Visibility = Visibility.Hidden;
                warningEmail.Visibility = Visibility.Visible;
                warningEmail.Text = "Wrong Email Format";
                
            }
            else if (emailAlreadyExist(userBox.Text) == true)
            {
                emailLabel.Visibility = Visibility.Hidden;
                warningEmail.Visibility = Visibility.Visible;
                warningEmail.Text = "Email Already Exist";
            }
            else
            {
                emailLabel.Visibility = Visibility.Hidden;
                warningEmail.Visibility = Visibility.Hidden;
                warningEmail.Text = "Wrong Email Format";
            }
            Validate();
        }

        private void PassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(passBox.Password))
            {
                passLabel.Visibility = Visibility.Visible;
                warningPass.Visibility = Visibility.Hidden;
                repassBox.IsEnabled = false;

            }
            else if (!passwordCheck(passBox.Password))
            {
                passLabel.Visibility = Visibility.Hidden;
                warningPass.Visibility = Visibility.Visible;
                repassBox.IsEnabled = false;

            }
            else
            {
                passLabel.Visibility = Visibility.Hidden;
                warningPass.Visibility = Visibility.Hidden;
                repassBox.IsEnabled = true;
            }
            Validate();

        }

        private void RepassBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(repassBox.Password))
            {
                warningPassre.Visibility = Visibility.Hidden;
                passreLabel.Visibility = Visibility.Visible;
            }
            else if ((repassBox.Password != passBox.Password) || !passwordCheck(passBox.Password))
            {
                warningPassre.Visibility = Visibility.Visible;
                passreLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                warningPassre.Visibility = Visibility.Hidden;
                passreLabel.Visibility = Visibility.Hidden;
            }
            
            Validate();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(passBox.Password);
            Login login = new Login(userBox.Text, passwordHash, false);
            _context.Logins.Add(login);
            _context.SaveChanges();
            MessageBox.Show("Account has been created.");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            userBox.Text = "";
            passBox.Password = "";
            repassBox.Password = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWin = new LoginWindow();
            loginWin.Show();
            Close();
        }

        private void UserBox_LostFocus(object sender, RoutedEventArgs e)
        {
            userBox.Select(0, 0);
        }
    }
}
