using System;
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
    public class SystemsController : Controller
    {
        private CrContainer db = new CrContainer();

        // GET: Systems
        public ActionResult Index()
        {
            var systems1 = db.Systems1.Include(s => s.Customer);
            return View(systems1.ToList());
        }

        // GET: Systems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Systems systems = db.Systems1.Find(id);
            if (systems == null)
            {
                return HttpNotFound();
            }
            return View(systems);
        }

        // GET: Systems/Create
        public ActionResult Create()
        {
            ViewBag.CustomersClient_Id = new SelectList(db.Customers, "Client_Id", "Email");
            return View();
        }

        // POST: Systems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "System_Id,Brands,Note,Drop_Off_Date,Pick_Up_Date,Quote,CustomersClient_Id,IsLaptop,IsDesktop,Is_All_In_One, IsMonitor,Tablet,IsCell_Phone,Mac_Number,Priority,Currect_Status,Job_Completed,Paid,Data_BackUp_Required,Login_Details,Missing_Adapter,Missing_Keys,Broken_Screen")] Systems systems)
        {
            if (ModelState.IsValid)
            {
                db.Systems1.Add(systems);
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { step = "3" });
            }

            ViewBag.CustomersClient_Id = new SelectList(db.Customers, "Client_Id", "Email", systems.CustomersClient_Id);
            return View(systems);
        }

        // GET: Systems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Systems systems = db.Systems1.Find(id);
            if (systems == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomersClient_Id = new SelectList(db.Customers, "Client_Id", "First_Name", systems.CustomersClient_Id);
            return View(systems);
        }

        // POST: Systems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "System_Id, Brands, Note, Drop_Off_Date, Pick_Up_Date, Quote, CustomersClient_Id, IsLaptop, IsDesktop, Is_All_In_One, IsMonitor, Tablet, IsCell_Phone, Mac_Number, Priority, Currect_Status, Job_Completed, Paid, Data_BackUp_Required, Login_Details, Missing_Adapter, Missing_Keys, Broken_Screen")] Systems systems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(systems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomersClient_Id = new SelectList(db.Customers, "Client_Id", "First_Name", systems.CustomersClient_Id);
            return View(systems);
        }

        // GET: Systems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Systems systems = db.Systems1.Find(id);
            if (systems == null)
            {
                return HttpNotFound();
            }
            return View(systems);
        }

        // POST: Systems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Systems systems = db.Systems1.Find(id);
            db.Systems1.Remove(systems);
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
