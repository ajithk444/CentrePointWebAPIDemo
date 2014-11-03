using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using StudyAdminAPILib;
using System.Text.RegularExpressions;
using System.Drawing;

namespace StudyAdminAPITester
{
    public class BatchTester 
    {

        public int TotalTests { get; set; }
        public int TotalPassed { get; set; }
        public int TotalFailed { get; set; }

        private static BatchTester _batchTester = new BatchTester();
        private XDocument xmlConfig;
        
        private BatchTester() { }


        public static BatchTester Instance
        {
            get
            {
                return _batchTester;
            }

        }

        public XDocument XmlConfig
        {
            set
            {
                xmlConfig = value;
            }
        }

        public void ResetBatch()
        {
            this.TotalTests = 0;
            this.TotalPassed = 0;
            this.TotalFailed = 0;
        }

        public KeyValuePair<string, string> RetrieveAPIKeyPar(XNamespace dns, string apiKeyPairId)
        {
            var doc = this.xmlConfig;
            string accessKey = (from a in doc.Root.Descendants(dns + "ApiKeyPair")
                    where a.Attribute("id").Value.Equals(apiKeyPairId)
                    select a.Attribute("accessKey").Value
                    ).FirstOrDefault();

            string secretKey = (from a in doc.Root.Descendants(dns + "ApiKeyPair")
                                where a.Attribute("id").Value.Equals(apiKeyPairId)
                                select a.Attribute("secretKey").Value
                   ).FirstOrDefault();

            return new KeyValuePair<string, string>(accessKey, secretKey);
        }

        public async Task RunSuite(XElement testSuiteElement, XNamespace XmlNamespace, System.Windows.Forms.ListBox resultsListBox)
        {

            string suiteId = testSuiteElement.Attributes("id").FirstOrDefault().Value;
            string apiKeyPairId = testSuiteElement.Attributes("apiKeyPairId").FirstOrDefault().Value;
            KeyValuePair<string, string> apiKeys = RetrieveAPIKeyPar(XmlNamespace, apiKeyPairId);
            
            ClientState.AccessKey = apiKeys.Key;
            ClientState.SecretKey = apiKeys.Value;
       
            resultsListBox.Items.Add(new ListBoxItem(Color.Black, string.Format("Suite: {0}", suiteId)));

            var apiTestsQuery = from b in testSuiteElement.Elements(XmlNamespace + "ApiTest")
                                      select b;

            foreach (var t in apiTestsQuery)
            {
                await RunApiTest(t, XmlNamespace, resultsListBox);
            }
        }

        public async Task RunApiTest(XElement apiTestElement, XNamespace XmlNamespace, System.Windows.Forms.ListBox resultsListBox)
        {
            
            string apiTestId = apiTestElement.Attributes("id").FirstOrDefault().Value;
            
            string uri = apiTestElement.Attributes("Uri").FirstOrDefault().Value;
            string httpMethodText = apiTestElement.Attributes("HttpMethod").FirstOrDefault().Value;

            XElement requestContent = apiTestElement.Elements(XmlNamespace + "RequestContent").FirstOrDefault();
            string request = string.Empty;
            
            if (requestContent != null) 
                request = requestContent.Value;

            HttpMethod httpMethod = HttpMethod.Get;
            
            switch (httpMethodText)
            { 
                case "GET":
                    httpMethod = HttpMethod.Get;
                    break;
                case "PUT":
                    httpMethod = HttpMethod.Put;
                    break;
                case "POST":
                    httpMethod = HttpMethod.Post;
                    break;
                case "DELETE":
                    httpMethod = HttpMethod.Delete;
                    break;
            }

            APITestCase apiTest = new APITestCase();
            apiTest.CurrentEndpoint = string.Format("{0}{1}", ClientState.BaseURI, uri);
            apiTest.HttpVerb = httpMethod;
            string expectedResponse = new Regex(ClientState.RemoveNewLineAndWhiteSpaceRegEx).Replace(apiTestElement.Elements(XmlNamespace + "ExpectedResponse").FirstOrDefault().Value, "");
            HttpStatusCode expectedStatusCode = ((HttpStatusCode)(Convert.ToInt32(apiTestElement.Elements(XmlNamespace + "ExpectedStatusCode").FirstOrDefault().Value)));

            string acutalResponse = await apiTest.Run(new Regex(ClientState.RemoveNewLineRegEx).Replace(request, ""));

            acutalResponse = new Regex(ClientState.RemoveNewLineAndWhiteSpaceRegEx).Replace(acutalResponse, "");
            HttpStatusCode actualStatusCode = apiTest.responseStatusCode;

            bool passed = (actualStatusCode.Equals(expectedStatusCode) && acutalResponse.Equals(expectedResponse));

            if (passed)
            {
                TotalPassed += 1;
                resultsListBox.Items.Add(new ListBoxItem( Color.Green, String.Format("\tApiTest: {0} PASSED", apiTestId)));
            }
            else
            {
                TotalFailed += 1;
                resultsListBox.Items.Add(new ListBoxItem( Color.Red, String.Format("\tApiTest: {0} FAILED", apiTestId)));
            }
        }

        public async Task RunBatch(String xmlNamespace, System.Windows.Forms.ListBox resultsListBox)
        {
            var doc = this.xmlConfig;
            XNamespace dns = xmlNamespace;

            var TestSuiteQuery = from a in doc.Root.Descendants(dns + "TestSuite")
                                 select a;

            foreach (var ele in TestSuiteQuery)
            {
                await RunSuite(ele, xmlNamespace, resultsListBox);
            }

        }

        public void ImportBatch(String xmlNamespace, System.Windows.Forms.ListBox importListBox)
        {
            var doc = this.xmlConfig;
            XNamespace dns = xmlNamespace;
            var TestSuiteQuery = from a in doc.Root.Descendants(dns + "TestSuite")
                        select a;

            foreach (var ele in TestSuiteQuery)
            {
               String suiteId = ele.Attributes("id").FirstOrDefault().Value;
               importListBox.Items.Add(String.Format("Test Suite: {0}", suiteId));

                var apiTestsQuery = from b in ele.Elements(dns + "ApiTest")
                                      select b;

                foreach (var t in apiTestsQuery)
                {
                    TotalTests += 1;
                    string apiTestId = t.Attributes("id").FirstOrDefault().Value;
                    string uri = t.Attributes("Uri").FirstOrDefault().Value;
                    string httpMethod = t.Attributes("HttpMethod").FirstOrDefault().Value;
                    
                    importListBox.Items.Add(string.Format("\tApiTest: {0} ({1} {2})",apiTestId, httpMethod, uri));
                }
                
            }

        }

        public void RunBatch()
        { 
        
        
        }
    }
}
