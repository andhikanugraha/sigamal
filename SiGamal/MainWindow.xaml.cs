using Microsoft.Win32;
using SiGamalEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

        private void GeneratePrivateKey(object sender, RoutedEventArgs e)
        {
            try
            {
                // Fetch ingredients for private key
                BigInteger p = BigInteger.Parse(pTextBox.Text);
                BigInteger g = BigInteger.Parse(gTextBox.Text);
                BigInteger x = BigInteger.Parse(xTextBox.Text);

                // Generate key
                SiGamalEngine.Key k = new SiGamalEngine.Key(p, g, x);
                SiGamalEngine.Key.PrivateKey pri = k.GeneratePrivateKey();
                SiGamalEngine.Key.PublicKey pub = k.GeneratePublicKey();

                xTextBox.Text = pri.X.ToString();
                yTextBox.Text = pub.Y.ToString();
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }

        private void SaveKeys(object sender, RoutedEventArgs e)
        {
            try
            {
                // Fetch ingredients for private key
                BigInteger p = BigInteger.Parse(pTextBox.Text);
                BigInteger g = BigInteger.Parse(gTextBox.Text);
                BigInteger x = BigInteger.Parse(xTextBox.Text);

                // Generate key
                SiGamalEngine.Key k = new SiGamalEngine.Key(p, g, x);
                SiGamalEngine.Key.PrivateKey pri = k.GeneratePrivateKey();
                SiGamalEngine.Key.PublicKey pub = k.GeneratePublicKey();

                SaveFileDialog fileBrowser = new SaveFileDialog();

                Nullable<bool> result = fileBrowser.ShowDialog();

                if (result == true)
                {
                    string fileName = fileBrowser.FileName;
                    k.saveToFile(fileName);
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message);
            }
        }

        private void LoadPublicKey(object sender, RoutedEventArgs e)
        {
            string fileKey = ShowOpenDialog("Public Key (*.pub)|*.pub");
            if (fileKey == null) return;

            SiGamalEngine.Key.PublicKey key = SiGamalEngine.Key.GeneratePublicKeyFromFile(fileKey);

            verifyGTextBox.Text = key.G.ToString();
            verifyPTextBox.Text = key.P.ToString();
            verifyYTextBox.Text = key.Y.ToString();
        }

        private void LoadPrivateKey(object sender, RoutedEventArgs e)
        {
            string fileKey = ShowOpenDialog("Private Key (*.pri)|*.pri");
            if (fileKey == null) return;

            SiGamalEngine.Key.PrivateKey key = SiGamalEngine.Key.GeneratePrivateKeyFromFile(fileKey);

            signPTextBox.Text = key.P.ToString();
            signGTextBox = key.G.ToString();
            signXTextBox.Text = key.X.ToString();
        }
    }
}
