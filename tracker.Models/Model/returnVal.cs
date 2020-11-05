using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tracker.Models;

namespace tracker.WebApi.Models
{
    public class returnVal
    {
        public List<appName> list;
        public int count;
    }
    public class returnSiteDomain
    {
        public List<siteDomain> list;
        public int count;
    }
    public class returnSiteId
    {
        public List<siteId> list;
        public int count;
    }
}