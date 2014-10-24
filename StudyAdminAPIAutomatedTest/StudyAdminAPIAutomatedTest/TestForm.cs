﻿using System;
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
using System.Net.Http;
using System.IO;

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
            cbHttpMethod.Items.Add(HttpMethod.Delete);
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
                string jsonResponse = string.Empty;
                Task<string> jsonResponseTask;
                string jsonRequest = txtBxRequest.Text;

                try
                {

                   // lblError.Text = String.Empty;
                    lblStatusCode.Text = String.Empty;
                    btnCompareResponse.Enabled = false;

                    if (!IsValidInput())
                        throw new Exception("Required Fields Missing");

                    // Updating Client State Before Execution
                    ClientState.BaseURI = cbBaseURI.Text;
                    ClientState.AccessKey = txtBxAccessKey.Text;
                    ClientState.SecretKey = txtBxSecretKey.Text;
                    
                    // Update Endpoint
                    apiTest = new APITestCase();
                    apiTest.CurrentEndpoint = ClientState.BaseURI + txtBxURI.Text;
                    apiTest.HttpVerb = (HttpMethod)cbHttpMethod.SelectedItem;
                    apiTest.dto = !apiTest.HttpVerb.Equals(HttpMethod.Get) ? GetJsonDTO(txtBxURI.Text, apiTest.HttpVerb, jsonRequest) : null;
                    jsonResponseTask = apiTest.HttpVerb.Equals(HttpMethod.Get) ? apiTest.Run() : apiTest.Run(jsonRequest);
                    InsertRequestToLog(apiTest.HttpVerb, txtBxURI.Text, jsonRequest);

                    await jsonResponseTask;

                    jsonResponse = jsonResponseTask.Result;
       
                    CheckForProblem(jsonResponse);
                    lastJsonResponse = jsonResponse; // Used for Compare Dialog Box

                    InsertResponseToLog(apiTest.HttpVerb, txtBxURI.Text, jsonResponse);


                }
                catch (JsonReaderException ex) 
                {
                    //lblError.Text = string.Format("      {0}", "Json format not valid");
                    //lblError.MaximumSize = new Size(495, 0);
                    //lblError.AutoSize = true;
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
                        errMsg = "Unable to connect to Study Admin API";
                    }
                    else
                    {
                        errMsg = current.Message;
                    }

                    //lblError.Text = string.Format("      {0}", errMsg);
                    //lblError.MaximumSize = new Size(495, 0);
                    //lblError.AutoSize = true;

                }
                finally 
                {
                    if (apiTest != null && apiTest.responseStatusCode != null) 
                    {          
                        if (apiTest.responseStatusCode.Equals(System.Net.HttpStatusCode.OK)) 
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
                        lblStatusCode.Text = string.Format("      HTTP Status Code {0}  {1}",  (int)apiTest.responseStatusCode,  (string)apiTest.responseStatusCode.ToString());         
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


        private void InsertRequestToLog(HttpMethod requestVerb, string uri, String jsonRequest)
        {

            StringBuilder sb = new StringBuilder();
            
            // If GET Request, show it in request
            sb.Append(string.Format("REQUEST ({0}):", DateTime.Now.ToString()));
            sb.Append(requestVerb.Equals(HttpMethod.Get) ? "    " + uri : "");
            sb.Append(Environment.NewLine);
            sb.Append(jsonRequest);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);

            sbLog.Insert(0, sb.ToString());
            txtBxResponse.Text = sbLog.ToString();

        }


        private void InsertResponseToLog(HttpMethod requestVerb, string uri, string jsonResponse)
        {


            StringBuilder sb = new StringBuilder();

            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("RESPONSE:" + Environment.NewLine);
            sb.Append(jsonResponse);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("-------------------------------------------------------------------------------------------------");
            sbLog.Insert(0, sb.ToString());            
            txtBxResponse.Text = sbLog.ToString();
        }


        private APIJsonDTO GetJsonDTO(string uri, HttpMethod verb, String request) 
        {

            if (verb.Equals(HttpMethod.Put) && uri.Contains("subjects")) // Update Subject
            {
                return (APIJsonDTO)JsonConvert.DeserializeObject<UpdateSubjectDTO>(request);
            }
            else if (verb.Equals(HttpMethod.Post) && uri.Contains("subjects")) // Add Subject
            {
                return (APIJsonDTO)JsonConvert.DeserializeObject<AddSubjectDTO>(request);
            }
            else
            {
                return null;
            }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }



    }
}
