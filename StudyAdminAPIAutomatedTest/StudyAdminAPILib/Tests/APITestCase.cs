using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAdminAPILib.Endpoints;
using System.Net.Http;


namespace StudyAdminAPILib.Tests
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
        public HttpRequestMessage _httpRequest;
        public string _name { get; set; }

        private string _accessKey;
        public String AccessKey
        {
            get { 
                return _accessKey;  
            }
            set { 
                _accessKey = value;  
            }
        }

        private string _secretKey;
        public String SecretKey
        {
            get {
                return _secretKey;
            }
            set {
                _secretKey = value;
            }
        }


        public virtual void Execute()
        {
           
        }

        public void BuildAuthHeader()
        {
            if (_httpRequest == null) _httpRequest = new HttpRequestMessage();
            var signature = APIUtils.Sign(_httpRequest, this.SecretKey);
            _httpRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("AGS", string.Format("{0}:{1}", this.AccessKey, signature));

        }

        public virtual void MakeRequest()
        {
       
            if (String.IsNullOrEmpty(_secretKey)) throw new Exception("Secret Key must be set");
            if (String.IsNullOrEmpty(_accessKey)) throw new Exception("Access Key must be set");

            if (_httpRequest == null) _httpRequest = new HttpRequestMessage();

        }

        public virtual Boolean HasPassed()
        {
            return true;
        }

    }


    public class GetSubjectTest : APITestCase
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

    }

}
