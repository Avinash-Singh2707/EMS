using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;

namespace EMS.Controllers
{
    public class DepartmentsController : Controller
    {
        private EmpDatabaseEntities db = new EmpDatabaseEntities();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dept_ID,Dept_Name")] Department department)
        {
            if (db.Departments.Any(d => d.Dept_ID == department.Dept_ID))
            {
                ModelState.AddModelError("Dept_ID", "Department ID already exists.");
            }
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                TempData["AlertMessage"] = "Department Added Successfully....!";
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dept_ID,Dept_Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Department Updated Successfully....!";
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Department department = db.Departments.Find(id);

                // Check if the department has any dependencies
                if (HasDependencies(department))
                {
                    string alertMessage = "Cannot delete the department because it has dependencies.";
                    return Content($"<script>alert('{alertMessage}'); window.location.href = '/Departments/Index';</script>");
                }

                // If there are no dependencies, proceed with deletion
                db.Departments.Remove(department);
                db.SaveChanges();
                TempData["AlertMessage"] = "Department Deleted Successfully....!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the department.");
                return View();
            }
        }

        // Method to check if the department has dependencies
        private bool HasDependencies(Department department)
        {
            // Check if the department is associated with any other entities
            // For example, you can check if there are any employees belonging to this department
            return db.Employees.Any(e => e.Emp_Dept_ID == department.Dept_ID);
        }

        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Department department = db.Departments.Find(id);
        //    db.Departments.Remove(department);
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
