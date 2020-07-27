using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    /// <summary>
    /// Web API Controller is similar to ASP.NET MVC controller. It handles incoming HTTP requests and send response back to the caller
    /// Must be derived from System.Web.Http.ApiController class.
    /// Based on the incoming request URL and HTTP verb(GET/POST/PUT/PATCH/DELETE),
    /// Web API decides which Web API controller and action method to execute
    /// </summary>

    /// <summary>
    ///Get() method will handle HTTP GET request
    ///Post() method will handle HTTP POST request
    ///Put() mehtod will handle HTTP PUT request
    ///Delete() method will handle HTTP DELETE request
    /// </summary>


    /// <summary>
    ///Action method name can be the same as HTTP verb name or it can start with HTTP verb with any suffix(case in-sensitive)
    ///or you can apply Http verb attributes to method.
    /// </summary>

    /// <summary>
    ///By default, if parameter type is of.NET primitive type such as int, bool, double, string, GUID, DateTime,
    ///decimal or any other type that can be converted from string type then it sets the value of a parameter from the query string.
    ///And if the parameter type is complex type then Web API tries to get the value from request body by default.
    /// </summary>

    /// <summary>
    ///[FromUri]  for query string and [FromBody] for body 
    /// </summary>


    /// <summary>
    ///The Web API action method can have following return types.
    ///1-Void
    ///2-Primitive type or Complex type
    ///3-HttpResponseMessage
    ///4-IHttpActionResult
    /// </summary>

    /// <summary>
    ///The Accept header attribute specifies the format of response data which the client expects
    ///and the Content-Type header attribute specifies the format of the data in the request body
    ///so that receiver can parse it into appropriate format.
    /// </summary>



    public class DemoController : ApiController
    {
        private ApplicationContext _applicationContext;
        public DemoController()
        {
            _applicationContext = new ApplicationContext();
        }
        public IHttpActionResult Get()
        {
            var users = _applicationContext.Users.ToList();
            if(users!=null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound();

            }

        }

        public IHttpActionResult Get(int id)
        {
            var user = _applicationContext.Users.FirstOrDefault(x=>x.UserId== id);
            if(user!=null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post(User user)
        {
            if (ModelState.IsValid)
            {
              var _user=   _applicationContext.Users.Add(user);
                _applicationContext.SaveChanges();
                return Ok(_user);
            }
            else
            {
                return BadRequest("Invalid Data");
            }
        }


        public IHttpActionResult put(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid Data");
            }
            else
            {
                var _user = _applicationContext.Users.FirstOrDefault(x => x.UserId == id);
                if(_user==null)
                {
                    return NotFound();
                }
                else
                {
                    _user.FirstName = user.FirstName;
                    _user.LastName = user.LastName;
                    _user.Gender = user.Gender;
                    _user.Salary = user.Salary;
                    _applicationContext.Entry(_user).State = EntityState.Modified;
                    _applicationContext.SaveChanges();
                    return Ok(_user);
                }
            }
        }


        public IHttpActionResult delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a Valid Id");
            }
            var _user = _applicationContext.Users.FirstOrDefault(x => x.UserId == id);
            _applicationContext.Users.Remove(_user);
            return Ok();
        }
    }
}
