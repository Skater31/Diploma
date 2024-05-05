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
    public partial class EquipmentEditWindow : Window
    {
        private readonly EquipmentConnection _equipmentConnection;
        private readonly MarkConnection _markConnection;

        private IEnumerable<Mark> Marks { get; set; }
        private int EquipmentId { get; set; }

        public EquipmentEditWindow(int equipmentId,EquipmentConnection equipmentConnection)
        {
            _equipmentConnection = equipmentConnection;
            _markConnection = new MarkConnection();

            EquipmentId = equipmentId;

            InitializeComponent();

            LoadMarks();
            LoadEquipment();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != string.Empty &&
                int.TryParse(textboxInventoryNumber.Text, out int invNum) &&
                decimal.TryParse(textboxPrice.Text, out decimal price) &&
                datePicker.Text != string.Empty &&
                comboBoxMark.SelectedItem != null)
            {
                var equipment = new Equipment
                {
                    Id = EquipmentId,
                    Name = textboxName.Text,
                    InventoryNumber = invNum,
                    Price = price,
                    YearOfInstalation = datePicker.DisplayDate,
                    MarkId = MarkNameToId(comboBoxMark.SelectedItem.ToString()),
                };

                _equipmentConnection.Edit(equipment);

                Close();
            }
        }

        private async void LoadEquipment()
        {
            if (EquipmentId != 0)
            {
                var equipment = await _equipmentConnection.GetById(EquipmentId);

                textboxName.Text = equipment.Name;
                textboxInventoryNumber.Text = equipment.InventoryNumber.ToString();
                textboxPrice.Text = equipment.Price.ToString();
                datePicker.Text = equipment.YearOfInstalation.ToString();
                comboBoxMark.SelectedItem = equipment.Mark.MarkName;
            }
        }

        private async void LoadMarks()
        {
            Marks = await _markConnection.GetAllMarks();

            var marksNames = new List<string>();

            foreach (var mark in Marks)
            {
                marksNames.Add(mark.MarkName);
            }

            comboBoxMark.ItemsSource = marksNames;
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
    }
}
