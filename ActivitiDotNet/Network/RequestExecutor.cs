using System;
using System.Net;
using System.Threading.Tasks;

using ActivitiDotNet.Helpers;
using ActivitiDotNet.Network.Model;

namespace ActivitiDotNet.Network
{
    internal class RequestExecutor<T>
    {
        private Response<T> _response;

        public Response<T> Execute(HttpWebRequest httpRequest)
        {
            _response = new Response<T>();

            try
            {
                var httpResponse = httpRequest.GetResponse() as HttpWebResponse;

                ParseResponse(httpResponse);
                httpResponse.Dispose();
            }
            catch (Exception ex)
            {
                _response.Exception = ex;
            }

            return _response;
        }

        public async Task<Response<T>> ExecuteAsync(HttpWebRequest httpRequest, bool isByteResponse = false)
        {
            _response = new Response<T>();

            try
            {
                var httpResponse = await httpRequest.GetResponseAsync() as HttpWebResponse;

                if (isByteResponse)
                {
                    ParseResponseBytes(httpResponse);
                }
                else
                {
                    ParseResponse(httpResponse);
                }

                httpResponse.Dispose();
            }
            catch (Exception ex)
            {
                _response.Exception = ex;
            }

            return _response;
        }

        private void ParseResponse(HttpWebResponse httpResponse)
        {
            _response.StatusCode = httpResponse.StatusCode;
            _response.Headers = httpResponse.Headers;
            _response.Body = IOHelper.ReadStream(httpResponse.GetResponseStream());
        }

        private void ParseResponseBytes(HttpWebResponse httpResponse)
        {
            _response.StatusCode = httpResponse.StatusCode;
            _response.Headers = httpResponse.Headers;
            _response.ByteData = IOHelper.ReadBytes(httpResponse.GetResponseStream());
        }
    }
}
