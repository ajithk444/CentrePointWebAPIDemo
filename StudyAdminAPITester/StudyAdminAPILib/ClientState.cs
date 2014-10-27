using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace StudyAdminAPILib
{

    /// <summary>
    /// Class that holds static variables which are accessible to all components in the application
    /// </summary>
    public class ClientState
    {
        private static string _baseURI;
        public static String BaseURI
        {
            get
            {
                return _baseURI;
            }
            set
            {
                _baseURI = value;
            }
        }

        /// <summary>
        /// Private Key for Api Authorization
        /// </summary>
        private static string _accessKey;
        public static String AccessKey
        {
            get 
            {
                return _accessKey;
            }
            set 
            {
                _accessKey = value;
            }
        }

        /// <summary>
        /// Secret Key for Api Authorization
        /// </summary>
        private static string _secretKey;
        public static String SecretKey
        {
            get
            {
                return _secretKey;
            }
            set
            {
                _secretKey = value;
            }
        }

        /// <summary>
        /// HttpClient for application
        /// </summary>
        private static HttpClient _client;
        public static HttpClient HttpClient
        {
            get 
            {
                if (_client == null) 
                {
                    _client = new HttpClient();
                    _client.BaseAddress = new Uri(ClientState.BaseURI);
                }

                return _client; 
            }
            set 
            { 
                _client = value; 
            }
        }

        private static AuthenticationHeaderValue _httpAuth;
        public static AuthenticationHeaderValue AuthenticationHeaderValue 
        {
            get
            {
                 return _httpAuth;
            }
            set
            {
                _httpAuth = value;
            }
        }

        /// <summary>
        /// default subject id. Application defaults to this. User has ability to modify.
        /// </summary>
        private static string _defaultSubjectId;
        public static string DefaultSubjectID
        {
            get
            {
                return _defaultSubjectId;
            }
            set
            {
                _defaultSubjectId = value;
            }
        }


        /// <summary>
        /// default in bed time. Application defaults to this. User has ability to modify.
        /// </summary>
        private static string _defaultInBed;
        public static string DefaultInBed
        {
            get
            {
                return _defaultInBed;
            }
            set
            {
                _defaultInBed = value;
            }
        }


        /// <summary>
        /// default out bed time. Application defaults to this. User has ability to modify.
        /// </summary>
        private static string _defaultOutBed;
        public static string DefaultOutBed
        {
            get
            {
                return _defaultOutBed;
            }
            set
            {
                _defaultOutBed = value;
            }
        }

        /// <summary>
        /// default out bed time. Application defaults to this. User has ability to modify.
        /// </summary>
        private static string _defaultDay;
        public static string DefaultDay
        {
            get
            {
                return _defaultDay;
            }
            set
            {
                _defaultDay = value;
            }
        }

        /// <summary>
        /// Default study id. Application defaults to this. User has ability to modify.
        /// </summary>
        private static string _defaultStudyId;
        public static string DefaultStudyId
        {
            get
            {
                return _defaultStudyId;
            }
            set
            {
                _defaultStudyId = value;
            }
        }

    }
}
