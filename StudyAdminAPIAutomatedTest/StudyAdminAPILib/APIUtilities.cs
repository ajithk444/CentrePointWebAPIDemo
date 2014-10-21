using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Http;
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

        public static string SendRequest(APIJsonDTO dto, string resourceEndpoint, HttpMethod httpVerb, string mediaType = "")
        {
            // Generate HttpRequestMessage
            HttpRequestMessage request = new HttpRequestMessage(httpVerb, resourceEndpoint);
                   
            // If post or get request, serialize Data Transfer Object
            if (httpVerb.Equals(HttpMethod.Post) || httpVerb.Equals(HttpMethod.Put)) { 
                request.Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8);
            }
           
            if (!(String.IsNullOrEmpty(mediaType))) { 
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(mediaType);
            }

            // Build Auth Header
            APIUtilities.BuildAuthHeader(ref request);

            string responseBody = null;

            try {
                
                var response = ClientState.HttpClient.SendAsync(request).Result;
                responseBody = response.Content.ReadAsStringAsync().Result;
            } 
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                 request.Dispose();
            }
           

            return responseBody;
        }


    }
}
