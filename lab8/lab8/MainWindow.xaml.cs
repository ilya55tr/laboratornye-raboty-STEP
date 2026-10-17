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

namespace lab8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new NameDialog();
            if (dlg.ShowDialog() == true)
            {
                int age = GetAge(dlg.BirthDate);
                HelloText.Text = $"Добрый день, {dlg.LastName} {dlg.FirstName} {dlg.PatronymicName} ({age} {YearsWord(age)}).";
            }
        }

        private static int GetAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
                age--;
            return age;
        }

        private static string YearsWord(int n)
        {
            if (n % 100 >= 11 && n % 100 <= 14) return "лет";
            switch (n % 10)
            {
                case 1: return "год";
                case 2: case 3: case 4: return "года";
                default: return "лет";
            }
        }
    }
}