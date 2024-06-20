using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;


namespace CacheService_.Controllers.Errors
{
    public class ServerError
    {
        public string? Message { get; set; }
        
        public static ActionResult InternalServerError(string message)
        {
            var serverError = new ServerError { Message = message };
            var json = JsonConvert.SerializeObject(serverError);

            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
