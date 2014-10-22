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

             this.responseJson = this.responseJson.Replace("\n", "").Replace("\r","").Replace("\"","'").Replace(" ","");
             string compareTo = txtResponseCompare.Text.Replace("\n", "").Replace("\r", "").Replace("\"", "'").Replace(" ", "");

             if (string.Compare(this.responseJson, compareTo) == 0) 
             {
                 lblMatchStatus.Text = "Matched Successfully";
                 lblMatchStatus.ForeColor = Color.Green;
             }
             else
             {
                 lblMatchStatus.Text = "No Match";
                 lblMatchStatus.ForeColor = Color.Red;
             }

            };
        }

    }
}
