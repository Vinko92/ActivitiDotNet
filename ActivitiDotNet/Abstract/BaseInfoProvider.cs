using System.Collections.Generic;
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

        public BaseInfoProvider(string url)
        {
            _url = ConfigurationManager.Instance.BaseUrl + url;
            _username = AuthorizationManager.Instance.Username;
            _password = AuthorizationManager.Instance.Password; ;
        }

        /// <summary>
        /// Get all objects.<typeparamref name="T"/></returns>
        /// </summary>
        /// <returns>List of <typeparamref name="T"/></returns>
        /// <exception cref="System.Exception">Throws Activity exception.</exception>
        protected List<T> GetAll()
        {
            return BaseInfoProvider<List<T>>.ExecuteOperation(_url, HttpMethod.GET, _username, _password, jsonRoot: "data");
        }

        protected async Task<List<T>> GetAllAsync()
        {
            ActivitiRESTClient<T> client = new ActivitiRESTClient<T>(_url, HttpMethod.GET);
            Response<T> response = await client.GetAsync(_username, _password);

            JObject jsonResponse = JObject.Parse(response.Body);

            return JsonConvert.DeserializeObject<List<T>>(
                                                jsonResponse.SelectToken("data").ToString());
        }


        protected T Get(string id)
        {
            string url = string.Concat(_url, "/", id);

            return ExecuteOperation(url, HttpMethod.GET, _username, _password);
        }

        protected bool TryDelete(string id, out T responseObject)
        {
            var client = new ActivitiRESTClient<T>(string.Concat(_url, "/", id), HttpMethod.DELETE);

            Response<T> response = client.Delete(_username, _password);
            int status = (int)response.StatusCode;

            responseObject = JsonConvert.DeserializeObject<T>(response.Body);

            return status >= 200 && status < 300;
        }

        protected T Delete(string id)
        {
            string url = string.Concat(_url, "/", id);

            return ExecuteOperation(url, HttpMethod.DELETE, _username, _password);
        }

        protected T Update(string id, T value)
        {
            string url = string.Concat(_url, "/", id);

            return ExecuteOperation(url, HttpMethod.PUT, _username, _password);
        }

        protected T Create(T value)
        {
            return ExecuteOperation(string.Concat(_url), HttpMethod.POST,_username, _password, JsonConvert.SerializeObject(value));
        }

        protected static T ExecuteOperation(string url, HttpMethod method, string username, string password, string body = "", string jsonRoot = "")
        {
            ActivitiRESTClient<T> client = InitClient(url, method, body);
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


    }
}
