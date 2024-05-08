using Client.AddWindows;
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
    public partial class PositionWindow : Window
    {
        private readonly PositionConnection _positionConnection;

        public PositionWindow()
        {
            _positionConnection = new PositionConnection();

            InitializeComponent();

            LoadPositions();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddPositionWindow(_positionConnection).ShowDialog();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listviewPositions.SelectedItem != null)
            {
                _positionConnection.Delete((Position)listviewPositions.SelectedItem);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            listviewPositions.ItemsSource = await _positionConnection.GetAllPositions();
        }

        private async void LoadPositions()
        {
            listviewPositions.ItemsSource = await _positionConnection.GetAllPositions();
        }
    }
}
