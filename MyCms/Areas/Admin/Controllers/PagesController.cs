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
    public class PagesController : Controller
    {
        private readonly IPageRepository pageRepository;
        private readonly IPageGroupRepository pageGroupRepository;
        private readonly MyCmsContext db = new MyCmsContext();

        public PagesController()
        {
            pageRepository = new PageRepository(db);
            pageGroupRepository = new PageGroupRepository(db);
        }

        // GET: Admin/Pages
        public ActionResult Index() => View(pageRepository.GetAll());

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAll(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,GroupId,Title,ShortDescription,Text,ImageName,ShowInSlider")] Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                page.CreateDate = DateTime.Now;
                page.Visit = 0;
                pageRepository.InsertPage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAll(), "GroupID", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAll(), "GroupID", "GroupTitle", page.GroupId);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,GroupId,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CreateDate")] Page page)
        {
            if (ModelState.IsValid)
            {
                pageRepository.UpdatePage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(pageGroupRepository.GetAll(), "GroupID", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = db.Pages.Find(id);
            pageRepository.DeletePage(page);
            pageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
