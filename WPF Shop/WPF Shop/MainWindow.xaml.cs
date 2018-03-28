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

namespace WPF_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddButton.IsEnabled = false;
            RemoveButton.IsEnabled = false;
        }
        List<Product> ProductList = new List<Product>();
        List<Product> BasketList = new List<Product>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var identicalName = ProductList.FirstOrDefault(x => x.ProductName.Contains(ProductNameBox.Text));

            if (Convert.ToDouble(ProductPriceBox.Text) > 0 && identicalName == null)
            {
                ProductList.Add(new Product { ProductName = ProductNameBox.Text, Cost = double.Parse(ProductPriceBox.Text) });
                StockList.ItemsSource = null;
                StockList.ItemsSource = ProductList;
                ProductNameBox.Clear();
                ProductPriceBox.Clear();
                AddButton.IsEnabled = true;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (StockList.SelectedIndex > -1)
            {
                var match = BasketList.Where(x => String.Equals(x.ProductName, ProductList[StockList.SelectedIndex].ProductName, StringComparison.CurrentCulture));
                if (match.Any())
                {
                    foreach (var item in match)
                    {
                        item.Amount += int.Parse(AddAmountBox.Text);
                    }
                }
                else
                {
                    BasketList.Add(ProductList[StockList.SelectedIndex]);

                    BasketList[BasketList.Count - 1].Amount = int.Parse(AddAmountBox.Text);
                }
                CustomerList.ItemsSource = null;
                CustomerList.ItemsSource = BasketList;
                RemoveButton.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("You can't purchase air, please select a product.");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            int index = CustomerList.SelectedIndex;
            if (index > -1)
            {
                BasketList.RemoveAt(index);

                CustomerList.ItemsSource = null;
                CustomerList.ItemsSource = BasketList;
            }
            else
            {
                MessageBox.Show("Subtracting 1 air from 0 air would give you 2,147,483,646 air, please don't.");
            }
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (BasketList.Count != 0)
            {
                double totalPrice = 0;
                foreach (var item in BasketList)
                {
                    totalPrice += item.Amount * item.Cost;
                }
                MessageBox.Show("Your purchase was made, the total price is: " + Convert.ToString(totalPrice));
            }
            else
            {
                MessageBox.Show("Your purchase of \"air\" will cost you 0$");
            }
        }
    }
    public class Product
    {
        public string ProductName { get; set; }
        public double Cost { get; set; }
        public int Amount { get; set; }
    }
}
