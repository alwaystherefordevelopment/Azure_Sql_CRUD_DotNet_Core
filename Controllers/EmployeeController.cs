using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagerApp.Models;

namespace UserManagerApp.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseContext _db;
        public EmployeeController(DatabaseContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var data= _db.Employees.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                _db.Employees.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int Id)
        {
            Employee model =_db.Employees.Find(Id);
            return View("Create", model);
        }
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", model);
        }

        public IActionResult Delete(int Id)
        {
           var data = _db.Employees.Find(Id);
            _db.Employees.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
