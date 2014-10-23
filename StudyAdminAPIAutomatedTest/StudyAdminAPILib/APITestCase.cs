using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using StudyAdminAPILib;
using System.Net.Http;
using StudyAdminAPILib.JsonDTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace StudyAdminAPILib
{

    public abstract class APITestCase : IAPITestCase
    {

        public string Name { get; set; }
        public String Endpoint { get; set; }
        public string UriFormat {get; set; }
        public APIJsonDTO dto;
        public HttpStatusCode responseStatusCode;

        public virtual async Task<string> Run(string jsonRequest)
        {
            throw new Exception("The function: \"Run\" cannot be run from abstract base class.");
            return null;
        }

        public string GetJsonRequestText()
        {
            JsonSerializerSettings jsonFormatter = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };

            return JsonConvert.SerializeObject(this.dto, jsonFormatter); 

        }

        public virtual void CheckResponse(string jsonResponse)
        {
            throw new Exception("The function: \"CheckResponse\" cannot be run from abstract base class.");
        }

    }

    #region SubjectEndpoints
    public class GetSubjectTest : APITestCase, IAPITestCase
    {

        
        public GetSubjectTest(string name, string subjectID) 
        {
            this.UriFormat = "{0}/v1/subjects/{1}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectID);
            this.dto = new StudyAdminAPILib.JsonDTOs.GetSubjectDTO() {
                SubjectID = subjectID
            };
        }

        public override async Task<string> Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDTO)this.dto).SubjectID);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto, 
                                                this.Endpoint,
                                                HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;


        }

    }

    public class GetSubjectStatsTest : APITestCase, IAPITestCase
    {


        public GetSubjectStatsTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/stats";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
            this.dto = new GetSubjectStatsDTO()
            {
                SubjectID = subjectId
            };
        }

        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectStatsDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectStatsDTO)this.dto).SubjectID);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }

    }

    public class GetSubjectDayStatsTest : APITestCase, IAPITestCase
    {


        public GetSubjectDayStatsTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/daystats";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
            this.dto = new GetSubjectStatsDTO() {
                SubjectID = subjectId
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDayStatsDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDayStatsDTO)this.dto).SubjectID);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;


        }


    }

    public class GetSubjectDayMinutesTest : APITestCase, IAPITestCase
    {

        public GetSubjectDayMinutesTest(string name, string subjectID, string day)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/dayminutes/{2}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectID, day);
            this.dto = new GetSubjectDayMinutesDTO()
            {
                subjectId = subjectID,
                day = day
            };
        }

        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDayMinutesDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDayMinutesDTO)this.dto).subjectId, ((GetSubjectDayMinutesDTO)this.dto).day);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }


    }

    public class GetSubjectSleepEpochsTest : APITestCase, IAPITestCase
    {

        public GetSubjectSleepEpochsTest(string name, string subjectId, string inBed, string outBed)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/sleepepochs?inbed={2}&outbed={3}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, inBed, outBed);
            this.dto = new GetSubjectSleepEpochsDTO()
            {
                subjectId = subjectId,
                inBed = inBed,
                outBed = outBed
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectSleepEpochsDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectSleepEpochsDTO)this.dto).subjectId,
                                                    ((GetSubjectSleepEpochsDTO)this.dto).inBed, ((GetSubjectSleepEpochsDTO)this.dto).outBed);


            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;


        }

    }

    public class GetSubjectSleepScoreTest : APITestCase, IAPITestCase
    {

        public GetSubjectSleepScoreTest(string name, string subjectId, string inBed, string outBed)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/sleepscore?inbed={2}&outbed={3}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, inBed, outBed);
            this.dto = new GetSubjectSleepScoreDTO()
            {
                subjectId = subjectId,
                inBed = inBed,
                outBed = outBed
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectSleepScoreDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectSleepScoreDTO)this.dto).subjectId,
                                                ((GetSubjectSleepScoreDTO)this.dto).inBed, ((GetSubjectSleepScoreDTO)this.dto).outBed);


            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;


        }


    }

    public class GetSubjectBoutsTest : APITestCase, IAPITestCase
    {

        public GetSubjectBoutsTest(string name, string subjectId, string start, string stop)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/bouts?start={2}&stop={3}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, start, stop);
            this.dto = new GetSubjectBoutsDTO()
            {
                subjectId = subjectId,
                start = start,
                stop = stop
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectBoutsDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectBoutsDTO)this.dto).subjectId,
                                                ((GetSubjectBoutsDTO)this.dto).start, ((GetSubjectBoutsDTO)this.dto).stop);


            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }

    }

    public class GetSubjectBedTimesTest : APITestCase, IAPITestCase
    {

        public GetSubjectBedTimesTest(string name, string subjectId, string start, string stop)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/bedtimes?start={2}&stop={3}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId, start, stop);
            this.dto = new GetSubjectBedTimesDTO()
            {
                subjectId = subjectId,
                start = start,
                stop = stop
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectBedTimesDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectBedTimesDTO)this.dto).subjectId,
                                            ((GetSubjectBedTimesDTO)this.dto).start, ((GetSubjectBedTimesDTO)this.dto).stop);


            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;


        }


     

    }

    public class GetSubjectWeightHistoryTest : APITestCase, IAPITestCase
    {

        public GetSubjectWeightHistoryTest(string name, string subjectId)
        {
            this.UriFormat = "{0}/v1/subjects/{1}/weighthistory";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectId);
            this.dto = new GetSubjectWeightHistoryDTO()
            {
                subjectId = subjectId
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object          
            this.dto = (GetSubjectWeightHistoryDTO)JsonConvert.DeserializeObject<GetSubjectWeightHistoryDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectWeightHistoryDTO)this.dto).subjectId);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }

    }

    public class AddSubjectTest : APITestCase, IAPITestCase
    {

        public AddSubjectTest(string name)
        {
            this.UriFormat = "{0}/v1/subjects";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);
            this.dto = new StudyAdminAPILib.JsonDTOs.AddSubjectDTO() {
                Gender = "Male",
                SiteID = "001",
                SubjectIdentifier = "000008",
                WearPosition = "Left Wrist",
                WeightLbs = "185.00",
                DOB = "1975-10-06"
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object          
            this.dto = (AddSubjectDTO)JsonConvert.DeserializeObject<AddSubjectDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                            this.Endpoint,
                                            HttpMethod.Post,
                                            "application/json");

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }

    }

    public class UpdateSubjectTest : APITestCase, IAPITestCase
    {

        public UpdateSubjectTest(string name, string subjectid)
        {
            this.UriFormat = "{0}/v1/subjects/{1}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, subjectid);
            this.dto = new StudyAdminAPILib.JsonDTOs.UpdateSubjectDTO() {
                SubjectId = subjectid,
                Gender = "Male",
                SiteID = "001",
                SubjectIdentifier = "000055",
                WearPosition = "Left Wrist",
                WeightLbs = "185.00",
                DOB = "1975-10-06"
            };
        }

        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object          
            this.dto = (APIJsonDTO)JsonConvert.DeserializeObject<UpdateSubjectDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((UpdateSubjectDTO)this.dto).SubjectId);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                                this.Endpoint,
                                                HttpMethod.Put,
                                                "application/json");

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }

    }
    #endregion

    #region SiteEndpoints
    public class GetSitesTest : APITestCase, IAPITestCase
    {

        public GetSitesTest(string name)
        {
            this.UriFormat = "{0}/v1/sites";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);
            this.dto = new StudyAdminAPILib.JsonDTOs.GetSitesDTO();
        }

        public override async Task<string> Run(string jsonRequest)
        {

            
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                                this.Endpoint,
                                                HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }


    }       
    #endregion

    #region StudyEndpoints
    public class GetStudyTest : APITestCase, IAPITestCase
    {
        public GetStudyTest(string name, string studyId)
        {
            this.UriFormat = "{0}/v1/studies/{1}";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, studyId);
            this.dto = new StudyAdminAPILib.JsonDTOs.GetStudyDTO()
            {
                StudyId = studyId
            };
        }

        public override async Task<string> Run(string jsonRequest)
        {


            this.dto = JsonConvert.DeserializeObject<GetStudyDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetStudyDTO)this.dto).StudyId);  

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                                this.Endpoint,
                                                HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }


    }

    public class GetStudiesTest : APITestCase, IAPITestCase
    {
        public GetStudiesTest(string name)
        {
            this.UriFormat = "{0}/v1/studies";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);
            this.dto = new StudyAdminAPILib.JsonDTOs.GetStudiesDTO();
        }

        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object     
            this.dto = JsonConvert.DeserializeObject<GetStudiesDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                                this.Endpoint,
                                                HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }


    }

    public class GetStudySubjectsTest : APITestCase, IAPITestCase
    {
        public GetStudySubjectsTest(string name, string studyId)
        {
            this.UriFormat = "{0}/v1/studies/{1}/subjects";
            this.Name = name;
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, studyId);
            this.dto = new StudyAdminAPILib.JsonDTOs.GetStudySubjectsDTO() { 
                StudyId = studyId
            };
        }


        public override async Task<string> Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object     
            this.dto = JsonConvert.DeserializeObject<GetStudySubjectsDTO>(jsonRequest);
            this.Endpoint = string.Format(UriFormat, ClientState.BaseURI, ((GetStudySubjectsDTO)this.dto).StudyId);

            Task<HttpResponseMessage> message = APIUtilities.SendRequestAsync(this.dto,
                                                this.Endpoint,
                                                HttpMethod.Get);

            await message;

            HttpResponseMessage response = message.Result;
            this.responseStatusCode = response.StatusCode;

            Task<String> responseTextTask = response.Content.ReadAsStringAsync();
            await responseTextTask;

            return responseTextTask.Result;

        }


    }
    #endregion StudyEndpoints



}
