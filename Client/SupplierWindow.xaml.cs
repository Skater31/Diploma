using Client.AddWindows;
using Client.Connection;
using Server_SIde.Models;
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
using System.Windows.Shapes;

namespace Client
{
    public partial class SupplierWindow : Window
    {
        private readonly SupplierConnection _supplierConnection;

        public SupplierWindow()
        {
            _supplierConnection = new SupplierConnection();

            InitializeComponent();

            LoadSuppliers();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddSupplierWindow(_supplierConnection).ShowDialog();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listviewSuppliers.SelectedItem != null)
            {
                _supplierConnection.Delete((Supplier)listviewSuppliers.SelectedItem);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            listviewSuppliers.ItemsSource = await _supplierConnection.GetAllSuppliers();
        }

        private async void LoadSuppliers()
        {
            listviewSuppliers.ItemsSource = await _supplierConnection.GetAllSuppliers();
        }
    }
}
