using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http;
using System.Net;
using StudyAdminAPILib.JsonDTOs;
using Newtonsoft.Json;

namespace StudyAdminAPILib
{
    public class APIUtilities
    {

        public static string Sign(HttpRequestMessage request, string secret)
        {
            var md5 = "";
            if (request.Content != null && request.Content.Headers.ContentMD5 != null && request.Content.Headers.ContentMD5.Length > 0)
                md5 = Encoding.UTF8.GetString(request.Content.Headers.ContentMD5);

            var type = "";
            if (request.Content != null && request.Content.Headers.ContentType != null)
                type = request.Content.Headers.ContentType.MediaType;

            if (!request.Headers.Date.HasValue) throw new Exception("");

            var stringToSign = request.Method + "\n" +
                md5 + "\n" +
                type + "\n" +
                request.Headers.Date.Value.ToString("s") + "Z\n" +
                request.RequestUri.ToString();

            return HMACSHA256Base64(secret, stringToSign);
        }

        public static string HMACSHA256Base64(string secret, string message)
        {
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            return Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(message)));
        }

        public static void BuildAuthHeader(ref HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.Date = DateTime.UtcNow;
            var signature = Sign(requestMessage, ClientState.SecretKey);
            requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("AGS", string.Format("{0}:{1}", ClientState.AccessKey, signature));
        }


        public static async Task<HttpResponseMessage> SendRequestAsync(string resourceEndpoint, HttpMethod httpVerb, String requestJson = "")
        {
            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(httpVerb, resourceEndpoint);

            // If post or get request, serialize Data Transfer Object
            if (httpVerb.Equals(HttpMethod.Post) || httpVerb.Equals(HttpMethod.Put))
            {
                request.Content = new StringContent(requestJson, Encoding.UTF8);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            // Build Auth Header
            APIUtilities.BuildAuthHeader(ref request);

            try
            {
                Task<HttpResponseMessage> response = ClientState.HttpClient.SendAsync(request);
                await response;

                return response.Result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                request.Dispose();
            }

        }

        public static APIJsonDTO GetJsonDTO(string uri, HttpMethod verb, String request)
        {
            if (verb.Equals(HttpMethod.Put) && uri.Contains("subjects")) // Update Subject
            {
                return (APIJsonDTO)JsonConvert.DeserializeObject<UpdateSubjectDTO>(request);
            }
            else if (verb.Equals(HttpMethod.Post) && uri.Contains("subjects")) // Add Subject
            {
                return (APIJsonDTO)JsonConvert.DeserializeObject<AddSubjectDTO>(request);
            }
            else
            {
                return null;
            }
        }


    }
}
