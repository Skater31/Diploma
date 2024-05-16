using Client.Connection;
using Server_SIde.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    public partial class MainWindow : Window
    {
        private readonly AuthConnection _authConnection;

        public MainWindow()
        {
            _authConnection = new AuthConnection();

            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Login = textBoxLogin.Text.Trim(),
                Password = textBoxPassword.Password.Trim(),
            };

            var isAuth = await _authConnection.IsAuthenticated(user);

            if (isAuth)
            {
                new WorkShopWindow().Show();

                Close();
            }
        }
    }
}