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

            string subjectId = ClientState.DefaultSubjectID;
            string inBed = "2014-05-27T16:40:00";
            string outBed = "2014-05-28T02:28:00";
            string day = "2014-05-27";



            _testCaseList = new List<APITestCase>()
            {
                // Subject Endpoints
               new GetSubjectTest("GetSubject", subjectId),
               new GetSubjectStatsTest("GetSubjectStats", subjectId),
               new GetSubjectDayStatsTest("GetSubjectDayStats", subjectId),
               new GetSubjectDayMinutesTest("GetSubjectDayMinutes", subjectId, day),
               new GetSubjectSleepEpochsTest("GetSubjectSleepEpochs", subjectId, inBed, outBed),
               new GetSubjectSleepScoreTest("GetSubjectSleepScore", subjectId, inBed, outBed),
               new GetSubjectBoutsTest("GetSubjectBouts", subjectId, inBed, outBed),
               new GetSubjectBedTimesTest("GetSubjectBedTimes", subjectId, inBed, outBed),
               new GetSubjectWeightHistoryTest("GetSubjectWeightHistory", subjectId),
               new AddSubjectTest("AddSubject"), 
               new GetStudiesTest("GetStudies")
            };
        }

        
    }
}
