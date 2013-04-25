using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SiGamal
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

        // --- Generic UI logic ---

        private void ShowMessageBox(string message,
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage icon = MessageBoxImage.Error)
        {
            string messageBoxText = message;
            string caption = "SiGamal";
            MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private string ShowOpenDialog(string filter = "All files (*.*)|*.*")
        {
            // Instantiate open file dialog
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = "";
            dlg.Filter = filter;

            // Show dialog
            Nullable<bool> result = dlg.ShowDialog();

            // Process choice
            if (result == true)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }

        private string ShowSaveDialog(string filter = "All files (*.*)|*.*")
        {
            // Instantiate save file dialog
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = "";
            dlg.Filter = filter;

            // Show dialog
            Nullable<bool> result = dlg.ShowDialog();

            // Process choice
            if (result == true)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }

        // --- Event handlers ---

        private void LoadUnsignedMessage(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = ShowOpenDialog();
                string contents = File.ReadAllText(path);
                UnsignedMessageTextBox.Text = contents;
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }

        private void LoadSignedMessage(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = ShowOpenDialog();
                string contents = File.ReadAllText(path);
                SignedMessageTextBox.Text = contents;
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }
    }
}
