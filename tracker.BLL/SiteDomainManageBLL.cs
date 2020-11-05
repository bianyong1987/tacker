using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracker.Models;
using tracker.WebApi.Models;

namespace tracker.BLL
{
    public class SiteDomainManageBLL
    {
        FirstCodeModel db = new FirstCodeModel();
        //tracker2Entities db = new tracker2Entities();
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="selectWord"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public returnSiteDomain GetAll(string selectWord, string pageSize, string currentPage, user user)
        {
            int size = int.Parse(pageSize);
            int cp = int.Parse(currentPage);
            int count = 0;
            List<siteDomain> list = new List<siteDomain>();
            if (string.IsNullOrWhiteSpace(selectWord))
            {
                if (user.role == "admin")
                {
                    list = db.siteDomain.Where(e => e.isDeleted == 0).OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = db.siteDomain.Where(e => e.isDeleted == 0).Count();
                }
                else
                {
                    list = db.siteDomain.Where(e => e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = db.siteDomain.Where(e => e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).Count();
                }
            }
            else
            {
                selectWord = selectWord.Trim();
                if (user.role == "admin")
                {
                    list = db.siteDomain.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0).OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = db.siteDomain.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0).Count();
                }
                else
                {
                    list = db.siteDomain.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = db.siteDomain.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).Count();
                }
            }
            returnSiteDomain r = new returnSiteDomain();
            r.list = list;
            r.count = count;
            return r;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="name"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<siteDomain> SearchSiteDomains(string name, user user)
        {
            List<siteDomain> list = new List<siteDomain>();
            if (string.IsNullOrWhiteSpace(name))
            {
                if (user.role == "admin")
                {
                    list = db.siteDomain.Where(e => e.isDeleted == 0).OrderByDescending(e => e.id).ToList();
                }
                else
                {
                    list = db.siteDomain.Where(e => e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).ToList();
                }
            }
            else
            {
                name = name.Trim();
                if (user.role == "admin")
                {
                    list = db.siteDomain.Where(e => e.val.Contains(name) & e.isDeleted == 0).OrderByDescending(e => e.id).ToList();
                }
                else
                {
                    list = db.siteDomain.Where(e => e.val.Contains(name) & e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).ToList();
                }
            }
            return list;
        }
        /// <summary>
        /// 根据id获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public siteDomain GetSiteDomainById(string id)
        {
            int i = int.Parse(id);
            siteDomain sitedomain = db.siteDomain.Where(e => e.id == i).First();
            return sitedomain;
        }
        /// <summary>
        /// 根据countryid获取SiteDomain
        /// </summary>
        /// <param name="countryid"></param>
        /// <returns></returns>
        public List<siteDomain> GetSiteDomainByUserid(string countryid)
        {
            int cid = int.Parse(countryid);
            country coun = db.country.Where(e => e.isDeleted == 0 && e.name == "ALL").FirstOrDefault();
            List<siteDomain> sitedomains = db.siteDomain.Where(e => e.isDeleted == 0 && (e.countryId == cid || e.countryId == coun.id)).ToList();
            return sitedomains;
        }
        /// <summary>
        /// 根据名称获取SiteDomain
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<siteDomain> GetSiteDomainByName(string name)
        {
            List<siteDomain> sitedomains = db.siteDomain.Where(e => e.val == name & e.isDeleted == 0).ToList();
            return sitedomains;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="name"></param>
        /// <param name="countryId"></param>
        /// <param name="user"></param>
        /// <param name="sourceID"></param>
        /// <returns></returns>
        public string AddSiteDomain(string name, string countryId, user user, int sourceID)
        {
            string res;
            db.siteDomain.Add(new siteDomain { val = name, countryId = int.Parse(countryId), userId = user.id, sourceID = sourceID });
            try
            {
                db.SaveChanges();
                res = "000";
            }
            catch
            {
                res = "111";
            }
            return res;
        }
        /// <summary>
        /// 根据值排除id获取sitedomain
        /// </summary>
        /// <param name="val"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<siteDomain> GetSiteDomainByValNotID(string val, int id)
        {
            List<siteDomain> sitedomains = db.siteDomain.Where(e => e.val == val & e.isDeleted == 0 & e.id != id).ToList();
            return sitedomains;
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        /// <param name="countryId"></param>
        /// <param name="sourceID"></param>
        /// <returns></returns>
        public string UpdateSiteDomain(int id, string val, string countryId, int sourceID)
        {
            string res;
            siteDomain sitedomain = db.siteDomain.Where(e => e.id == id).First();
            sitedomain.val = val;
            sitedomain.countryId = int.Parse(countryId);
            sitedomain.sourceID = sourceID;
            try
            {
                db.SaveChanges();
                res = "000";
            }
            catch
            {
                res = "111";
            }
            return res;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteSiteDomainById(int id)
        {
            string res;
            siteDomain sitedomain = db.siteDomain.Where(e => e.id == id).First();
            sitedomain.isDeleted = 1;
            try
            {
                db.SaveChanges();
                res = "000";
            }
            catch
            {
                res = "111";
            }
            return res;
        }
    }
}
