﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeuntechSite.Models;
using BeuntechSite.Models.DataContext;

namespace BeuntechSite.Controllers
{
    public class SiteKimlikController : Controller
    {
        private BeuntechSiteContext db = new BeuntechSiteContext();

        // GET: SiteKimlik
        public ActionResult Index()
        {
            return View(db.SiteKimlik.ToList());
        }

        // GET: SiteKimlik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteKimlik siteKimlik = db.SiteKimlik.Find(id);
            if (siteKimlik == null)
            {
                return HttpNotFound();
            }
            return View(siteKimlik);
        }

        // GET: SiteKimlik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteKimlik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KimlikID,Title,Keywords,Description,LogoURL,Unvan")] SiteKimlik siteKimlik)
        {
            if (ModelState.IsValid)
            {
                db.SiteKimlik.Add(siteKimlik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteKimlik);
        }

        // GET: SiteKimlik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteKimlik siteKimlik = db.SiteKimlik.Find(id);
            if (siteKimlik == null)
            {
                return HttpNotFound();
            }
            return View(siteKimlik);
        }

        // POST: SiteKimlik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KimlikID,Title,Keywords,Description,LogoURL,Unvan")] SiteKimlik siteKimlik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteKimlik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteKimlik);
        }

        // GET: SiteKimlik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteKimlik siteKimlik = db.SiteKimlik.Find(id);
            if (siteKimlik == null)
            {
                return HttpNotFound();
            }
            return View(siteKimlik);
        }

        // POST: SiteKimlik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteKimlik siteKimlik = db.SiteKimlik.Find(id);
            db.SiteKimlik.Remove(siteKimlik);
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
