
using RepositoryExample_15_02_22.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryExample_15_02_22.Controllers
{
   
    public class ProductController : Controller
    {
        // GET: Product
        
        ProductRepository pr = new ProductRepository();
        ProductsModel pm = new ProductsModel();
        BaseRepository<Categories> rep = new BaseRepository<Categories>();
        public ActionResult Index()
        {
           
            pm.pList = pr.Listele();
            
            return View(pm);
        }
        public ActionResult Detay(int id)
        {
            pm.products = pr.Bul(id);
            return View(pm);
        }
     
       
        public ActionResult Ekle()
        {
            pm.selectLists = rep.GenelListe().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            });

            return View(pm);
        }
        [HttpPost]
        public ActionResult Ekle(ProductsModel model)
        {
            if (ModelState.IsValid)
            {
                Products p = new Products();
                p.ProductID = model.products.ProductID;
                p.ProductName = model.products.ProductName;
                p.QuantityPerUnit = model.products.QuantityPerUnit;
                p.CategoryID = model.products.CategoryID;
                pr.Ekle(p);
                pr.Guncel();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
        public ActionResult Guncel(int id)
        {
            pm.products = pr.Bul(id);
            pm.selectLists = rep.GenelListe().Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            });
            return View(pm);
        }
        [HttpPost]
        public ActionResult Guncel(int id, ProductsModel pro)
        {
            if (ModelState.IsValid)
            {
                Products sec = pr.Bul(id);
                sec.ProductName = pro.products.ProductName;
                sec.QuantityPerUnit = pro.products.QuantityPerUnit;
                pr.Guncel();
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Sec()

        { 
            pm.pList = pr.GenelListe().OrderByDescending(x => x.ProductID).Skip(10).ToList();

            var xdeger = pm.pList.Count();
           
            pm.pList.Take(xdeger - 10);
               
            return View(pm);
        }



    }
}