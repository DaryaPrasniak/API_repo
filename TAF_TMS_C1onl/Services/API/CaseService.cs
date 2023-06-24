using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Services.API
{
    public class CaseService : BaseService
    {
        public static readonly string GET_CASE = "index.php?/api/v2/get_case/{case_id}";
        public static readonly string ADD_CASE = "index.php?/api/v2/add_case/{section_id}";
        public static readonly string UPDATE_CASE = "index.php?/api/v2/update_case/{case_id}";
        public static readonly string DELETE_CASE = "index.php?/api/v2/delete_case/{case_id}";

        public CaseService(ApiClient apiClient) : base(apiClient)
        {
        }

        public RestResponse GetCase(int caseId)
        {
            var request = new RestRequest(GET_CASE)
                .AddUrlSegment("case_id", caseId);

            return _apiClient.Execute(request);
        }

        public Case GetAsCase(int caseId)
        {
            var request = new RestRequest(GET_CASE)
                .AddUrlSegment("case_id", caseId);

            return _apiClient.Execute<Case>(request);
        }

        public Case AddCase(int sectionId, Case caseForCreate)
        {
            var request = new RestRequest(ADD_CASE, Method.Post)
                .AddUrlSegment("section_id", sectionId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(caseForCreate);

            return _apiClient.Execute<Case>(request);
        }

        public Case UpdateCase(int Id, Case caseForUpdate)
        {
            var request = new RestRequest(UPDATE_CASE, Method.Post)
                .AddUrlSegment("case_id", Id)
                .AddHeader("Content-Type", "application/json")
                .AddBody(caseForUpdate);

            return _apiClient.Execute<Case>(request);
        }

        public RestResponse DeleteCase(int сaseId)
        {
            var request = new RestRequest(DELETE_CASE, Method.Post)
                .AddUrlSegment("case_id", сaseId)
                .AddHeader("Content-Type", "application/json")
                .AddBody("");

            return _apiClient.Execute(request);
        }
    }
}
