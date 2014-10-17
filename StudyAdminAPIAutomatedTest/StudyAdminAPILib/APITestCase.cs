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

    public abstract class APITestCase
    {

        public string Name { get; set; }
        public APIEndpoint Endpoint { get; set; }
        public string ExpectedStatusCode { get; set; }
        public string UriFormat {get; set; }

        public APIJsonDTO dto;


        public virtual string Run(string jsonRequest) 
        {
            throw new Exception("The function: \"Run\" cannot be run from abstract base class.");
            return string.Empty;
        }

        public virtual Boolean HasPassed() 
        {
            throw new Exception("The function: \"HasPassed\" cannot be run from abstract base class");
            return false;     
        }
    }


    public class GetSubjectTest : APITestCase, IAPITestCase
    {

        
        public GetSubjectTest(string name) 
        {
            this.UriFormat = "{0}/v1/subjects/{1}";
            this.Name = name;
            this.Endpoint = new APIEndpoint(string.Format(UriFormat, ClientState.BaseURI, ClientState.DefaultSubjectID), HttpMethod.Get);
            this.ExpectedStatusCode = "200";
            this.dto = new StudyAdminAPILib.JsonDTOs.GetSubjectDTO() {
                SubjectID = ClientState.DefaultSubjectID
            };
        }


        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDTO>(jsonRequest);
            
            // Update Endpoint URI
            this.Endpoint.uri = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDTO)this.dto).SubjectID);
       
            // Generate HttpRequestMessage
            HttpRequestMessage request = APIUtilities.InitRequestMessage(HttpMethod.Get, Endpoint.uri);

            var response = ClientState.HttpClient.SendAsync(request).Result;

            var responseBody = response.Content.ReadAsStringAsync().Result;

            return responseBody;

        }

        public override Boolean HasPassed()
        {
            return true;
        }

    }


    public class GetStudiesTest : APITestCase, IAPITestCase
    {


        public GetStudiesTest(string name)
        {
            this.UriFormat = "{0}/v1/studies";
            this.Name = name;
            this.Endpoint = new APIEndpoint(string.Format(UriFormat, ClientState.BaseURI), HttpMethod.Get);
            this.ExpectedStatusCode = "200";
            this.dto = new StudyAdminAPILib.JsonDTOs.GetStudiesDTO();
        }


        public override string Run(string jsonRequest)
        {
            // De-Serialize Json request from user and set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetStudiesDTO>(jsonRequest);

            // Update Endpoint URI
            this.Endpoint.uri = string.Format(UriFormat, ClientState.BaseURI);

            // Generate HttpRequestMessage
            HttpRequestMessage request = APIUtilities.InitRequestMessage(HttpMethod.Get, Endpoint.uri);

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
