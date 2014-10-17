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
            ClientState.AccessKey = "AKIAIOSFODNN7EXAMPLE";
            ClientState.SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY";
            ClientState.DefaultSubjectID = "000058";

            // Add items to Base URI combo box
            ClientState.BaseURI = "https://studyadmin-dev.actigraphcorp.com"; // defaults to dev
            cbBaseURI.Items.Add(ClientState.BaseURI);
            cbBaseURI.Items.Add("https://studyadmin.actigraphcorp.com"); // add production option
            cbBaseURI.SelectedIndex = 0;
            

            // Populate Tests Combo Box
            List<string> testCases = (from i in TestCaseRepo.Instance.TestCases select i.Name).ToList();
            testCases.Insert(0, "");
            cBBuiltInTests.DataSource = testCases;
          
            // Set defaults for access and secret keys
            txtBxAccessKey.Text = ClientState.AccessKey;
            txtBxSecretKey.Text = ClientState.SecretKey;

            // setting onselectedchage action for tests combo box
            cBBuiltInTests.SelectedIndexChanged += (o, e) =>
            {
                APITestCase apiTest = (from i in TestCaseRepo.Instance.TestCases where i.Name.Equals(cBBuiltInTests.Text) select i).FirstOrDefault();
                if (apiTest != null) 
                {
                    txtBxRequest.Text = JsonConvert.SerializeObject(apiTest.dto);
                    lblEndpointResult.Text = apiTest.Endpoint.uri;
                } 
                else 
                {
                    txtBxRequest.Text = string.Empty;
                    lblEndpointResult.Text = string.Empty;
                }
            };


            // setting click action for execute button
            btnExecute.Click += async (o,e) => {

                APITestCase apiTest = (from i in TestCaseRepo.Instance.TestCases where i.Name.Equals(cBBuiltInTests.Text) select i).FirstOrDefault();
                apiTest.Run(txtBxRequest.Text);

            };
            
        }


        private void PerformInputValidation()
        {
            if (String.IsNullOrEmpty(txtBxAccessKey.Text))
            {

            }

        }



        /*
        private void label1_Click(object sender, EventArgs e)
        {

        }
        */



    }
}
