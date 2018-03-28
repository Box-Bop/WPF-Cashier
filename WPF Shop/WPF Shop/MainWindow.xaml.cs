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
        }
        List<Product> product = new List<Product>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            product.Add(new Product() { ProductName = ProductNameBox.Text, Cost = double.Parse(ProductPriceBox.Text), Amount = int.Parse(ProductQuantityBox.Text) });
            StockList.Items.Add(new Product() { ProductName = ProductNameBox.Text, Cost = double.Parse(ProductPriceBox.Text), Amount = int.Parse(ProductQuantityBox.Text) });
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in StockList.SelectedItems)
            {
                if (StockList.SelectedItems != null)
                {
                    if (CustomerList.Items.Count == 0)
                    {
                        product.Where(x => x.ProductName == x.ProductName).ToList().ForEach(y => y.Amount = y.Amount - (y.Amount - 1));
                        CustomerList.Items.Add(product);
                    }
                    else
                    {
                        //foreach (ListViewItem prB in CustomerList.Items)
                        //{
                        //product.Where(x => x.ProductName == x.ProductName
                        if (!CustomerList.Items.Contains(product.Where(x => x.ProductName == x.ProductName)))
                        {
                            product.Where(x => x.ProductName == StockList.SelectedItem.ToString()).ToList().ForEach(y => y.Amount = y.Amount - (y.Amount - 1));
                            CustomerList.Items.Add(product);
                        }
                        else
                        {
                            product.Where(x => x.ProductName == x.ProductName).ToList().ForEach(y => y.Amount = y.Amount + 1);
                            CustomerList.Items.Add(product);
                        }
                        //}
                    }
                }
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
