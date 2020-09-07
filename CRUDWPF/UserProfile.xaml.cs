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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUDWPF
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : UserControl
    {
        Regex passRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");
        MyContext _context = new MyContext();
        string email;

        public UserProfile(string email)
        {
            InitializeComponent();
            this.email = email;
            warning.Visibility = Visibility.Visible;
        }

        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!passRegex.IsMatch(newPassword.Password))
            {
                warning.Visibility = Visibility.Visible;
            }
            else
            {
                warning.Visibility = Visibility.Hidden;
            }
        }

        private void RePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var emailQuery = _context.Logins.Where(l => l.Email == email).First();

            if (oldPassword.Password != emailQuery.Password)
            {
                MessageBox.Show("Wrong old password");
            }

            else if (!passRegex.IsMatch(newPassword.Password))
            {
                warning.Visibility = Visibility.Visible;
            }
            else if ((newPassword.Password != rePassword.Password))
            {
                MessageBox.Show("Confirm password is not same as new password");
            }
            else
            {
                warning.Visibility = Visibility.Hidden;
                emailQuery.Password = BCrypt.Net.BCrypt.HashPassword(rePassword.Password);
                emailQuery.IsForgot = false;
                _context.SaveChanges();
                MessageBox.Show("Password has been changed");
            }
        }
    }
}
