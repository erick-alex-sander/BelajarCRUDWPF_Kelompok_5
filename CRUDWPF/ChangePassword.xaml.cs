using CRUDWPF.Context;
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
using System.Windows.Shapes;

namespace CRUDWPF
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        Regex passRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");
        MyContext _context = new MyContext();
        string email;

        public ChangePassword(string email)
        {
            InitializeComponent();
            this.email = email;
            Validate();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            Close();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Validate();
        }

        private void RePasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Validate();
        }

        void Validate()
        {
            submit.IsEnabled = passRegex.IsMatch(passwordBox.Password) &&
                               (passwordBox.Password == rePasswordBox.Password);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string emailExist = email;
            var update = _context.Logins.Where(l => l.Email == emailExist).First();
            string hashPass = BCrypt.Net.BCrypt.HashPassword(passwordBox.Password);
            update.Password = hashPass;
            update.IsForgot = false;
            _context.SaveChanges();
            MainWindow main = new MainWindow(update);
            main.Show();
            Close();
        }
    }
}
