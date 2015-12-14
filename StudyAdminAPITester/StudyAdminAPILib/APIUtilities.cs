using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using StudyAdminAPILib.JsonDTOs;
using Newtonsoft.Json;

namespace StudyAdminAPILib
{
    public class SendHttpRequestResult
    {
        public HttpRequestMessage request {get; set;}
        public HttpResponseMessage response {get; set;}
    }

    public class APIUtilities
    {

        public static HttpMethod GetHttpMethodFromText(string httpMethodText)
        {
            switch (httpMethodText)
            {
                case "GET":
                    return  HttpMethod.Get;
                case "PUT":
                    return HttpMethod.Put;
                case "POST":
                    return HttpMethod.Post;
                case "DELETE":
                    return HttpMethod.Delete;
            }
            return null;
        }

        public static string Sign(HttpRequestMessage request, string secret)
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

            return HMACSHA256Base64(secret, stringToSign);
        }

        public static string HMACSHA256Base64(string secret, string message)
        {
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(message)));
        }
        /// <summary>
        /// The method builds the authentication header
        /// </summary>
        /// <param name="requestMessage"></param>
        public static void BuildAuthHeader(ref HttpRequestMessage requestMessage, bool includeDateInHeader)
        {
            // this is only done for testing purposes, A date should always be included in the HTTP Header.
            if (includeDateInHeader) requestMessage.Headers.Date = DateTime.UtcNow;
            
            var signature = Sign(requestMessage, ClientState.SecretKey);
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("AGS", string.Format("{0}:{1}", ClientState.AccessKey, signature));
        }

        public static async Task<SendHttpRequestResult> SendRequestAsync(string resourceEndpoint, HttpMethod httpVerb, String requestJson, bool includeDateInHeader)
        {

            // Generate HttpClient   
             HttpClient client = client = new HttpClient()
             {
                 BaseAddress = new Uri(ClientState.BaseURI)
             };

             // Generate HttpRequestMessage
             HttpRequestMessage httpRequest = new HttpRequestMessage(httpVerb, resourceEndpoint);
            
            try
            {   
                // If post or get request, serialize Data Transfer Object
                if (httpVerb.Equals(HttpMethod.Post) || httpVerb.Equals(HttpMethod.Put))
                {
                    httpRequest.Content = new StringContent(requestJson, Encoding.UTF8);
                    httpRequest.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                }

                // Build Auth Header
                APIUtilities.BuildAuthHeader(ref httpRequest, includeDateInHeader);
                
                HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);

                return new SendHttpRequestResult()
                {
                     request = httpRequest,
                     response = httpResponse
                };
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

    }
}
