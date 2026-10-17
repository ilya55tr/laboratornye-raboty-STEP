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

namespace lab8
{
    /// <summary>
    /// Логика взаимодействия для NameDialog.xaml
    /// </summary>
    public partial class NameDialog : Window
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PatronymicName { get; set; } = "";
        public DateTime BirthDate { get; set; }

        public NameDialog()
        {
            InitializeComponent();
            birthDatePicker.DisplayDateEnd = DateTime.Today;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (firstNameTextBox.Text == "" || lastNameTextBox.Text == "" || patronymicNameTextBox.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (birthDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату рождения.");
                return;
            }

            if (birthDatePicker.SelectedDate.Value > DateTime.Today)
            {
                MessageBox.Show("Дата рождения не может быть в будущем.");
                return;
            }

            FirstName = firstNameTextBox.Text;
            LastName = lastNameTextBox.Text;
            PatronymicName = patronymicNameTextBox.Text;
            BirthDate = birthDatePicker.SelectedDate.Value;

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
