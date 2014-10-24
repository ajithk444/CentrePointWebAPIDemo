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
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text.RegularExpressions;

namespace StudyAdminAPIAutomatedTest
{
    public partial class TestForm : Form
    {

        private StringBuilder sbLog;
        private String lastJsonResponse;
        private String defaultAccessKeyText;
        private String defaultSecretKeyText;


        public TestForm()
        {
            InitializeComponent();
            sbLog = new StringBuilder();

             //Initialize Client State Object
             //ClientState.AccessKey = "2f6507c9-f504-41cb-885f-601e507587b5";
             //ClientState.SecretKey = "71f6cde3-cd43-4a2b-9207-8c657424a48b";
             //ClientState.DefaultSubjectID = "594";

            // Add items to Base URI combo box
            ClientState.BaseURI = "https://studyadmin-api-dev.actigraphcorp.com"; // defaults to dev
            cbBaseURI.Items.Add(ClientState.BaseURI);
            //cbBaseURI.Items.Add("https://studyadmin-api.actigraphcorp.com"); // add production option
            cbBaseURI.SelectedIndex = 0;

            // Populate HttpMethod Dropdown list and default it to "GET" request type
            cbHttpMethod.Items.Add(HttpMethod.Get);
            cbHttpMethod.Items.Add(HttpMethod.Post);
            cbHttpMethod.Items.Add(HttpMethod.Put);
            cbHttpMethod.SelectedIndex = 0;
            txtBxRequest.Enabled = false;

            // Populate Built-In Tests Combo Box
            List<string> testCases = (from i in TestCaseRepo.Instance.TestCases
                                      select i.Name).ToList();
            testCases.Insert(0, "");
            cBBuiltInTests.DataSource = testCases;

            // Setting Help LInk
            linkLabelHelp.Links.Add(new LinkLabel.Link());
            linkLabelHelp.Click += (o,e) => {  Process.Start("https://github.com/actigraph/StudyAdminAPIDocumentation"); };

            // Set defaults for access and secret keys
            defaultAccessKeyText = "<Enter Access Key>";
            txtBxAccessKey.Text = "2f6507c9-f504-41cb-885f-601e507587b5";

           // txtBxAccessKey.Text = defaultAccessKeyText;
            txtBxAccessKey.MouseClick += (o, e) =>
            {
                if (txtBxAccessKey.Text.Equals(defaultAccessKeyText)) { 
                    txtBxAccessKey.Text = string.Empty;
                }
            };

            defaultSecretKeyText = "<Enter Secret Key>";
            txtBxSecretKey.Text = "71f6cde3-cd43-4a2b-9207-8c657424a48b";
            //txtBxSecretKey.Text = defaultSecretKeyText;
            txtBxSecretKey.MouseClick += (o, e) => 
            {
                if (txtBxSecretKey.Text.Equals(defaultSecretKeyText)) {
                    txtBxSecretKey.Text = string.Empty;
                }
            };


            cbHttpMethod.SelectedIndexChanged += (o, e) => 
            {
                txtBxRequest.Enabled = true;
                if (((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get))
                {
                    txtBxRequest.Clear();
                    txtBxRequest.Enabled = false;
                }    
            };

            // btnPopulate click action for button
            btnPopualte.Click += (o, e) => 
            {                
                // clear response box when selecting new built in test
                lblStatusCode.Text = string.Empty;
                btnCompareResponse.Enabled = false;

                APITestCase apiTest = (
                from i in TestCaseRepo.Instance.TestCases 
                where i.Name.Equals(cBBuiltInTests.Text) 
                select i).FirstOrDefault();

                if (apiTest != null) 
                {
                    txtBxURI.Text = apiTest.DefaultResourceURI;
                    cbHttpMethod.SelectedItem = apiTest.HttpVerb;
                    
                    if (((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get))
                    {
                        txtBxRequest.Enabled = false;
                        txtBxRequest.Clear();
                    }
                    else 
                    {
                        txtBxRequest.Enabled = true;
                        txtBxRequest.Text = apiTest.GetJsonRequestText(); ;
                    }
                } 
                else 
                {
                    txtBxRequest.Clear();
                }
            };

            // setting onselectedchange action for baseURI combo box
            cbBaseURI.SelectedIndexChanged += (o, e) => 
            {
                txtBxRequest.Text = string.Empty;
                cBBuiltInTests.SelectedIndex = 0;
                txtBxResponse.Text = string.Empty;
                lblStatusCode.Text = string.Empty;
                btnCompareResponse.Enabled = false;
            };

            // Open Compare Response Form in Dialog Box
            btnCompareResponse.Click += (o, e) => 
            {
                CompareResponse compareResponse = new CompareResponse(lastJsonResponse);
                compareResponse.ShowDialog();
            };

            // setting click action for execute button
            btnExecute.Click += async (o,e) => {
           
                APITestCase apiTest = null;
                Task<string> jsonResponseTask;
                string jsonResponse = string.Empty;
                string jsonRequestRaw = txtBxRequest.Text;    
                
                DateTime requestTime = DateTime.Now;
                string errorMessage = string.Empty;

                try
                {

                    lblStatusCode.Text = String.Empty;
                    btnCompareResponse.Enabled = false;

                    lblError.Text = string.Empty;
                    if (!IsValidInput()) { 
                       lblError.Text = "Required Fields Missing";
                       return;
                    }
                    // Updating Client State Before Execution
                    ClientState.BaseURI = cbBaseURI.Text;
                    ClientState.AccessKey = txtBxAccessKey.Text;
                    ClientState.SecretKey = txtBxSecretKey.Text;
                    
                    // Update Endpoint
                    apiTest = new APITestCase();
                    apiTest.CurrentEndpoint = string.Format("{0}{1}",ClientState.BaseURI,txtBxURI.Text);
                    apiTest.HttpVerb = (HttpMethod)cbHttpMethod.SelectedItem;

                    requestTime = DateTime.Now;

                    jsonResponseTask = apiTest.Run(new Regex("(\r\n|\r|\n)").Replace(jsonRequestRaw, ""));

                    await jsonResponseTask;

                    jsonResponse = jsonResponseTask.Result;
                    lastJsonResponse = jsonResponse;

                }
                catch (Exception ex) // Catch All
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
                        errMsg = "Unable to connect to Study Admin API";
                    }
                    else
                    {
                        errMsg = current.Message;
                    }

                    lblError.Text = errMsg;

                }
                finally 
                {
                    // Update Response Status Code
                    if (apiTest != null && apiTest.responseStatusCode != null) 
                    {
                        if (apiTest.responseStatusCode.Equals(System.Net.HttpStatusCode.OK) || apiTest.responseStatusCode.Equals(System.Net.HttpStatusCode.Created)) 
                        {
                            lblStatusCode.ForeColor = Color.Green;
                            lblStatusCode.ImageAlign = ContentAlignment.MiddleLeft;
                            lblStatusCode.Image = StudyAdminAPITester.Properties.Resources.check_smaller;
                            btnCompareResponse.Enabled = true;
                        } 
                        else 
                        {
                            lblStatusCode.ForeColor = Color.Red;
                            lblStatusCode.ImageAlign = ContentAlignment.MiddleLeft;
                            lblStatusCode.Image = StudyAdminAPITester.Properties.Resources.cancel_small;
                            btnCompareResponse.Enabled = true;
                        }
                        lblStatusCode.Text = string.Format("      HTTP Status Code {0} {1}",  (int)apiTest.responseStatusCode,  (string)apiTest.responseStatusCode.ToString());

                        // Update Log
                        sbLog.Insert(0, GetResponseLog(jsonResponse, apiTest.responseStatusCode));
                        sbLog.Insert(0, GetRequestLog(apiTest.HttpVerb, txtBxURI.Text, jsonRequestRaw, requestTime));
                        txtBxResponse.Text = sbLog.ToString();

                    }

                }
                
            };

            #region response right click menu


            toolStripMenuItemClearLog.Click += (obj, sender) => { txtBxResponse.Clear(); lblStatusCode.Text = string.Empty; };
            toolStripMenuItemSaveLog.Click += (obj, sender) =>
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "TXT Files (*.txt)|*.txt";
                    saveFileDialog.Title = "Save to a text File";
                    var result = saveFileDialog.ShowDialog();
                    if (result != DialogResult.OK)
                        return;

                    using (StreamWriter s = new StreamWriter(saveFileDialog.FileName))
                        s.Write(txtBxResponse.Text);

                    Process.Start(saveFileDialog.FileName);
                }
            };


            #endregion response right click menu

            
        }


        private string GetRequestLog(HttpMethod requestVerb, string uri, String jsonRequest, DateTime requestTime)
        {

            StringBuilder sb = new StringBuilder();
            
            // If GET Request, show it in request
            sb.Append(string.Format("REQUEST ({0}):", requestTime.ToString()));
            sb.Append(string.Format("    {0}   {1}",requestVerb.ToString(),uri));
            sb.Append(Environment.NewLine);
            sb.Append(jsonRequest);
            return sb.ToString();

        }


        private string GetResponseLog(string jsonResponse, HttpStatusCode statusCode)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(String.Format("RESPONSE: (Status Code: {0} - {1}){2}",(int) statusCode, statusCode.ToString(), Environment.NewLine));
            sb.Append(jsonResponse);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("-------------------------------------------------------------------------------------------------");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            return sb.ToString();

        }


        private Boolean IsValidInput()
        {
            bool isValid = true;

            lblAccessKeyRequired.Text = string.Empty;
            lblSecretKeyRequired.Text = string.Empty;
            lblRequestRequired.Text = string.Empty;
            lblBaseURIRequired.Text = string.Empty;


            if (String.IsNullOrEmpty( txtBxAccessKey.Text ) || txtBxAccessKey.Text.Equals(defaultAccessKeyText)) 
            {
                lblAccessKeyRequired.Text = "*";
                isValid = false;
            }

            if (String.IsNullOrEmpty(txtBxSecretKey.Text) || txtBxSecretKey.Text.Equals(defaultSecretKeyText))  
            {
                lblSecretKeyRequired.Text = "*";
                isValid = false;
            }

            if (String.IsNullOrEmpty( txtBxURI.Text)) 
            {
                lblUriRequired.Text = "*";
                isValid = false;
            }

            if (txtBxRequest.Enabled && String.IsNullOrEmpty( txtBxRequest.Text )) 
            {
                lblRequestRequired.Text = "*";
                isValid = false;
            }

            if (string.IsNullOrEmpty(cbBaseURI.Text)) 
            {
                lblBaseURIRequired.Text = "*";
                isValid = false;
            }

            return isValid;

        }

    }
}
