using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using tracker.Models;

namespace tracker.WebApi.App_Start
{
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {//重写基类的验证方式，加入我们自定义的Ticket验证
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            tracker2Entities db = new tracker2Entities();

            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            //var authorization = actionContext.Request.Headers.Authorization;

            string query = actionContext.Request.RequestUri.Query;
            if (!query.StartsWith("?"))
            {
                HandleUnauthorizedRequest(actionContext);
                return;
            }
            string tmp_a = query.Substring(1, query.Length - 1);
            string[] tmp_list = tmp_a.Split('&');
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            for (int i = 0; i < tmp_list.Count(); i++)
            {
                string[] tmp_list2 = tmp_list[i].Split('=');
                dictionary.Add(tmp_list2[0], tmp_list2[1]);
            }
            string token = dictionary["token"];


            //if ((authorization != null) && (authorization.Parameter != null))
            //{
            //解密用户ticket,并校验用户名密码是否匹配
            //var encryptTicket = authorization.Parameter;
            if (ValidateTicket(token))
            {
                base.IsAuthorized(actionContext);
            }
            else
            {
                HandleUnauthorizedRequest(actionContext);
            }
            //}
            ////如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            //else
            //{
            //    var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
            //    bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
            //    if (isAnonymous) base.OnAuthorization(actionContext);
            //    else HandleUnauthorizedRequest(actionContext);
            //}
        }

        //校验用户名密码（正式环境中应该是数据库校验）
        private bool ValidateTicket(string encryptTicket)
        {
            //解密Ticket
            var strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;
            var time = FormsAuthentication.Decrypt(encryptTicket).Expiration;
            //if (DateTime.Parse(time.ToString()) < DateTime.Now)
            //{
            //    return false;
            //}
            //从Ticket里面获取用户名和密码
            var index = strTicket.IndexOf("&");
            string strUser = strTicket.Substring(0, index);
            string strPwd = strTicket.Substring(index + 1);
            tracker2Entities db = new tracker2Entities();
            List<user> list = db.user.Where(e => e.name == strUser & e.password == strPwd).ToList();

            if (list.Count > 0)
            {
                if (list[0].ticket != encryptTicket)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
            //if (strUser == "admin" && strPwd == "123456")
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}