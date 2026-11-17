using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace excersise2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var list = new ObservableCollection<Client>()
            {
                new Client()
                {
                    Id = 1,
                    FirstName = "Петр",
                    LastName = "Петров",
                    PreferredColor = Colors.Blue,
                    ShortInfo = "Умею создавать шаблоны WPF",
                    Tariffs = new List<string>()
                    {
                        "Домашний интернет",
                        "Мобильная связь",
                        "Телевидение"
                    }
                },
                new Client()
                {
                    Id = 2,
                    FirstName = "Василий",
                    LastName = "Пупкин",
                    PreferredColor = Colors.Pink,
                    ShortInfo = "Умею кататься на лыжах"
                },
                new Client()
                {
                    Id = 3,
                    FirstName = "Екатерина",
                    LastName = "Кашина",
                    PreferredColor = Colors.Aqua,
                    ShortInfo = "Сдал на права с первого раза",
                    Tariffs = new List<string>()
                    {
                        "Домашний интернет",
                        "Мобильная связь",
                        "Телевидение"
                    }
                },
                new Client()
                {
                    Id = 4,
                    FirstName = "Сергей",
                    LastName = "Котов",
                    PreferredColor = Colors.Purple,
                    ShortInfo = "Разработчик ПО"
                }
            };

            ClientsList.ItemsSource = list;
        }
    }
}
