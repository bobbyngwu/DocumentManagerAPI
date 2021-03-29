using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using DM.Specs.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace DM.Specs.Services.Implementation
{
    public class HttpRequestHelper : IHttpRequest
    {
        private RestRequest _restRequest;
        private RestClient _restClient;


        public HttpRequestHelper(IEnvironmentSetting environmentSetting)
        {
            _restRequest = new RestRequest();
            _restClient = new RestClient(environmentSetting?.GetEnvironmentSettings()?.BaseUrl);
        }

        public HttpRequestHelper SetResourse(string resource)
        {
            _restRequest.Resource = resource;
            return this;
        }

        public HttpRequestHelper SetMethod(HttpMethod method)
        {
            switch (method.ToString())
            {
                case "DELETE":
                    _restRequest.Method = Method.DELETE;
                    break;
                case "POST":
                    _restRequest.Method = Method.POST;
                    break;
                case "GET":
                    _restRequest.Method = Method.GET;
                    break;
                case "PUT":
                    _restRequest.Method = Method.PUT;
                    break;
                default:
                    _restRequest.Method = Method.GET;
                    break;
            }
           ;
            return this;
        }

        public HttpRequestHelper AddHeaders(IDictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                _restRequest.AddParameter(header.Key, header.Value, ParameterType.HttpHeader);
            }
            return this;
        }

        public HttpRequestHelper AddJsonContent(object data)
        {
            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddHeader("Content-Type", "application/json");
            _restRequest.AddJsonBody(data);
            return this;
        }

        public HttpRequestHelper AddEtagHeader(string value)
        {
            _restRequest.AddHeader("If-None-Match", value);
            return this;
        }


        public HttpRequestHelper AddParameter(string name, object value)
        {
            _restRequest.AddParameter(name, value);
            return this;
        }

        public HttpRequestHelper AddParameters(IDictionary<string, object> parameters)
        {
            foreach (var item in parameters)
            {
                _restRequest.AddParameter(item.Key, item.Value);
            }
            return this;
        }

        public HttpResponseObject Execute()
        {
            try
            {
                var response = _restClient.Execute(_restRequest);
                return new HttpResponseObject() { Content = response.Content, StatusCode = response.StatusCode };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public T Execute<T>()
        {
            var response = _restClient.Execute(_restRequest);
            var data = JsonConvert.DeserializeObject<T>(response.Content);
            return data;
        }

        public HttpResponseObject Authenticate()
        {
            throw new NotImplementedException();
        }

    }
}
