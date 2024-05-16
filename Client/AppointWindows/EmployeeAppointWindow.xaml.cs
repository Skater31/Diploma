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
        private readonly FreeEquipmentConnection _freeEquipmentConnection;

        private List<FreeEquipment> FreeEquipment { get; set; }
        private IEnumerable<Employee> Employees { get; set; }

        public EmployeeAppointWindow(EmployeeConnection employeeConnection, 
            FreeEquipmentConnection freeEquipmentConnection, List<FreeEquipment> freeEquipment)
        {
            _employeeConnection = employeeConnection;
            _freeEquipmentConnection = freeEquipmentConnection;

            FreeEquipment = freeEquipment;

            InitializeComponent();

            LoadEmployees();
            LoadFreeEquipment();
        }

        private void ButtonAppoint_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxEmployee.SelectedItem != null)
            {
                var empId = EmployeeNameToId(comboBoxEmployee.SelectedItem.ToString());

                AppointEmployeeForFreeEquip(empId);

                _freeEquipmentConnection.Edit(FreeEquipment);

                Close();
            }
        }

        private async void LoadEmployees()
        {
            Employees = await _employeeConnection.GetAllEmployees();

            var employees = (List<Employee>)Employees;

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
                freeEquipNames.Add($"{freeEquip.Name} | {freeEquip.InventoryNumber}");
            }

            comboBoxFreeEquip.ItemsSource = freeEquipNames;
            comboBoxFreeEquip.SelectedIndex = 0;
        }

        private int EmployeeNameToId(string employeeName)
        {
            foreach (var employee in Employees)
            {
                if (employee.FullName == employeeName)
                {
                    return employee.Id;
                }
            }

            return 0;
        }

        private void AppointEmployeeForFreeEquip(int employeeId)
        {
            for (int i = 0; i < FreeEquipment.Count; i++)
            {
                FreeEquipment[i].EmployeeId = employeeId;
            }
        }
    }
}
