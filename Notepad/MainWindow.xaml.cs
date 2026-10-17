using System.ComponentModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Notepad
{
    public partial class MainWindow : Window
    {
        string filter = "Text (*.txt)|*.txt|CSV (*.csv)|*.csv|JSON (*.json)|*.json";

        // Текст на момент последнего открытия/сохранения — с ним сравниваем, чтобы понять, есть ли изменения
        string savedText = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter;
            if (openFileDialog.ShowDialog() == true)
            {
                if (File.Exists(openFileDialog.FileName))
                {
                    EditorTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                    savedText = EditorTextBox.Text;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private bool SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filter;
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, EditorTextBox.Text);
                savedText = EditorTextBox.Text;
                return true;
            }
            return false;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (EditorTextBox.Text == savedText)
            {
                return;
            }

            MessageBoxResult result = MessageBox.Show("Сохранить изменения в файле?", "Блокнот",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (!SaveFile())
                {
                    e.Cancel = true;
                }
            }
            else if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
