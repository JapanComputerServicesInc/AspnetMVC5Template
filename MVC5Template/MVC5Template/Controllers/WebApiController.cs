using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC5Template.Controllers
{
    public class WebApiController : ApiController
    {
        [HttpGet]
        public string GetUser()
        {
            return "";
        }

        [HttpGet]
        public string GetUser(int id)
        {
            return "";
        }

        [HttpPost]
        public string PostUser(int id)
        {
            return "";
        }

        [HttpPut]
        public void PutUser()
        {

        }

        [HttpDelete]
        public void DeleteUser()
        {

        } 
    }
}
