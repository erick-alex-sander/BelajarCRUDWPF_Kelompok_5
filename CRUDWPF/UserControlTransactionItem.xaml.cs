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
        Regex numOnly = new Regex("^[0-9]");

        public UserControlTransactionItem()
        {
            InitializeComponent();

            var obj = _context.TransactionItems
                .Include(a => a.Item)
                .Include(b => b.Transaction)
                .ToList();

            dataTI.ItemsSource = obj;
            itemBox.ItemsSource = obj;
        }

        private void DataTI_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBox_Click(object sender, MouseButtonEventArgs e)
        {
            searchBox.Text = "";
            searchBox.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filteredData = _context.TransactionItems.Where(i => i.Item.Name.Contains(searchBox.Text)
                || i.Transaction.Id.ToString().Contains(searchBox.Text)).ToList();
            dataTI.ItemsSource = filteredData;
        }
    }
}
