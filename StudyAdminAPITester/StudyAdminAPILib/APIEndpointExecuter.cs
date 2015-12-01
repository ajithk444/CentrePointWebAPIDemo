using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudyAdminAPILib
{

	public class APIEndpointExecuterResult
	{
		public HttpRequestMessage Request { get; set; }
		public HttpResponseMessage Response { get; set; }
		public string ResponseContent { get; set; }
	}

	public class APIEndpointExecuter
	{

		public string _Uri { get; set; }
		public HttpMethod _HttpVerb { get; set; }

		public APIEndpointExecuter(string uri, HttpMethod httpVerb)
		{
			_Uri = uri;
			_HttpVerb = httpVerb;
		}

		public async Task<APIEndpointExecuterResult> Run(string requestJson, bool includeDateHeader = true)
		{

			SendHttpRequestResult result = await APIUtilities.SendRequestAsync(
				_Uri,
				_HttpVerb,
				requestJson,
				includeDateHeader);

			APIEndpointExecuterResult returnVal = new APIEndpointExecuterResult();

			returnVal.Request = result.request;
			returnVal.Response = result.response;
			returnVal.ResponseContent = await result.response.Content.ReadAsStringAsync();
			
			return returnVal;
		}
	}
}
