using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem;
using System.Web.Script.Serialization;

namespace StudentManagementSystem.Areas.Class.Controllers
{
    public class CLASSesController : Controller
    {
        private STMSEntities db = new STMSEntities();

        // GET: Class/CLASSes
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetClasses()
        {
            var classList = db.CLASSes.Select(p => new { p.CLASSID, p.CLASSCODE, p.CLASSNAME }).ToList();
            return Json(classList, JsonRequestBehavior.AllowGet);
        }

        // GET method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS cLASS = db.CLASSes.Find(id);
            if (cLASS == null)
            {
                return HttpNotFound();
            }
            return View(cLASS);
        }

        // GET method
        public ActionResult Create()
        {
            return View();
        }

        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLASSID,CLASSCODE,CLASSNAME")] CLASS cLASS)
        {
            if (ModelState.IsValid)
            {
                db.CLASSes.Add(cLASS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLASS);
        }

        // GET method
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS cLASS = db.CLASSes.Find(id);
            if (cLASS == null)
            {
                return HttpNotFound();
            }
            return View(cLASS);
        }

        // POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLASSID,CLASSCODE,CLASSNAME")] CLASS cLASS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLASS);
        }

        // GET method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASS cLASS = db.CLASSes.Find(id);
            if (cLASS == null)
            {
                return HttpNotFound();
            }
            return View(cLASS);
        }

        // POST method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASS cLASS = db.CLASSes.Find(id);
            db.CLASSes.Remove(cLASS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
