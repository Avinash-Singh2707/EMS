using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;

namespace EMS.Controllers
{
    public class Grade_masterController : Controller
    {
        private EmpDatabaseEntities db = new EmpDatabaseEntities();

        // GET: Grade_master
        public ActionResult Index()
        {
            return View(db.Grade_master.ToList());
        }

        // GET: Grade_master/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade_master grade_master = db.Grade_master.Find(id);
            if (grade_master == null)
            {
                return HttpNotFound();
            }
            return View(grade_master);
        }

        // GET: Grade_master/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grade_master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Grade_Code,Description,Min_Salary,Max_Salary")] Grade_master grade_master)
        {

            if (db.Grade_master.Any(d => d.Grade_Code == grade_master.Grade_Code))
            {
                ModelState.AddModelError("Grade_Code", "Grade Code already exists.");
            }
            if (ModelState.IsValid)
            {
                db.Grade_master.Add(grade_master);
                db.SaveChanges();
                TempData["AlertMessage"] = "Grade Added Successfully....!";
                return RedirectToAction("Index");
            }

            return View(grade_master);
        }

        // GET: Grade_master/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade_master grade_master = db.Grade_master.Find(id);
            if (grade_master == null)
            {
                return HttpNotFound();
            }
            return View(grade_master);
        }

        // POST: Grade_master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Grade_Code,Description,Min_Salary,Max_Salary")] Grade_master grade_master)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grade_master).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Grade Updated Successfully....!";
                return RedirectToAction("Index");
            }
            return View(grade_master);
        }

        // GET: Grade_master/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade_master grade_master = db.Grade_master.Find(id);
            if (grade_master == null)
            {
                return HttpNotFound();
            }
            return View(grade_master);
        }

        // POST: Grade_master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                Grade_master grade_master = db.Grade_master.Find(id);

                // Check if the grade_master has any dependencies
                if (HasDependencies(grade_master))
                {
                    string alertMessage = "Cannot delete the grade because it belongs to certain employees.";
                    return Content($"<script>alert('{alertMessage}'); window.location.href = '/Grade_master/Index';</script>");
                }

                // If there are no dependencies, proceed with deletion
                db.Grade_master.Remove(grade_master);
                db.SaveChanges();
                TempData["AlertMessage"] = "Grade Deleted Successfully....!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the grade.");
                return View();
            }
        }

        // Method to check if the grade has dependencies
        private bool HasDependencies(Grade_master grade_master)
        {
            // Check if the grade_master is associated with any employees
            return db.Employees.Any(e => e.Emp_Grade == grade_master.Grade_Code);
        }

        //public ActionResult DeleteConfirmed(string id)
        //{



        //    Grade_master grade_master = db.Grade_master.Find(id);
        //    db.Grade_master.Remove(grade_master);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
