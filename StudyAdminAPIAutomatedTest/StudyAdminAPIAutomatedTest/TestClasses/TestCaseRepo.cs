using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAdminAPILib;


namespace StudyAdminAPIAutomatedTest
{
   /**
    * Acts as a wrapper for the data structure that holds all tests
    */
    public class TestCaseRepo
    {
        private static TestCaseRepo _instance = new TestCaseRepo();
        private List<APITestCase> _testCaseList;


        public static TestCaseRepo Instance {
            get {
                return _instance;
            }
        }

        public  List<APITestCase> TestCases
        {
            get 
            { 
                return _testCaseList;  
            } 
        }

        // Private Constructor
        private TestCaseRepo() 
        { 
            InitializeTestCases(); 
        }


        private void InitializeTestCases()
        {

            _testCaseList = new List<APITestCase>()
            {
               new GetSubjectTest() {
                    dto = new StudyAdminAPILib.JsonDTOs.GetSubjectDTO(){
                        SubjectID = ClientState.DefaultSubjectID
                    },
                    _endpoint = new Endpoint() {
                        uri = string.Format("{0}/v1/subjects/{1}", ClientState.BaseURI, ClientState.DefaultSubjectID)
                    }, 
                    _expectedStatusCode = "200",
                    _name = "GetSubject"
               }
            };
        }

        
    }
}
