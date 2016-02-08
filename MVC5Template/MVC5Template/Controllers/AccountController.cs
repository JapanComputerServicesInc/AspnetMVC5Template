using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MVC5Template.Models;
using System.Web.SessionState;

namespace MVC5Template.Controllers
{
    public class AccountController : DefaultController
    {
        public AccountController() : base("AccountController")
        {
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            logger.Debug("Test");
            IEnumerable<User> result = DapperManager.Select<User>("MVC5TemplateServer",
                "SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password",
                new { UserID = model.UserID, Password = model.Password });
            if (result.Count() != 0)
            {
                FormsAuthentication.RedirectFromLoginPage(model.UserID, false);
                //FormsAuthentication.SetAuthCookie(model.UserID, false);
                return this.Redirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(
                    "Login_Error", HttpContext.GetGlobalResourceObject("ResourceError", "Login_LoginError_ErrorMessage").ToString());
                return View(model);
            }
        }

        //
        // POST: /User/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return this.Redirect("/");
        }

        public ActionResult List()
        {
            IEnumerable<User> result = DapperManager.Select<User>(
                "MVC5TemplateServer",
                "SELECT * FROM [dbo].[User]");

            return View(result);
        }

        public ActionResult Create([Bind(Include = "UserID,Password,FamilyName,FirstName,Birthday,Sex,MobilePhone,PostalCode,Prefectures,City,Address1,Address2,Apartment")] User user)
        {
            int result = DapperManager.Insert(
                "MVC5TemplateServer",
                "INSERT [dbo].[User] VALUES (UserID, Password, FamilyName, FirstName, Birthday, Sex, MobilePhone, PostalCode, Prefectures, City, Address1, Address2, Apartment)", user);

            return View();
        }

        public ActionResult Detail(int id)
        {
            IEnumerable<User> user = DapperManager.Select<User>("MVC5TemplateServer",
    "SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID",
    new { UserID = id });

            return View(user.FirstOrDefault());
        }

        public ActionResult Delete(int id)
        {
            int result = DapperManager.Insert(
                "MVC5TemplateServer",
                "INSERT [dbo].[User] VALUES (UserID, Password, FamilyName, FirstName, Birthday, Sex, MobilePhone, PostalCode, Prefectures, City, Address1, Address2, Apartment)", new { UserID = id });
            return View();
        }

        public ActionResult Edit(string id)
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            User user = DapperManager.Select<User>("MVC5TemplateServer",
                "SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID",
                new { UserID = id }).FirstOrDefault();

            return View(user);
        }

        public ActionResult Edit([Bind(Include = "UserID,Password,FamilyName,FirstName,Birthday,Sex,MobilePhone,PostalCode,Prefectures,City,Address1,Address2,Apartment")] User user)
        {
            int result = DapperManager.Update("MVC5TemplateServer", "UPDATE [dbo].[User] SET Password = @Password, FamilyName = @FamilyName, FirstName = @FirstName, Birthday = @Birthday, Sex = @Sex, MobilePhone = @MobilePhone, PostalCode = @PostalCode, Prefectures = @Prefectures, City = @City, Address1 = @Address1, Address2 = @Address2, Apartment = @Apartment", user);
            return View();
        }
    }
}