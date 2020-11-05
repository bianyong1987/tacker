using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracker.Models;
using tracker.WebApi.Models;

namespace tracker.BLL
{
    public class SiteIdManageBLL
    {
        FirstCodeModel db = new FirstCodeModel();
        //tracker2Entities db = new tracker2Entities();
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <param name="selectWord"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public returnSiteId GetAll(string selectWord, string pageSize, string currentPage, user user)
        {
            int size = int.Parse(pageSize);
            int cp = int.Parse(currentPage);
            int count = 0;
            List<siteId> list = new List<siteId>();
            if (string.IsNullOrWhiteSpace(selectWord))
            {
                if (user.role == "admin")
                {
                    list = db.siteId.Where(e => e.isDeleted == 0).OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = db.siteId.Where(e => e.isDeleted == 0).Count();
                }
                else
                {
                    list = db.siteId.Where(e => e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = db.siteId.Where(e => e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).Count();
                }
            }
            else
            {
                selectWord = selectWord.Trim();
                if (user.role == "admin")
                {
                    list = db.siteId.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0).OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = db.siteId.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0).Count();
                }
                else
                {
                    list = db.siteId.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = db.siteId.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).Count();
                }
            }
            returnSiteId r = new returnSiteId();
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
        public List<siteId> SearchSiteIds(string name, user user)
        {
            List<siteId> list = new List<siteId>();
            if (string.IsNullOrWhiteSpace(name))
            {
                if (user.role == "admin")
                {
                    list = db.siteId.Where(e => e.isDeleted == 0).OrderByDescending(e => e.id).ToList();
                }
                else
                {
                    list = db.siteId.Where(e => e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).ToList();
                }
            }
            else
            {
                name = name.Trim();
                if (user.role == "admin")
                {

                    list = db.siteId.Where(e => e.val.Contains(name) & e.isDeleted == 0).OrderByDescending(e => e.id).ToList();
                }
                else
                {
                    list = db.siteId.Where(e => e.val.Contains(name) & e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).ToList();
                }
            }
            return list;
        }
        /// <summary>
        /// 根据id查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public siteId GetSiteIdById(string id)
        {
            int i = int.Parse(id);
            siteId siteid = db.siteId.Where(e => e.id == i).First();
            return siteid;
        }
        /// <summary>
        /// 根据companyid查找
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<siteId> GetSiteIdByUserid(int cid)
        {
            country coun = db.country.Where(e => e.isDeleted == 0 && e.name == "ALL").FirstOrDefault();
            List<siteId> siteids = db.siteId.Where(e => e.isDeleted == 0 && (e.countryId == cid || e.countryId == coun.id)).ToList();
            return siteids;
        }
        /// <summary>
        /// 根据名称查找
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<siteId> GetSiteIdByName(string name)
        {
            List<siteId> siteids = db.siteId.Where(e => e.val == name & e.isDeleted == 0).ToList();
            return siteids;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="name"></param>
        /// <param name="countryId"></param>
        /// <param name="sourceID"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string AddSiteId(string name, string countryId, int sourceID, user user)
        {
            string res;
            db.siteId.Add(new siteId { val = name, countryId = int.Parse(countryId), userId = user.id, sourceID = sourceID });
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
        /// 根据值排除相关id查找
        /// </summary>
        /// <param name="val"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<siteId> GetSiteIdByValNotId(string val, int id)
        {
            List<siteId> siteids = db.siteId.Where(e => e.val == val & e.isDeleted == 0 & e.id != id).ToList();
            return siteids;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        /// <param name="countryId"></param>
        /// <param name="sourceID"></param>
        /// <returns></returns>
        public string UpdateSiteId(int id, string val, string countryId, int sourceID)
        {
            string res;
            siteId siteid = db.siteId.Where(e => e.id == id).First();
            siteid.val = val;
            siteid.countryId = int.Parse(countryId);
            siteid.sourceID = sourceID;
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
        public string DeleteSiteIdById(int id)
        {
            string res;
            siteId siteid = db.siteId.Where(e => e.id == id).First();
            siteid.isDeleted = 1;
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
