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

namespace Client.AddWindows
{
    public partial class AddSupplierWindow : Window
    {
        private readonly SupplierConnection _supplierConnection;

        public AddSupplierWindow(SupplierConnection supplierConnection)
        {
            _supplierConnection = supplierConnection;

            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != string.Empty &&
                textboxNumber.Text != string.Empty)
            {
                _supplierConnection.Add(new Supplier { SupplierName = textboxName.Text, ContactNumber = textboxNumber.Text });

                Close();
            }
        }
    }
}
