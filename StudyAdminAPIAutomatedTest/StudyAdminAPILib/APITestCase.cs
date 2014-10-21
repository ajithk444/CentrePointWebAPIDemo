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

        
        public GetSubjectTest(string name) 
        {
            this.UriFormat = "{0}/v1/subjects/{1}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ClientState.DefaultSubjectID);
            this.dto = new StudyAdminAPILib.JsonDTOs.GetSubjectDTO() {
                SubjectID = ClientState.DefaultSubjectID
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


        public GetSubjectStatsTest(string name)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/stats";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ClientState.DefaultSubjectID);
            this.dto = new GetSubjectStatsDTO()
            {
              SubjectID = ClientState.DefaultSubjectID  
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


        public GetSubjectDayStatsTest(string name)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/daystats";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ClientState.DefaultSubjectID);
            this.dto = new GetSubjectStatsDTO()
            {
                SubjectID = ClientState.DefaultSubjectID
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


        public GetSubjectDayMinutesTest(string name)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/dayminutes/{2}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ClientState.DefaultSubjectID, DateTime.Today.ToShortDateString());
            this.dto = new GetSubjectDayMinutesDTO()
            {
                subjectId = ClientState.DefaultSubjectID,
                day = "2013-08-01"
            };
        }

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDayMinutesDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDayMinutesDTO)this.dto).subjectId, ((GetSubjectDayMinutesDTO)this.dto).day.ToString());

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
