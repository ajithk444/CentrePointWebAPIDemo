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

    public class APITestCase
    {

        public string Name { get; set; }
        public String CurrentEndpoint { get; set; }
        public String DefaultResourceURI { get; set; }
        protected APIJsonDTO dto;
        public HttpRequestMessage request { get; set; }
        public HttpResponseMessage response { get; set; }
        public HttpMethod HttpVerb { get; set; }


        public async Task<string> Run(string requestJson, bool includeDateHeader = true)
        {

            SendHttpRequestResult result = await APIUtilities.SendRequestAsync(
                this.CurrentEndpoint,
                this.HttpVerb,
                requestJson,
                includeDateHeader);

            this.request = result.request;
            this.response = result.response;

            return await response.Content.ReadAsStringAsync();
        }


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
    public class GetSubjectTest : APITestCase
    {
        public GetSubjectTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectStatsTest : APITestCase
    {
        public GetSubjectStatsTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/stats", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectDayStatsTest : APITestCase
    {
        public GetSubjectDayStatsTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/daystats", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectDayMinutesTest : APITestCase
    {
        public GetSubjectDayMinutesTest(string name, string subjectID, string day)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/dayminutes/{1}", subjectID, day);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectSleepEpochsTest : APITestCase
    {
        public GetSubjectSleepEpochsTest(string name, string subjectId, string inBed, string outBed)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/sleepepochs?inbed={1}&outbed={2}", subjectId, inBed, outBed);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectSleepScoreTest : APITestCase
    {
        public GetSubjectSleepScoreTest(string name, string subjectId, string inBed, string outBed)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/sleepscore?inbed={1}&outbed={2}", subjectId, inBed, outBed);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectBoutsTest : APITestCase
    {
        public GetSubjectBoutsTest(string name, string subjectId, string start, string stop)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/bouts?start={1}&stop={2}", subjectId, start, stop);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectBedTimesTest : APITestCase
    {
        public GetSubjectBedTimesTest(string name, string subjectId, string start, string stop)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/bedtimes?start={1}&stop={2}", subjectId, start, stop);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectWeightHistoryTest : APITestCase
    {
        public GetSubjectWeightHistoryTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/weighthistory", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectDataFilesTest : APITestCase
    {
        public GetSubjectDataFilesTest(string name, string subjectId)
        {
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/datafiles", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }


    public class AddSubjectTest : APITestCase
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

    public class EditSubjectTest : APITestCase
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
	public class AddSiteTest : APITestCase
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

    public class GetSitesTest : APITestCase
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
    public class GetStudyTest : APITestCase
    {
        public GetStudyTest(string name, string studyId)
        {
            this.DefaultResourceURI = string.Format("/v1/studies/{0}", studyId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }

    public class GetStudiesTest : APITestCase
    {
        public GetStudiesTest(string name)
        {
            this.DefaultResourceURI = "/v1/studies";
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }

    public class GetStudySubjectsTest : APITestCase
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

	public class GetUploadTest : APITestCase
	{
		public GetUploadTest(string name, string uploadId)
		{
			this.DefaultResourceURI = string.Format("/v1/uploads/{0}", uploadId);
			this.Name = name;
			this.HttpVerb = HttpMethod.Get;
		}
	}

    public class GetDataFileDownloadURLTest : APITestCase
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
