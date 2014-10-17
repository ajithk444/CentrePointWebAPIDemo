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
    public enum HTTPStatusCode
    {
        // ToDo: Fill in rest of the codes
        Code404,
        Code200
    }

    public abstract class APITestCase
    {

        public string Name { get; set; }
        public Endpoint Endpoint { get; set; }
        public string ExpectedStatusCode { get; set; }
        
        public JsonDTO dto;


        public virtual string Run(string jsonRequest) 
        { 
            throw new Exception("This method must run from a child class.");
            return string.Empty;
        }

        public virtual Boolean HasPassed() 
        {
            throw new Exception("The HasPassed method cannot be run from a base class.");
            return false;     
        }
    }


    public class GetSubjectTest : APITestCase, ITestCase
    {

        public string uriFormat = "{0}/v1/subjects/{1}";

        public GetSubjectTest() 
        {
            this.Name = "GetSubject";
            this.Endpoint = new Endpoint(string.Format(uriFormat, ClientState.BaseURI, ClientState.DefaultSubjectID), HttpMethod.Get);
            this.ExpectedStatusCode = "200";
            this.dto = new StudyAdminAPILib.JsonDTOs.GetSubjectDTO()
            {
                SubjectID = ClientState.DefaultSubjectID
            };
        }


        public override string Run(string jsonRequest)
        {
            // De-Serialize Json request from user and set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDTO>(jsonRequest);
            
            // Update Endpoint URI
            this.Endpoint.uri = string.Format(uriFormat, ClientState.BaseURI, ((GetSubjectDTO)this.dto).SubjectID);
       
            // Generate HttpRequestMessage
            HttpRequestMessage request = APIUtils.InitRequestMessage(HttpMethod.Get, Endpoint.uri);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

        public override Boolean HasPassed()
        {
            return true;
        }

    }


    public class GetStudiesTest : APITestCase, ITestCase
    {

        public string uriFormat = "{0}/v1/studies";

        public GetStudiesTest()
        {
            this.Name = "GetStudiesTest";
            this.Endpoint = new Endpoint(string.Format(uriFormat, ClientState.BaseURI), HttpMethod.Get);
            this.ExpectedStatusCode = "200";
            this.dto = new StudyAdminAPILib.JsonDTOs.GetStudiesDTO()
            {     
            };
        }


        public override string Run(string jsonRequest)
        {
            // De-Serialize Json request from user and set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetStudiesDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint.uri = string.Format(uriFormat, ClientState.BaseURI);

            // Generate HttpRequestMessage
            HttpRequestMessage request = APIUtils.InitRequestMessage(HttpMethod.Get, Endpoint.uri);


            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

        public override Boolean HasPassed()
        {
            return true;
        }

    }


}
