using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web_Api.Controllers
{
    //Web API Controller is similar to ASP.NET MVC controller. It handles incoming HTTP requests and send response back to the caller
    //Must be derived from System.Web.Http.ApiController class.
    //Based on the incoming request URL and HTTP verb (GET/POST/PUT/PATCH/DELETE),
    //Web API decides which Web API controller and action method to execute

    //Get() method will handle HTTP GET request
    //Post() method will handle HTTP POST request
    //Put() mehtod will handle HTTP PUT request
    //Delete() method will handle HTTP DELETE request


    //Action method name can be the same as HTTP verb name or it can start with HTTP verb with any suffix(case in-sensitive)
    //or you can apply Http verb attributes to method.


    public class DemoController : ApiController
    {
        public string Get()
        {
            return "Welcome To Web API";
        }
    }
}
