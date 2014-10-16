using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAdminAPILib
{
    public enum HTTPVerb {
        GET,
        POST,
        SET,
        PUT
    }

    public class Endpoint
    {
        public HTTPVerb action;
        public string uniqueId;
        public string uri;
    }
}
