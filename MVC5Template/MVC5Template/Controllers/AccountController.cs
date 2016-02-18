using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using MVC5Template.Models;
using System.Web.SessionState;
using System.Net;

namespace MVC5Template.Controllers
{
    public class AccountController : DefaultController
    {
        public AccountController() : base("AccountController")
        {
        }

        public ActionResult Index()
        {
            IEnumerable<User> result = DapperManager.Query<User>(
                "MVC5TemplateServer",
                "SELECT * FROM [dbo].[User]");

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Password,FamilyName,FirstName,Birthday,Sex,MobilePhone,PostalCode,Prefectures,City,Address1,Address2,Apartment")] User user)
        {
            if (ModelState.IsValid)
            {
                int result = DapperManager.Execute(
                    "MVC5TemplateServer",
                    "INSERT [dbo].[User] (UserID, Password, FamilyName, FirstName, Birthday, Sex, MobilePhone, PostalCode, Prefectures, City, Address1, Address2, Apartment) VALUES (@UserID, @Password, @FamilyName, @FirstName, @Birthday, @Sex, @MobilePhone, @PostalCode, @Prefectures, @City, @Address1, @Address2, @Apartment)", user);

                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                IEnumerable<User> user = DapperManager.Query<User>("MVC5TemplateServer", "SELECT * FROM [dbo].[User] WHERE UserID = @UserID", new { UserID = id });
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user.FirstOrDefault());
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = DapperManager.Query<User>("MVC5TemplateServer",
            "SELECT * FROM [dbo].[User] WHERE UserID = @UserID",
            new { UserID = id }).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int result = DapperManager.Execute(
                "MVC5TemplateServer",
                "DELETE FROM [dbo].[User] WHERE UserID = @UserID", new { UserID = id });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = DapperManager.Query<User>("MVC5TemplateServer",
                "SELECT * FROM [dbo].[User] WHERE UserID = @UserID",
                new { UserID = id }).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Password,FamilyName,FirstName,Birthday,Sex,MobilePhone,PostalCode,Prefectures,City,Address1,Address2,Apartment")] User user)
        {
            if (ModelState.IsValid)
            {
                int result = DapperManager.Execute("MVC5TemplateServer", "UPDATE [dbo].[User] SET Password = @Password, FamilyName = @FamilyName, FirstName = @FirstName, Birthday = @Birthday, Sex = @Sex, MobilePhone = @MobilePhone, PostalCode = @PostalCode, Prefectures = @Prefectures, City = @City, Address1 = @Address1, Address2 = @Address2, Apartment = @Apartment WHERE UserID = @UserID", user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<User> result = DapperManager.Query<User>("MVC5TemplateServer",
                    "SELECT UserID FROM [dbo].[User] WHERE UserID = @UserID AND Password = @Password",
                    new { UserID = model.UserID, Password = model.Password });
                if (result.Count() != 0)
                {
                    FormsAuthentication.RedirectFromLoginPage(model.UserID, false);
                    //FormsAuthentication.SetAuthCookie(model.UserID, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        return this.Redirect(returnUrl);
                    return RedirectToAction(string.Empty, "Home");
                }
                else
                {
                    ModelState.AddModelError(
                        "Login_Error", HttpContext.GetGlobalResourceObject("ResourceError", "Login_LoginError_ErrorMessage").ToString());
                }
            }
            return View(model);
        }

        //
        // POST: /User/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            
            return this.Redirect("/");
        }
    }
}