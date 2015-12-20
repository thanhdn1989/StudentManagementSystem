using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagementSystem;

namespace StudentManagementSystem.Areas.Parent.Controllers
{
    public class ParentController : Controller
    {
        private STMSEntities db = new STMSEntities();

        // GET: Parent/Parent
        public ActionResult Index()
        {
            return View(db.PARENTs.ToList());
        }

        // GET: Parent/Parent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARENT pARENT = db.PARENTs.Find(id);
            if (pARENT == null)
            {
                return HttpNotFound();
            }
            return View(pARENT);
        }

        // GET: Parent/Parent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parent/Parent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PARENTID,PARENTCODE,PARENTNUMBER,PARENTNAME")] PARENT pARENT)
        {
            if (ModelState.IsValid)
            {
                db.PARENTs.Add(pARENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pARENT);
        }

        // GET: Parent/Parent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARENT pARENT = db.PARENTs.Find(id);
            if (pARENT == null)
            {
                return HttpNotFound();
            }
            return View(pARENT);
        }

        // POST: Parent/Parent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PARENTID,PARENTCODE,PARENTNUMBER,PARENTNAME")] PARENT pARENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pARENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pARENT);
        }

        // GET: Parent/Parent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PARENT pARENT = db.PARENTs.Find(id);
            if (pARENT == null)
            {
                return HttpNotFound();
            }
            return View(pARENT);
        }

        // POST: Parent/Parent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PARENT pARENT = db.PARENTs.Find(id);
            db.PARENTs.Remove(pARENT);
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
