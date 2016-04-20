using MVC5Template.Dapper;
using MVC5Template.Extensions;
using MVC5Template.Areas.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Template.Models;
using System.Net;

namespace MVC5Template.Areas.Sample.Controllers
{
    public class BulletinBoardController : Controller
    {
        // GET: Sample/BulletinBoard
        public ActionResult Index()
        {
            BulletinBoardModel model = new BulletinBoardModel();
            IEnumerable<TopicTable> topics = DapperManager.Query<TopicTable>( 
                "MVC5TemplateServer",
                "SELECT TopicId,Title,Detail,InsertUserId,InsertDate,FamilyName+FirstName as UserName FROM [dbo].[TopicTable] inner join [User] on InsertUserId = UserID");

            model.Topics = topics;
            return View(model);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                BulletinBoardModel model = new BulletinBoardModel();
                IEnumerable<TopicTable> topics = DapperManager.Query<TopicTable>(
                    "MVC5TemplateServer",
                    "SELECT TopicId,Title,Detail,InsertUserId,InsertDate,FamilyName+FirstName as UserName FROM [dbo].[TopicTable] inner join [User] on InsertUserId = UserID where TopicId = @TopicId", new { TopicId = id });

                IEnumerable<CommentTable> comments = DapperManager.Query<CommentTable>(
                    "MVC5TemplateServer",
                    "SELECT TopicId,No,Comment,InsertUserId,InsertDate,FamilyName+FirstName as UserName FROM [dbo].[CommentTable] inner join [User] on InsertUserId = UserID where TopicId = @TopicId order by No", new { TopicId = id });

                model.Topics = topics;
                model.Comments = comments;

                if (topics == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(string id, string comment, int userid)
        {
            if (ModelState.IsValid)
            {
                int result = DapperManager.Execute(
                    "MVC5TemplateServer",
                    "INSERT INTO CommentTable values(@TopicId, (select ISNULL(MAX(No), 0) + 1 from CommentTable where TopicId = @TopicId), @Comment, @InsertUserId, GETDATE())", new
                    {
                        TopicId = id,
                        Comment = comment,
                        InsertUserId = userid
                    });

                return RedirectToAction("Detail");
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string sTitle,string sDetail, int userid)
        {
            if (ModelState.IsValid)
            {
                int result = DapperManager.Execute(
                    "MVC5TemplateServer",
                    "INSERT INTO TopicTable values((select ISNULL(MAX(TopicId),1000) +1 from TopicTable), @Title, @Detail, @InsertUserId, GETDATE())", new
                    {
                        Title = sTitle,
                        Detail = sDetail,
                        InsertUserId = userid
                    });

                return RedirectToAction("Index");
            }
            return View();
        }


    }
}