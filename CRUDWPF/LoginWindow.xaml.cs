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
using System.Windows.Shapes;

namespace CRUDWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        string username;
        string password;
        private Regex _emailValid = new Regex("(^[^0-9]+[a-zA-Z0-9])+(@gmail.com|@yahoo.com|hotmail.com)");
        private MyContext _context = new MyContext();

        public LoginWindow()
        {
           
            InitializeComponent();
            emailValid.Visibility = Visibility.Hidden;
            emailBox.Text = Settings1.Default.Saving;
            passwordBox.Password = Settings1.Default.PassSaving;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            username = emailBox.Text;
            password = passwordBox.Password;
            loginButton.IsDefault = true;
            
            try
            {
                var loginQuery = _context.Logins.Where(l => l.Email == username).First();
                if (!BCrypt.Net.BCrypt.Verify(password, loginQuery.Password))
                {
                    MessageBox.Show("Wrong Password");
                }
                else
                {
                   
                    MainWindow main = new MainWindow(loginQuery);
                    main.Show();
                    
                    
                    if (checkBox.IsChecked == true && loginQuery.IsForgot == false)
                    {
                        Settings1.Default.Saving = username;
                        Settings1.Default.PassSaving = password;
                        Settings1.Default.Save();
                    }

                    else if (checkBox.IsChecked == false)
                    {
                        Settings1.Default.Saving = "";
                        Settings1.Default.PassSaving = "";
                        Settings1.Default.Save();
                    }
                    Close();
                }

            }

            catch
            {
                if (!_emailValid.IsMatch(emailBox.Text))
                {
                    emailValid.Visibility = Visibility.Visible;
                    emailInsert.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("No username like : " + username);
                }
                
            }
            
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailBox.Text))
            {
                emailInsert.Visibility = Visibility.Visible;
                emailValid.Visibility = Visibility.Hidden;
            }
            
            else
            {
                emailValid.Visibility = Visibility.Hidden;
                emailInsert.Visibility = Visibility.Hidden;

            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
       {
            
            if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
               
                passInsert.Visibility = Visibility.Visible;
            }
            else
            {
                passInsert.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Register register = new Register();
            register.Show();
            Close();
        }

        private void Hyperlink2_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            Close();
        }

        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            emailBox.Select(0, 0);
        }
    }
}
