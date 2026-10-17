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

namespace SelfWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Client client = new Client();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = client;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (client.FullName == "" ||
                client.PassportSeries == "" ||
                client.PassportNumber == "")
            {
                MessageBox.Show("Заполните все поля", 
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            ClientInfoWindow infoWindow= new ClientInfoWindow(client);
            infoWindow.Owner = this;
            infoWindow.ShowDialog();
        }
    }
}