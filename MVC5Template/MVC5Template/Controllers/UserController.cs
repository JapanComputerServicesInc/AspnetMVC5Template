using MVC5Template.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC5Template.Controllers
{
    public class UserController : DefaultApiController
    {
        // GET: api/User
        public IEnumerable<User> Get()
        {
            return DapperManager.Query<User>("MVC5TemplateServer", "SELECT * FROM [dbo].[User]");
        }

        // GET: api/User/5
        public IEnumerable<User> Get(int id)
        {
            return DapperManager.Query<User>("MVC5TemplateServer", "SELECT * FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password", new { UserID = id });
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put([FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
