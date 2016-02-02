using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

namespace MVC5Template.Controllers
{
    public class DefaultController : Controller
    {
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        protected DefaultController() : base()
        {
        }

        protected string ContllorName
        {
            get { return this.RouteData.Values["controller"].ToString(); }
        }

        protected string ActionName
        {
            get { return this.RouteData.Values["action"].ToString(); }
        }

        /// <summary>
        /// Cookieを設定する
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="value">設定値</param>
        protected void SetCookie(string key, string value)
        {
            Response.AppendCookie(new HttpCookie(key)
            {
                Value = value,
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            });
        }

        /// <summary>
        /// Cookieを取得する
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns></returns>
        protected string GetCookie(string key)
        {
            return Request.Cookies[key].Value;
        }

        protected void DeleteCookieValue(string key)
        {
        }

        /// <summary>
        /// セッションを設定する
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="value">設定値</param>
        protected void SetSession(string key, object value)
        {
            Session[key] = value;
        }

        /// <summary>
        /// セッションを取得する
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns></returns>
        protected object GetSession(string key)
        {
            return Session[key];
        }

        protected void DeleteSessionValue(string key)
        {
        }

        protected void DisposeSession()
        {
        }

        /// <summary>
        /// テンポラリデータを設定する
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="value">設定値</param>
        protected void SetTempData(string key, object value)
        {
            this.TempData[key] = value;
        }

        /// <summary>
        /// テンポラリデータを取得する
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns></returns>
        protected object GetTempData(string key)
        {
            return this.TempData[key];
        }
    }
}