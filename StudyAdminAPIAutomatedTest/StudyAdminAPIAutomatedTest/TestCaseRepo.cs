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


            ClientState.DefaultSubjectID = "594";
            ClientState.DefaultInBed = "2014-05-27T16:40:00";
            ClientState.DefaultOutBed = "2014-05-28T02:28:00";
            ClientState.DefaultDay = "2014-05-27";
            ClientState.DefaultStudyId = "1";

            _testCaseList = new List<APITestCase>()
            {
                // Subject Endpoints
               new GetSubjectTest("GetSubject", ClientState.DefaultSubjectID),
               new UpdateSubjectTest("UpdateSubject", ClientState.DefaultSubjectID),
               new AddSubjectTest("AddSubject"), 
               new GetSubjectStatsTest("GetSubjectStats", ClientState.DefaultSubjectID),
               new GetSubjectDayStatsTest("GetSubjectDayStats", ClientState.DefaultSubjectID),
               new GetSubjectDayMinutesTest("GetSubjectDayMinutes", ClientState.DefaultSubjectID,   ClientState.DefaultDay),
               new GetSubjectSleepEpochsTest("GetSubjectSleepEpochs", ClientState.DefaultSubjectID, ClientState.DefaultInBed,  ClientState.DefaultOutBed),
               new GetSubjectSleepScoreTest("GetSubjectSleepScore", ClientState.DefaultSubjectID, ClientState.DefaultInBed,  ClientState.DefaultOutBed),
               new GetSubjectBoutsTest("GetSubjectBouts", ClientState.DefaultSubjectID, ClientState.DefaultInBed,  ClientState.DefaultOutBed),
               new GetSubjectBedTimesTest("GetSubjectBedTimes", ClientState.DefaultSubjectID, ClientState.DefaultInBed,  ClientState.DefaultOutBed),
               new GetSubjectWeightHistoryTest("GetSubjectWeightHistory", ClientState.DefaultSubjectID),
               

               // Site Endpoints
               new GetSitesTest("GetSites"),


               // Study Endpoints
               new GetStudiesTest("GetStudies"),
               new GetStudyTest("GetStudy",  ClientState.DefaultStudyId),
               new GetStudySubjectsTest("GetStudySubjects",  ClientState.DefaultStudyId)
            };
        }

        
    }
}
