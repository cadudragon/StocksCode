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
        public HttpResponseHelper()
        {

        }

        public HttpResponseHelper(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }


        public HttpResponseHelper(object obj, HttpStatusCode statusCode)
        {
            Message = JsonConvert.SerializeObject(obj);
            StatusCode = statusCode;
        }

        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ObjectResult GetObjectResult()
        {
            ObjectResult result = new ObjectResult(Message)
            {
                StatusCode = (int?)StatusCode
            };

            return result;
        }
    }
}
