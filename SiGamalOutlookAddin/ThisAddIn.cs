using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using SiGamalEngine;
using System.Numerics;

namespace SiGamalOutlookAddin
{
    public partial class ThisAddIn
    {
        Outlook.Inspectors inspectors;

        // Controll @ Toolbar
        private string toolBarTagEmail = "Sign Email";

        private Office.CommandBarButton siGamalBarButton;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            inspectors = this.Application.Inspectors;
            inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);
            inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(AddToEmail); 
        }

        void Inspectors_NewInspector(Outlook.Inspector Inspector)
        {
            Outlook.MailItem item = Inspector.CurrentItem as Outlook.MailItem;
            if (item != null)
            {
                if (item.EntryID == null)
                {
                    item.Subject = "Adding Subject";
                    item.Body = "Adding Body";
                }
                
            }
        }

        private void AddToEmail(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            Outlook.MailItem _ObjMailItem = (Outlook.MailItem)Inspector.CurrentItem;
            System.Diagnostics.Debug.WriteLine("Add to Mail");
            if (Inspector.CurrentItem is Outlook.MailItem)
            {
                System.Diagnostics.Debug.WriteLine("Add to Mail 1");
                bool IsExists = false;

                foreach (Office.CommandBar _ObjCmd in Inspector.CommandBars)
                {
                    if (_ObjCmd.Name == toolBarTagEmail)
                    {
                        IsExists = true;
                        _ObjCmd.Delete();
                    }
                }

                Office.CommandBar _ObjCommandBar = Inspector.CommandBars.Add(toolBarTagEmail, Office.MsoBarPosition.msoBarTop, false, true);
                siGamalBarButton = (Office.CommandBarButton)_ObjCommandBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, missing, missing, true);
                
                if (!IsExists)
                {
                    System.Diagnostics.Debug.WriteLine("Add to Mail - 2");
                    siGamalBarButton.Caption = "SiGamal";
                    siGamalBarButton.Style = Office.MsoButtonStyle.msoButtonIconAndCaptionBelow;
                    siGamalBarButton.FaceId = 500;
                    siGamalBarButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(siGamalBarButton_Click);
                    _ObjCommandBar.Visible = true;
                    siGamalBarButton.Visible = true;
                    
                }
            }
        }

        private void siGamalBarButton_Click(Office.CommandBarButton ctrl, ref bool cancel)
        {
            try
            {
                SiGamal view = new SiGamal();
                view.ShowDialog();
                if (view.isSign)
                    SignEmail(view.key.GeneratePrivateKey());
                else
                    VerifyEmail(view.pubKey);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message.ToString());
            }
        }

        private void SignEmail(Key.PrivateKey key)
        {
            Outlook.Application application = Globals.ThisAddIn.Application;
            Outlook.Inspector inspector = application.ActiveInspector();
            Outlook.MailItem item = (Outlook.MailItem)inspector.CurrentItem;
            //Outlook.MailItem item = Outlook. Inspector.CurrentItem as Outlook.MailItem;
            if (item != null)
            {
                if (item.EntryID == null)
                {
                    // Put Algorithm Sign Here
                    SHA256 sha = new SHA256();
                    BigInteger hash = sha.GetMessageDigestToBigInteger(item.Body);
                    System.Windows.Forms.MessageBox.Show("Hash=" +sha.GetMessageDigestToBigInteger(item.Body).ToString());
                    item.Body += "\n<sign>"+ SiGamalGenerator.signature(key.P,key.G,key.X,hash) +"<sign>";
                }

            }
        }
        private void VerifyEmail(Key.PublicKey pubKey)
        {
            Outlook.Application application = Globals.ThisAddIn.Application;
            Outlook.Inspector inspector = application.ActiveInspector();
            Outlook.MailItem item = (Outlook.MailItem)inspector.CurrentItem;
            //Outlook.MailItem item = Outlook. Inspector.CurrentItem as Outlook.MailItem;
            if (item != null)
            {
                if (item.EntryID == null)
                {
                    // Put Algorithm Verify Here
                    string rs = item.Body.Substring(item.Body.IndexOf("<sign>"));
                    rs = rs.Substring(6);
                    rs = rs.Substring(0,rs.IndexOf("<sign>"));
                    System.Windows.Forms.MessageBox.Show(rs);
                    System.Windows.Forms.MessageBox.Show(rs.Substring(0,rs.IndexOf('-')));
                    System.Windows.Forms.MessageBox.Show(item.Body.Substring(0,item.Body.IndexOf("\n<sign>")-1));
                    BigInteger r = BigInteger.Parse("0" + rs.Substring(0,rs.IndexOf('-')),System.Globalization.NumberStyles.HexNumber);
                    BigInteger s = BigInteger.Parse("0" + rs.Substring(rs.IndexOf('-') + 1), System.Globalization.NumberStyles.HexNumber);
                    SHA256 sha = new SHA256();
                    if (SiGamalGenerator.verification(r, s, pubKey.G, sha.GetMessageDigestToBigInteger(item.Body.Substring(0,item.Body.IndexOf("\n<sign>")-1)), pubKey.Y, pubKey.P))
                    {
                        System.Windows.Forms.MessageBox.Show("TRUE");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("FALSE");
                    }
                }

            }
        }
        
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
