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
using Client.AddWindows;

namespace Client
{
    public partial class WorkShopWindow : Window
    {
        private readonly EquipmentConnection _equipmentConnection;
        private readonly FreeEquipmentConnection _freeEquipmentConnection;

        public WorkShopWindow()
        {
            _equipmentConnection = new EquipmentConnection();
            _freeEquipmentConnection = new FreeEquipmentConnection();

            InitializeComponent();

            LoadEquipment();
        }

        private void MainButtonAdd_Click(object sender, RoutedEventArgs e)
        {
           var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    new AddWindow(_equipmentConnection, 1).ShowDialog();
                    break;

                case "combine":
                    new AddWindow(_equipmentConnection, 2).ShowDialog();
                    break;

                case "mill":
                    new AddWindow(_equipmentConnection, 3).ShowDialog();
                    break;

                case "elevator":
                    new AddWindow(_equipmentConnection, 4).ShowDialog();
                    break;

                case "warehouseTHM":
                    new FreeEquipmentAddWindow(_freeEquipmentConnection, 1).ShowDialog();
                    break;

                case "warehouseBHM":
                    new FreeEquipmentAddWindow(_freeEquipmentConnection, 2).ShowDialog();
                    break;

                case "warehouseFP":
                    new FreeEquipmentAddWindow(_freeEquipmentConnection, 3).ShowDialog();
                    break;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    if (listViewGristMill.SelectedItem != null)
                    {
                        _equipmentConnection.Delete((Equipment)listViewGristMill.SelectedItem);
                    }
                    break;

                case "combine":
                    if (listViewCombine.SelectedItem != null)
                    {
                        _equipmentConnection.Delete((Equipment)listViewCombine.SelectedItem);
                    }
                    break;

                case "mill":
                    if (listViewMill.SelectedItem != null)
                    {
                        _equipmentConnection.Delete((Equipment)listViewMill.SelectedItem);
                    }
                    break;

                case "elevator":
                    if (listViewElevator.SelectedItem != null)
                    {
                        _equipmentConnection.Delete((Equipment)listViewElevator.SelectedItem);
                    }
                    break;

                case "warehouseTHM":
                    if (listviewWarehouseTHM.SelectedItem != null)
                    {
                        _freeEquipmentConnection.Delete((FreeEquipment)listviewWarehouseTHM.SelectedItem);
                    }
                    break;

                case "warehouseBHM":
                    if (listviewWarehouseBHM.SelectedItem != null)
                    {
                        _freeEquipmentConnection.Delete((FreeEquipment)listviewWarehouseBHM.SelectedItem);
                    }
                    break;

                case "warehouseFP":
                    if (listviewWarehouseFP.SelectedItem != null)
                    {
                        _freeEquipmentConnection.Delete((FreeEquipment)listviewWarehouseFP.SelectedItem);
                    }
                    break;
            }
        }

        private void MainButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    var equipGristMill = (Equipment)listViewGristMill.SelectedItem;
                    new EquipmentEditWindow(_equipmentConnection, equipGristMill.Id, equipGristMill.WorkshopId).ShowDialog();
                    break;

                case "combine":
                    var equipCombine = (Equipment)listViewCombine.SelectedItem;
                    new EquipmentEditWindow(_equipmentConnection, equipCombine.Id, equipCombine.Id).ShowDialog();
                    break;

                case "mill":
                    var equipMill = (Equipment)listViewMill.SelectedItem;
                    new EquipmentEditWindow(_equipmentConnection, equipMill.Id, equipMill.WorkshopId).ShowDialog();
                    break;

                case "elevator":
                    var equipElevator = (Equipment)listViewElevator.SelectedItem;
                    new EquipmentEditWindow(_equipmentConnection, equipElevator.Id, equipElevator.WorkshopId).ShowDialog();
                    break;

                case "warehouseTHM":
                    var freeEquipWarehouseTHM = (FreeEquipment)listviewWarehouseTHM.SelectedItem;
                    new FreeEquipmentEditWindow(_freeEquipmentConnection, freeEquipWarehouseTHM.Id, freeEquipWarehouseTHM.WarehouseId).ShowDialog();
                    break;

                case "warehouseBHM":
                    var freeEquipWarehouseBHM = (FreeEquipment)listviewWarehouseBHM.SelectedItem;
                    new FreeEquipmentEditWindow(_freeEquipmentConnection, freeEquipWarehouseBHM.Id, freeEquipWarehouseBHM.WarehouseId).ShowDialog();
                    break;

                case "warehouseFP":
                    var freeEquipWarehouseFP = (FreeEquipment)listviewWarehouseFP.SelectedItem;
                    new FreeEquipmentEditWindow(_freeEquipmentConnection, freeEquipWarehouseFP.Id, freeEquipWarehouseFP.WarehouseId).ShowDialog();
                    break;
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            switch (tabItemName)
            {
                case "gristMill":
                    listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment(1);
                    break;

                case "combine":
                    listViewCombine.ItemsSource = await _equipmentConnection.GetAllEquipment(2);
                    break;

                case "mill":
                    listViewMill.ItemsSource = await _equipmentConnection.GetAllEquipment(3);
                    break;

                case "elevator":
                    listViewElevator.ItemsSource = await _equipmentConnection.GetAllEquipment(4);
                    break;

                case "warehouseTHM":
                    listviewWarehouseTHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(1);
                    break;

                case "warehouseBHM":
                    listviewWarehouseBHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(2);
                    break;

                case "warehouseFP":
                    listviewWarehouseFP.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(3);
                    break;
            }
        }

        private async void TextBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            var tabItemName = ((TabItem)tabControl.SelectedItem).Name;

            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxFind.Text))
            {
                switch (tabItemName)
                {
                    case "gristMill":
                        listViewGristMill.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text, 1);
                        break;

                    case "combine":
                        listViewCombine.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text, 2);
                        break;

                    case "mill":
                        listViewMill.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text, 3);
                        break;

                    case "elevator":
                        listViewElevator.ItemsSource = await _equipmentConnection.Find(textBoxFind.Text, 4);
                        break;

                    case "warehouseTHM":
                        listviewWarehouseTHM.ItemsSource = await _freeEquipmentConnection.Find(textBoxFind.Text, 1);
                        break;

                    case "warehouseBHM":
                        listviewWarehouseBHM.ItemsSource = await _freeEquipmentConnection.Find(textBoxFind.Text, 2);
                        break;

                    case "warehouseFP":
                        listviewWarehouseFP.ItemsSource = await _freeEquipmentConnection.Find(textBoxFind.Text, 3);
                        break;
                }
            }

            if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxFind.Text))
            {
                switch (tabItemName)
                {
                    case "gristMill":
                        listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment(1);
                        break;

                    case "combine":
                        listViewCombine.ItemsSource = await _equipmentConnection.GetAllEquipment(2);
                        break;

                    case "mill":
                        listViewMill.ItemsSource = await _equipmentConnection.GetAllEquipment(3);
                        break;

                    case "elevator":
                        listViewElevator.ItemsSource = await _equipmentConnection.GetAllEquipment(4);
                        break;

                    case "warehouseTHM":
                        listviewWarehouseTHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(1);
                        break;

                    case "warehouseBHM":
                        listviewWarehouseBHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(2);
                        break;

                    case "warehouseFP":
                        listviewWarehouseFP.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(3);
                        break;
                }
            }
        }

        private async Task LoadEquipment()
        {
            listViewGristMill.ItemsSource = await _equipmentConnection.GetAllEquipment(1);
            listViewCombine.ItemsSource = await _equipmentConnection.GetAllEquipment(2);
            listViewMill.ItemsSource = await _equipmentConnection.GetAllEquipment(3);
            listViewElevator.ItemsSource = await _equipmentConnection.GetAllEquipment(4);

            listviewWarehouseTHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(1);
            listviewWarehouseBHM.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(2);
            listviewWarehouseFP.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment(3);
        }
    }
}
