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
        private static TestCaseRepo _instance = null; 
        private List<APITestCase> _testCaseList;


        public static TestCaseRepo Instance {
            get {
                
                if (_instance == null) 
                {
                    _instance = new TestCaseRepo();
                }

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
               new GetSubjectTest("Get Subject") ,
               new GetSubjectStatsTest("GetSubjectStats"),
               new GetSubjectDayStatsTest("GetSubjectDayStats"),
               new GetSubjectDayMinutesTest("GetSubjectDayMinutes"),
               new AddSubjectTest("AddSubject"), 
               new GetStudiesTest("GetStudies"),
               
               
            };
        }

        
    }
}
