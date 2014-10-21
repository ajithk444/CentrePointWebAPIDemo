using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyAdminAPILib;
using Newtonsoft.Json;
using StudyAdminAPILib.JsonDTOs;

namespace StudyAdminAPIAutomatedTest
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            // Initialize Client State Object
            ClientState.AccessKey = "2f6507c9-f504-41cb-885f-601e507587b5";
            ClientState.SecretKey = "71f6cde3-cd43-4a2b-9207-8c657424a48b";
            ClientState.DefaultSubjectID = "594";

            // Add items to Base URI combo box
            ClientState.BaseURI = "https://studyadmin-api-dev.actigraphcorp.com"; // defaults to dev
            //cbBaseURI.Items.Add("http://localhost:49248");
            cbBaseURI.Items.Add(ClientState.BaseURI);
            cbBaseURI.Items.Add("https://studyadmin-api.actigraphcorp.com"); // add production option
            cbBaseURI.SelectedIndex = 0;
            
            // Populate Tests Combo Box
            List<string> testCases = (from i in TestCaseRepo.Instance.TestCases
                                      select i.Name).ToList();
            testCases.Insert(0, "");
            cBBuiltInTests.DataSource = testCases;
          
            // Set defaults for access and secret keys
            txtBxAccessKey.Text = ClientState.AccessKey;
            txtBxSecretKey.Text = ClientState.SecretKey;

            // Setting onselectedchage action for tests combo box
            cBBuiltInTests.SelectedIndexChanged += (o, e) => {
                
                // clear response box when selecting new built in test
                txtBxResponse.Text = string.Empty;
                
                APITestCase apiTest = (
                from i in TestCaseRepo.Instance.TestCases 
                where i.Name.Equals(cBBuiltInTests.Text) 
                select i).FirstOrDefault();

                if (apiTest != null) {
                    txtBxRequest.Text = apiTest.GetJsonRequestText();
                } else {
                    txtBxRequest.Text = string.Empty;
                }
            };

            // setting onselectedchange action for baseURI combo box
            cbBaseURI.SelectedIndexChanged += (o, e) => {

                ClientState.BaseURI = cbBaseURI.Text;
                txtBxRequest.Text = string.Empty;
                cBBuiltInTests.SelectedIndex = 0;
                cbBaseURI.Text = string.Empty;
                txtBxResponse.Text = string.Empty;

            };

           
            // setting click action for execute button
            btnExecute.Click += (o,e) => {
    
                try
                {

                    if (!IsValidInput())
                        throw new Exception("** Required Fields Missing **");
                    
                    // Updating Client State Before Execution
                    ClientState.BaseURI = cbBaseURI.Text;
                    ClientState.AccessKey = txtBxAccessKey.Text;
                    ClientState.SecretKey = txtBxSecretKey.Text;
                    APITestCase apiTest = (from i in TestCaseRepo.Instance.TestCases
                                            where i.Name.Equals(cBBuiltInTests.Text)
                                            select i).FirstOrDefault();

                    string jsonResponse = apiTest.Run(txtBxRequest.Text);

                    if (jsonResponse.Equals("Unauthorized")) {
                        throw new Exception("Unauthorized Access. Please verify Base URI, Access Key and Private Key");
                    }

                    txtBxResponse.Text = jsonResponse;
                }
                catch (Exception ex) {
                    
                    lblValidationError.Text = String.Empty;
                    
                    if (ex.InnerException != null && ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message.StartsWith("Unable to connect")) 
                    {
                        lblValidationError.Text = "** Unable to connect to Study Admin API **";
                    }
                    else
                    {
                        lblValidationError.Text = ex.Message;
                    }
                }
                
            };
            
        }


        private Boolean IsValidInput()
        {
            bool isValid = true;

            lblAccessKeyRequired.Text = string.Empty;
            lblSecretKeyRequired.Text = string.Empty;
            lblTestRequired.Text = string.Empty;
            lblRequestRequired.Text = string.Empty;

            if (String.IsNullOrEmpty( txtBxAccessKey.Text )) 
            {
                lblAccessKeyRequired.Text = "*";
                isValid = false;
            }

            if (String.IsNullOrEmpty( txtBxSecretKey.Text ))  
            {
                lblSecretKeyRequired.Text = "*";
                isValid = false;
            }

            if (!(cBBuiltInTests.SelectedIndex > 0))
            {
                lblTestRequired.Text = "*";
                isValid = false;
            }

            if (String.IsNullOrEmpty( txtBxRequest.Text )) 
            {
                lblRequestRequired.Text = "*";
                isValid = false;
            }

            return isValid;

        }


    }
}
