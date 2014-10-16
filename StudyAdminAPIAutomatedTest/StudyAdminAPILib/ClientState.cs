using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

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


        public static HttpClient _client;
        public static HttpClient HttpClient
        {
            get 
            { 
                return _client; 
            }
            set 
            { 
                _client = value; 
            }
        }

        /// <summary>
        /// default subject id. Application defaults to this. User has ability to modify.
        /// </summary>
        public static string _defaultSubjectId;
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


    }
}
