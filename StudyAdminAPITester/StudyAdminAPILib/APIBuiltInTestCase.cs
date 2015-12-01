using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using StudyAdminAPILib;
using System.Net.Http;
using StudyAdminAPILib.JsonDTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;


namespace StudyAdminAPILib
{

    public class APIBuiltInTestCase
    {

        public string Name { get; set; }
        public String CurrentEndpoint { get; set; }
        public String DefaultResourceURI { get; set; }
        protected APIJsonDTO dto;
        public HttpMethod HttpVerb { get; set; }

        public string GetJsonRequestText()
        {
            JsonSerializerSettings jsonFormatter = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            return JsonConvert.SerializeObject(this.dto, jsonFormatter);
        }
    }

    #region SubjectEndpoints
    public class GetSubjectTest : APIBuiltInTestCase
    {
        public GetSubjectTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectStatsTest : APIBuiltInTestCase
    {
        public GetSubjectStatsTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/stats", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectDayStatsTest : APIBuiltInTestCase
    {
        public GetSubjectDayStatsTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/daystats", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectDayMinutesTest : APIBuiltInTestCase
    {
        public GetSubjectDayMinutesTest(string name, string subjectID, string day)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/dayminutes/{1}", subjectID, day);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectSleepEpochsTest : APIBuiltInTestCase
    {
        public GetSubjectSleepEpochsTest(string name, string subjectId, string inBed, string outBed)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/sleepepochs?inbed={1}&outbed={2}", subjectId, inBed, outBed);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectSleepScoreTest : APIBuiltInTestCase
    {
        public GetSubjectSleepScoreTest(string name, string subjectId, string inBed, string outBed)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/sleepscore?inbed={1}&outbed={2}", subjectId, inBed, outBed);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectBoutsTest : APIBuiltInTestCase
    {
        public GetSubjectBoutsTest(string name, string subjectId, string start, string stop)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/bouts?start={1}&stop={2}", subjectId, start, stop);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectBedTimesTest : APIBuiltInTestCase
    {
        public GetSubjectBedTimesTest(string name, string subjectId, string start, string stop)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/bedtimes?start={1}&stop={2}", subjectId, start, stop);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectWeightHistoryTest : APIBuiltInTestCase
    {
        public GetSubjectWeightHistoryTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/weighthistory", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectDataFilesTest : APIBuiltInTestCase
    {
        public GetSubjectDataFilesTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/datafiles", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }


    public class AddSubjectTest : APIBuiltInTestCase
    {
        public AddSubjectTest(string name, string siteId)
        {
            this.Name = name;
            this.HttpVerb = HttpMethod.Post;
            this.DefaultResourceURI = "/v1/subjects";
            this.dto = new StudyAdminAPILib.JsonDTOs.AddSubjectDTO()
            {
                Gender = "Male",
                SiteID = siteId,
                SubjectIdentifier = "000008",
                WearPosition = "Left Wrist",
                WeightLbs = "185.00",
                DOB = "1975-10-06"
            };
        }

    }

    public class EditSubjectTest : APIBuiltInTestCase
    {
        public EditSubjectTest(string name, string subjectid, string stieId)
        {
            this.Name = name;
            this.HttpVerb = HttpMethod.Put;
            this.DefaultResourceURI = "/v1/subjects";
            this.dto = new StudyAdminAPILib.JsonDTOs.UpdateSubjectDTO()
            {
                SubjectId = subjectid,
                Gender = "Male",
                SiteID = stieId,
                SubjectIdentifier = "000055",
                WearPosition = "Left Wrist",
                WeightLbs = "185.00",
                DOB = "1975-10-06"
            };
        }

    }
    #endregion

    #region SiteEndpoints
	public class AddSiteTest : APIBuiltInTestCase
	{
		public AddSiteTest(string name)
		{
			this.DefaultResourceURI = "/v1/sites";
			this.Name = name;
			this.HttpVerb = HttpMethod.Post;
			this.dto = new StudyAdminAPILib.JsonDTOs.AddSiteDTO()
			{
				StudyId = "8",
				SiteName = "Site1",
				SiteIdentifier = "001",
				AllowDOB = "false",
				AllowGender = "false",
				AllowWeight = "false",
				DateFormat = "m/d/yyyy",
				PreferredWeightUnits = "Pounds",
				Timezone = "(GMT)",
				Location = "Pensacola, Florida",
				Description = "This is Site 1 (Site Identifier: 001)"
			};
		}
	}

    public class GetSitesTest : APIBuiltInTestCase
    {

        public GetSitesTest(string name)
        {
            this.DefaultResourceURI = "/v1/sites";
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }
    #endregion

    #region StudyEndpoints
    public class GetStudyTest : APIBuiltInTestCase
    {
        public GetStudyTest(string name, string studyId)
        {
            this.DefaultResourceURI = string.Format("/v1/studies/{0}", studyId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }

    public class GetStudiesTest : APIBuiltInTestCase
    {
        public GetStudiesTest(string name)
        {
            this.DefaultResourceURI = "/v1/studies";
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }

    public class GetStudySubjectsTest : APIBuiltInTestCase
    {
        public GetStudySubjectsTest(string name, string studyId)
        {
            this.DefaultResourceURI = string.Format("/v1/studies/{0}/subjects", studyId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }
    #endregion StudyEndpoints

    #region UploadEndpoints

	public class GetUploadTest : APIBuiltInTestCase
	{
		public GetUploadTest(string name, string uploadId)
		{
			this.DefaultResourceURI = string.Format("/v1/uploads/{0}", uploadId);
			this.Name = name;
			this.HttpVerb = HttpMethod.Get;
		}
	}

    public class GetDataFileDownloadURLTest : APIBuiltInTestCase
    {
        public GetDataFileDownloadURLTest(string name, string dataFileId)
        {
            this.DefaultResourceURI = string.Format("/v1/datafiles/{0}/downloadurl", dataFileId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    #endregion

}
