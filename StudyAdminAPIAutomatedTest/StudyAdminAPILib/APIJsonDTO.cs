using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudyAdminAPILib.JsonDTOs
{
    public class APIJsonDTO { }

    public class GetStudiesDTO : APIJsonDTO { }

    public class GetSubjectDTO : APIJsonDTO
    {
        [JsonProperty(Required = Required.Default)]
        public String SubjectID;
    }


}
