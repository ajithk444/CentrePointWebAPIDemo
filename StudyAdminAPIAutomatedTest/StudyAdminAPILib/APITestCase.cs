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


        public virtual void Run(string jsonRequest) 
        { 
            throw new Exception("This method must run from a child class."); 
        }

        public virtual Boolean HasPassed() 
        {
            throw new Exception("The HasPassed method cannot be run from a base class.");
            return false;     
        }
    }


    public class GetSubjectTest : APITestCase, ITestCase
    {

        public GetSubjectTest() 
        {
            this.Name = "GetSubject";
        }

        public GetSubjectTest(string baseURI, Endpoint endpoint, string expectedStatusCode) : base()
        {
            this.Name = "GetSubject";
            this.Endpoint = endpoint;
            this.ExpectedStatusCode = expectedStatusCode;
        }

        public override void Run(string json)
        {
            // Update endpont URI from Json Object
            GetSubjectDTO dataTranserObject = JsonConvert.DeserializeObject<GetSubjectDTO>(json);
            this.Endpoint.uri = string.Format("{0}/v1/subjects/{1}", ClientState.BaseURI, dataTranserObject.SubjectID);
            this.dto = dataTranserObject;
            HttpRequestMessage request = APIUtils.InitRequestMessage(HttpMethod.Get, Endpoint.uri);
         
            


        }

        public override Boolean HasPassed()
        {
            return true;
        }

    }



}
