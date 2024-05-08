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
    public partial class EmployeeEditWindow : Window
    {
        private readonly EmployeeConnection _employeeConnection;
        private readonly PositionConnection _positionConnection;
        private readonly int _employeeId;

        private IEnumerable<Position> Positions { get; set; }

        public EmployeeEditWindow(EmployeeConnection employeeConnection, int employeeId)
        {
            _employeeConnection = employeeConnection;
            _employeeId = employeeId;

            _positionConnection = new PositionConnection();

            InitializeComponent();

            LoadPositions();
            LoadEmployee();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != string.Empty &&
                comboBoxPosition.SelectedItem != null)
            {
                var employee = new Employee
                {
                    Id = _employeeId,
                    FullName = textboxName.Text,
                    PositionId = PositionNameToId(comboBoxPosition.SelectedItem.ToString()),
                };

                _employeeConnection.Edit(employee);

                Close();
            }
        }

        private async void LoadEmployee()
        {
            if (_employeeId != 0)
            {
                var employee = await _employeeConnection.GetById(_employeeId);

                textboxName.Text = employee.FullName;
                comboBoxPosition.SelectedItem = employee.Position.PositionName;
            }
        }

        private async void LoadPositions()
        {
            Positions = await _positionConnection.GetAllPositions();

            var positionsNames = new List<string>();

            foreach (var position in Positions)
            {
                positionsNames.Add(position.PositionName);
            }

            comboBoxPosition.ItemsSource = positionsNames;
        }

        private int PositionNameToId(string positionName)
        {
            foreach (var position in Positions)
            {
                if (position.PositionName == positionName)
                {
                    return position.Id;
                }
            }

            return 0;
        }
    }
}
