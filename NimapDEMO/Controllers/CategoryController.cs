using NimapDEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace NimapDEMO.Controllers
{
    
    public class CategoryController : Controller
    {
        NimapDBEntities1 dbo=new NimapDBEntities1();
        // GET: Category
        public ActionResult Index(int?i)
        {
            var list = dbo.sp_join().ToList().ToPagedList(i??1,5);
           
            return View(list);
        }
        [HttpGet]
        public ActionResult IndexSearch(string txtSearch, int? i)
        {
            //var list = dbo.sp_join().ToList().ToPagedList(i ?? 1, 5);          
            var Tlist = dbo.sp_join().ToList();
            var list = Tlist.Where(x => x.CategoryName.ToLower().Contains(txtSearch)).ToList().ToPagedList(i ?? 1, 5);
            return View("Index",list);
        }
        [HttpGet]
        public ActionResult Search(string txtSearch, int? i)
        {
           // var categories = dbo.tblCategories.ToList().ToPagedList(i??1,2);
            var categories = dbo.tblCategories.Where(x => x.CategoryName.Contains(txtSearch)||txtSearch==null).ToList().ToPagedList(i??1, 5);

            return View(categories);
        }
        [HttpPost]
        public ActionResult Search(string txtSearch)
        {
           var categories = dbo.tblCategories.Where(x=>x.CategoryName.Contains(txtSearch)).ToList().ToPagedList(1,5);
           
            return View(categories);

        }
    }
}