﻿using System;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActivitiDotNet.Network.Model
{
    internal class Response<T>
    { 
        private int _statusCode;
        private object _responseData;
        private object _responseHeaders;

        public HttpStatusCode StatusCode
        {
            get;  set;
        }

        public string Body
        {
            get;  set;
        }

        public object Headers
        {
            get;set;
        }

        public Exception Exception
        {
            get;set;
        }

        public T ParseResponse(string root = "")
        {
            if (this.Exception == null)
            {
                if (!string.IsNullOrEmpty(root))
                {
                    JObject json = new JObject();
                    T retvalue = default(T);

                    try
                    {
                        json = JObject.Parse(this.Body);
                    }
                    catch { }

                    if(json.SelectToken(root)  != null)
                        retvalue = JsonConvert.DeserializeObject<T>(json.SelectToken(root).ToString());

                    return retvalue;
                }
                else
                {
                    return JsonConvert.DeserializeObject<T>(this.Body);
                }
            }
            else
            {
                throw this.Exception;
            }
        }
    }
}
