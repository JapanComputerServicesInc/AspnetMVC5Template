using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Template.App_Code
{
    public class DefaultContllor : Controller
    {
        /// <summary>
        /// Cookieを設定する
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetCookie(string key, string value)
        {
            Response.AppendCookie(new HttpCookie(key)
            {
                Value = value,
                Expires = DateTime.Now .AddDays(7),
                HttpOnly = true
            });
        }
        /// <summary>
        /// Cookieを取得する
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCookie(string key)
        {
            return Request.Cookies[key].Value;
        }

        /// <summary>
        /// セッションを設定する
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetSession(string key, object value)
        {
            Session[key] = value;           
        }

        /// <summary>
        /// セッションを取得する
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetSession(string key)
        {
            return Session[key];   
        }
    }
}