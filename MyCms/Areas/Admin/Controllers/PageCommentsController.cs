using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyCms.Areas.Admin.Controllers
{
    public class PageCommentsController : Controller
    {
        private MyCmsContext db = new MyCmsContext();

        // GET: Admin/PageComments
        public ActionResult Index()
        {
            var pageComments = db.PageComments.Include(p => p.Page);
            return View(pageComments.ToList());
        }

        // GET: Admin/PageComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageComment pageComment = db.PageComments.Find(id);
            if (pageComment == null)
            {
                return HttpNotFound();
            }
            return View(pageComment);
        }

        // GET: Admin/PageComments/Create
        public ActionResult Create()
        {
            ViewBag.PageID = new SelectList(db.Pages, "PageId", "Title");
            return View();
        }

        // POST: Admin/PageComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,PageID,Name,Email,Website,Comment,CreationDate")] PageComment pageComment)
        {
            if (ModelState.IsValid)
            {
                db.PageComments.Add(pageComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PageID = new SelectList(db.Pages, "PageId", "Title", pageComment.PageID);
            return View(pageComment);
        }

        // GET: Admin/PageComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageComment pageComment = db.PageComments.Find(id);
            if (pageComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageID = new SelectList(db.Pages, "PageId", "Title", pageComment.PageID);
            return View(pageComment);
        }

        // POST: Admin/PageComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,PageID,Name,Email,Website,Comment,CreationDate")] PageComment pageComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageID = new SelectList(db.Pages, "PageId", "Title", pageComment.PageID);
            return View(pageComment);
        }

        // GET: Admin/PageComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageComment pageComment = db.PageComments.Find(id);
            if (pageComment == null)
            {
                return HttpNotFound();
            }
            return View(pageComment);
        }

        // POST: Admin/PageComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PageComment pageComment = db.PageComments.Find(id);
            db.PageComments.Remove(pageComment);
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
