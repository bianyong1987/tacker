using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;
using tracker.BLL;
using tracker.Common;
using tracker.Models;
using tracker.WebApi.App_Start;
using tracker.WebApi.Models;

namespace tracker.WebApi.Controllers
{
    [RequestAuthorize]
    public class AppNameManageController : ApiController
    {
        AppNameManageBLL amBLL = new AppNameManageBLL();
        CountryManageBLL cmBLL = new CountryManageBLL();
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="selectWord"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public result<List<appName>> getAll(string selectWord, string pageSize, string currentPage, string token)
        {
            result<List<appName>> res = new result<List<appName>>();
            List<appName> list = new List<appName>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", list);
                return res;
            }
            returnVal r = amBLL.GetAll(selectWord, pageSize, currentPage, user);
            res.setResult("000", r.count.ToString(), r.list);
            return res;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="name"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public result<List<appName>> searchAppNames(string name, string token)
        {
            result<List<appName>> res = new result<List<appName>>();
            List<appName> list = new List<appName>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", list);
                return res;
            }
            list = amBLL.SearchAppNames(name, user);
            res.setResult("000", "", list);
            return res;
        }
        /// <summary>
        /// 根据id获取appname
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public result<appName> getAppNameById(string id)
        {
            result<appName> res = new result<appName>();
            appName appname = amBLL.GetAppNameById(id);
            res.setResult("000", "", appname);
            return res;
        }
        /// <summary>
        /// 根据countryid获取appname
        /// </summary>
        /// <param name="token"></param>
        /// <param name="countryid"></param>
        /// <returns></returns>
        [HttpGet]
        public result<List<appName>> getAppNameByUserid(string token, string countryid)
        {
            result<List<appName>> res = new result<List<appName>>();
            List<appName> appnames = new List<appName>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", appnames);
                return res;
            }
            country country = cmBLL.Getcountry();
            if (country == null)
            {
                return new result<List<appName>>()
                {
                    code = "100",
                    msg = "",
                    data = null
                };
            }
            appnames = amBLL.GetAppNameByUserid(countryid);
            res.setResult("000", "", appnames);
            return res;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="job"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public result<string> addAppName([FromBody] JObject job, string token)
        {
            result<string> res = new result<string>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", "");
                return res;
            }
            if (job == null)
            {
                res.setResult("100", "invalid parameter", "");
                return res;
            }
            string name = job["val"].ToString();
            string pkg_name = job["pkg_name"].ToString();
            string pkg_id = job["pkg_id"].ToString();
            int sourceID = int.Parse(job["sourceID"].ToString());
            List<appName> appnames = amBLL.GetAppNameByName(name);
            if (appnames.Count != 0)
            {
                res.setResult("100", "this appName/'name has already exisited!", "");
                return res;
            }
            string countryId = job["countryId"].ToString();
            var s = amBLL.AddAppName(name, pkg_name, pkg_id, sourceID, countryId, user);
            res.setResult(s, "", "");
            return res;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public result<string> updateAppName([FromBody] JObject job)
        {
            result<string> res = new result<string>();
            if (job == null)
            {
                res.setResult("100", "invalid parameter", "");
                return res;
            }
            int id = int.Parse(job["id"].ToString());
            string val = job["val"].ToString();
            string countryId = job["countryId"].ToString();
            string pkg_name = job["pkg_name"].ToString();
            string pkg_id = job["pkg_id"].ToString();
            string sourceID = job["sourceID"].ToString();
            List<appName> appnames = amBLL.GetAppNameByIdVal(id, val);
            if (appnames.Count != 0)
            {
                res.setResult("100", "this appName'name has already exisited!", "");
                return res;
            }
            var s = amBLL.UpdateAppName(id, val, countryId, pkg_name, pkg_id, sourceID);
            res.setResult(s, "", "");
            return res;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public result<string> deleteAppNameById([FromBody] JObject job)
        {
            result<string> res = new result<string>();
            if (job == null)
            {
                res.setResult("100", "invalid parameter", "");
                return res;
            }
            int id = int.Parse(job["id"].ToString());
            var s = amBLL.DeleteAppNameById(id);
            res.setResult(s, "", "");
            return res;
        }
       
    }
}
