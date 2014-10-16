using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAdminAPILib;
using System.Net.Http;
using StudyAdminAPILib.JsonDTOs;

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
    
        public Endpoint _endpoint { get; set; }
        public string _expectedStatusCode { get; set; }
        public string _name { get; set; }
        public IJsonDTO dto;


       public HttpRequestMessage InitRequestMessage()
        {
            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            APIUtils.BuildAuthHeader(ref _httpRequest);
            return  _httpRequest;
        }
    }


    public class GetSubjectTest : APITestCase, ITestCase
    {

        public GetSubjectTest() 
        {
            this._name = "GetSubject";
        }

        public GetSubjectTest(string baseURI, Endpoint endpoint, string expectedStatusCode) : base()
        {
            this._name = "GetSubject";
            this._endpoint = endpoint;
            this._expectedStatusCode = expectedStatusCode;
        }

        public void Run()
        {
            HttpRequestMessage request = InitRequestMessage();
            request.Dispose();
        }

        public Boolean HasPassed()
        {
            return true;
        }

    }



}
