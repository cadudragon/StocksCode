using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace StocksCode.Common.Helpers
{
    /// <summary>
    /// Helper to create HttpResponses outside controllers.
    /// </summary>
    public class HttpResponseHelper
    {

        public object ObjectResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public HttpResponseHelper(HttpStatusCode statusCode)
        {
            ObjectResponse = new { title = Enum.GetName(typeof(HttpStatusCode), statusCode) };
            StatusCode = statusCode;
        }

        public HttpResponseHelper(string message, HttpStatusCode statusCode)
        {
            ObjectResponse = new { title = message };
            StatusCode = statusCode;
        }

        public HttpResponseHelper(object obj, HttpStatusCode statusCode)
        {
            ObjectResponse = obj;
            StatusCode = statusCode;
        }

        public ObjectResult GetObjectResult()
        {
            ObjectResult result = new ObjectResult(ObjectResponse)
            {
                StatusCode = (int?)StatusCode
            };

            return result;
        }
    }
}
