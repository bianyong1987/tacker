using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using tracker.Models;

namespace tracker.Common
{
    public class ExplainToken
    {
        public string token { get; set; }
        public static user getUserByToken(string token)
        {
            var strTicket = FormsAuthentication.Decrypt(token).UserData;
            var index = strTicket.IndexOf("&");
            string strUser = strTicket.Substring(0, index);
            string strPwd = strTicket.Substring(index + 1);

            using (tracker2Entities db = new tracker2Entities())
            {
                user u = db.user.Where(e => e.isDeleted == 0 & e.name == strUser & e.password == strPwd).FirstOrDefault();
                return u;
            }
        }
    }
}
