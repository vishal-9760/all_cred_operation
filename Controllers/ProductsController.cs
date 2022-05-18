using all_cred_operation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace all_cred_operation.Controllers
{
    public class ProductsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {
            var pro = db.products.ToList();
            return View(pro);
        }
        public ActionResult Create()
        {
            var cat=db.categories.ToList();
            ViewBag.cat = cat;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            db.products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var pro = db.products.SingleOrDefault(e => e.Id==id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var pro = db.products.SingleOrDefault(e => e.Id == id);
            db.products.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}