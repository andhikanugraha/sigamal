using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using SiGamalEngine;

namespace SiGamalOutlookAddin
{
    public partial class SiGamal : Form
    {
        public bool isSign = false;
        public Key key;
        public Key.PublicKey pubKey;

        public SiGamal()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void SignButton_Click(object sender, EventArgs e)
        {
            isSign = true;
            key = new Key(BigInteger.Parse(pSignTextBox.Text), BigInteger.Parse(gSignTextBox.Text), BigInteger.Parse(xSignTextBox.Text));
            Close();
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            isSign = false;
            pubKey = new Key.PublicKey();
            pubKey.P = BigInteger.Parse(pVerifyTextBox.Text);
            pubKey.G = BigInteger.Parse(gVerifyTextBox.Text);
            pubKey.Y = BigInteger.Parse(yVerifyTextBox.Text);
            Close();
        }

        private void LoadKeyVerifyButton_Click(object sender, EventArgs e)
        {
            // Load Key for Verify
            string fileKey = ShowOpenDialog("Public Key (*.pub)|*.pub");
            if (fileKey == null) return;

            Key.PublicKey pubkey = Key.GeneratePublicKeyFromFile(fileKey);
            
            gVerifyTextBox.Text = pubkey.G.ToString();
            pVerifyTextBox.Text = pubkey.P.ToString();
            yVerifyTextBox.Text = pubkey.Y.ToString();
        }

        private void RandomKeySignButton_Click(object sender, EventArgs e)
        {
            // Generate Random Key
            key = Key.GenerateRandomKey();
            Key.PrivateKey pKey = key.GeneratePrivateKey();
            pSignTextBox.Text = pKey.P.ToString();
            gSignTextBox.Text = pKey.G.ToString();
            xSignTextBox.Text = pKey.X.ToString();
        }

        private string ShowOpenDialog(string filter = "All files (*.*)|*.*")
        {
            string s = null;
            // Instantiate open file dialog
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            dlg.DefaultExt = "";
            dlg.Filter = filter;

            // Show dialog
            DialogResult result = dlg.ShowDialog();

            // Process choice
            if (result == DialogResult.OK)
            {
                string filename = dlg.FileName;
                s = filename;
            }
            return s;
        }

        private void LoadKeySignButton_Click(object sender, EventArgs e)
        {
            // Load Key Sign
            string fileKey = ShowOpenDialog("Public Key (*.pri)|*.pri");
            if (fileKey == null) return;

            Key.PrivateKey prkey = Key.GeneratePrivateKeyFromFile(fileKey);

            gSignTextBox.Text = prkey.G.ToString();
            pSignTextBox.Text = prkey.P.ToString();
            xSignTextBox.Text = prkey.X.ToString();
        }

        private void SaveKeySignButton_Click(object sender, EventArgs e)
        {
            // Save Key
            try
            {
                // Fetch ingredients for private key
                BigInteger p = BigInteger.Parse(pSignTextBox.Text);
                BigInteger g = BigInteger.Parse(gSignTextBox.Text);
                BigInteger x = BigInteger.Parse(xSignTextBox.Text);

                // Generate key
                Key k = new Key(p, g, x);
                Key.PrivateKey pri = k.GeneratePrivateKey();
                Key.PublicKey pub = k.GeneratePublicKey();

                SaveFileDialog fileBrowser = new SaveFileDialog();

                DialogResult result = fileBrowser.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string fileName = fileBrowser.FileName;
                    k.saveToFile(fileName);
                }
            }
            catch (Exception ex)
            {
                //ShowMessageBox("Key generation failed.");
            }
        }
    }
}
