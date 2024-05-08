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

namespace Client.EditWindows
{
    public partial class FreeEquipmentEditWindow : Window
    {
        private readonly FreeEquipmentConnection _freeEquipmentConnection;
        private readonly MarkConnection _markConnection;
        private readonly SupplierConnection _supplierConnection;
        private readonly int _freeEquipmentId;
        private readonly int _warehouseId;

        private IEnumerable<Mark> Marks { get; set; }
        private IEnumerable<Supplier> Suppliers { get; set; }

        public FreeEquipmentEditWindow(FreeEquipmentConnection freeEquipmentConnection, int freeEquipmentId, int warehouseId)
        {
            _freeEquipmentConnection = freeEquipmentConnection;
            _markConnection = new MarkConnection();
            _supplierConnection = new SupplierConnection();

            _freeEquipmentId = freeEquipmentId;
            _warehouseId = warehouseId;

            InitializeComponent();

            LoadMarksAndSuppliers();
            LoadEquipment();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != string.Empty &&
                int.TryParse(textboxInventoryNumber.Text, out int invNum) &&
                decimal.TryParse(textboxPrice.Text, out decimal price) &&
                comboBoxSupplier.SelectedItem != null &&
                comboBoxMark.SelectedItem != null)
            {
                var freeEquipment = new FreeEquipment
                {
                    Id = _freeEquipmentId,
                    Name = textboxName.Text,
                    InventoryNumber = invNum,
                    Price = price,
                    MarkId = MarkNameToId(comboBoxMark.SelectedItem.ToString()),
                    WarehouseId = _warehouseId,
                    SupplierId = SupplierNameToId(comboBoxSupplier.SelectedItem.ToString()),
                };

                _freeEquipmentConnection.Edit(freeEquipment);

                Close();
            }
        }

        private async void LoadEquipment()
        {
            if (_freeEquipmentId != 0)
            {
                var freeEquipment = await _freeEquipmentConnection.GetById(_freeEquipmentId);

                textboxName.Text = freeEquipment.Name;
                textboxInventoryNumber.Text = freeEquipment.InventoryNumber.ToString();
                textboxPrice.Text = freeEquipment.Price.ToString();
                comboBoxMark.SelectedItem = freeEquipment.Mark.MarkName;
                comboBoxSupplier.SelectedItem = freeEquipment.Supplier.SupplierName;
            }
        }

        private async void LoadMarksAndSuppliers()
        {
            Marks = await _markConnection.GetAllMarks();
            Suppliers = await _supplierConnection.GetAllSuppliers();

            var marksNames = new List<string>();
            var suppliersNames = new List<string>();

            foreach (var mark in Marks)
            {
                marksNames.Add(mark.MarkName);
            }

            foreach (var supplier in Suppliers)
            {
                suppliersNames.Add(supplier.SupplierName);
            }

            comboBoxMark.ItemsSource = marksNames;
            comboBoxSupplier.ItemsSource = suppliersNames;
        }

        private int MarkNameToId(string markName)
        {
            foreach (var mark in Marks)
            {
                if (mark.MarkName == markName)
                {
                    return mark.Id;
                }
            }

            return 0;
        }

        private int SupplierNameToId(string supplierName)
        {
            foreach (var supplier in Suppliers)
            {
                if (supplier.SupplierName == supplierName)
                {
                    return supplier.Id;
                }
            }

            return 0;
        }
    }
}
