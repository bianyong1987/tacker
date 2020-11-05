using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using tracker.Models;
using tracker.WebApi.Models;

namespace tracker.BLL
{
    public class AppNameManageBLL
    {
        //tracker2Entities db = new tracker2Entities();
        FirstCodeModel db = new FirstCodeModel();
        List<appName> list = new List<appName>();
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <param name="selectWord"></param>
        /// <param name="pageSize"></param>
        /// <param name="currentPage"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public returnVal GetAll(string selectWord, string pageSize, string currentPage, user user)
        {
            int size = int.Parse(pageSize);
            int cp = int.Parse(currentPage);
            int count = 0;
            if (string.IsNullOrWhiteSpace(selectWord))
            {
                if (user.role == "admin")
                {
                    var adminappname = db.appName.Where(e => e.isDeleted == 0);
                    list = adminappname.OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = adminappname.Count();
                }
                else
                {
                    var appname = db.appName.Where(e => e.isDeleted == 0 & (e.userId == user.id | e.userId == null));
                    list = appname.OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = appname.Count();
                }
            }
            else
            {
                selectWord = selectWord.Trim();
                if (user.role == "admin")
                {
                    var adminappname = db.appName.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0);
                    list = adminappname.OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = adminappname.Count();
                }
                else
                {
                    var appname = db.appName.Where(e => e.val.Contains(selectWord) & e.isDeleted == 0 & (e.userId == user.id | e.userId == null));
                    list = appname.OrderByDescending(e => e.id).Skip((cp - 1) * size).Take(size).ToList();
                    count = appname.Count();
                }

            }
            returnVal r = new returnVal();
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
        public List<appName> SearchAppNames(string name, user user)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (user.role == "admin")
                {
                    list = db.appName.Where(e => e.isDeleted == 0).OrderByDescending(e => e.id).ToList();
                }
                else
                {
                    list = db.appName.Where(e => e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).ToList();
                }
            }
            else
            {
                name = name.Trim();
                if (user.role == "admin")
                {
                    list = db.appName.Where(e => e.val.Contains(name) & e.isDeleted == 0).OrderByDescending(e => e.id).ToList();
                }
                else
                {
                    list = db.appName.Where(e => e.val.Contains(name) & e.isDeleted == 0 & (e.userId == user.id | e.userId == null)).OrderByDescending(e => e.id).ToList();
                }
            }
            return list;
        }
        /// <summary>
        ///根据id获取appname
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public appName GetAppNameById(string id)
        {
            int i = int.Parse(id);
            appName appname = db.appName.Where(e => e.id == i).First();
            return appname;
        }
       
        /// <summary>
        /// 根据countryid获取appname
        /// </summary>
        /// <param name="countryid"></param>
        /// <returns></returns>
        public List<appName> GetAppNameByUserid(string countryid)
        {
            int cid = int.Parse(countryid);
            country coun = db.country.Where(e => e.isDeleted == 0 && e.name == "ALL").FirstOrDefault();
            List<appName> appNames = db.appName.Where(e => e.isDeleted == 0 && (e.countryId == cid || e.countryId == coun.id)).ToList();
            return appNames;
        }
        /// <summary>
        /// 根据名字获取appname
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<appName> GetAppNameByName(string name)
        {
            List<appName> appnames = db.appName.Where(e => e.val == name & e.isDeleted == 0).ToList();
            return appnames;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pkg_name"></param>
        /// <param name="pkg_id"></param>
        /// <param name="sourceID"></param>
        /// <param name="countryId"></param>
        /// <param name="u"></param>
        /// <returns></returns>
        public string AddAppName(string name, string pkg_name, string pkg_id, int sourceID, string countryId, user user)
        {
            string res = "";
            db.appName.Add(new appName { val = name, countryId = int.Parse(countryId), userId = user.id, pkg_name = pkg_name, pkg_id = pkg_id, sourceID = sourceID });
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
        /// 获取appname
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public List<appName> GetAppNameByIdVal(int id, string val)
        {
            List<appName> appnames = db.appName.Where(e => e.val == val & e.isDeleted == 0 & e.id != id).ToList();
            return appnames;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="val"></param>
        /// <param name="countryId"></param>
        /// <param name="pkg_name"></param>
        /// <param name="pkg_id"></param>
        /// <param name="sourceID"></param>
        /// <returns></returns>
        public string UpdateAppName(int id, string val, string countryId, string pkg_name, string pkg_id, string sourceID)
        {
            string res = "";
            appName appname = db.appName.Where(e => e.id == id).First();
            appname.val = val;
            appname.countryId = int.Parse(countryId);
            appname.pkg_name = pkg_name;
            appname.pkg_id = pkg_id;
            appname.sourceID = int.Parse(sourceID);
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
        public string DeleteAppNameById(int id) {
            string res = "";
            appName appname = db.appName.Where(e => e.id == id).First();
            appname.isDeleted = 1;
            try
            {
                db.SaveChanges();
                res="000";
            }
            catch
            {
                res="111";
            }
            return res;
        }
    }

}
