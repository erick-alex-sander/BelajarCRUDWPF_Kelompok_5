using CRUDWPF.Context;
using CRUDWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for UserControlTransactionItem.xaml
    /// </summary>
    public partial class UserControlTransactionItem : UserControl
    {
        private MyContext _context = new MyContext();
        static Regex numOnly = new Regex("^[0-9]+$");
        private static bool IsTextAllowed(string text)
        {
            return numOnly.IsMatch(text);
        }

        public UserControlTransactionItem()
        {
            InitializeComponent();

            var obj = _context.TransactionItems
                .Include(a => a.Item)
                .Include(b => b.Transaction)
                .ToList();

            dataTI.ItemsSource = obj;

            itemBox.ItemsSource = obj;
            itemBox.DisplayMemberPath = "Item.Name";
            itemBox.SelectedValuePath = "Item.Id";
            
           
        }

        private void DataTI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                TransactionItem transactionItem = (TransactionItem)dataTI.SelectedItem;
                id.Text = Convert.ToString(transactionItem.Id);
            }

            catch (Exception)
            {
                id.Text = "";
            }
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(id.Text);
            var obj = _context.TransactionItems
                .Include(i => i.Item)
                .Include(t => t.Transaction)
                .Single(c => c.Id == Id);
            MessageBoxResult result = MessageBox.Show("This cannot be undone", "Warning", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show(obj.Item.Name + " With the transaction no" +
                        obj.Transaction.Id + " Has been deleted");
                    _context.TransactionItems.Remove(obj);
                    _context.SaveChanges();

                    dataTI.ItemsSource = _context.TransactionItems
                        .Include(a => a.Item)
                        .Include(b => b.Transaction)
                        .ToList();
                    break;
                case MessageBoxResult.No:
                    break;

            }
        }


        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredData = _context.TransactionItems.Where(i => i.Item.Name.Contains(searchBox.Text)
                || i.Transaction.Id.ToString().Contains(searchBox.Text)).ToList();
            dataTI.ItemsSource = filteredData;

            if (searchBox.Text.Equals(""))
            {
                searchText.Visibility = Visibility.Visible;
            }
            else
            {
                searchText.Visibility = Visibility.Hidden;
            }
        }

        private void ItemBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            itemBox.SelectedIndex = -1;

            if (!String.IsNullOrWhiteSpace(itemBox.Text))
            {
                itemBox.IsDropDownOpen = true;
                itemText.Visibility = Visibility.Hidden;
                var filteredData = _context.TransactionItems.Where(i => i.Item.Name.Contains(itemBox.Text)).ToList();
                itemBox.ItemsSource = filteredData;
                itemBox.DisplayMemberPath = "Item.Name";
                itemBox.SelectedValuePath = "Item.Id";
                itemBox.IsEnabled = true;
            }
            else
            {
                var obj = _context.TransactionItems
                    .Include(a => a.Item)
                    .Include(b => b.Transaction)
                    .ToList();
                itemText.Visibility = Visibility.Visible;
                itemBox.ItemsSource = obj;
                itemBox.DisplayMemberPath = "Item.Name";
                itemBox.SelectedValuePath = "Item.Id";
            }
        }

        private void ButtonUp_Click(object sender, RoutedEventArgs e)
        {
            int plus;
            int init = Convert.ToInt16(quantityBox.Text);

            plus = init + 1;
            if (plus >= 1000)
            {
                plus = 1000;
            }

            quantityBox.Text = Convert.ToString(plus);
        }

        private void ButtonDown_Click(object sender, RoutedEventArgs e)
        {
            int minus;
            int init = Convert.ToInt16(quantityBox.Text);

            minus = init - 1;
            if (minus <= 1)
            {
                minus = 1;
            }

            quantityBox.Text = Convert.ToString(minus);
        }

        private void QuantityBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void QuantityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(quantityBox.Text))
                {
                    quantityBox.Text = "1";
                }
                else if (Convert.ToInt16(quantityBox.Text) >= 1000)
                {
                    quantityBox.Text = "1000";
                }
            }
            
            catch (Exception)
            {
                quantityBox.Text = "1000";
            }
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            int itemId = Convert.ToInt16(itemBox.SelectedValue);
            var itemObj = _context.Items.Find(itemId);
            int transactionId = Convert.ToInt16(transactionBox.SelectedValue);
            var transactionObj = _context.Transactions.Find(transactionId);
            int quantity = Convert.ToInt16(quantityBox.Text);

            if (String.IsNullOrWhiteSpace(id.Text))
            {
                var insert = new TransactionItem(quantity, itemObj, transactionObj);
                _context.SaveChanges();
                MessageBox.Show("Data has been inserted.");
            }

        }
    }
}
