using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using DM.Specs.Services.Implementation;

namespace DM.Specs.Services.Interfaces
{
    public interface IHttpRequest
    {
        HttpRequestHelper SetResourse(string resource);
        HttpRequestHelper SetMethod(HttpMethod method);
        HttpRequestHelper AddHeaders(IDictionary<string, string> headers);
        HttpRequestHelper AddJsonContent(object data);
        HttpResponseObject Execute();
        HttpResponseObject Authenticate();
        T Execute<T>();
    }
}
