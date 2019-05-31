﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComputerRepair;

namespace ComputerRepair.Controllers
{
    public class AgentsController : Controller
    {
        private CrContainer db = new CrContainer();

        // GET: Agents
        public ActionResult Index()
        {
            var agents = db.Agents.Include(a => a.System);
            return View(agents.ToList());
        }

        // GET: Agents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // GET: Agents/Create
        public ActionResult Create()
        {

            ViewBag.SystemsSystem_Id = new SelectList(db.Systems1, "System_Id", "Mac_Number");
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Agent_Id,First_Name,Last_Name,Employ_Id,Shift_Type,SystemsSystem_Id")] Agents agents)
        {
            if (ModelState.IsValid)
            {
                db.Agents.Add(agents);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { step = "Done" });
            }

            ViewBag.SystemsSystem_Id = new SelectList(db.Systems1, "System_Id", "Mac_Number", agents.SystemsSystem_Id);
            return View(agents);
        }

        // GET: Agents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            ViewBag.SystemsSystem_Id = new SelectList(db.Systems1, "System_Id", "Brands", agents.SystemsSystem_Id);
            return View(agents);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Agent_Id,First_Name,Last_Name,Employ_Id,Shift_Type,SystemsSystem_Id")] Agents agents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SystemsSystem_Id = new SelectList(db.Systems1, "System_Id", "Brands", agents.SystemsSystem_Id);
            return View(agents);
        }

        // GET: Agents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agents agents = db.Agents.Find(id);
            if (agents == null)
            {
                return HttpNotFound();
            }
            return View(agents);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agents agents = db.Agents.Find(id);
            db.Agents.Remove(agents);
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
