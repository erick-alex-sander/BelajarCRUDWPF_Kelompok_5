using CRUDWPF.Context;
using CRUDWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        private Regex _emailValid = new Regex("(^[^0-9]+[a-zA-Z0-9])+(@gmail.com|@yahoo.com|hotmail.com)");
        SmtpClient sendEmail = new SmtpClient()
        {
            Port = 587,
            Host = "smtp.gmail.com",
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("eacoldmelon72@gmail.com", "cupcakepancake"),
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network
        };

        MailMessage mail = new MailMessage()
        {
            From = new MailAddress("eacoldmelon72@gmail.com"),
            Subject = "Confirm new password at : " + DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm:ss"),
            IsBodyHtml = true
        };

        public static string emailBody(string email, string passTemp)
        {
            string messageBody = "<p>Dear, " + email + "</p>";
            messageBody += "<br />";
            messageBody += "<p>Here is your key for change your password,insert it " +
                "at password in login window : " + "<b>" + passTemp + "</b></p>";
            messageBody += "<p>Please keep it confidental and do not tell anyone your password</p>";
            messageBody += "<p>regards, </p>";
            return messageBody;
        }

        MyContext _context = new MyContext();
        LoginWindow loginWin = new LoginWindow();

        public ForgotPassword()
        {
            InitializeComponent();
            warning.Visibility = Visibility.Hidden;
        }


        public bool EmailExist(string email)
        {
            try
            {
                var existEmail = _context.Logins.Where(l => l.Email == email).First(); 
                return true;
            }

            catch
            {
                return false;
            }
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(emailBox.Text == "")
            {
                placeholder.Visibility = Visibility.Visible;
            }
            else
            {
                warning.Visibility = Visibility.Hidden;
                placeholder.Visibility = Visibility.Hidden;
            }
            
            
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string generate = Guid.NewGuid().ToString().Substring(0, 8);

            string passTemp = BCrypt.Net.BCrypt.HashPassword(generate);

            try
            {
                Login login = _context.Logins.Where(l => l.Email == emailBox.Text).First();
                login.Password = passTemp;
                login.IsForgot = true;
                _context.SaveChanges();

                mail.To.Add(new MailAddress(emailBox.Text));
                mail.Body = emailBody(emailBox.Text, generate);
                sendEmail.Send(mail);
                _context.SaveChanges();
                MessageBox.Show("Email has been sent");
                loginWin.Show();
                Close();
            }
            catch (Exception)
            {
                if (!_emailValid.IsMatch(emailBox.Text))
                {
                    warning.Visibility = Visibility.Visible;
                    emailBox.Text = "";
                }
                else if (!EmailExist(emailBox.Text))
                {
                    warning.Text = "email does not exist";
                    warning.Visibility = Visibility.Visible;
                    emailBox.Text = "";
                }
                else
                {
                    MessageBox.Show("Error sending email.");
                }
                
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            loginWin.Show();
            Close();
        }
    }
}
