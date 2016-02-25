using MVC5Template.Dapper;
using MVC5Template.Extension;
using MVC5Template.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MVC5Template.Areas.Site.Controllers
{
    public class UserController : SupportApiController
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
