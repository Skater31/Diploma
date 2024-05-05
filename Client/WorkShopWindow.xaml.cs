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
                new AddWindow(_equipmentConnection).ShowDialog();
            }
        }

        private void MainButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var tab = (TabItem)tabControl.SelectedItem;

            if (tab.Name == "gristMill")
            {
                var equipmnet = (Equipment)listViewGristMill.SelectedItem;

                if (equipmnet != null)
                {
                    new EquipmentEditWindow(equipmnet.Id, _equipmentConnection).ShowDialog();
                }
            }
        }

        private async Task LoadEquipment()
        {
            listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment();
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            var tab = (TabItem)tabControl.SelectedItem;

            if (tab.Name == "gristMill")
            {
                listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var tab = (TabItem)tabControl.SelectedItem;

            if (tab.Name == "gristMill")
            {
                _equipmentConnection.Delete((Equipment)listViewGristMill.SelectedItem);
            }
        }

        private async void TextBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxFind.Text))
            {
                listViewGristMill.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text);
            }

            if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxFind.Text))
            {
                listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment();
            }
        }
    }
}
