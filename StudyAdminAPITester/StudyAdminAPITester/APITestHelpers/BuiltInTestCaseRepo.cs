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
        private List<APIBuiltInTestCase> _testCaseList;
		
		public int SubjectListStartIndex;
		public int SitesListStartIndex;
		public int StudiesListStartIndex;
		public int UploadsListStartIndex;

        public static BuiltInTestCaseRepo Instance {
            get {
                
                if (_instance == null)  
                    _instance = new BuiltInTestCaseRepo();
             
                return _instance;
            }
        }

        public  List<APIBuiltInTestCase> TestCases
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

            string defaultSubjectID = "108";
            string defaultSiteId = "9";
            string defaultInBed = "2014-05-27T16:40:00";
            string defaultOutBed = "2014-05-28T02:28:00";
            string defaultDay = "2014-05-27";
            string defaultStudyId = "9";
            string defaultDataFileId = "299";
			string defaultUploadId = "34204";



            _testCaseList = new List<APIBuiltInTestCase>()
            {
                // Subject Endpoints
               new GetSubjectTest("GetSubject", defaultSubjectID), // index: 0 
               new AddSubjectTest("AddSubject",defaultSiteId), // index: 1 
               new EditSubjectTest("EditSubject", defaultSubjectID, defaultSiteId), // index: 2
               new GetSubjectStatsTest("GetSubjectStats", defaultSubjectID), // index: 3
               new GetSubjectDayStatsTest("GetSubjectDayStats", defaultSubjectID),  // index: 4
               new GetSubjectDayMinutesTest("GetSubjectDayMinutes", defaultSubjectID,   defaultDay), // index: 5
               new GetSubjectSleepEpochsTest("GetSubjectSleepEpochs", defaultSubjectID, defaultInBed,  defaultOutBed), // index: 6
               new GetSubjectSleepScoreTest("GetSubjectSleepScore", defaultSubjectID, defaultInBed,  defaultOutBed), // index: 7
               new GetSubjectBoutsTest("GetSubjectBouts", defaultSubjectID, defaultInBed,  defaultOutBed), // index: 8
               new GetSubjectBedTimesTest("GetSubjectBedTimes", defaultSubjectID, defaultInBed,  defaultOutBed), // index: 9
               new GetSubjectWeightHistoryTest("GetSubjectWeightHistory", defaultSubjectID), // index: 10
               new GetSubjectDataFilesTest("GetSubjectDataFiles", defaultSubjectID), // index: 11
               
               // Site Endpoints
               new GetSitesTest("GetSites"), // index: 12
			   new AddSiteTest("AddSite"), // index: 13

               // Study Endpoints
               new GetStudiesTest("GetStudies"), // index: 14
               new GetStudyTest("GetStudy",  defaultStudyId), // index: 15
               new GetStudySubjectsTest("GetStudySubjects",  defaultStudyId), // index: 16

               // Upload Endpoints
               new GetUploadTest("GetUpload", defaultDataFileId), // index: 17
			   new GetDataFileDownloadURLTest("GetDataFileDownloadURL", defaultDataFileId) // index: 17
            };

			SubjectListStartIndex = 0;
			SitesListStartIndex = 12;
			StudiesListStartIndex = 14;
			UploadsListStartIndex = 17;
        }

        
    }
}
