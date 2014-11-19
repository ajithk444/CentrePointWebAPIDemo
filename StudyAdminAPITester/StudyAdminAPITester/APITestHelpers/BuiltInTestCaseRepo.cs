using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAdminAPILib;


namespace StudyAdminAPITester
{
   /**
    * Acts as a wrapper for the data structure that holds all tests
    */
    public class BuiltInTestCaseRepo
    {
        private static BuiltInTestCaseRepo _instance = null; 
        private List<APITestCase> _testCaseList;


        public static BuiltInTestCaseRepo Instance {
            get {
                
                if (_instance == null)  
                    _instance = new BuiltInTestCaseRepo();
             
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
        private BuiltInTestCaseRepo() 
        { 
            InitializeTestCases(); 
        }


        private void InitializeTestCases()
        {

            string defaultSubjectID = "594";
            string defaultSiteId = "33";
            string defaultInBed = "2014-05-27T16:40:00";
            string defaultOutBed = "2014-05-28T02:28:00";
            string defaultDay = "2014-05-27";
            string defaultStudyId = "1";

            _testCaseList = new List<APITestCase>()
            {
                // Subject Endpoints
               new GetSubjectTest("GetSubject", defaultSubjectID),
               new AddSubjectTest("AddSubject",defaultSiteId), 
               new EditSubjectTest("EditSubject", defaultSubjectID, defaultSiteId),
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
