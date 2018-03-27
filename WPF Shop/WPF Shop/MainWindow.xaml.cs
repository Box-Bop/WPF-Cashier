﻿using System;
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
                if (StockList.SelectedItem != null)
                {
                    //CustomerList.Items.Add((item as Product).Amount - ((item as Product).Amount - 1));
                    CustomerList.Items.Add((item as Product));
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
