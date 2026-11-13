using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace lab10
{
    public class GameState : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int coins = 0;
        public int Coins
        {
            get { return coins; }
            set 
            { 
                coins = value; 
                OnPropertyChanged();
            }
        }

        private int coinsPerClick = 1;
        public int CoinsPerClick
        {
            get { return coinsPerClick; }
            set
            {
                coinsPerClick = value; 
                OnPropertyChanged();
            }
        }

        private int coinsPerSecond = 1;
        public int CoinsPerSecond
        {
            get { return coinsPerSecond; }
            set
            {
                coinsPerSecond = value; 
                OnPropertyChanged();
            }
        }

        private int clickUpgradePrice = 10;
        public int ClickUpgradePrice
        {
            get { return clickUpgradePrice; }
            set
            {
                clickUpgradePrice = value;
                OnPropertyChanged();
            }
        }

        private int passiveUpgradePrice = 10;
        public int PassiveUpgradePrice
        {
            get { return passiveUpgradePrice; }
            set
            {
                passiveUpgradePrice = value;
                OnPropertyChanged();
            }
        }

        public void Click()
        {
            Coins += CoinsPerClick;
        }

        public void AddPassiveCoins()
        {
            Coins += CoinsPerSecond;
        }

        public void BuyClickUpgrade()
        {
            if (Coins >= ClickUpgradePrice)
            {
                Coins -= ClickUpgradePrice;

                CoinsPerClick++;

                ClickUpgradePrice = (int)Math.Ceiling(
                    ClickUpgradePrice * 1.2m);
            }
        }

        public void BuyPassiveUpgrade()
        {
            if (Coins >= PassiveUpgradePrice)
            {
                Coins -= PassiveUpgradePrice;

                CoinsPerSecond++;

                PassiveUpgradePrice = (int)Math.Ceiling(
                    PassiveUpgradePrice * 1.2m);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
