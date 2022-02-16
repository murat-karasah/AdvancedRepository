using AdvancedRepository.Business;
using AdvancedRepository.Models;
using AdvancedRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedRepository.Controllers
{
    public class CustomersController : Controller
    {
        BaseRepository<Customers> crp = new BaseRepository<Customers>();
        CustomerModel cm = new CustomerModel();

        public ActionResult Index(string name)
        {
            if (name == null)//Eger Name nulll ise bos bırak//Arama-Search Kısmı
            {
                name = "";
            }
            cm.cList = crp.GetAllList().Where(x => x.CompanyName.Contains(name)).ToList();
            return View(cm);
        }

        public ActionResult Detay(string id)
        {
            cm.Customers = crp.Bul(id);
            return View(cm);
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(CustomerModel entity)
        {
            if (ModelState.IsValid)
            {
                Customers c = new Customers();
                c.CustomerID = entity.Customers.CustomerID;
                c.CompanyName = entity.Customers.CompanyName;
                c.ContactName = entity.Customers.ContactName;
                crp.Add(c);
                crp.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Sil(string id)
        {
            Customers c = crp.Bul(id);
            crp.Delete(c);
            crp.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(string id)
        {
            cm.Customers = crp.Bul(id);
            return View(cm);
        }
        [HttpPost]
        public ActionResult Guncelle(string id,Customers customers)
        {
            if (ModelState.IsValid)
            {
                Customers sec = crp.Bul(id);
                sec.CompanyName = customers.CompanyName;
                sec.ContactName= customers.ContactName;
                sec.City = customers.City;

                crp.Save();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}