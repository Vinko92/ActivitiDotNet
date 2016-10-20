namespace ActivitiDotNet.Network
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using Helpers;
    using Model;

    internal class ActivitiRESTClient<T> where T : class
    {
        private string _url;
        private string _body;
        private HttpWebRequest _request;
        private HttpMethod _method;

        public HttpMethod Method
        {
            get
            {
                return _method;
            }
            set
            {
                _method = value;
            }
        }

        public ActivitiRESTClient(string url)
        {
            _request = WebRequest.Create(url) as HttpWebRequest;
            _url = url;
        }

        public ActivitiRESTClient(string url, HttpMethod method)
        {
            _request = WebRequest.Create(url) as HttpWebRequest;
            _request.Method = method.ToString();
        }

        public ActivitiRESTClient(string url, HttpMethod method, string body)
        {
            _request = WebRequest.Create(url) as HttpWebRequest;
            _request.Method = method.ToString();
            _request.ContentType = "application/json";
            _body = body;
            _url = url;
        }

        public async Task<Response<T>> GetAsync(string username, string password)
        {
            AddAuthorizationHeader(username, password);
            RequestExecutor<T> executor = new RequestExecutor<T>();

            return await executor.ExecuteAsync(_request);
        }

        public Response<T> Get(string username, string password)
        {
            return GetAsync(username, password).GetAwaiter().GetResult();
        }

        public Response<T> Post(string username, string password)
        {
            RequestExecutor<T> executor = new RequestExecutor<T>();

            AddAuthorizationHeader(username, password);

            using (var reqestStream = new StreamWriter(_request.GetRequestStream()))
            {
                reqestStream.Write(_body);
            }

            return executor.Execute(_request);

        }

        public string GetString(string username, string password)
        {
            string result = string.Empty;
            int statusCode = (int)GetData(username, password, out result);

            if (statusCode >= 200 && statusCode < 300)
            {
                return result;
            }

            return string.Empty;
        }

        public HttpStatusCode GetData(string username, string password, out string data)
        {
            data = string.Empty;
            HttpStatusCode statusCode = HttpStatusCode.OK;
            HttpWebRequest request = WebRequest.Create(_url) as HttpWebRequest;

            // Set up the request properties.
            request.Method = _method.ToString();

            //Authetnicate
            string base64 = string.Format("{0}:{1}", username, password).ToBase64();
            request.Headers.Add("Authorization", string.Format("Basic {0}", base64));

            try
            {
                var response = request.GetResponse() as HttpWebResponse;

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    data = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return statusCode;
        }

        public HttpStatusCode PostFile(string path, string fileName, string username, string password)
        {
            MultipartHelper.FileParameter f = new MultipartHelper.FileParameter(File.ReadAllBytes(path), fileName, "multipart/form-data");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("loanRequest", f);

            return MultipartHelper.MultipartFormDataPost(_url, parameters, username, password).StatusCode;
        }

        public async Task<Response<T>> DeleteAsync(string username, string password)
        {
            RequestExecutor<T> executor = new RequestExecutor<T>();
            AddAuthorizationHeader(username, password);
            return await executor.ExecuteAsync(_request);
        }

        public Response<T> Delete(string username, string password)
        {
            return DeleteAsync(username, password).GetAwaiter().GetResult();
        }

        public HttpStatusCode DeleteData(string username, string password)
        {
            HttpStatusCode statusCode = HttpStatusCode.OK;
            HttpWebRequest request = WebRequest.Create(_url) as HttpWebRequest;

            // Set up the request properties.
            request.Method = _method.ToString();

            try
            {
                var response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException webException)
            {
                statusCode = ((HttpWebResponse)webException.Response).StatusCode;
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }

            return statusCode;
        }

        public void AddAuthorizationHeader(string username, string password)
        {
            //Authetnicate
            string base64 = string.Format("{0}:{1}", username, password).ToBase64();
            _request.Headers.Add("Authorization", string.Format("Basic {0}", base64));
        }
    }
}
