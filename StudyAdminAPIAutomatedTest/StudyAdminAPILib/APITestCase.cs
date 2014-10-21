using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public virtual string Run(string jsonRequest) 
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

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDTO>(jsonRequest);
            return APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDTO)this.dto).SubjectID),
                                            HttpMethod.Get);

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

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectStatsDTO>(jsonRequest);
            return APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectStatsDTO)this.dto).SubjectID),
                                            HttpMethod.Get);

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

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDayStatsDTO>(jsonRequest);
            return APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDayStatsDTO)this.dto).SubjectID),
                                            HttpMethod.Get);


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

        public override string Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectDayMinutesDTO>(jsonRequest);
            return APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectDayMinutesDTO)this.dto).subjectId, ((GetSubjectDayMinutesDTO)this.dto).day),
                                            HttpMethod.Get);

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

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectSleepEpochsDTO>(jsonRequest);
            return APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectSleepEpochsDTO)this.dto).subjectId,
                                                    ((GetSubjectSleepEpochsDTO)this.dto).inBed, ((GetSubjectSleepEpochsDTO)this.dto).outBed),
                                            HttpMethod.Get);


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

        public override string Run(string jsonRequest)
        {

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectSleepScoreDTO>(jsonRequest);
            string jsonResponse = APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectSleepScoreDTO)this.dto).subjectId,
                                                ((GetSubjectSleepScoreDTO)this.dto).inBed, ((GetSubjectSleepScoreDTO)this.dto).outBed),
                                            HttpMethod.Get);

            CheckResponse(jsonResponse);
            return jsonResponse;




        }

        public override void CheckResponse(string jsonResponse)
        {
            try
            {
                if (jsonResponse.Equals("\"{}\"")) return;

                try
                {
                    // First try deserializing in JObject
                    JObject obj = JsonConvert.DeserializeObject<JObject>(jsonResponse);
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        // If unsuccessful then try deserializing to JArray
                        JArray obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);
                        return;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(jsonResponse);
            }
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

        public override string Run(string jsonRequest)
        {
            

            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectBoutsDTO>(jsonRequest);
            string jsonResponse = APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectBoutsDTO)this.dto).subjectId,
                                                ((GetSubjectBoutsDTO)this.dto).start, ((GetSubjectBoutsDTO)this.dto).stop),
                                            HttpMethod.Get);

            CheckResponse(jsonResponse);
            return jsonResponse;


        }

        public override void CheckResponse(string jsonResponse)
        {
            try
            {
                if (jsonResponse.Equals("\"{}\"")) return;

                try
                {
                    // First try deserializing in JObject
                    JObject obj = JsonConvert.DeserializeObject<JObject>(jsonResponse);
                    return;
                }
                catch (Exception) 
                {
                    try
                    {
                        // If unsuccessful then try deserializing to JArray
                        JArray obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);
                        return;
                    }
                    catch (Exception e) 
                    {
                        throw e;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception(jsonResponse);
            }
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

        public override string Run(string jsonRequest)
        {
            // Deserialize Json request from user & set it to DTO object
            this.dto = JsonConvert.DeserializeObject<GetSubjectBedTimesDTO>(jsonRequest);
            string jsonResponse = APIUtilities.SendRequest(this.dto,
                                        string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectBedTimesDTO)this.dto).subjectId,
                                            ((GetSubjectBedTimesDTO)this.dto).start, ((GetSubjectBedTimesDTO)this.dto).stop),
                                        HttpMethod.Get);

            CheckResponse(jsonResponse);
            return jsonResponse;



        }

        public override void CheckResponse(string jsonResponse)
        {
            try
            {
                if (jsonResponse.Equals("\"{}\"")) return;

                JArray obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);
                if (obj.Count > 0)  {
                    return;
                }
            }
            catch (Exception)
            {
                throw new Exception(jsonResponse);
            }
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

        public override string Run(string jsonRequest)
        {

            // Send Request            
            this.dto = (GetSubjectWeightHistoryDTO)JsonConvert.DeserializeObject<GetSubjectWeightHistoryDTO>(jsonRequest);
            string jsonResponse = APIUtilities.SendRequest(this.dto,
                                       string.Format(UriFormat, ClientState.BaseURI, ((GetSubjectWeightHistoryDTO)this.dto).subjectId),
                                       HttpMethod.Get);

            CheckResponse(jsonResponse);
            return jsonResponse;
        }

        public override void CheckResponse(string jsonResponse)
        {
            try
            {
                JArray obj = JsonConvert.DeserializeObject<JArray>(jsonResponse);
                if (obj.Count > 0)
                {
                    return;
                }
            }
            catch (Exception)
            {
                throw new Exception(jsonResponse);
            }
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


        public override string Run(string jsonRequest) 
        {
            this.dto = (AddSubjectDTO)JsonConvert.DeserializeObject<AddSubjectDTO>(jsonRequest);
            string jsonResponse =  APIUtilities.SendRequest(((APIJsonDTO)JsonConvert.DeserializeObject<AddSubjectDTO>(jsonRequest)),
                                         string.Format(UriFormat, ClientState.BaseURI),
                                         HttpMethod.Post, 
                                         "application/json");

            CheckResponse(jsonResponse);
            return jsonResponse;
        }

        public override void CheckResponse(string jsonResponse)
        {
            try {
                this.dto = JsonConvert.DeserializeObject<AddSubjectDTO>(jsonResponse);
            }
            catch (Exception)
            {
                throw new Exception(jsonResponse);
            }
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

        public override string Run(string jsonRequest)
        {
            this.dto = (APIJsonDTO)JsonConvert.DeserializeObject<UpdateSubjectDTO>(jsonRequest);
            string jsonResponse = APIUtilities.SendRequest(this.dto, 
                                              string.Format(UriFormat, ClientState.BaseURI, ((UpdateSubjectDTO)this.dto).SubjectId),
                                              HttpMethod.Put, 
                                              "application/json");
            CheckResponse(jsonResponse);
            return jsonResponse;

        }

        public override void CheckResponse(string jsonResponse)
        {
            if (!String.IsNullOrEmpty(jsonResponse))  {
                try {
                    this.dto = JsonConvert.DeserializeObject<UpdateSubjectDTO>(jsonResponse);
                }
                catch (Exception) {
                    throw new Exception(jsonResponse);
                }
            }
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


        public override string Run(string jsonRequest)
        {
        

            return APIUtilities.SendRequest(this.dto,
                                              string.Format(UriFormat, ClientState.BaseURI),
                                              HttpMethod.Get);
            
          


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


        public override string Run(string jsonRequest)
        {
            this.dto = JsonConvert.DeserializeObject<GetStudyDTO>(jsonRequest);
            return APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetStudyDTO)this.dto).StudyId),
                                            HttpMethod.Get);

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


        public override string Run(string jsonRequest)
        {
            this.dto = JsonConvert.DeserializeObject<GetStudiesDTO>(jsonRequest);
            return APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI),
                                            HttpMethod.Get);

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

        public override string Run(string jsonRequest)
        {
            this.dto = JsonConvert.DeserializeObject<GetStudySubjectsDTO>(jsonRequest);
            return APIUtilities.SendRequest(this.dto,
                                            string.Format(UriFormat, ClientState.BaseURI, ((GetStudySubjectsDTO)this.dto).StudyId),
                                            HttpMethod.Get);

        }


    }
    #endregion StudyEndpoints



}
