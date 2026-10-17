using System.Windows;

namespace lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string CorrectPassword = "123qwe";

        public MainWindow()
        {
            InitializeComponent();
        }

        // Упражнение 1: проверка пароля, Упражнение 2: повтор попытки
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Text == CorrectPassword)
            {
                MessageBox.Show("Пароль правильный.", "Авторизация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show("Ошибка аутентификации.\nПовторить попытку?", "Ошибка",
                MessageBoxButton.YesNo, MessageBoxImage.Error);

            if (result == MessageBoxResult.Yes)
            {
                PasswordTextBox.Clear();
                PasswordTextBox.Focus();
            }
            else
            {
                Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти?", "Выход",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
