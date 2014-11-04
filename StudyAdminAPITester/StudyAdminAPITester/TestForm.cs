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
using System.Xml.Schema;
using System.Xml;
using System.Xml.Linq;

namespace StudyAdminAPITester
{
    public partial class TestForm : Form
    {

        private StringBuilder sbLog;
        private StringBuilder sbLogBatch;
        private String lastJsonResponse;
        private String defaultAccessKeyText;
        private String defaultSecretKeyText;
        private String xmlNamespace = "http://www.w3schools.com";

        public TestForm()
        {
            InitializeComponent();
            sbLog = new StringBuilder();
            sbLogBatch = new StringBuilder();

            // Add items to Base URI combo box
            ClientState.BaseURI = "https://studyadmin-api-dev.actigraphcorp.com"; // defaults to dev
            cbBaseURI.Items.Add(ClientState.BaseURI);
            cbBaseURI.SelectedIndex = 0;

            cbBatchBaseUri.Items.Add(ClientState.BaseURI);
            cbBatchBaseUri.SelectedIndex = 0;

            // Populate HttpMethod Dropdown list and default it to "GET" request type
            cbHttpMethod.Items.Add(HttpMethod.Get);
            cbHttpMethod.Items.Add(HttpMethod.Post);
            cbHttpMethod.Items.Add(HttpMethod.Put);
            cbHttpMethod.SelectedIndex = 0;
            txtBxRequest.Enabled = false;

            lblStatusCode.Text = string.Empty;
            btnExecute.Enabled = false;
            lblError.Text = string.Empty;
            lblAccessKeyRequired.Text = string.Empty;
            lblSecretKeyRequired.Text = string.Empty;
            lblError.Text = string.Empty;

            // Populate Built-In Tests Combo Box
            List<string> testCases = (from i in BuiltInTestCaseRepo.Instance.TestCases
                                      select i.Name).ToList();
            testCases.Insert(0, "");
            cBBuiltInTests.DataSource = testCases;

            // Setting Help LInk
            linkLabelHelp.Links.Add(new LinkLabel.Link());
            linkLabelHelp.Click += (o, e) => { Process.Start("https://github.com/actigraph/StudyAdminAPIDocumentation"); };

            // Set defaults for access and secret keys
            defaultAccessKeyText = "<Enter Access Key>";
            txtBxAccessKey.Text = defaultAccessKeyText;
            txtBxAccessKey.MouseClick += (o, e) =>
            {
                if (txtBxAccessKey.Text.Equals(defaultAccessKeyText))
                {
                    txtBxAccessKey.Text = string.Empty;
                }
            };

            defaultSecretKeyText = "<Enter Secret Key>";
            txtBxSecretKey.Text = defaultSecretKeyText;
            txtBxSecretKey.MouseClick += (o, e) =>
            {
                if (txtBxSecretKey.Text.Equals(defaultSecretKeyText))
                {
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

                btnExecute.Enabled = (txtBxURI.TextLength != 0 && ((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get)) ||
                        (txtBxURI.TextLength != 0 && txtBxRequest.TextLength != 0 && !((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get));
            };

            // btnPopulate click action for button
            btnPopualte.Click += (o, e) =>
            {
                // clear response box when selecting new built in test
                lblStatusCode.Text = string.Empty;
                btnCompareResponse.Enabled = false;

                APITestCase apiTest = (
                from i in BuiltInTestCaseRepo.Instance.TestCases
                where i.Name.Equals(cBBuiltInTests.Text)
                select i).FirstOrDefault();

                if (apiTest != null)
                {
                    txtBxURI.Text = apiTest.DefaultResourceURI;
                    cbHttpMethod.SelectedItem = apiTest.HttpVerb;

                    if (((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get))
                    {
                        btnExecute.Enabled = true;
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


            // Open Compare Response Form in Dialog Box
            btnCompareResponse.Click += (o, e) =>
            {
                CompareResponse compareResponse = new CompareResponse(lastJsonResponse);
                compareResponse.ShowDialog();
            };

            txtBxRequest.TextChanged += (o, e) =>
            {
                btnExecute.Enabled = (txtBxURI.TextLength != 0 && ((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get)) ||
                           (txtBxURI.TextLength != 0 && txtBxRequest.TextLength != 0 && !((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get));

            };

            txtBxURI.TextChanged += (o, e) =>
            {
                btnExecute.Enabled = (txtBxURI.TextLength != 0 && ((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get)) ||
                    (txtBxURI.TextLength != 0 && txtBxRequest.TextLength != 0 && !((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get));
            };

            int previousSplitterDisatnace = splitContainerRequest.SplitterDistance;
            splitContainerRequest.SplitterMoved += (o, e) =>
            {
                if (grpBxContent.Height <= 20 || grpBxResponse.Height <= 20)
                {
                    splitContainerRequest.SplitterDistance = previousSplitterDisatnace;
                }
                else
                {
                    previousSplitterDisatnace = splitContainerRequest.SplitterDistance;
                }
            };


            // setting click action for execute button
            btnExecute.Click += async (o, e) =>
            {

                APITestCase apiTest = null;
                string jsonResponse = string.Empty;
                string jsonRequestRaw = txtBxRequest.Text;
                DateTime requestTime = DateTime.Now;

                try
                {
                    lblStatusCode.Text = String.Empty;
                    btnCompareResponse.Enabled = false;

                    lblError.Text = string.Empty;
                    if (!IsValidInput())
                    {
                        lblError.Text = "Required Fields Missing";
                        return;
                    }

                    // Updating Client State Before Execution
                    ClientState.BaseURI = cbBaseURI.Text;
                    ClientState.AccessKey = txtBxAccessKey.Text;
                    ClientState.SecretKey = txtBxSecretKey.Text;

                    // Update Endpoint
                    apiTest = new APITestCase();
                    apiTest.CurrentEndpoint = string.Format("{0}{1}", ClientState.BaseURI, txtBxURI.Text);
                    apiTest.HttpVerb = (HttpMethod)cbHttpMethod.SelectedItem;

                    // Request Message Time Stamp
                    requestTime = DateTime.Now;

                    // Hide "Waiting For Response..." label
                    lblWaitingForResponse.Visible = true;

                    // disable send request button while text is running
                    btnExecute.Enabled = false;

                    // await for async method to finish
                    jsonResponse = await apiTest.Run(new Regex("(\r\n|\r|\n)").Replace(jsonRequestRaw, ""));

                    // Set last Json response for tool
                    lastJsonResponse = jsonResponse;

                    // re-enable send request button after request is complete
                    btnExecute.Enabled = true;

                    // Hide "Waiting For Response..." label
                    lblWaitingForResponse.Visible = false;

                    // Enable Compare Button
                    btnCompareResponse.Enabled = true;

                    // Update Response Status Code     
                    if (apiTest.responseStatusCode.Equals(System.Net.HttpStatusCode.OK) || apiTest.responseStatusCode.Equals(System.Net.HttpStatusCode.Created))
                    {
                        lblStatusCode.ForeColor = Color.Green;
                        lblStatusCode.Image = StudyAdminAPITester.Properties.Resources.check_smaller;
                    }
                    else
                    {
                        lblStatusCode.ForeColor = Color.Red;
                        lblStatusCode.Image = StudyAdminAPITester.Properties.Resources.cancel_small;
                    }

                    lblStatusCode.ImageAlign = ContentAlignment.MiddleLeft;
                    lblStatusCode.Text = string.Format("      HTTP Status Code {0} {1}", (int)apiTest.responseStatusCode, (string)apiTest.responseStatusCode.ToString());

                    // Update Log
                    InsertResposneToLog(jsonResponse, apiTest.responseStatusCode);
                    InsertRequestToLog(apiTest.HttpVerb, apiTest.CurrentEndpoint, jsonRequestRaw, requestTime);
                    txtBxResponse.Text = sbLog.ToString();

                    // Focus on Response text box
                    txtBxResponse.Focus();

                }
                catch (HttpRequestException)
                {
                    lblError.Text = string.Format("A problem occured while sending request to {0}", apiTest.CurrentEndpoint);
                }
                catch (Exception) // Catch Everything else
                {
                    lblError.Text = "A problem has occured. Please contact the Study Admin Team."; 
                }
                finally
                {
                    btnExecute.Enabled = true;
                    lblWaitingForResponse.Visible = false;
                }
            };

            #region response right click menu

            toolStripMenuItemClearLog.Click += (obj, sender) =>
            {
                txtBxResponse.Clear();
                sbLog.Clear();
                lblStatusCode.Text = string.Empty;
                lblError.Text = string.Empty;
                lblUriRequired.Text = string.Empty;
                lblAccessKeyRequired.Text = string.Empty;
                lblSecretKeyRequired.Text = string.Empty;
            };

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


        private void InsertRequestToLog( HttpMethod requestVerb, string uri, String jsonRequest, DateTime requestTime)
        {
            sbLog.Insert(0, string.Format("Content:{0}{1}", Environment.NewLine, jsonRequest));
            sbLog.Insert(0, string.Format("Authorization: {0}{1}", ClientState.AuthenticationHeaderValue.ToString(), Environment.NewLine));
            sbLog.Insert(0, string.Format("Date: {0}{1}", requestTime.ToString(), Environment.NewLine));
            sbLog.Insert(0, string.Format("{0}  {1}{2}", requestVerb.ToString(), uri, Environment.NewLine));
            sbLog.Insert(0, string.Format("REQUEST:{0}", Environment.NewLine));
        }


        private void InsertResposneToLog(string jsonResponse, HttpStatusCode statusCode)
        {
            sbLog.Insert(0, Environment.NewLine);
            sbLog.Insert(0, Environment.NewLine);
            sbLog.Insert(0, Environment.NewLine);

            for (int i = 0; i < 7; i++)
                sbLog.Insert(0, "--------------------");

            sbLog.Insert(0, Environment.NewLine);
            sbLog.Insert(0, Environment.NewLine);
            sbLog.Insert(0, Environment.NewLine);
            sbLog.Insert(0, jsonResponse);
            sbLog.Insert(0, String.Format("RESPONSE: {0} {1}{2}", (int)statusCode, statusCode.ToString(), Environment.NewLine));
            sbLog.Insert(0, Environment.NewLine);
            sbLog.Insert(0, Environment.NewLine);
        }


        private Boolean IsValidInput()
        {
            bool isValid = true;

            lblAccessKeyRequired.Text = string.Empty;
            lblSecretKeyRequired.Text = string.Empty;
            lblBaseURIRequired.Text = string.Empty;
            lblUriRequired.Text = string.Empty;

            if (String.IsNullOrEmpty(txtBxAccessKey.Text) || txtBxAccessKey.Text.Equals(defaultAccessKeyText))
            {
                lblAccessKeyRequired.Text = "*";
                isValid = false;
            }

            if (String.IsNullOrEmpty(txtBxSecretKey.Text) || txtBxSecretKey.Text.Equals(defaultSecretKeyText))
            {
                lblSecretKeyRequired.Text = "*";
                isValid = false;
            }

            if (String.IsNullOrEmpty(txtBxURI.Text))
            {
                lblUriRequired.Text = "*";
                isValid = false;
            }

            if (string.IsNullOrEmpty(cbBaseURI.Text))
            {
                lblBaseURIRequired.Text = "*";
                isValid = false;
            }

            return isValid;
        }

        private void btnImportConfig_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML Files (*.xml)|*.xml";
                openFileDialog.Title = "Save to a xml File";
                var result = openFileDialog.ShowDialog();

                if (result != DialogResult.OK)
                    return;
          
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add(xmlNamespace, XmlReader.Create(new StringReader(StudyAdminAPITester.Properties.Resources.BatchAPITestsXSD)));

                XDocument xmlConfig = XDocument.Load(openFileDialog.OpenFile());

                bool xmlValid = true;
                StringBuilder sb = new StringBuilder();

                xmlConfig.Validate(schemas, (s, args) => {
                    xmlValid = false;
                    sb.Append(string.Format("\u2022 {0}{1}", args.Exception.Message, Environment.NewLine));
                });

                if (!xmlValid)
                {
                    MessageBox.Show(string.Format("The following are problems with imported XML document:{0}{1}", 
                                    Environment.NewLine, sb.ToString()), "XML Validation Error");
                    return;
                }

                lstBxImportTests.Items.Clear();
                lstBxBatchResults.Items.Clear();
                btnRunBatch.Enabled = true;
                grpResults.Visible = false;

                BatchTester.Instance.ResetBatch();
                BatchTester.Instance.XmlConfig = xmlConfig;
                BatchTester.Instance.ImportBatch(xmlNamespace, lstBxImportTests);
            }
        }

        private void lnkXmlSchema_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filename = "BatchAPITests.xsd";
           
            var xmlSchema = new StreamWriter(new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read));
            xmlSchema.AutoFlush = true;
            xmlSchema.Write(StudyAdminAPITester.Properties.Resources.BatchAPITestsXSD);
            xmlSchema.Dispose();
           
            if (File.Exists(filename)) 
                Process.Start(filename);
        }

        private void lnkSampeXML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filename = "BatchAPITests.xml";
            var xmlSchema = new StreamWriter(new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read));
            xmlSchema.AutoFlush = true;
            xmlSchema.Write(StudyAdminAPITester.Properties.Resources.BatchAPITestsXML);
            xmlSchema.Dispose();

            if (File.Exists(filename))
                Process.Start(filename);  
        }

        private async void btnRunBatch_Click(object sender, EventArgs e)
        {
            btnRunBatch.Enabled = false;
            ClientState.BaseURI = cbBatchBaseUri.Text;
 
            try
            {
                lblBatchStatus.Visible = true;
                await BatchTester.Instance.RunBatch(xmlNamespace, lstBxBatchResults, sbLogBatch);

                grpResults.Visible = true;
                lblTestsPassed.Text = "Total Passed: " + BatchTester.Instance.TotalPassed;
                lblTestsFailed.Text = "Total Failed: " + BatchTester.Instance.TotalFailed;
                lblTotalTests.Text = "Total Tests: " + BatchTester.Instance.TotalTests;  
            } 
            catch (Exception ex)
            {
                if (ex.Message.Contains("API Key"))
                    MessageBox.Show(ex.Message, "Problem");
                else
                    MessageBox.Show("A problem occured with batch tester.", "Problem");
            }
            finally
            {
                lblBatchStatus.Visible = false;
            }
        }

        private void lstBxBatchResults_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBoxItem item = lstBxBatchResults.Items[e.Index] as ListBoxItem; 
            if (item != null)
            {
                e.Graphics.DrawString (
                    item.Message, 
                    lstBxBatchResults.Font, 
                    new SolidBrush(item.ItemColor), 
                    0, 
                    e.Index * lstBxBatchResults.ItemHeight
                );
            }
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            string filename = "StudyAdminAPIBatchTestLog.txt";
            var logStramWriter = new StreamWriter(new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read));
            logStramWriter.AutoFlush = true;
            logStramWriter.Write(sbLogBatch.ToString());
            logStramWriter.Dispose();

            if (File.Exists(filename))
                Process.Start(filename);  
        }

    }
}
