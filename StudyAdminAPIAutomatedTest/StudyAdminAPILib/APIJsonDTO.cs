using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudyAdminAPILib.JsonDTOs
{
    public abstract class APIJsonDTO 
    {
        public virtual bool SerializedSuccessfullyAfterResponse() 
        {
            throw new Exception("The function: \"SerializeSuccessfullyAfterResponse\" cannot be run from abstract base class.");
            return false;
        }
    }

    #region Subject DTOs
    public class GetSubjectDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String SubjectID;
    }

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

        public override bool SerializedSuccessfullyAfterResponse()
        {
            if (String.IsNullOrEmpty(this.SubjectId) || string.IsNullOrEmpty(this.SubjectIdentifier))
            {
                return false;
            }

            return true;
        }

    }

    public class GetSubjectStatsDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String SubjectID;
    }

    public class GetSubjectDayStatsDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String SubjectID;
    }

    public class GetSubjectDayMinutesDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String subjectId;

        [JsonProperty(Required = Required.Default)]
        public String day;
    }

    public class GetSubjectSleepEpochsDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String subjectId;

        [JsonProperty(Required = Required.Default)]
        public String inBed;

        [JsonProperty(Required = Required.Default)]
        public String outBed;
    }

    public class GetSubjectSleepScoreDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String subjectId;

        [JsonProperty(Required = Required.Default)]
        public String inBed;

        [JsonProperty(Required = Required.Default)]
        public String outBed;
    }

    public class GetSubjectBoutsDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String subjectId;

        [JsonProperty(Required = Required.Default)]
        public String start;

        [JsonProperty(Required = Required.Default)]
        public String stop;
    }

    public class GetSubjectBedTimesDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String subjectId;

        [JsonProperty(Required = Required.Default)]
        public String start;

        [JsonProperty(Required = Required.Default)]
        public String stop;
    }
   
    public class GetSubjectWeightHistoryDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String subjectId;
    }
    #endregion

    #region Site DTOs
    public class GetSitesDTO : APIJsonDTO { }
    #endregion 

    #region Study DTOs
    public class GetStudiesDTO : APIJsonDTO { }

    public class GetStudyDTO : APIJsonDTO 
    {
        [JsonProperty(Required = Required.Default)]
        public String StudyId;
    
    }

    public class GetStudySubjectsDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String StudyId;

    }
    #endregion


}
