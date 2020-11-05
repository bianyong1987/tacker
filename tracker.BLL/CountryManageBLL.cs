using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tracker.Models;

namespace tracker.BLL
{
    public class CountryManageBLL
    {
        FirstCodeModel db = new FirstCodeModel();
        //tracker2Entities db = new tracker2Entities();
        /// <summary>
        /// 获取国家
        /// </summary>
        /// <returns></returns>
        public country Getcountry()
        {
            country country = db.country.Where(e => e.isDeleted == 0 && e.name == "ALL").FirstOrDefault();
            return country;
        }
        /// <summary>
        /// 获取国家列表
        /// </summary>
        /// <returns></returns>
        public List<country> GetCountrys()
        {
            List<country> countrys = db.country.Where(e => e.isDeleted == 0).OrderByDescending(e => e.id).ToList();
            return countrys;
        }
        /// <summary>
        /// 搜索国家
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<country> SearchCountrys(string name)
        {
            List<country> countrys = db.country.Where(e => e.name.Contains(name) & e.isDeleted == 0).OrderByDescending(e => e.id).ToList();
            return countrys;
        }
        /// <summary>
        /// 根据id获取国家
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public country GetCountryById(string id)
        {
            int i = int.Parse(id);
            country country = db.country.Where(e => e.id == i).First();
            return country;
        }
        /// <summary>
        /// 根据名称获取国家
        /// </summary>
        /// <param name="countryname"></param>
        /// <returns></returns>
        public List<country> GetCountryByName(string countryname)
        {
            List<country> countrys = db.country.Where(e => e.name == countryname & e.isDeleted == 0).ToList();
            return countrys;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="countryname"></param>
        /// <returns></returns>
        public string PutCountry(string countryname)
        {
            string res;
            db.country.Add(new country { name = countryname });
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
        public List<country> GetCountryByNameNotId(int id, string countryname)
        {
            List<country> countrys = db.country.Where(e => e.name == countryname & e.isDeleted == 0 & e.id != id).ToList();
            return countrys;
        }
        /// <summary>
        /// 更新国家
        /// </summary>
        /// <param name="id"></param>
        /// <param name="countryname"></param>
        /// <returns></returns>
        public string UpdateCountry(int id, string countryname)
        {
            string res;
            country country = db.country.Where(e => e.id == id).First();
            country.name = countryname;
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
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool DeleteCountrys(List<int> list)
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    db.country.Attach(new country { id = list[i] });
                    db.country.Remove(new country { id = list[i] });
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteCountryById(int id)
        {
            string res;
            country country = db.country.Where(e => e.id == id).First();
            country.isDeleted = 1;
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
