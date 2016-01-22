using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVC5Template.Models
{
    public class LoginViewModel
    {
        [Required(
            ErrorMessageResourceName = "Login_UserID_ErrorMessage_Required",
            ErrorMessageResourceType = typeof(MVC5Template.App_GlobalResources.ResourceError))]
        [RegularExpression(
            "[0-9]+",
            ErrorMessageResourceName = "Login_UserID_ErrorMessage_RegularExpression",
            ErrorMessageResourceType = typeof(MVC5Template.App_GlobalResources.ResourceError))]
        public string UserID { get; set; }

        [Required(
            ErrorMessageResourceName = "Login_Password_ErrorMessage_Required",
            ErrorMessageResourceType = typeof(MVC5Template.App_GlobalResources.ResourceError))]
        public string Password { get; set; }
    }
}
