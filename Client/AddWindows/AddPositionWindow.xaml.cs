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
    public partial class AddPositionWindow : Window
    {
        private readonly PositionConnection _positionConnection;

        public AddPositionWindow(PositionConnection positionConnection)
        {
            _positionConnection = positionConnection;

            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text != string.Empty)
            {
                _positionConnection.Add(new Position { PositionName = textboxName.Text.Trim() });

                Close();
            }
        }
    }
}
