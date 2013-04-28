using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace SiGamalOutlookAddin
{
    public partial class ThisAddIn
    {
        Outlook.Inspectors inspectors;

        // Controll @ Toolbar
        private string toolBarTagEmail = "Sign Email";

        private Office.CommandBarButton siGamalBarButton;
        private Office.CommandBarButton verifyButton;

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

            if (Inspector.CurrentItem is Outlook.MailItem)
            {
                _ObjMailItem = (Outlook.MailItem)Inspector.CurrentItem;
                bool IsExists = false;

                foreach (Office.CommandBar _ObjCmd in Inspector.CommandBars)
                {
                    if (_ObjCmd.Name == toolBarTagEmail)
                    {
                        IsExists = true;
                        _ObjCmd.Delete();
                    }
                }

                Office.CommandBar _ObjCommandBar = Inspector.CommandBars.Add(toolBarTagEmail, Office.MsoBarPosition.msoBarBottom, false, true);
                siGamalBarButton = (Office.CommandBarButton)_ObjCommandBar.Controls.Add(Office.MsoControlType.msoControlButton, 1, missing, missing, true);
                
                if (!IsExists)
                {
                    siGamalBarButton.Caption = "Si-Gamal";
                    siGamalBarButton.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
                    siGamalBarButton.FaceId = 500;
                    siGamalBarButton.Click += new Office._CommandBarButtonEvents_ClickEventHandler(siGamalBarButton_Click);
                    
                    
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
                    SignEmail();
                else
                    VerifyEmail();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message.ToString());
            }
        }

        private void SignEmail()
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
                    item.Body += "\n<sign>"+ "Key String Sign" +"<sign>";
                }

            }
        }
        private void VerifyEmail()
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
