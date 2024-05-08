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

namespace Client.AddWindows
{
    public partial class EmployeeAddWindow : Window
    {
        private readonly EmployeeConnection _employeeConnection;
        private readonly PositionConnection _positionConnection;

        private IEnumerable<Position> Positions { get; set; }

        public EmployeeAddWindow(EmployeeConnection employeeConnection)
        {
            _employeeConnection = employeeConnection;

            _positionConnection = new PositionConnection();

            InitializeComponent();

            LoadPositions();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != string.Empty &&
                comboBoxPosition.SelectedItem != null)
            {
                var employee = new Employee
                {
                    FullName = textboxName.Text,
                    PositionId = PositionNameToId(comboBoxPosition.SelectedItem.ToString()),
                };

                _employeeConnection.Add(employee);

                Close();
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
