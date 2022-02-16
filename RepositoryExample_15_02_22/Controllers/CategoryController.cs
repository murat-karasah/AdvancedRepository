using RepositoryExample_15_02_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryExample_15_02_22.Controllers
{
    public class CategoryController : Controller
    {
        BaseRepository<Categories> rep = new BaseRepository<Categories>();
        CategoriesModel cm = new CategoriesModel();

        public ActionResult Index(string name)
        {
            if (name == null)//Eger Name nulll ise bos bırak//Arama-Search Kısmı
            {
                name = "";
            }
            cm.cList = rep.GenelListe().Where(x => x.CategoryName.Contains(name)).ToList();
            return View(cm);
        }
        public ActionResult Detay(int id)
        {
            cm.Categories = rep.Bul(id);
            return View(cm);
           
        }
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(CategoriesModel entity)
        {
            if (ModelState.IsValid)
            {
            Categories c = new Categories();
            c.CategoryID = entity.Categories.CategoryID;
            c.CategoryName = entity.Categories.CategoryName;
            c.Description = entity.Categories.Description;
            rep.Ekle(c);
            rep.Guncel();
             return RedirectToAction("Index");
            }
            return View();
            
        }
        public ActionResult Sil(int id)
        {
            Categories c = rep.Bul(id);
            rep.Sil(c);
            rep.Guncel();
            return RedirectToAction("Index");
        }
        public ActionResult Guncel(int id)
        {
            cm.Categories = rep.Bul(id);
            return View(cm);
        }
        [HttpPost]
        public ActionResult Guncel(int id,CategoriesModel categories)
        {
            if (ModelState.IsValid)
            {
                Categories sec = rep.Bul(id);
                sec.CategoryName = categories.Categories.CategoryName;
                sec.Description = categories.Categories.Description;
                rep.Guncel();
                return RedirectToAction("Index");

            }
            return View();

        }
        public ActionResult Sec()
        {
            cm.cList = rep.GenelListe().OrderBy(x => x.CategoryID).Skip(3).Take(5).ToList();
            return View(cm);
        }
    }
}