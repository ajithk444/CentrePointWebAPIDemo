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
        private String lastJsonResponse;
        private String defaultAccessKeyText;
        private String defaultSecretKeyText;
        private String xmlNamespace = "http://www.w3schools.com";
		private String base64String;
		private bool multipleRequestsRunning = false;
        
        public TestForm()
        {
            InitializeComponent();
            sbLog = new StringBuilder();
			
            System.Version current = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //Major.Minor.Build.Revision
            //Show as many decimals as we need to for the version (ie: 2.0 instead of 2.0.0.0)
            this.Text += " v" + current.ToString(current.Revision != 0 ? 4 : current.Build != 0 ? 3 : 2);

			lblRequestCount.Visible = false;
			txtBxRequestCount.Visible = false;

            // Add items to Base URI combo box
            ClientState.BaseURI = "https://studyadmin-api-dev.actigraphcorp.com"; // defaults to dev
            txtBaseURI.Text = ClientState.BaseURI;

            // Populate HttpMethod Dropdown list and default it to "GET" request type
            cbHttpMethod.Items.Add(HttpMethod.Get);
            cbHttpMethod.Items.Add(HttpMethod.Post);
            cbHttpMethod.Items.Add(HttpMethod.Put);
            cbHttpMethod.SelectedIndex = 0;
            txtBxRequest.Enabled = false;

			// Populdate File Type Combo Box for Upload
			cmBxFileType.Items.Add("EPOCH");
			cmBxFileType.SelectedIndex = 0;

            lblStatusCode.Text = string.Empty;
            btnSendRequest.Enabled = false;
            lblError.Text = string.Empty;
            lblAccessKeyRequired.Text = string.Empty;
            lblSecretKeyRequired.Text = string.Empty;
            lblError.Text = string.Empty;
            lblBaseURIRequired.Text = string.Empty;

            // Populate Built-In Tests Combo Box
            List<string> testCases = (from i in BuiltInTestCaseRepo.Instance.TestCases
                                      select i.Name).ToList();
			
			
			// Add separators in Built-in Tests dropdown
			testCases.Insert(BuiltInTestCaseRepo.Instance.SubjectListStartIndex, "--------------- Subject Endpoints ---------------");
			testCases.Insert(BuiltInTestCaseRepo.Instance.SitesListStartIndex + 1, "--------------- Site Endpoints ---------------");
			testCases.Insert(BuiltInTestCaseRepo.Instance.StudiesListStartIndex + 2, "--------------- Study Endpoints ---------------");
			testCases.Insert(BuiltInTestCaseRepo.Instance.UploadsListStartIndex + 3, "--------------- Upload Endpoints ---------------");
			testCases.Insert(0, ""); 
            cBBuiltInTests.DataSource = testCases;

            // Setting Help LInk
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

                btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
            };

			btnSelectActivityFile.Click += (o, e) =>
			{
				using (var openFileDialog = new OpenFileDialog())
				{
					DialogResult result = openFileDialog.ShowDialog();
					base64String = null;
					if (!string.IsNullOrEmpty(openFileDialog.FileName))
					{ 
						using (var fileStream = new System.IO.FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
						{
							byte[] filebytes = new byte[fileStream.Length];
							fileStream.Read(filebytes, 0, Convert.ToInt32(fileStream.Length));
						
							APIBuiltInTestCase apiTest = (
							from i in BuiltInTestCaseRepo.Instance.TestCases
							where i.Name.Equals(cBBuiltInTests.Text)
							select i).FirstOrDefault();

							if (apiTest.GetType().Equals(typeof(PostUploadTest)))
							{
								PostUploadTest test = ((PostUploadTest)apiTest);
								base64String = Convert.ToBase64String(filebytes);
								
								// Put placeholder here
								test.SetDeviceData("<" + new FileInfo(openFileDialog.FileName).Name + ">");
								
								test.SetFileType(cmBxFileType.SelectedItem.ToString());
								btnPopualte.PerformClick();
							}
						}
					}
				}
			};

            // btnPopulate click action for button
            btnPopualte.Click += async (o, e) =>
            {
                // clear response box when selecting new built in test
                lblStatusCode.Text = string.Empty;
                btnCompareResponse.Enabled = false;

                APIBuiltInTestCase apiTest = (
                from i in BuiltInTestCaseRepo.Instance.TestCases
                where i.Name.Equals(cBBuiltInTests.Text)
                select i).FirstOrDefault();

                if (apiTest != null)
                {
                    txtBxURI.Text = apiTest.DefaultResourceURI;
                    cbHttpMethod.SelectedItem = apiTest.HttpVerb;
					pnlActivityFile.Enabled = apiTest.AllowActivityFilePanal;

                    if (((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get))
                    {
                        btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
                        txtBxRequest.Enabled = false;
                        txtBxRequest.Clear();
                    }
                    else
                    {
                        txtBxRequest.Enabled = true;
						txtBxRequest.Text = "Loading Request Content...";
						txtBxRequest.Text = apiTest.GetJsonRequestText();
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

			txtBxAccessKey.TextChanged += (o, e) =>
			{
				btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
			};

			txtBxSecretKey.TextChanged += (o, e) =>
			{
				btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
			};

			txtBaseURI.TextChanged += (o, e) =>
			{
				btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
			};

            txtBxRequest.TextChanged += (o, e) =>
            {
                btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
            };

            txtBxURI.TextChanged += (o, e) =>
            {
                btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
            };

            int previousSplitterDisatnace = splitContainerRequest.SplitterDistance;
            splitContainerRequest.SplitterMoved += (o, e) =>
            {
                if (grpBxResponse.Height <= 20)
                {
                    splitContainerRequest.SplitterDistance = previousSplitterDisatnace;
                }
                else
                {
                    previousSplitterDisatnace = splitContainerRequest.SplitterDistance;
                }
            };

			rdBtnPerformMultipleReqTrue.CheckedChanged += (o, e) =>
			{
					lblRequestCount.Visible = rdBtnPerformMultipleReqTrue.Checked;
					txtBxRequestCount.Visible = rdBtnPerformMultipleReqTrue.Checked;
					if (txtBxRequestCount.Visible && string.IsNullOrEmpty(txtBxRequestCount.Text)) txtBxRequestCount.Text = "10000";
			};

            // setting click action for execute button
            btnSendRequest.Click += async (o, e) =>
            {

				// represents the number of request to make to single endpoint
				long totalRequestNumber = 1;
				
				// check for multiple requests
				lblError.Text = "";
				if (rdBtnPerformMultipleReqTrue.Checked) {
					if (!long.TryParse(txtBxRequestCount.Text, out totalRequestNumber)) {
						lblError.Text = "Request count is invalid";
						return;
					}
					multipleRequestsRunning = true;
				}

				for (int i = 0; i < totalRequestNumber; i++)
					await SendRequest(i+1, totalRequestNumber);

				multipleRequestsRunning = false;

				// re-enable send request button after request is complete
				btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;

            };

            #region response right click menu

            toolStripMenuItemClearLog.Click += (obj, sender) =>
            {
                txtBxResponse.Clear();
                sbLog.Clear();
                lblStatusCode.Text = string.Empty;
                lblError.Text = string.Empty;
                lblAccessKeyRequired.Text = string.Empty;
                lblSecretKeyRequired.Text = string.Empty;
                lblBaseURIRequired.Text = string.Empty;
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


		private async Task SendRequest(long requestNumber, long totalRequests)
		{

			APIEndpointExecuter apiEndpointExecuter = null;
			APIEndpointExecuterResult apiEndpointExecuterResult = null;
			string jsonResponse = string.Empty;
			string jsonRequestRaw = txtBxRequest.Text;
			DateTime requestTime;
			DateTime responseTime;

			try
			{
				// Clear Status Code label
				lblStatusCode.Text = String.Empty;
				btnCompareResponse.Enabled = false;

				// Updating Client State Before Execution
				ClientState.BaseURI = txtBaseURI.Text;
				ClientState.AccessKey = txtBxAccessKey.Text;
				ClientState.SecretKey = txtBxSecretKey.Text;

				// Create Endpoint Executer
				apiEndpointExecuter = new APIEndpointExecuter(ClientState.BaseURI + txtBxURI.Text, (HttpMethod)cbHttpMethod.SelectedItem);
	
				// Hide "Waiting For Response..." label
				lblStatus.Text = "[ "+requestNumber + " / " + totalRequests+" ] Waiting For Response...";
				lblStatus.Visible = true;

				// disable send request button while text is running
				btnSendRequest.Enabled = false;

				// Set Request Timestamp
				requestTime = DateTime.Now;

				/** BEGIN: Snippet to Update Json Request with Base 64 String that was set **/
				APIBuiltInTestCase selectedBuiltInTest = (
				from i in BuiltInTestCaseRepo.Instance.TestCases
				where i.Name.Equals(cBBuiltInTests.Text)
				select i).FirstOrDefault();

				if (chkBxUseFile.Checked && selectedBuiltInTest != null && selectedBuiltInTest.GetType().Equals(typeof(PostUploadTest)))
				{
					try
					{
						PostUploadDTO postUploadDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<PostUploadDTO>(new Regex("(\r\n|\r|\n)").Replace(txtBxRequest.Text, ""));
						postUploadDTO.ActivityFiles.FirstOrDefault().DeviceData = base64String;
						base64String = null;

						JsonSerializerSettings jsonFormatter = new JsonSerializerSettings
						{
							Formatting = Newtonsoft.Json.Formatting.Indented,
							DateFormatHandling = DateFormatHandling.IsoDateFormat,
							DateTimeZoneHandling = DateTimeZoneHandling.Utc
						};

						jsonRequestRaw = JsonConvert.SerializeObject(postUploadDTO, jsonFormatter);
					
					}
					catch { }
				}
				/** END: Snippet to Update Json Request with Base 64 String **/

				// await for async method to finish
				apiEndpointExecuterResult = await apiEndpointExecuter.Run(new Regex("(\r\n|\r|\n)").Replace(jsonRequestRaw, ""));
				jsonResponse = apiEndpointExecuterResult.ResponseContent;

				// Set Response Timestamp
				responseTime = DateTime.Now;

				// Set last Json response for tool
				lastJsonResponse = jsonResponse;

				// Hide status label
				lblStatus.Visible = false;

				// Enable Compare Button
				btnCompareResponse.Enabled = true;

				// Update Response Status Code     
				if (apiEndpointExecuterResult.Response.StatusCode.Equals(System.Net.HttpStatusCode.OK) || apiEndpointExecuterResult.Response.StatusCode.Equals(System.Net.HttpStatusCode.Created))
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
				lblStatusCode.Text = string.Format("      HTTP Status Code {0} {1}",
												(int)apiEndpointExecuterResult.Response.StatusCode, (string)apiEndpointExecuterResult.Response.StatusCode.ToString());

				// Update Log
				lblStatus.Text = "[ " + requestNumber + " / " + totalRequests + " ] Updating Response Log...";
				lblStatus.Visible = true;
				this.Refresh();

				InsertResposneToLog(jsonResponse, apiEndpointExecuterResult.Response.StatusCode);
				InsertRequestToLog(apiEndpointExecuter, apiEndpointExecuterResult, txtBxRequest.Text, requestTime, responseTime);

				txtBxResponse.Text = await Task.Run(() =>
				{
					return sbLog.ToString();
				});

				// Hide status label
				lblStatus.Visible = false;

				// Focus on Response text box
				txtBxResponse.Focus();

			}
			catch (HttpRequestException)
			{
				lblError.Text = string.Format("A problem occured while sending request to {0}", apiEndpointExecuter._Uri);
			}
			catch (Exception) // Catch Everything else
			{
				lblError.Text = "A problem has occured. Please contact the Study Admin Team.";
			}
			finally
			{
				lblStatus.Visible = false;
			}
		}

		private void InsertRequestToLog(APIEndpointExecuter apiEndpointExecuter, APIEndpointExecuterResult apiEndpointExecuteResult, String jsonRequest, DateTime requestTime, DateTime responseTime)
        {
            sbLog.Insert(0, string.Format("Content:{0}{1}", Environment.NewLine, jsonRequest));
            sbLog.Insert(0, string.Format("Time: {0}ms{1}", (responseTime - requestTime).TotalMilliseconds, Environment.NewLine));
            sbLog.Insert(0, string.Format("Authorization: {0}{1}", apiEndpointExecuteResult.Request.Headers.Authorization.ToString(), Environment.NewLine));
            sbLog.Insert(0, string.Format("Date: {0}{1}", requestTime.ToString(), Environment.NewLine));
			sbLog.Insert(0, string.Format("{0}  {1}{2}", apiEndpointExecuter._HttpVerb, apiEndpointExecuter._Uri, Environment.NewLine));
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

        /// <summary>
        /// Import XML Batch Config Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportConfig_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML Files (*.xml)|*.xml";
                openFileDialog.Title = "Save to a xml File";
                var result = openFileDialog.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                using (var xmlStream = openFileDialog.OpenFile())
                {
                    BatchTester.Instance.ResetBatch();
                    XDocument xmlDoc;

                    lstBxBatchResults.Items.Clear();
                    lstBxImportTests.Items.Clear();
                    btnRunBatch.Enabled = false;
                    grpResults.Visible = false;
                    btnViewLog.Enabled = false;
                    lblImportedXMLConfig.Visible = false;

                    if (BatchTester.Instance.ImportBatchSuccessful(xmlNamespace, xmlStream, lstBxImportTests, out xmlDoc))
                    {
                        lblImportedXMLConfig.Text = string.Format("Imported File: {0}", new FileInfo(openFileDialog.FileName).Name);
                        lblImportedXMLConfig.Visible = true;

                        lblImportedTestCount.Text = string.Format("Test Count: {0}", BatchTester.Instance.TotalImportedTests );
                        lblImportedTestCount.Visible = true;

                        lnkClearImport.Visible = true;
                        lnkClearImport.Enabled = true;

                        BatchTester.Instance.XmlConfig = xmlDoc;
                        btnRunBatch.Enabled = true;
                    }
                    else
                    {
                        lstBxImportTests.Items.Clear();
                    }   
                }
             }
        }

        private bool ShouldSendRequestButtonBeEnabled {
            get {

				bool batchModeNotRunning = !BatchTester.Instance.BatchRunning;
				bool multipleRequestsNotRunning = !multipleRequestsRunning;
				bool baseUriNotEmpty = txtBaseURI.TextLength != 0;
				bool accessKeyNotEmpty = (txtBxAccessKey.TextLength != 0 && !txtBxAccessKey.Text.Equals(defaultAccessKeyText));
				bool secretKeyNotEmpty = (txtBxSecretKey.TextLength != 0 && !txtBxSecretKey.Text.Equals(defaultSecretKeyText));

				return (batchModeNotRunning && multipleRequestsNotRunning && baseUriNotEmpty && accessKeyNotEmpty && secretKeyNotEmpty &&
					((txtBxURI.TextLength != 0 && ((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get)) ||
                               (txtBxURI.TextLength != 0 && txtBxRequest.TextLength != 0 && !((HttpMethod)cbHttpMethod.SelectedItem).Equals(HttpMethod.Get))));
            }
        }

        /// <summary>
        /// Opens XML Schema Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkXmlSchema_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filename = "BatchAPITests.xsd";

            using (var xmlSchema = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)))
            { 
                xmlSchema.AutoFlush = true;
                xmlSchema.Write(StudyAdminAPITester.Properties.Resources.BatchAPITestsXSD);
                xmlSchema.Dispose();
            }
           if (File.Exists(filename))
               Process.Start(filename);
        }

        /// <summary>
        /// Opens Sample XML Document
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkSampeXML_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filename = "BatchAPITests.xml";
            using (var xmlSchema = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)))
            { 
                xmlSchema.AutoFlush = true;
                xmlSchema.Write(StudyAdminAPITester.Properties.Resources.BatchAPITestsXML);
                xmlSchema.Dispose();
            }
            if (File.Exists(filename))
                Process.Start(filename);
        }

        private async void btnRunBatch_Click(object sender, EventArgs e)
        {
            btnRunBatch.Enabled = false;  
            try
            {
                BatchTester.Instance.ResetBatch(); // Reset Test Counters (Pass, Fail, Total)
                BatchTester.Instance.log.Clear();  // Clear Log
                lstBxBatchResults.Items.Clear();   // Clear Batch Results List Box
                
                lblBatchStatus.Text = "Running Tests...";
                lblBatchStatus.Visible = true;
                lnkClearImport.Enabled = false; // Disable 'Clear Import' link
                btnImportBatchConfig.Enabled = false; // Disable Import
                btnViewLog.Enabled = false; // Disable 'View Log' button
                grpResults.Visible = false; // Hide Results Group Box

                toolStripMenuItemClearBatch.Enabled = false;
                btnSendRequest.Enabled = false;
                BatchTester.Instance.BatchRunning = true;

                await BatchTester.Instance.RunBatch(xmlNamespace, lstBxBatchResults);

                BatchTester.Instance.BatchRunning = false;
                grpResults.Visible = true;
                btnViewLog.Enabled = true;
                btnImportBatchConfig.Enabled = true;
                toolStripMenuItemClearBatch.Enabled = true;
                btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
                lblTestsPassed.Text = "Total Passed: " + BatchTester.Instance.TotalPassed;
                lblTestsFailed.Text = "Total Failed: " + BatchTester.Instance.TotalFailed;
                lblTotalTests.Text = "Total Tests: " + BatchTester.Instance.TotalRunTests;  
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
                toolStripMenuItemClearBatch.Enabled = true;
                btnSendRequest.Enabled = this.ShouldSendRequestButtonBeEnabled;
                lnkClearImport.Enabled = true;
                lblBatchStatus.Visible = false;
                btnRunBatch.Enabled = BatchTester.Instance.XmlConfig != null;
                btnImportBatchConfig.Enabled = true;
                BatchTester.Instance.BatchRunning = false;
            }
        }

        private void lstBxBatchResults_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0) 
            {
                ListBoxItem item = lstBxBatchResults.Items[e.Index] as ListBoxItem; 
                if (item != null)
                {
                    e.Graphics.DrawString(item.Message,
                        e.Font, new SolidBrush(item.ItemColor), e.Bounds, StringFormat.GenericDefault);
                }
            }
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            string filename = "StudyAdminAPIBatchTestLog.txt";

            // remove file if it exists
            if (File.Exists(filename)) File.Delete(filename);

            using (var logStramWriter = new StreamWriter(new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)))
            {
                logStramWriter.AutoFlush = true;
                logStramWriter.Write(BatchTester.Instance.log.ToString());
            }

            if (File.Exists(filename))
                Process.Start(filename);     
            
        }

        private void toolStripMenuItemClearBatchLog(object sender, EventArgs e)
        {
            lstBxBatchResults.Items.Clear();
            BatchTester.Instance.log.Clear();
            grpResults.Visible = false;
            btnViewLog.Enabled = false;
            btnRunBatch.Enabled = BatchTester.Instance.XmlConfig != null; 
        }


        private void lnkClearImport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lstBxBatchResults.Items.Clear();
            BatchTester.Instance.log.Clear();
            lstBxImportTests.Items.Clear();
            grpResults.Visible = false;
            btnViewLog.Enabled = false;
            btnRunBatch.Enabled = false;
            BatchTester.Instance.XmlConfig = null;
            BatchTester.Instance.ResetBatch();
            lblBatchStatus.Text = string.Empty;
            lblImportedXMLConfig.Text = string.Empty;
            lnkClearImport.Visible = false;
            lblImportedTestCount.Visible = false;
        }

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
				cmBxFileType.Enabled = chkBxUseFile.Checked;
				btnSelectActivityFile.Enabled = chkBxUseFile.Checked;
		}
    }
}
