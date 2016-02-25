using MVC5Template.Dapper;
using MVC5Template.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC5Template.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
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
    }
}