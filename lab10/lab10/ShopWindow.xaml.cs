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

namespace lab10
{
    /// <summary>
    /// Логика взаимодействия для ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        private GameState game;
        public ShopWindow(GameState game)
        {
            InitializeComponent();
            this.game = game;
            DataContext = game;
        }

        private void BuyClick_Click(object sender, RoutedEventArgs e)
        {
            game.BuyClickUpgrade();
        }

        private void BuyPassive_Click(object sender, RoutedEventArgs e)
        {
            game.BuyPassiveUpgrade();
        }
    }
}
