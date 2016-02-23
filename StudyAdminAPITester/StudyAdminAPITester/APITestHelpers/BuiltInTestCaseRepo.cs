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

        public static BuiltInTestCaseRepo Instance {
            get {
                
                if (_instance == null)  
                    _instance = new BuiltInTestCaseRepo();
             
                return _instance;
            }
        }

        public List<APIBuiltInTestCase> AllTestCases
        {
            get 
            { 
                return _testCaseList;  
            } 
        }

		public List<string> SubjectTestCases
		{
			get
			{
				return AllTestCases.Where(x => x.Name.Contains("Subject") && !x.Name.Contains("Study")).Select(x => x.Name).ToList();
			}
		}

		public List<string> SiteTestCases
		{
			get
			{
				return AllTestCases.Where(x => x.Name.Contains("Site")).Select(x => x.Name).ToList();
			}
		}


		public List<string> StudyTestCases
		{
			get
			{
				return AllTestCases.Where(x => (x.Name.Contains("Study") || x.Name.Contains("Studies")) && (!x.Name.Contains("GetStudyWebhookHistory"))).Select(x => x.Name).ToList();
			}
		}


		public List<string> UploadTestCases
		{
			get
			{
				return AllTestCases.Where(x => x.Name.Contains("Upload") || x.Name.Equals("GetDataFileDownloadURL")).Select(x => x.Name).ToList();
			}
		}

		public List<string> WebHooksTestCases
		{
			get
			{
				return AllTestCases.Where(x => x.Name.Equals("GetStudyWebhookHistory")).Select(x => x.Name).ToList();
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
			string defaultSubjectIdentifier = "000055";
            string defaultSiteId = "9";
            string defaultInBed = "2014-05-27T16:40:00";
            string defaultOutBed = "2014-05-28T02:28:00";
            string defaultDay = "2014-05-27";
            string defaultStudyId = "9";
            string defaultDataFileId = "299";
			string defaultUploadId = "418";



            _testCaseList = new List<APIBuiltInTestCase>()
            {
                // Subject Endpoints
               new GetSubjectTest("GetSubject", defaultSubjectID), 
               new AddSubjectTest("AddSubject",defaultSiteId), 
               new EditSubjectTest("EditSubject", defaultSubjectID, defaultSiteId),
               new GetSubjectStatsTest("GetSubjectStats", defaultSubjectID), 
			   new GetSubjectStatsTest("GetSubjectStats", defaultSubjectID), 
               new GetSubjectDayStatsTest("GetSubjectDayStats", defaultSubjectID), 
               new GetSubjectDayMinutesTest("GetSubjectDayMinutes", defaultSubjectID, defaultDay),
               new GetSubjectSleepEpochsTest("GetSubjectSleepEpochs", defaultSubjectID, defaultInBed,  defaultOutBed), 
               new GetSubjectSleepScoreTest("GetSubjectSleepScore", defaultSubjectID, defaultInBed,  defaultOutBed),
               new GetSubjectBoutsTest("GetSubjectBouts", defaultSubjectID, defaultInBed,  defaultOutBed),
               new GetSubjectBedTimesTest("GetSubjectBedTimes", defaultSubjectID, defaultInBed,  defaultOutBed),
               new GetSubjectWeightHistoryTest("GetSubjectWeightHistory", defaultSubjectID), 
               new GetSubjectDataFilesTest("GetSubjectDataFiles", defaultSubjectID), 
               
               // Site Endpoints
               new GetSitesTest("GetSites"), 
			   new AddSiteTest("AddSite"),

               // Study Endpoints
               new GetStudiesTest("GetStudies"), 
               new GetStudyTest("GetStudy",  defaultStudyId), 
               new GetStudySubjectsTest("GetStudySubjects",  defaultStudyId), 
			   new GetStudySubjectsByIdentifierTest("GetStudySubjectsByIdentifierTest", defaultStudyId, defaultSubjectIdentifier), 

               // Upload Endpoints
               new GetUploadTest("GetUploadDetails", defaultUploadId),
			   new PostUploadTest("PostUpload"),
			   new GetDataFileDownloadURLTest("GetDataFileDownloadURL", defaultDataFileId),
               new GetStudyWebhookHistoryTest(@"GetStudyWebhookHistory", defaultStudyId, DateTime.UtcNow.AddDays(-1).ToString("s"))
            };
        }

        
    }
}
