using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.DataLayer;
using WebApplication3.Models;
using System.Runtime.Caching;
namespace WebApplication3.Controllers
{
    public class MyAPIController : ApiController
    {
        //public List<Student> Get()
        //{
        //    SQLDataHelper sqlData = new SQLDataHelper();
        //    return sqlData.GetStudentsData();
        //}

        public List<Student> Get()
        {
            ObjectCache cashe = MemoryCache.Default;
            if (cashe["student"] == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy { AbsoluteExpiration = System.DateTimeOffset.Now.AddMinutes(30) };
                SQLDataHelper sqlHelper = new SQLDataHelper();
                var cacheItem = new CacheItem("student", sqlHelper.GetStudentsData());
                cashe.Add(cacheItem, policy);
            }
            return (List<Student>)cashe.Get("student");
        }
        //    public List<Student> Get()
        //    {SQLDataHelper sqlData = new SQLDataHelper();
        //        ObjectCache _mycache = MemoryCache.Default;
        //        if (_mycache["student_name"] == null)
        //        {
        //            CacheItemPolicy _mypolicy = new CacheItemPolicy();
        //            _mypolicy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60);
        //            CacheItem _ci = new CacheItem("student_name", sqlData.GetStudentsName());
        //            _mycache.Add(_ci, _mypolicy);
        //            return (List<Student>)_mycache.Get("student_name");
        //        }
        //        else
        //        {
        //            return  (List<Student>)_mycache.Get("student-name");
        //        }                     
        //    }
        //}
    }
}
