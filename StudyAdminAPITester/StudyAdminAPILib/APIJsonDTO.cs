using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudyAdminAPILib.JsonDTOs
{
    public abstract class APIJsonDTO  { }

    #region Subject DTOs
    
    public class AddSubjectDTO : APIJsonDTO
    {

        [JsonProperty(Required = Required.Default)]
        public String Gender;

        [JsonProperty(Required = Required.Default)]
        public String SiteID;

        [JsonProperty(Required = Required.Default)]
        public String SubjectIdentifier;

        [JsonProperty(Required = Required.Default)]
        public String WearPosition;

        [JsonProperty(Required = Required.Default)]
        public String WeightLbs;

        [JsonProperty(Required = Required.Default)]
        public String DOB;

    }

    public class UpdateSubjectDTO : APIJsonDTO
    {

        [JsonProperty(Required = Required.Default)]
        public String SubjectId;

        [JsonProperty(Required = Required.Default)]
        public String Gender;

        [JsonProperty(Required = Required.Default)]
        public String SiteID;

        [JsonProperty(Required = Required.Default)]
        public String SubjectIdentifier;

        [JsonProperty(Required = Required.Default)]
        public String WearPosition;

        [JsonProperty(Required = Required.Default)]
        public String WeightLbs;

        [JsonProperty(Required = Required.Default)]
        public String DOB;

    }


	public class AddSiteDTO : APIJsonDTO
	{
		[JsonProperty(Required = Required.Default)]
		public String StudyId;

		[JsonProperty(Required = Required.Default)]
		public String SiteName;

		[JsonProperty(Required = Required.Default)]
		public String SiteIdentifier;

		[JsonProperty(Required = Required.Default)]
		public String Location;

		[JsonProperty(Required = Required.Default)]
		public String Description;

		[JsonProperty(Required = Required.Default)]
		public String Timezone;

		[JsonProperty(Required = Required.Default)]
		public String DateFormat;

		[JsonProperty(Required = Required.Default)]
		public String AllowWeight;

		[JsonProperty(Required = Required.Default)]
		public String AllowGender;

		[JsonProperty(Required = Required.Default)]
		public String AllowDOB;

		[JsonProperty(Required = Required.Default)]
		public String PreferredWeightUnits;
	}


    #endregion

}
