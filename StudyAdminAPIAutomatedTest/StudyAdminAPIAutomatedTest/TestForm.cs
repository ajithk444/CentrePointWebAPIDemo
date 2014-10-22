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
using Newtonsoft.Json.Linq;
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
                lblStatusCode.Text = string.Empty;
                btnCompareResponse.Enabled = false;

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
                txtBxRequest.Text = string.Empty;
                cBBuiltInTests.SelectedIndex = 0;
                cbBaseURI.Text = string.Empty;
                txtBxResponse.Text = string.Empty;
                lblStatusCode.Text = string.Empty;
                btnCompareResponse.Enabled = false;
            };

            // Open Compare Response Form
            btnCompareResponse.Click += (o, e) =>
            {
                CompareResponse compareResponse = new CompareResponse(txtBxResponse.Text);
                compareResponse.ShowDialog();
            };
           
            // setting click action for execute button
            btnExecute.Click += (o,e) => {
            APITestCase apiTest = null; 
            
                try
                {
                    txtBxResponse.Text = String.Empty;
                    lblValidationError.Text = String.Empty;
                    lblStatusCode.Text = String.Empty;
                    btnCompareResponse.Enabled = false;

                    if (!IsValidInput())
                        throw new Exception("** Required Fields Missing **");

                    
                    // Updating Client State Before Execution
                    ClientState.BaseURI = cbBaseURI.Text;
                    ClientState.AccessKey = txtBxAccessKey.Text;
                    ClientState.SecretKey = txtBxSecretKey.Text;
                    apiTest = (from i in TestCaseRepo.Instance.TestCases
                                           where i.Name.Equals(cBBuiltInTests.Text)
                                           select i).FirstOrDefault();

                    string jsonResponse = apiTest.Run(txtBxRequest.Text);
                    CheckForProblem(jsonResponse);
                    txtBxResponse.Text = jsonResponse;

                }
                catch (Exception ex)
                {
                    // retrieve the inner most exception
                    Exception current = ex;
                    while (current.InnerException != null) 
                    {
                        current = current.InnerException;
                    }
                    
                    string errMsg = null;
                    if (current.Message.StartsWith("Unable to connect"))
                    {
                        errMsg = "** Unable to connect to Study Admin API **";
                    }
                    else
                    {
                        errMsg = current.Message;
                    }

                    lblValidationError.Text = errMsg;
                    lblValidationError.MaximumSize = new Size(375, 0);
                    lblValidationError.AutoSize = true;

                }
                finally 
                {
                    if (apiTest != null && apiTest.responseStatusCode != null) 
                    {          
                        if (apiTest.responseStatusCode.Equals(System.Net.HttpStatusCode.OK)) 
                        {
                            lblStatusCode.ForeColor = Color.Green;
                            btnCompareResponse.Enabled = true;
                        } 
                        else 
                        {
                            lblStatusCode.ForeColor = Color.Red;
                        }
                        lblStatusCode.Text = "HTTP Status Code: " + apiTest.responseStatusCode.ToString();         
                    }
                }
                
            };
            
        }


        private void CheckForProblem(string jsonResponse)
        {

            if (jsonResponse.Equals("Unauthorized"))
            {
                throw new Exception("Unauthorized Access. Please verify Base URI, Access Key and Private Key.");
            }

            try
            {
                // Try Parsing Response to standard Jobject
                JsonConvert.DeserializeObject<JObject>(jsonResponse);
            }
            catch (Exception) 
            {
                try
                {
                    // If JObject didn't work, then try Parsing Response to standard JArray
                    JsonConvert.DeserializeObject<JArray>(jsonResponse);
                }
                catch (Exception) 
                {
                    try
                    {
                        // If JArray didn't work, then try Parsing Response to standard JRaw
                        JsonConvert.DeserializeObject<JRaw>(jsonResponse);
                    }
                    catch (Exception) 
                    {
                        throw new Exception(jsonResponse);
                    }
                }
            }
          
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
