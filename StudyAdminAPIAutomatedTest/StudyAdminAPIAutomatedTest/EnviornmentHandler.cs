using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace StudyAdminAPIAutomatedTest 
{

    public enum enviornment {
        Production,
        Development
    }

    public class EnviornmentHandler
    {

        private static EnviornmentHandler _instance = new EnviornmentHandler();
        private EnviornmentSection _enviornment;

        // Private constructor for singleton
        private EnviornmentHandler() { }

        public static EnviornmentHandler Instance {
            get {
                return _instance;
            }
        }

        public EnviornmentSection Enviornment
        {
            get
            {
                return _enviornment;
            }
            set
            {
                _enviornment = value;
            }
        }

        public void Initialize()
        {
            string enviornmentToUse = ConfigurationManager.AppSettings["enviornment"];
            switch (enviornmentToUse)
            {
                case "Production":
                    _enviornment = (StudyAdminAPIAutomatedTest.EnviornmentSection)ConfigurationManager.GetSection("EnviornmentSection/Production");
                    break;
                case "Development":
                    _enviornment = (StudyAdminAPIAutomatedTest.EnviornmentSection)ConfigurationManager.GetSection("EnviornmentSection/Development");
                    break;
                default:
                    throw new Exception("Enviornment Not Specified");
            }

        }

    }

    public class EnviornmentSection : ConfigurationSection
    {
        public enviornment enviornment {get; set;}
        private string baseURI;
        private string accessKey;
        private string secretKey;

        [ConfigurationProperty("BaseURI")]
        public string BaseURI { 
            get { 
                return baseURI;
            } 
            set {
                this.baseURI = value;
            }
        }

        [ConfigurationProperty("AccessKey")]
        public string AccessKey { 
            get { 
                return accessKey;
            } 
            set {
                this.accessKey = value;
            }
        }

        [ConfigurationProperty("SecreyKey")]
        public string SecreyKey { 
            get { 
                return secretKey;
            } 
            set {
                this.secretKey = value;
            }
        }
    }


}
