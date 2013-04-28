using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace SiGamalOutlookAddin
{
    public partial class SiGamal : Form
    {
        public bool isSign = false;
        
        // Set Key
        public List<BigInteger> key;

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
            key = new List<BigInteger>();
            key.Add(BigInteger.Parse(pSignTextBox.Text));
            key.Add(BigInteger.Parse(gSignTextBox.Text));
            key.Add(BigInteger.Parse(xSignTextBox.Text));
            Close();
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            isSign = false;
            key = new List<BigInteger>();
            key.Add(BigInteger.Parse(pVerifyTextBox.Text));
            key.Add(BigInteger.Parse(gVerifyTextBox.Text));
            key.Add(BigInteger.Parse(yVerifyTextBox.Text));
            Close();
        }

        private void LoadKeyVerifyButton_Click(object sender, EventArgs e)
        {
            // Load Key for Verify

        }

        private void RandomKeySignButton_Click(object sender, EventArgs e)
        {
            // Generate Random Key

        }

        private void LoadKeySignButton_Click(object sender, EventArgs e)
        {
            // Load Key Sign

        }

        private void SaveKeySignButton_Click(object sender, EventArgs e)
        {
            // Save Key

        }
    }
}
