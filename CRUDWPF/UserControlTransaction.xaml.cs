using CRUDWPF.Context;
using CRUDWPF.Model;
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

namespace CRUDWPF
{
    public partial class UserControlTransaction : UserControl
    {
        MyContext context = new MyContext();
        public UserControlTransaction()
        {
            InitializeComponent();
            dtList.ItemsSource = context.Transactions.ToList();
            btnUpdate.IsEnabled = false;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var data = dtList.SelectedItem as Transaction;
            var trans = context.Transactions.Find(data.Id);
            trans.OrderDate = data.OrderDate;
            context.SaveChanges();
            MessageBox.Show("1 row has been update");
            dtList.ItemsSource = context.Transactions.ToList();

            txtDatePicker.SelectedDate = null;
            txtID.Text = "";

            dtList.SelectedItem = null;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var data = dtList.SelectedItem as Transaction;
            var trans = context.Transactions.Find(data.Id);
            context.Transactions.Remove(trans);
            context.SaveChanges();
            MessageBox.Show("1 row has been delete");
            dtList.ItemsSource = context.Transactions.ToList();

            txtDatePicker.SelectedDate = null;
            txtID.Text = "";

            dtList.SelectedItem = null;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var filteredData = context.Transactions.Where(Q => Q.Id.ToString().Contains(txtSearch.Text) ); 
            dtList.ItemsSource = filteredData;
        }

        private void dtList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = dtList.SelectedItem as Transaction;
            txtID.Text = Convert.ToString(data.Id);
            txtDatePicker.SelectedDate.Value = Convert.ToDateTime(data.OrderDate);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            //if (txtName.Text.Equals(""))
            if (txtDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Nama Wajib di masukkan");
            }
            else
            {
                var input = new Transaction(txtDatePicker.SelectedDate.Value);
                context.Transactions.Add(input);
                context.SaveChanges();
                MessageBox.Show("Data Berhasil Insert");
            }

            txtID.Text = "";
            txtDatePicker.SelectedDate = null;
            dtList.SelectedItem = null;
            dtList.ItemsSource = context.Transactions.ToList();
        }

        private void txtDatePicker_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDatePicker.Text))
            {
                lblStatusName.Content = "*Date Picker Cannot Empty !";
                btnInsert.IsEnabled = false;
            }
            else if (!txtDatePicker.Text.All(char.IsLetterOrDigit))
            {
                lblStatusName.Content = "*Date Picker Must Contain Only Date Format !";
                btnInsert.IsEnabled = false;
            }
            else
            {
                lblStatusName.Content = "";
                btnInsert.IsEnabled = true;
            }
        }
    }
}
