using System;
using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Configuration;
using ActivitiDotNet.Constants;
using ActivitiDotNet.Model;
using ActivitiDotNet.Network;
using ActivitiDotNet.Network.Model;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActivitiDotNet.Process
{
    public class ProcessInfoProvider : BaseInfoProvider<ProcessInfo>, IReadable<ProcessInfo>
    {

        private string _baseUrl;
        private ActivitiRESTClient<ProcessInfo> client;

        public ProcessInfoProvider(string baseUrl) : base(UrlConstants.PROCESS)
        {
            _baseUrl = ConfigurationManager.Instance.BaseUrl;
        }

        public ProcessInfo UpdateProcessCategory(string id, string categoryName)
        {
            string url = string.Concat(_baseUrl, UrlConstants.PROCESS, "/", id);

            JObject json = new JObject();
            json.Add("category", categoryName);

            return ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", json.ToString());
        }

        public ProcessInfo Activate(string id)
        {
            string url = string.Concat(_baseUrl, UrlConstants.PROCESS, "/", id);

            JObject json = new JObject();
            json.Add("action", "activate");
            json.Add("includeProcessInstances", "true");
            json.Add("date", DateTime.Now.ToString("yyyy-MM-ddThh:mm:ssZ"));

            return ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", json.ToString());
        }

        public ProcessInfo Suspend(string id)
        {
            string url = string.Concat(_baseUrl, UrlConstants.PROCESS, "/", id);

            JObject json = new JObject();
            json.Add("action", "suspend");
            json.Add("includeProcessInstances", "false");
            json.Add("date", DateTime.Now.ToString("yyyy-MM-ddThh:mm:ssZ"));

            return ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", json.ToString());
        }

        public List<UserInfo> GetAllCandidateStarters(string processId)
        {
            string url = string.Concat(_baseUrl, UrlConstants.PROCESS, "/", processId, "/identitylinks");

            return BaseInfoProvider<List<UserInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public UserInfo AddUserCandidate(string processId, string userId)
        {
            string url = string.Concat(_baseUrl, UrlConstants.PROCESS, "/", processId, "/identitylinks");

            JObject json = new JObject();
            json.Add("user", userId);

            return BaseInfoProvider<UserInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", json.ToString());
        }

        public UserInfo AddGroupCandidate(string processId, string groupId)
        {
            string url = string.Concat(_baseUrl, UrlConstants.PROCESS, "/", processId, "/identitylinks");

            JObject json = new JObject();
            json.Add("group", groupId);

            return BaseInfoProvider<UserInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", json.ToString());
        }

        public new List<ProcessInfo> GetAll()
        {
            return base.GetAll();
        }

        public new ProcessInfo Get(string id)
        {
            return base.Get(id);
        }
    }
}
