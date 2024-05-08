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

namespace Client.AppointWindows
{
    public partial class EmployeeAppointWindow : Window
    {
        private readonly EmployeeConnection _employeeConnection;

        private IEnumerable<FreeEquipment> FreeEquipment { get; set; }

        public EmployeeAppointWindow(EmployeeConnection employeeConnection, List<FreeEquipment> freeEquipment)
        {
            _employeeConnection = employeeConnection;

            FreeEquipment = freeEquipment;

            InitializeComponent();

            LoadEmployees();
            LoadFreeEquipment();
        }

        private void ButtonAppoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void LoadEmployees()
        {
            var employees = (List<Employee>)await _employeeConnection.GetAllEmployees();

            var employeeNames = new List<string>();

            foreach (var employee in employees)
            {
                employeeNames.Add(employee.FullName);
            }

            comboBoxEmployee.ItemsSource = employeeNames;
        }

        private void LoadFreeEquipment()
        {
            var freeEquipNames = new List<string>();

            foreach(var freeEquip in FreeEquipment)
            {
                freeEquipNames.Add($"{freeEquip.Name} [{freeEquip.InventoryNumber}]");
            }

            comboBoxFreeEquip.ItemsSource = freeEquipNames;
        }
    }
}
