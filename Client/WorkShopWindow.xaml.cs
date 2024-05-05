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
using System.Threading.Tasks;
using Client.Connection;
using Client.EditWindows;
using Server_SIde.Models;

namespace Client
{
    public partial class WorkShopWindow : Window
    {
        private readonly EquipmentConnection _equipmentConnection;

        public WorkShopWindow()
        {
            _equipmentConnection = new EquipmentConnection();

            InitializeComponent();

            LoadEquipment();
        }

        private void MainButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var tab = (TabItem)tabControl.SelectedItem;

            if (tab.Name == "gristMill")
            {
                new AddWindow(_equipmentConnection).Show();
            }
        }

        private void MainButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var tab = (TabItem)tabControl.SelectedItem;

            if (tab.Name == "gristMill")
            {
                new EquipmentEditWindow(((Equipment)listViewGristMill.SelectedItem).Id, _equipmentConnection).Show();
            }
        }

        private async Task LoadEquipment()
        {
            listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment();
        }
    }
}
