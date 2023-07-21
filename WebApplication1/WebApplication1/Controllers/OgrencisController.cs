using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OgrencisController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            return View(db.MyEntities.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return newHttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.MyEntities.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.MyEntities.Add(ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return newHttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.MyEntities.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return newHttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenci ogrenci = db.MyEntities.Find(id);
            if (ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(ogrenci);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        private ActionResult newHttpStatusCodeResult(HttpStatusCode badRequest)
        {
            throw new NotImplementedException();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ogrenci ogrenci = db.MyEntities.Find(id);
            db.MyEntities.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
