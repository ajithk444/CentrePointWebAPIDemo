using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyAdminAPILib.Endpoints;

namespace StudyAdminAPILib.Tests
{
    public class GetSubjectTest : APITestCase
    {
        public GetSubjectTest() { }

        public GetSubjectTest(string baseURI, Endpoint endpoint, string expectedStatusCode) : base()
        {
             this._endpoint = endpoint;
             this._expectedStatusCode = expectedStatusCode;
        }

    }
}
