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



namespace StudyAdminAPILib
{

    public abstract class APITestCase : IAPITestCase
    {

        public string Name { get; set; }
        public String CurrentEndpoint { get; set; }
        public String DefaultResourceURI { get; set; }
        public string UriFormat {get; set; }
        public APIJsonDTO dto;
        public HttpStatusCode responseStatusCode;
        public HttpMethod HttpVerb { get; set; }

        public virtual async Task<string> Run(string jsonRequest)
        {
            throw new Exception("The function: \"Run( String )\" cannot be run from abstract base class.");
            return null;
        }

        public virtual async Task<string> Run(HttpMethod verb = null)
        {

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.CurrentEndpoint,
                (verb == null ? HttpMethod.Get : verb), this.dto);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;
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
    public class GetSubjectTest : APITestCase, IAPITestCase
    {

        
        public GetSubjectTest(string name, string subjectId) 
        {
            this.UriFormat = "{0}/v1/subjects/{1}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
        }

    }

    public class GetSubjectStatsTest : APITestCase, IAPITestCase
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

    public class GetSubjectDayStatsTest : APITestCase, IAPITestCase
    {

        public GetSubjectDayStatsTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/daystats";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/daystats", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
      
        }

    }

    public class GetSubjectDayMinutesTest : APITestCase, IAPITestCase
    {

        public GetSubjectDayMinutesTest(string name, string subjectID, string day)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/dayminutes/{2}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/dayminutes/{1}", subjectID, day);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectID, day);

        }


    }

    public class GetSubjectSleepEpochsTest : APITestCase, IAPITestCase
    {

        public GetSubjectSleepEpochsTest(string name, string subjectId, string inBed, string outBed)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/sleepepochs?inbed={2}&outbed={3}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/sleepepochs?inbed={1}&outbed={2}", subjectId, inBed, outBed);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, inBed, outBed);
        }

    }

    public class GetSubjectSleepScoreTest : APITestCase, IAPITestCase
    {

        public GetSubjectSleepScoreTest(string name, string subjectId, string inBed, string outBed)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/sleepscore?inbed={2}&outbed={3}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/sleepscore?inbed={1}&outbed={2}", subjectId, inBed, outBed);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, inBed, outBed);

        }


    }

    public class GetSubjectBoutsTest : APITestCase, IAPITestCase
    {

        public GetSubjectBoutsTest(string name, string subjectId, string start, string stop)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/bouts?start={2}&stop={3}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/bouts?start={1}&stop={2}", subjectId, start, stop);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, start, stop);
        }

    }

    public class GetSubjectBedTimesTest : APITestCase, IAPITestCase
    {

        public GetSubjectBedTimesTest(string name, string subjectId, string start, string stop)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/bedtimes?start={2}&stop={3}";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/bedtimes?start={1}&stop={2}", subjectId, start, stop);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, start, stop);

        }

    }

    public class GetSubjectWeightHistoryTest : APITestCase, IAPITestCase
    {

        public GetSubjectWeightHistoryTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/weighthistory";
            this.DefaultResourceURI = string.Format("/v1/subjects/{0}/weighthistory", subjectId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
        }

    }

    public class AddSubjectTest : APITestCase, IAPITestCase
    {

        public AddSubjectTest(string name)
        {
            this.UriFormat = "{0}/v1/subjects";
            this.Name = name;
            this.HttpVerb = HttpMethod.Post;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI);
            this.DefaultResourceURI = "/v1/subjects";
            this.dto = new StudyAdminAPILib.JsonDTOs.AddSubjectDTO() {
                Gender = "Male",
                SiteID = "001",
                SubjectIdentifier = "000008",
                WearPosition = "Left Wrist",
                WeightLbs = "185.00",
                DOB = "1975-10-06"
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object          
            this.dto = (AddSubjectDTO)JsonConvert.DeserializeObject<AddSubjectDTO>(jsonRequest);
         
            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(
                                            this.CurrentEndpoint,
                                            HttpMethod.Post,
                                            this.dto);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }

    }

    public class UpdateSubjectTest : APITestCase, IAPITestCase
    {

        public UpdateSubjectTest(string name, string subjectid)
        {
            this.UriFormat = "{0}/v1/subjects";
            this.Name = name;
            this.HttpVerb = HttpMethod.Put;
            this.DefaultResourceURI = "/v1/subjects";
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, subjectid);
            this.dto = new StudyAdminAPILib.JsonDTOs.UpdateSubjectDTO() {
                SubjectId = subjectid,
                Gender = "Male",
                SiteID = "001",
                SubjectIdentifier = "000055",
                WearPosition = "Left Wrist",
                WeightLbs = "185.00",
                DOB = "1975-10-06"
            };
        }

        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object          
            this.dto = (APIJsonDTO)JsonConvert.DeserializeObject<UpdateSubjectDTO>(jsonRequest);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(
                                                this.CurrentEndpoint,
                                                HttpMethod.Put,
                                                this.dto);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }

    }
    #endregion

    #region SiteEndpoints
    public class GetSitesTest : APITestCase, IAPITestCase
    {

        public GetSitesTest(string name)
        {
            this.UriFormat = "{0}/v1/sites";
            this.DefaultResourceURI = "/v1/sites";
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI);
        }

    }       
    #endregion

    #region StudyEndpoints
    public class GetStudyTest : APITestCase, IAPITestCase
    {
        public GetStudyTest(string name, string studyId)
        {
            this.UriFormat = "{0}/v1/studies/{1}";
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, studyId);
        }

    }

    public class GetStudiesTest : APITestCase, IAPITestCase
    {
        public GetStudiesTest(string name)
        {
            this.UriFormat = "{0}/v1/studies";
            this.DefaultResourceURI = "/v1/studies";
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI);
        }

    }

    public class GetStudySubjectsTest : APITestCase, IAPITestCase
    {
        public GetStudySubjectsTest(string name, string studyId)
        {
            this.UriFormat = "{0}/v1/studies/{1}/subjects";
            this.DefaultResourceURI = string.Format("/v1/studies/{0}/subjects", studyId);
            this.Name = name;
            this.HttpVerb = HttpMethod.Get;
            this.CurrentEndpoint = string.Format(UriFormat, ClientState.BaseURI, studyId);
        }

    }
    #endregion StudyEndpoints



}
