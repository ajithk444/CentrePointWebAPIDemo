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

    public class APITestCase 
    {
    
        public Endpoint _endpoint { get; set; }
        public string _expectedStatusCode { get; set; }
        public HttpRequestMessage _httpRequest;

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


        public void Execute()
        {
           

        }

        public void BuildAuthHeader()
        {
            if (_httpRequest == null) _httpRequest = new HttpRequestMessage();


        }

        public void MakeRequest()
        {
       
            if (String.IsNullOrEmpty(_secretKey)) throw new Exception("Secret Key must be set");
            if (String.IsNullOrEmpty(_accessKey)) throw new Exception("Access Key must be set");

            if (_httpRequest == null) _httpRequest = new HttpRequestMessage();

        }

    }

}
