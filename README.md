This repository contains a C# implementation of the Study Admin API tester application. The application targets the .NET
Framework version 4.5 and utilizes Microsoft's Windows Forms technology. The graphical user interface allows users to easily
test requests and responses against the Study Admin API. 

Study Admin API Documentation
==========================
This code-base is built on the Study Admin API documentation: https://github.com/actigraph/StudyAdminAPIDocumentation



Study Admin API Tester
==========================

### Single Test Mode ###

To run this tool in "single test" mode you will need to obtain an API key value pair from a Study Admin administrator. After obtaining API key value pair, enter access & secret keys in corresponding text boxes within tool. To specify an endpoint, you can select a option from the "Built-In Tests" drop down and click "Populate" button. The user will also have to ability to specify a custom endpoint by selecting an HTTP verb and specifying the resource URI.

When a request is formulated, the user will click the "Send Request" button to submit the request to the api. The user
will be able to view the http response along with the status code in the response log.

![2014-12-03_16-43-01](https://cloud.githubusercontent.com/assets/9215408/5290337/8702b14e-7b0b-11e4-97fb-80f5de99bc7f.png)




### Batch Mode ###

To run this tool in "batch mode", you will have to import a Batch Config XML File. This XML file will specify the specific tests along with the expected http status codes and response for each test. The tool will contain a sample XML batch config along with the XML Schema that validates the XML.

![2014-12-03_16-38-07](https://cloud.githubusercontent.com/assets/9215408/5290284/0fa15d4e-7b0b-11e4-8bec-d5d05998ec6a.png)




Connecting to Study Admin API - C# Demo
==========================

**Example of invoking 'Studies' Endpoint**    

    string baseUri = "https://studyadmin-api.actigraphcorp.com";
    string resourceUri = "/v1/studies";
    string endpointUri = baseUri + resourceUri;
    HttpResponseMessage resposne = SendRequestAsync(endpointUri, HttpMethod.Get, null).Result;
	
**Example of method Sending Request to Study Admin API**

  	
	public static async Task<HttpResponseMessage> SendRequestAsync(string endpointUri, HttpMethod httpVerb, string requestContentJson)
	{
	    // Generate HttpClient   
	     HttpClient client = client = new HttpClient()
	     {
	         BaseAddress = new Uri("https://studyadmin-api.actigraphcorp.com")
	     };
	
	     // Generate HttpRequestMessage
	     HttpRequestMessage httpRequest = new HttpRequestMessage(httpVerb, endpointUri);
	    
	    try
	    {   
	        // If 'post' or 'put' request, set content-type in request header to 'application/json'
	        if (httpVerb.Equals(HttpMethod.Post) || httpVerb.Equals(HttpMethod.Put))
	        {
	            httpRequest.Content = new StringContent(requestContentJson, Encoding.UTF8);
	            httpRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
	        }
	
	        // Build Request Header
	        BuildRequestHeader(ref httpRequest);
	        
			// return response from API 
	        return await client.SendAsync(httpRequest);

		}
	    catch (Exception)
	    {
	        throw;
	    }
	    finally
	    {
	        httpRequest.Dispose();
	        client.Dispose();
	    }
	}


**Example of method building request header**
        
	public static void BuildRequestHeader(ref HttpRequestMessage requestMessage)
	{        
		string apiAccessKey = "Api Access Key Goes Here";
		string apiSecretKey = "Api Secret Key Goes Here";
	
	    var signature = Sign(requestMessage, apiSecretKey);
	    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("AGS", string.Format("{0}:{1}", apiAccessKey, signature));
	}

**Example of Request Signing method**

	public static string Sign(HttpRequestMessage request, string apiSecretKey)
	{
	    var md5 = "";
	    if (request.Content != null && request.Content.Headers.ContentMD5 != null && request.Content.Headers.ContentMD5.Length > 0)
	        md5 = Encoding.UTF8.GetString(request.Content.Headers.ContentMD5);
	
	    var type = "";
	    if (request.Content != null && request.Content.Headers.ContentType != null)
	        type = request.Content.Headers.ContentType.MediaType;
	
	    var stringToSign = request.Method + "\n" +
	        md5 + "\n" +
	        type + "\n" +
	        (request.Headers.Date.HasValue ? request.Headers.Date.Value.ToString("s") + "Z\n" : "\n") +
	        request.RequestUri.ToString();
	
	    return HMACSHA256Base64(apiSecretKey, stringToSign);
	}


**Example of method performing HMAC SHA256 Encrypted Hash**

	public static string HMACSHA256Base64(string apiSecretKey, string message)
    {
        var hash = new HMACSHA256(Encoding.UTF8.GetBytes(apiSecretKey));
        return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(message)));
    }

