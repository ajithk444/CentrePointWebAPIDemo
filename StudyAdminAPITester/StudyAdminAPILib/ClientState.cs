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

        private static string _removeNewLineRegEx = "(\r\n|\r|\n)";
        public static String RemoveNewLineRegEx
        {
            get
            {
                return _removeNewLineRegEx;
            }
        }

        private static string _removeNewLineAndWhiteSpaceRegEx = @"(\r\n|\r|\n|\s)";
        public static String RemoveNewLineAndWhiteSpaceRegEx
        {
            get
            {
                return _removeNewLineAndWhiteSpaceRegEx;
            }
        }

    }
}
