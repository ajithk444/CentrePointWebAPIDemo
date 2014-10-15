using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAdminAPILib.Tests;

namespace StudyAdminAPILib
{

    public class TestCaseRepo
    {
        private static TestCaseRepo _instance = new TestCaseRepo();
        public List<APITestCase> _testCaseList;

        private TestCaseRepo() {
            InitializeTestCases();
        }

        public static TestCaseRepo Instance {
            get { 
                 return _instance; 
            }
        }

        public void InitializeTestCases()
        {
            /***
             * Temporary Code
             */
            string baseURI = "https://studyadmin-dev.actigraphcorp.com/";
            string expectedStatusCode = "101.1";
            string uniqueID = "1";
            /***
             * End of temporary Code
             */

            _testCaseList = new List<APITestCase>()
            {
               new GetSubjectTest() {
                    _endpoint = new Endpoints.Endpoint() {
                        uri = string.Format("{0}/v1/subjects/{1}",baseURI,uniqueID)
                    }, 
                    _expectedStatusCode = expectedStatusCode,
               }
            };
        }

        
    }
}
