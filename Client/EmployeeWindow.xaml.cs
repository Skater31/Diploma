using Client.AddWindows;
using Client.AppointWindows;
using Client.Connection;
using Client.EditWindows;
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
    public partial class EmployeeWindow : Window
    {
        private readonly EmployeeConnection _employeeConnection;
        private readonly FreeEquipmentConnection _freeEquipmentConnection;

        public EmployeeWindow(FreeEquipmentConnection freeEquipmentConnection)
        {
            _employeeConnection = new EmployeeConnection();
            _freeEquipmentConnection = freeEquipmentConnection;

            InitializeComponent();

            LoadEmployees();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeAddWindow(_employeeConnection).ShowDialog();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeEditWindow(_employeeConnection, ((Employee)listviewEmployees.SelectedItem).Id).ShowDialog();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listviewEmployees.SelectedItem != null)
            {
                _employeeConnection.Delete((Employee)listviewEmployees.SelectedItem);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            listviewEmployees.ItemsSource = await _employeeConnection.GetAllEmployees();
        }

        private void ButtonPosition_Click(object sender, RoutedEventArgs e)
        {
            new PositionWindow().ShowDialog();
        }

        private void ButtonSupplier_Click(object sender, RoutedEventArgs e)
        {
            new SupplierWindow().ShowDialog();
        }

        private async void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var employee = (Employee)listviewEmployees.SelectedItem;

            if (employee != null)
            {
                listviewFreeEquipment.ItemsSource = await _employeeConnection.GetAllByEmployeeId(employee.Id);
            }
        }

        private async void ButtonFreeEquip_Click(object sender, RoutedEventArgs e)
        {
            listviewFreeEquipment.ItemsSource = await _freeEquipmentConnection.GetAllFreeEquipment();
        }

        private void ButtonAppoint_Click(object sender, RoutedEventArgs e)
        {
            var freeEquipList = listviewFreeEquipment.SelectedItems.OfType<FreeEquipment>().ToList();

            if (freeEquipList.Count > 0)
            {
                new EmployeeAppointWindow(_employeeConnection, _freeEquipmentConnection, freeEquipList).ShowDialog();
            }
        }

        private async void LoadEmployees()
        {
            listviewEmployees.ItemsSource = await _employeeConnection.GetAllEmployees();
        }
    }
}
