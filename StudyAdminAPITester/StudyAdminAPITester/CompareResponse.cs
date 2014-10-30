using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StudyAdminAPIAutomatedTest
{
    public partial class CompareResponse : Form
    {
        private String responseJson;

        public CompareResponse(string responseJson)
        {
            InitializeComponent();
           
            this.responseJson = responseJson;
            
            btnCancel.Click += (o, e) => {
                this.Close();
            };

            btnCompare.Click += (o, e) => {

                if (string.IsNullOrEmpty(txtResponseCompare.Text)) {
                     lblMatchStatus.Text = "    Missing Compare Field";
                     lblMatchStatus.ForeColor = Color.Red;
                     lblMatchStatus.Image = StudyAdminAPITester.Properties.Resources.cancel_small;
                     lblMatchStatus.ImageAlign = ContentAlignment.TopLeft;
                     return;
                 }

                 if (string.IsNullOrEmpty(this.responseJson))
                 {
                     lblMatchStatus.Text = "    Response From API is Empty";
                     lblMatchStatus.ForeColor = Color.Red;
                     lblMatchStatus.Image = StudyAdminAPITester.Properties.Resources.cancel_small;
                     lblMatchStatus.ImageAlign = ContentAlignment.TopLeft;
                     return;
                 }
     
                 this.responseJson = new Regex(@"(\r\n|\r|\n|\s)").Replace(this.responseJson, "");
                 string compareTo = new Regex(@"(\r\n|\r|\n|\s)").Replace(txtResponseCompare.Text, "");

                 if (string.Compare(this.responseJson, compareTo) == 0) 
                 {
                    lblMatchStatus.Text = "    Matched Successfully";
                    lblMatchStatus.ForeColor = Color.Green;
                    lblMatchStatus.Image = StudyAdminAPITester.Properties.Resources.check_smaller;
                    lblMatchStatus.ImageAlign = ContentAlignment.TopLeft;
                 }
                 else
                 {
                    lblMatchStatus.Text = "    No Match";
                    lblMatchStatus.ForeColor = Color.Red;
                    lblMatchStatus.Image = StudyAdminAPITester.Properties.Resources.cancel_small;
                    lblMatchStatus.ImageAlign = ContentAlignment.TopLeft;
                 }
             
          };
        }


    }
}
