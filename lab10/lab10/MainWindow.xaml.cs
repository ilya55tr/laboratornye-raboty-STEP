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
using System.Windows.Threading;

namespace lab10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameState game = new GameState();
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = game;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            game.AddPassiveCoins();
        }

        private void ClickButton_Click(object sender, RoutedEventArgs e)
        {
            game.Click();
        }

        private void ShopButton_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow shop = new ShopWindow(game);
            shop.Owner = this;
            shop.ShowDialog();
        }
    }
}