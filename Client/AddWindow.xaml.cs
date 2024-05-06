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
    public partial class AddWindow : Window
    {
        private readonly EquipmentConnection _equipmentConnection;
        private readonly MarkConnection _markConnection;
        private readonly int _workshopId;

        private IEnumerable<Mark> Marks { get; set; }

        public AddWindow(EquipmentConnection equipmentConnection, int worshopId)
        {
            _equipmentConnection = equipmentConnection;
            _markConnection = new MarkConnection();
            _workshopId = worshopId;

            InitializeComponent();

            LoadMarks();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != string.Empty &&
                int.TryParse(textboxInventoryNumber.Text, out int invNum) &&
                decimal.TryParse (textboxPrice.Text, out decimal price) &&
                datePicker.Text != string.Empty &&
                comboBoxMark.SelectedItem != null)
            {
                var equipment = new Equipment
                {
                    Name = textboxName.Text,
                    InventoryNumber = invNum,
                    Price = price,
                    YearOfInstalation = datePicker.DisplayDate,
                    MarkId = MarkNameToId(comboBoxMark.SelectedItem.ToString()),
                    WorkshopId = _workshopId,
                };

                _equipmentConnection.Add(equipment);

                Close();
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
