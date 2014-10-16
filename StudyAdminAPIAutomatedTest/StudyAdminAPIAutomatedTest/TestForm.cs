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

namespace StudyAdminAPIAutomatedTest
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            // Add items to Base URI combo box
            cbBaseURI.Items.Add("https://studyadmin-dev.actigraphcorp.com");
            cbBaseURI.Items.Add("https://studyadmin.actigraphcorp.com");
            cbBaseURI.SelectedIndex = 0;

            // Populate Tests Combo Box
            cBBuiltInTests.DataSource = (from i in TestCaseRepo.Instance.TestCases select i._name).ToList();

            // Initialize Client State Object
            ClientState.BaseURI = cbBaseURI.SelectedText;
            ClientState.AccessKey = "AKIAIOSFODNN7EXAMPLE";  
            ClientState.SecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY"; 
            ClientState.DefaultSubjectID = "000058";

            // Set defaults for access and secret keys
            txtBxAccessKey.Text = ClientState.AccessKey;
            txtBxSecretKey.Text = ClientState.SecretKey;

            string json = "";
            // setting click action
            btnExecute.Click += async (o,e) => {      
                
                APITestCase testCase = (from i in TestCaseRepo.Instance.TestCases where i._name.Equals( cBBuiltInTests.Text ) select i).FirstOrDefault();
                json = JsonConvert.SerializeObject(new StudyAdminAPILib.JsonDTOs.GetSubjectDTO() { SubjectID = ClientState.DefaultSubjectID });

                 MessageBox.Show(json, "test");
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
