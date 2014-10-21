using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAdminAPILib;
using System.Net.Http;
using StudyAdminAPILib.JsonDTOs;
using Newtonsoft.Json;

namespace StudyAdminAPILib
{

    public abstract class APITestCase : IAPITestCase
    {

        public string Name { get; set; }
        public String Endpoint { get; set; }
        public string UriFormat {get; set; }
        public APIJsonDTO dto;


        public virtual string Run(string jsonRequest) 
        {
            throw new Exception("The function: \"Run\" cannot be run from abstract base class.");
            return null;
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

    public class GetSubjectTest : APITestCase, IAPITestCase
    {

        
        public GetSubjectTest(string name, string subjectID) 
        {
            this.UriFormat = "{0}/v1/subjects/{1}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectID);
            this.dto = new StudyAdminAPILib.JsonDTOs.GetSubjectDTO() {
                SubjectID = subjectID
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDTO>(jsonRequest);
            
            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDTO)this.dto).SubjectID);
       
            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);

            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetSubjectStatsTest : APITestCase, IAPITestCase
    {


        public GetSubjectStatsTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/stats";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
            this.dto = new GetSubjectStatsDTO()
            {
                SubjectID = subjectId
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectStatsDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectStatsDTO)this.dto).SubjectID);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);

            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetSubjectDayStatsTest : APITestCase, IAPITestCase
    {


        public GetSubjectDayStatsTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/daystats";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
            this.dto = new GetSubjectStatsDTO() {
                SubjectID = subjectId
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDayStatsDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDayStatsDTO)this.dto).SubjectID);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);

            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetSubjectDayMinutesTest : APITestCase, IAPITestCase
    {

        public GetSubjectDayMinutesTest(string name, string subjectID, string day)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/dayminutes/{2}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectID, day);
            this.dto = new GetSubjectDayMinutesDTO()
            {
                subjectId = subjectID,
                day = day
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDayMinutesDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDayMinutesDTO)this.dto).subjectId, ((GetSubjectDayMinutesDTO)this.dto).day);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);
            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetSubjectSleepEpochsTest : APITestCase, IAPITestCase
    {

        public GetSubjectSleepEpochsTest(string name, string subjectId, string inBed, string outBed)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/sleepepochs?inbed={2}&outbed={3}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, inBed, outBed);
            this.dto = new GetSubjectSleepEpochsDTO()
            {
                subjectId = subjectId,
                inBed = inBed,
                outBed = outBed
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectSleepEpochsDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectSleepEpochsDTO)this.dto).subjectId,
                ((GetSubjectSleepEpochsDTO)this.dto).inBed, ((GetSubjectSleepEpochsDTO)this.dto).outBed);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);
            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetSubjectSleepScoreTest : APITestCase, IAPITestCase
    {

        public GetSubjectSleepScoreTest(string name, string subjectId, string inBed, string outBed)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/sleepscore?inbed={2}&outbed={3}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, inBed, outBed);
            this.dto = new GetSubjectSleepScoreDTO()
            {
                subjectId = subjectId,
                inBed = inBed,
                outBed = outBed
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectSleepScoreDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectSleepScoreDTO)this.dto).subjectId,
                ((GetSubjectSleepScoreDTO)this.dto).inBed, ((GetSubjectSleepScoreDTO)this.dto).outBed);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);
            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetSubjectBoutsTest : APITestCase, IAPITestCase
    {

        public GetSubjectBoutsTest(string name, string subjectId, string start, string stop)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/bouts?start={2}&stop={3}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, start, stop);
            this.dto = new GetSubjectBoutsDTO()
            {
                subjectId = subjectId,
                start = start,
                stop = stop
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectBoutsDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectBoutsDTO)this.dto).subjectId,
                ((GetSubjectBoutsDTO)this.dto).start, ((GetSubjectBoutsDTO)this.dto).stop);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);
            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetSubjectBedTimesTest : APITestCase, IAPITestCase
    {

        public GetSubjectBedTimesTest(string name, string subjectId, string start, string stop)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/bedtimes?start={2}&stop={3}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, start, stop);
            this.dto = new GetSubjectBedTimesDTO()
            {
                subjectId = subjectId,
                start = start,
                stop = stop
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectBedTimesDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectBedTimesDTO)this.dto).subjectId,
                ((GetSubjectBedTimesDTO)this.dto).start, ((GetSubjectBedTimesDTO)this.dto).stop);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);
            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetSubjectWeightHistoryTest : APITestCase, IAPITestCase
    {

        public GetSubjectWeightHistoryTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/weighthistory";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
            this.dto = new GetSubjectWeightHistoryDTO()
            {
                subjectId = subjectId
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectWeightHistoryDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectWeightHistoryDTO)this.dto).subjectId);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);
            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class AddSubjectTest : APITestCase, IAPITestCase
    {

        public AddSubjectTest(string name)
        {
            this.UriFormat = "{0}/v1/subjects";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);
            this.dto = new StudyAdminAPILib.JsonDTOs.AddSubjectDTO() {
                Gender = "Male",
                SiteID = "001",
                SubjectIdentifier = "000008",
                WearPosition = "Left Wrist",
                WeightLbs = "185.00",
                DOB = "1975-10-06"
            };
        }


        public override string Run(string jsonRequest) 
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<AddSubjectDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this.Endpoint);

            request.Content = new StringContent(JsonConvert.SerializeObject(this.dto), Encoding.UTF8);
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            // Build Auth Header
            APIUtilities.BuildAuthHeader(ref request);


            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class UpdateSubjectTest : APITestCase, IAPITestCase
    {

        public UpdateSubjectTest(string name)
        {
            this.UriFormat = "{0}/v1/subjects/{1}";
            this.Name = name;
            //this.Endpoint = new APIEndpoint(string.Format(UriFormat, ClientState.BaseURI, ClientState.DefaultSubjectID), HttpMethod.Put);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ClientState.DefaultSubjectID);
            this.dto = new StudyAdminAPILib.JsonDTOs.UpdateSubjectDTO() {
                SubjectId = "594",
                Gender = "Male",
                SiteID = "001",
                SubjectIdentifier = "000008",
                WearPosition = "Left Wrist",
                WeightLbs = "185.00",
                DOB = "1975-10-06"
            };
        }


        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<UpdateSubjectDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, this.Endpoint);

            request.Content = new StringContent(JsonConvert.SerializeObject(this.dto), Encoding.UTF8);
            request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            // Build Auth Header
            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;
            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

    }

    public class GetStudiesTest : APITestCase, IAPITestCase
    {

        public GetStudiesTest(string name)
        {
            this.UriFormat = "{0}/v1/studies";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);
            this.dto = new StudyAdminAPILib.JsonDTOs.GetStudiesDTO();
        }


        public override string Run(string jsonRequest)
        {
            // De-Serialize Json request from user and set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetStudiesDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);

            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, this.Endpoint);

            APIUtilities.BuildAuthHeader(ref request);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }


    }




}
