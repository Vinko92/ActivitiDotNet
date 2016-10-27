using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using ActivitiDotNet.Configuration;
using ActivitiDotNet.Network;
using ActivitiDotNet.Network.Model;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActivitiDotNet.Abstract
{
    public class BaseInfoProvider<T> where T : class
    {
        protected string _url;
        protected string _username;
        protected string _password;
        protected string _baseUrl;

        public BaseInfoProvider(string url)
        {
            _baseUrl = ConfigurationManager.Instance.BaseUrl;

            _url = url;

            _username = AuthorizationManager.Instance.Username;
            _password = AuthorizationManager.Instance.Password; ;
        }

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>List of <typeparamref name="T"/></returns>
        /// <exception cref="System.Exception"></exception>
        internal virtual List<T> GetAll()
        {
            return BaseInfoProvider<List<T>>.ExecuteOperation(string.Concat(_baseUrl, _url), HttpMethod.GET, _username, _password, jsonRoot: "data");
        }

        //TODO: Sort, TenantId, Pagination

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>List of <typeparamref name="T"/></returns>
        /// <exception cref="System.Exception"></exception>
        /// <example>
        /// Usage:
        ///     GetAll("id:jobid","executionId:executionId");
        /// </example>
        internal virtual List<T> GetAll(params string[] queryKeyValues)
        {
            string url = string.Concat(_baseUrl, _url) + "?" + string.Join("&", queryKeyValues);

            return BaseInfoProvider<List<T>>.ExecuteOperation(url, HttpMethod.GET, _username, _password, jsonRoot: "data");
        }

        /// <summary>
        /// Get all objects.<typeparamref name="T"/></returns>
        /// </summary>
        /// <returns>List of <typeparamref name="T"/></returns>
        /// <exception cref="System.Exception">Throws Activity exception.</exception>
        internal List<T> GetAll(string jsonRoot)
        {
            return BaseInfoProvider<List<T>>.ExecuteOperation(string.Concat(_baseUrl, _url), HttpMethod.GET, _username, _password, jsonRoot);
        }

        internal async Task<List<T>> GetAllAsync()
        {
            ActivitiRESTClient<T> client = new ActivitiRESTClient<T>(_baseUrl + _url, HttpMethod.GET);
            Response<T> response = await client.GetAsync(_username, _password);

            JObject jsonResponse = JObject.Parse(response.Body);

            return JsonConvert.DeserializeObject<List<T>>(
                                                jsonResponse.SelectToken("data").ToString());
        }


        internal T Get(string id)
        {
            string url = string.Concat(_baseUrl, _url, "/", id);

            return ExecuteOperation(url, HttpMethod.GET, _username, _password);
        }

        internal T Get(string id, string jsonRoot)
        {
            string url = string.Concat(_baseUrl, _url, "/", id);

            return ExecuteOperation(string.Concat(_baseUrl, _url), HttpMethod.GET, _username, _password, jsonRoot);
        }

        internal bool TryDelete(string id, out T responseObject)
        {
            var client = new ActivitiRESTClient<T>(string.Concat(_baseUrl, _url, "/", id), HttpMethod.DELETE);

            Response<T> response = client.Delete(_username, _password);
            int status = (int)response.StatusCode;

            responseObject = JsonConvert.DeserializeObject<T>(response.Body);

            return status >= 200 && status < 300;
        }

        internal T Delete(string id)
        {
            string url = string.Concat(_baseUrl, _url, "/", id);

            return ExecuteOperation(url, HttpMethod.DELETE, _username, _password);
        }

        internal T Update(string id, T value)
        {
            string url = string.Concat(_baseUrl, _url, "/", id);

            return ExecuteOperation(url, HttpMethod.PUT, _username, _password);
        }

        internal void Create(ref T value)
        {
            value = ExecuteOperation(string.Concat(_baseUrl, _url), HttpMethod.POST, _username, _password, JsonConvert.SerializeObject(value));
        }

        internal static T ExecuteOperation(string url, HttpMethod method, string username, string password, string body = "", string jsonRoot = "")
        {
            ActivitiRESTClient<T> client = InitClient(FormatUrl(url), method, body);
            Response<T> response = null;

            switch (method)
            {
                case HttpMethod.POST:
                    response = client.Post(username, password);
                    break;
                case HttpMethod.PUT:
                    response = client.Post(username, password);
                    break;
                case HttpMethod.GET:
                    response = client.Get(username, password);
                    break;
                case HttpMethod.DELETE:
                    response = client.Delete(username, password);
                    break;
                default:
                    return null;
            }

            return response.ParseResponse(jsonRoot);
        }

        internal static byte[] GetBytes(string url, string username, string password)
        {
            ActivitiRESTClient<T> client = InitClient(FormatUrl(url), HttpMethod.GET, string.Empty);
            Response<T> response = null;

            response = client.Get(username, password, true);

            return response.ByteData;
        }

        internal static Dictionary<string, string> GetProperties(string url, string username, string password)
        {
            ActivitiRESTClient<T> client = InitClient(FormatUrl(url), HttpMethod.GET, string.Empty);
            Response<T> response = null;
            Dictionary<string, string> properties = new Dictionary<string, string>();

            response = client.Get(username, password, true);
            if (response.Exception != null)
            {
                JObject json = JObject.Parse(response.Body);

                foreach (JToken jsonToken in json.Children())
                {
                    var next = jsonToken.Next;
                }

                return properties;
            }
            else
            {
                throw response.Exception;
            }
        }

        internal static HttpStatusCode PostFile(string url, byte[] fileData, string fileName, string mimeType, string username, string password)
        {
            ActivitiRESTClient<T> client = InitClient(FormatUrl(url), HttpMethod.GET, string.Empty);

            return client.PostFile(fileData, fileName, mimeType, username, password);
        }

        private static ActivitiRESTClient<T> InitClient(string url, HttpMethod method, string body)
        {
            ActivitiRESTClient<T> client = null;

            if (!string.IsNullOrEmpty(body))
            {
                client = new ActivitiRESTClient<T>(url, method, body);
            }
            else
            {
                client = new ActivitiRESTClient<T>(url, method);
            }

            return client;
        }

        private static string FormatUrl(string url)
        {
            Uri uri;

            try
            {
                uri = new Uri(url);
            }
            catch
            {
                uri = new Uri(ConfigurationManager.Instance.BaseUrl + url);
            }

            return uri.AbsoluteUri;
        }
    }
}
