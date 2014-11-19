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
        protected string UriFormat {get; set; }
        protected APIJsonDTO dto;
        public HttpStatusCode responseStatusCode;
        public HttpMethod HttpVerb { get; set; }


        public async Task<string> Run(string requestJson)
        {
            HttpResponseMessage response = await APIUtilities.SendRequestAsync(
                this.CurrentEndpoint,
                this.HttpVerb,
                requestJson);

            this.responseStatusCode = response.StatusCode;

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
            this.UriFormat = "{0}/v1/subjects/{1}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectStatsTest : APITestCase
    {
        public GetSubjectStatsTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/stats";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/stats", subjectId);
            this.Name = name;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectDayStatsTest : APITestCase
    {
        public GetSubjectDayStatsTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/daystats";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/daystats", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;      
        }
    }

    public class GetSubjectDayMinutesTest : APITestCase
    {
        public GetSubjectDayMinutesTest(string name, string subjectID, string day)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/dayminutes/{2}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/dayminutes/{1}", subjectID, day);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectSleepEpochsTest : APITestCase
    {
        public GetSubjectSleepEpochsTest(string name, string subjectId, string inBed, string outBed)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/sleepepochs?inbed={2}&outbed={3}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/sleepepochs?inbed={1}&outbed={2}", subjectId, inBed, outBed);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectSleepScoreTest : APITestCase
    {
        public GetSubjectSleepScoreTest(string name, string subjectId, string inBed, string outBed)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/sleepscore?inbed={2}&outbed={3}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/sleepscore?inbed={1}&outbed={2}", subjectId, inBed, outBed);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectBoutsTest : APITestCase
    {
        public GetSubjectBoutsTest(string name, string subjectId, string start, string stop)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/bouts?start={2}&stop={3}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/bouts?start={1}&stop={2}", subjectId, start, stop);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectBedTimesTest : APITestCase
    {
        public GetSubjectBedTimesTest(string name, string subjectId, string start, string stop)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/bedtimes?start={2}&stop={3}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/bedtimes?start={1}&stop={2}", subjectId, start, stop);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class GetSubjectWeightHistoryTest : APITestCase
    {
        public GetSubjectWeightHistoryTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/weighthistory";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/weighthistory", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }
    }

    public class AddSubjectTest : APITestCase
    {
        public AddSubjectTest(string name, string siteId)
        {
            this.UriFormat = "{0}/v1/subjects";
            this.Name = name;
            this.HttpVerb = HttpMethod.Post;
            this.DefaultResourceURI = "/v1/subjects";
            this.dto = new StudyAdminAPILib.JsonDTOs.AddSubjectDTO() {
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
            this.UriFormat = "{0}/v1/subjects";
            this.Name = name;
            this.HttpVerb = HttpMethod.Put;
            this.DefaultResourceURI = "/v1/subjects";
            this.dto = new StudyAdminAPILib.JsonDTOs.UpdateSubjectDTO() {
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
    public class GetSitesTest : APITestCase
    {

        public GetSitesTest(string name)
        {
            this.UriFormat = "{0}/v1/sites";
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
            this.UriFormat = "{0}/v1/studies/{1}";
            this.DefaultResourceURI = string.Format("/v1/studies/{0}",studyId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }

    public class GetStudiesTest : APITestCase
    {
        public GetStudiesTest(string name)
        {
            this.UriFormat = "{0}/v1/studies";
            this.DefaultResourceURI = "/v1/studies";
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }

    public class GetStudySubjectsTest : APITestCase
    {
        public GetStudySubjectsTest(string name, string studyId)
        {
            this.UriFormat = "{0}/v1/studies/{1}/subjects";
            this.DefaultResourceURI = string.Format("/v1/studies/{0}/subjects", studyId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
        }

    }
    #endregion StudyEndpoints



}
