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
            get {
                return xmlConfig;
            }
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
            XElement apiKeyElement = (
                                      from a in doc.Root.Descendants(dns + "ApiKeyPair") 
                                      where a.Attribute("id").Value.Equals(apiKeyPairId) 
                                      select a
                                      ).FirstOrDefault();

            if (apiKeyElement == null)
                throw new Exception(string.Format("API Key Pair '{0}' not found", apiKeyPairId));

            return new KeyValuePair<string, string>(apiKeyElement.Attribute("accessKey").Value, apiKeyElement.Attribute("secretKey").Value);
        }

        public async Task RunSuite(XElement testSuiteElement, XNamespace XmlNamespace, System.Windows.Forms.ListBox resultsListBox, StringBuilder log)
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
                await RunApiTest(t, XmlNamespace, resultsListBox, log);       
        }

        public async Task RunApiTest(XElement apiTestElement, XNamespace XmlNamespace, System.Windows.Forms.ListBox resultsListBox, StringBuilder log)
        {
            
            string apiTestId = apiTestElement.Attributes("id").FirstOrDefault().Value;
            string uri = apiTestElement.Attributes("Uri").FirstOrDefault().Value;
            HttpMethod httpMethod = APIUtilities.GetHttpMethodFromText(apiTestElement.Attributes("HttpMethod").FirstOrDefault().Value);
            

            XElement requestContent = apiTestElement.Elements(XmlNamespace + "RequestContent").FirstOrDefault();
            string request = string.Empty;
            string requestFormatted = string.Empty;

            if (requestContent != null) 
            { 
                request = requestContent.Value;
                requestFormatted = new Regex(ClientState.RemoveNewLineRegEx).Replace(request, ""); // Removing New Lines before sent to API
            }

            APITestCase apiTest = new APITestCase() { 
                CurrentEndpoint = string.Format("{0}{1}", ClientState.BaseURI, uri),
                HttpVerb = httpMethod
            };
           
            string expectedResponse = apiTestElement.Elements(XmlNamespace + "ExpectedResponse").FirstOrDefault().Value;
            string expectedResponseFormatted = new Regex(ClientState.RemoveNewLineAndWhiteSpaceRegEx).Replace(expectedResponse, ""); // remove new lines and whitespace before comparing with actual response

            HttpStatusCode expectedStatusCode = ((HttpStatusCode)(Convert.ToInt32(apiTestElement.Elements(XmlNamespace + "ExpectedStatusCode").FirstOrDefault().Value)));

            DateTime requestTime = DateTime.Now;

            string actualResponse = await apiTest.Run(new Regex(ClientState.RemoveNewLineRegEx).Replace(request, ""));
            string actualResponseFormatted = new Regex(ClientState.RemoveNewLineAndWhiteSpaceRegEx).Replace(actualResponse, ""); // remove new lines and whitespace before comparing with expected response
            
            HttpStatusCode actualStatusCode = apiTest.responseStatusCode;

            bool testPassed = (actualStatusCode.Equals(expectedStatusCode) && actualResponseFormatted.Equals(expectedResponseFormatted));

            if (testPassed)
            {
                TotalPassed += 1;
                resultsListBox.Items.Add(new ListBoxItem( Color.Green, String.Format("   ApiTest: {0} PASSED", apiTestId)));
            }
            else
            {
                TotalFailed += 1;
                resultsListBox.Items.Add(new ListBoxItem(Color.Red, String.Format("   ApiTest: {0} FAILED", apiTestId)));
            }

            // format request and expected response for log
            string requestFormattedWithNewLines = new Regex(ClientState.RemoveNewLineRegEx).Replace(request, Environment.NewLine); // add new lines for readability purposes for log
            string expectedResponseFormattedWithNewLines = new Regex(ClientState.RemoveNewLineRegEx).Replace(expectedResponse, Environment.NewLine); // add new lines for readability purposes for log

            UpdateLog(log, testPassed, requestTime, apiTest, requestFormattedWithNewLines, expectedStatusCode, expectedResponseFormattedWithNewLines, actualResponse);

        }


        public void UpdateLog(StringBuilder log, bool hasPassed, DateTime requestTime, APITestCase apiTestCase, string request, HttpStatusCode expectedStatusCode, string expectedResponse, string actualResponse)
        {
            log.Append(string.Format("Test Result: {0}{1}", hasPassed ? "PASSED" : "FAILED", Environment.NewLine));
            log.Append(string.Format("REQUEST:{0}", Environment.NewLine));
            log.Append(string.Format("{0}  {1}{2}", apiTestCase.HttpVerb, apiTestCase.CurrentEndpoint, Environment.NewLine));
            log.Append(string.Format("Date: {0}{1}", requestTime.ToString(), Environment.NewLine));
            log.Append(string.Format("Authorization: {0}{1}", ClientState.AuthenticationHeaderValue.ToString(), Environment.NewLine));
            log.Append(string.Format("Content:{0}", request));
            log.Append(Environment.NewLine);
            log.Append(Environment.NewLine);
            log.Append(String.Format("EXPECTED RESPONSE: {0} {1}", (int)expectedStatusCode, expectedStatusCode.ToString()));
            log.Append(expectedResponse);
            log.Append(Environment.NewLine);
            log.Append(String.Format("ACTUAL RESPONSE: {0} {1}", (int)apiTestCase.responseStatusCode, apiTestCase.responseStatusCode.ToString()));
            log.Append(Environment.NewLine);
            log.Append(actualResponse);
            log.Append(Environment.NewLine);

            for (int i = 0; i < 7; i++)
                log.Append("--------------------");

            log.Append(Environment.NewLine);
            log.Append(Environment.NewLine);
            log.Append(Environment.NewLine);
        }

        public async Task RunBatch(String xmlNamespace, System.Windows.Forms.ListBox resultsListBox, StringBuilder log)
        {
            var doc = this.xmlConfig;
            XNamespace dns = xmlNamespace;

            var TestSuiteQuery = from a in doc.Root.Descendants(dns + "TestSuite")
                                 select a;

            foreach (var ele in TestSuiteQuery)
                await RunSuite(ele, xmlNamespace, resultsListBox, log);

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

                    importListBox.Items.Add(string.Format("   ApiTest: {0} ({1} {2})", apiTestId, httpMethod, uri));
                }
                
            }

        }
    }
}
