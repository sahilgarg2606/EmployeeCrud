using EmployeeCrud.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCrud.Controllers
{
    public class EmployeeController : Controller
    {
        basicCrudDbEntities db = new basicCrudDbEntities();
        // GET: Employee
        public ActionResult Index()
        {
            var res = db.Employees.ToList();
            return View(res);
        }
        public ActionResult AddEmployee()
        {
             
                return View();
              
        }
        
        [HttpPost]
        public ActionResult AddEmployee(Employee model)
        {
           
            
                if (ModelState.IsValid)
                {
                    Employee obj = new Employee();
                    obj.EmpId = model.EmpId;
                    obj.EmpName = model.EmpName;
                    obj.EmpDep = model.EmpDep;
                    obj.EmpLoc = model.EmpLoc;
                    obj.EmpSal = model.EmpSal;
                    db.Employees.Add(obj);
                    db.SaveChanges();
                var res = db.Employees.ToList();
                return View("Index", res);
            }
            else
            {
                ModelState.Clear();
                var res = db.Employees.ToList();
                return View("Index", res);
            }
              
            }
           
        
      
        public ActionResult Delete(int id)
        {
            var res = db.Employees.Where(x => x.EmpId == id).First();
            db.Employees.Remove(res);
            db.SaveChanges();
            var list = db.Employees.ToList();
            return View("Index" , list);
        }
    }
}