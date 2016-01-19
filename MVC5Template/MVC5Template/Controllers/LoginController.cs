using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MVC5Template.Models;

namespace MVC5Template.Controllers
{
    // このコントローラは認証いらない
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ReturnUrl = "/Login/Login";
            return View();
        }

        // GET: Login
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            string UserID = "999999";
            DapperSample<User> dapper = new DapperSample<User>("MVC5TemplateServer");
            dynamic result = dapper.Select("SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID", new { UserID = UserID });
            if (result.Count != 0)
            {
                View();
            }
            else
            {
                View("Login");
            }

            //var userManager = new ApplicationUserManager(new ApplicationUserStore());
            //userManager.PasswordHasher = new PasswordHasher();

            //var user = await userManager.FindAsync(model.UserName, model.Password);
            //if (user != null)
            //{
            //    var authentication = this.HttpContext.GetOwinContext().Authentication;
            //    var identify = await userManager.CreateIdentityAsync(
            //        user,
            //        DefaultAuthenticationTypes.ApplicationCookie);
            //    authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            //    authentication.SignIn(new AuthenticationProperties() { IsPersistent = false }, identify);

            //    return Redirect(returnUrl);
            //}
            //else
            //{
            //    ModelState.AddModelError("", "ログインIDまたはパスワードが無効です。");
            //}
            return View("Menu");
        }
    }
}