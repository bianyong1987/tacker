using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tracker.BLL;
using tracker.Common;
using tracker.Models;
using tracker.WebApi.App_Start;
using tracker.WebApi.Models;

namespace tracker.WebApi.Controllers
{
    [RequestAuthorize]
    public class SiteIdManageController : ApiController
    {
        SiteIdManageBLL simBLL = new SiteIdManageBLL();
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
        public result<List<siteId>> getAll(string selectWord, string pageSize, string currentPage, string token)
        {
            result<List<siteId>> res = new result<List<siteId>>();
            List<siteId> list = new List<siteId>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", list);
                return res;
            }
            var r = simBLL.GetAll(selectWord, pageSize, currentPage, user);
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
        public result<List<siteId>> searchSiteIds(string name, string token)
        {
            result<List<siteId>> res = new result<List<siteId>>();
            List<siteId> list = new List<siteId>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", list);
                return res;
            }
            list = simBLL.SearchSiteIds(name, user);
            res.setResult("000", "", list);
            return res;
        }
        /// <summary>
        /// 根据id查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public result<siteId> getSiteIdById(string id)
        {
            result<siteId> res = new result<siteId>();
            siteId siteid = simBLL.GetSiteIdById(id);
            res.setResult("000", "", siteid);
            return res;
        }
        /// <summary>
        /// 根据countryid查找
        /// </summary>
        /// <param name="token"></param>
        /// <param name="countryid"></param>
        /// <returns></returns>
        [HttpGet]
        public result<List<siteId>> getSiteIdByUserid(string token, string countryid)
        {
            result<List<siteId>> res = new result<List<siteId>>();
            List<siteId> siteids = new List<siteId>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", siteids);
                return res;
            }
            int cid = int.Parse(countryid);
            country country = cmBLL.Getcountry();
            if (country == null)
            {
                return new result<List<siteId>>()
                {
                    code = "100",
                    msg = "",
                    data = null
                };
            }
            siteids = simBLL.GetSiteIdByUserid(cid);
            res.setResult("000", "", siteids);
            return res;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="job"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public result<string> addSiteId([FromBody] JObject job, string token)
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
            int sourceID = int.Parse(job["sourceID"].ToString());
            List<siteId> list = simBLL.GetSiteIdByName(name);
            if (list.Count != 0)
            {
                res.setResult("100", "this siteId/'name has already exisited!", "");
                return res;
            }
            string countryId = job["countryId"].ToString();
            var r = simBLL.AddSiteId(name, countryId, sourceID, user);
            res.setResult(r, "", "");
            return res;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public result<string> updateSiteId([FromBody] JObject job)
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
            int sourceID = int.Parse(job["sourceID"].ToString());
            List<siteId> siteids = simBLL.GetSiteIdByValNotId(val, id);
            if (siteids.Count != 0)
            {
                res.setResult("100", "this siteId'name has already exisited!", "");
                return res;
            }
            var r = simBLL.UpdateSiteId(id, val, countryId, sourceID);
            res.setResult(r, "", "");
            return res;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public result<string> deleteSiteIdById([FromBody] JObject job)
        {
            result<string> res = new result<string>();
            if (job == null)
            {
                res.setResult("100", "invalid parameter", "");
                return res;
            }
            int id = int.Parse(job["id"].ToString());
            var r = simBLL.DeleteSiteIdById(id);
            res.setResult(r, "", "");
            return res;
        }
    }
}
