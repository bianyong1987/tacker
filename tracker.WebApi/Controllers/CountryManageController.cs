using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tracker.BLL;
using tracker.Models;
using tracker.WebApi.Models;
using Newtonsoft.Json;
using tracker.WebApi.App_Start;

namespace tracker.WebApi.Controllers
{
    [RequestAuthorize]
    public class CountryManageController : ApiController
    {
        CountryManageBLL cmBLL = new CountryManageBLL();
        /// <summary>
        /// 获取国家列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public result<List<country>> getCountrys()
        {
            List<country> list = cmBLL.GetCountrys();
            result<List<country>> res = new result<List<country>>();
            res.setResult("000", "", list);
            return res;
        }
        /// <summary>
        /// 搜索国家信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public result<List<country>> searchCountrys(string name)
        {
            List<country> list = new List<country>();
            if (string.IsNullOrWhiteSpace(name))
            {
                list = cmBLL.GetCountrys();
            }
            else
            {
                name = name.Trim();
                list = cmBLL.SearchCountrys(name);
            }
            result<List<country>> res = new result<List<country>>();
            res.setResult("000", "", list);
            return res;
        }
        /// <summary>
        /// 根据id获取国家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public result<country> getCountryById(string id)
        {
            country country = cmBLL.GetCountryById(id);
            result<country> res = new result<country>();
            res.setResult("000", "", country);
            return res;
        }
        /// <summary>
        /// 插入一个国家
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPut]
        public result<string> putCountry([FromBody] JObject job)
        {
            result<string> res = new result<string>();
            if (job == null)
            {
                res.setResult("100", "invalid parameter", "");
                return res;
            }
            string name = job["name"].ToString();
            List<country> list = cmBLL.GetCountryByName(name);
            if (list.Count != 0)
            {
                res.setResult("100", "this country/'name has already exisited!", "");
                return res;
            }
            var s = cmBLL.PutCountry(name);
            res.setResult(s, "", "");
            return res;
        }
        /// <summary>
        /// 修改国家信息
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public result<string> updateCountry([FromBody] JObject job)
        {
            result<string> res = new result<string>();
            if (job == null)
            {
                res.setResult("100", "invalid parameter", "");
                return res;
            }
            int id = int.Parse(job["id"].ToString());
            string name = job["name"].ToString();
            List<country> countrys = cmBLL.GetCountryByNameNotId(id, name);
            if (countrys.Count != 0)
            {
                res.setResult("100", "this country'name has already exisited!", "");
                return res;
            }
            var s = cmBLL.UpdateCountry(id, name);
            res.setResult(s, "", "");
            return res;
        }
        /// <summary>
        /// 删除国家信息
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool deleteCountrys([FromBody] JObject job)
        {
            List<int> list = JsonConvert.DeserializeObject<List<int>>(job.ToString());
            return cmBLL.DeleteCountrys(list);
        }
        /// <summary>
        /// 根据id删除国家
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public result<string> deleteCountryById([FromBody] JObject job)
        {
            result<string> res = new result<string>();
            if (job == null)
            {
                res.setResult("100", "invalid parameter", "");
                return res;
            }
            int id = int.Parse(job["id"].ToString());
            var s = cmBLL.DeleteCountryById(id);
            res.setResult(s, "", "");
            return res;
        }
    }
}
