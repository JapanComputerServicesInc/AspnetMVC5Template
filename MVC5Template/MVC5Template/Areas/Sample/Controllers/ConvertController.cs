using MVC5Template.Extension;
using System;
using System.Web.Http;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class ConvertController : SupportApiController
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
