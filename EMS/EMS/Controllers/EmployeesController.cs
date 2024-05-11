using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using System.Web.Helpers;
using EMS.Models;

namespace EMS.Controllers
{

    [Authorize]
    public class EmployeesController : Controller
    {
        private EmpDatabaseEntities db = new EmpDatabaseEntities();

        // GET: Employees
        public ActionResult Index(int page = 1, string sort = "Emp_First_Name", string sortdir = "asc", string search = "")
        {
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = GetEmployees(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public List<Employee> GetEmployees(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {

            var v = (from a in db.Employees
                     where
                             a.Emp_First_Name.Contains(search) ||
                             a.Emp_Last_Name.Contains(search) ||
                             a.Emp_Home_Address.Contains(search) ||
                             a.Emp_Grade.Contains(search) ||
                             a.Emp_Designation.Contains(search)
                     select a
                            );
            totalRecord = v.Count();
            v = v.OrderBy(sort + " " + sortdir);
            if (pageSize > 0)
            {
                v = v.Skip(skip).Take(pageSize);
            }
            return v.ToList();
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name");
            ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Grade_Code");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Emp_ID,Emp_First_Name,Emp_Last_Name,Emp_Date_of_Birth,Emp_Date_of_Joining,Emp_Dept_ID,Emp_Grade,Emp_Designation,Emp_Salary,Emp_Gender,Emp_Marital_Status,Emp_Home_Address,Emp_Contact_Num")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                TempData["AlertMessage"] = "Employee Added Successfully....!";
                return RedirectToAction("Index");
            }

            ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name", employee.Emp_Dept_ID);
            ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Description", employee.Emp_Grade);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name", employee.Emp_Dept_ID);
            ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Grade_Code", employee.Emp_Grade);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Emp_ID,Emp_First_Name,Emp_Last_Name,Emp_Date_of_Birth,Emp_Date_of_Joining,Emp_Dept_ID,Emp_Grade,Emp_Designation,Emp_Salary,Emp_Gender,Emp_Marital_Status,Emp_Home_Address,Emp_Contact_Num")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Employee Updated Successfully....!";
                return RedirectToAction("Index");
            }
            ViewBag.Emp_Dept_ID = new SelectList(db.Departments, "Dept_ID", "Dept_Name", employee.Emp_Dept_ID);
            ViewBag.Emp_Grade = new SelectList(db.Grade_master, "Grade_Code", "Grade_Code", employee.Emp_Grade);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            TempData["AlertMessage"] = "Employee Deleted Successfully....!";
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
