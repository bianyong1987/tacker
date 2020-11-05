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
    public class SiteDomainManageController : ApiController
    {
        SiteDomainManageBLL sdmBLL = new SiteDomainManageBLL();
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
        public result<List<siteDomain>> getAll(string selectWord, string pageSize, string currentPage, string token)
        {
            result<List<siteDomain>> res = new result<List<siteDomain>>();
            List<siteDomain> list = new List<siteDomain>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", list);
                return res;
            }
            returnSiteDomain r = sdmBLL.GetAll(selectWord, pageSize, currentPage, user);
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
        public result<List<siteDomain>> searchSiteDomains(string name, string token)
        {
            result<List<siteDomain>> res = new result<List<siteDomain>>();
            List<siteDomain> list = new List<siteDomain>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", list);
                return res;
            }
            list = sdmBLL.SearchSiteDomains(name, user);
            res.setResult("000", "", list);
            return res;
        }
        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public result<siteDomain> getSiteDomainById(string id)
        {
            result<siteDomain> res = new result<siteDomain>();
            var siteDomain = sdmBLL.GetSiteDomainById(id);
            res.setResult("000", "", siteDomain);
            return res;
        }
        /// <summary>
        /// 根据countryid获取SiteDomain
        /// </summary>
        /// <param name="token"></param>
        /// <param name="countryid"></param>
        /// <returns></returns>
        [HttpGet]
        public result<List<siteDomain>> getSiteDomainByUserid(string token, string countryid)
        {
            result<List<siteDomain>> res = new result<List<siteDomain>>();
            List<siteDomain> sitedomains = new List<siteDomain>();
            user user = ExplainToken.getUserByToken(token);
            if (user == null)
            {
                res.setResult("100", "权限出错", sitedomains);
                return res;
            }
            country country = cmBLL.Getcountry();
            if (country == null)
            {
                return new result<List<siteDomain>>()
                {
                    code = "100",
                    msg = "",
                    data = null
                };
            }
            sitedomains = sdmBLL.GetSiteDomainByUserid(countryid);
            res.setResult("000", "", sitedomains);
            return res;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="job"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPut]
        public result<string> addSiteDomain([FromBody] JObject job, string token)
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
            List<siteDomain> list = sdmBLL.GetSiteDomainByName(name);
            if (list.Count != 0)
            {
                res.setResult("100", "this siteDomain/'name has already exisited!", "");
                return res;
            }
            string countryId = job["countryId"].ToString();
            var s = sdmBLL.AddSiteDomain(name, countryId, user, sourceID);
            res.setResult(s, "", "");
            return res;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public result<string> updateSiteDomain([FromBody] JObject job)
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
            List<siteDomain> sitedomains = sdmBLL.GetSiteDomainByValNotID(val, id); ;
            if (sitedomains.Count != 0)
            {
                res.setResult("100", "this siteDomain'name has already exisited!", "");
                return res;
            }
            var s = sdmBLL.UpdateSiteDomain(id, val, countryId, sourceID);
            res.setResult(s, "", "");
            return res;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public result<string> deleteSiteDomainById([FromBody] JObject job)
        {
            result<string> res = new result<string>();
            if (job == null)
            {
                res.setResult("100", "invalid parameter", "");
                return res;
            }
            int i = int.Parse(job["id"].ToString());
            var s = sdmBLL.DeleteSiteDomainById(i);
            res.setResult(s, "", "");
            return res;
        }
    }
}
