using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace StudyAdminAPILib
{
    public class Endpoint
    {
        public HttpMethod httpMethod;
        public string uniqueId;
        public string uri;

        public Endpoint(string uri, HttpMethod httpMethod) 
        {
            this.uri = uri;
            this.httpMethod = httpMethod;
        }
    }
}
