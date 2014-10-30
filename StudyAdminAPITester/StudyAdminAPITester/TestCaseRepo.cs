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

            string defaultSubjectID = "594";
            string defaultInBed = "2014-05-27T16:40:00";
            string defaultOutBed = "2014-05-28T02:28:00";
            string defaultDay = "2014-05-27";
            string defaultStudyId = "1";

            _testCaseList = new List<APITestCase>()
            {
                // Subject Endpoints
               new GetSubjectTest("GetSubject", defaultSubjectID),
               new AddSubjectTest("AddSubject"), 
               new EditSubjectTest("EditSubject", defaultSubjectID),
               new GetSubjectStatsTest("GetSubjectStats", defaultSubjectID),
               new GetSubjectDayStatsTest("GetSubjectDayStats", defaultSubjectID),
               new GetSubjectDayMinutesTest("GetSubjectDayMinutes", defaultSubjectID,   defaultDay),
               new GetSubjectSleepEpochsTest("GetSubjectSleepEpochs", defaultSubjectID, defaultInBed,  defaultOutBed),
               new GetSubjectSleepScoreTest("GetSubjectSleepScore", defaultSubjectID, defaultInBed,  defaultOutBed),
               new GetSubjectBoutsTest("GetSubjectBouts", defaultSubjectID, defaultInBed,  defaultOutBed),
               new GetSubjectBedTimesTest("GetSubjectBedTimes", defaultSubjectID, defaultInBed,  defaultOutBed),
               new GetSubjectWeightHistoryTest("GetSubjectWeightHistory", defaultSubjectID),
               
               // Site Endpoints
               new GetSitesTest("GetSites"),

               // Study Endpoints
               new GetStudiesTest("GetStudies"),
               new GetStudyTest("GetStudy",  defaultStudyId),
               new GetStudySubjectsTest("GetStudySubjects",  defaultStudyId)
            };
        }

        
    }
}
