using MVC5Template.Json;
using System;
using System.Web.Http;

namespace MVC5Template.Controllers
{
    public class ConvertController : DefaultApiController
    {
        public string GetSerializeObject([FromUri]string className)
        {
            try
            {
                return JsonManager<object>.SerializeObject(Activator.CreateInstance(Type.GetType(className)));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
