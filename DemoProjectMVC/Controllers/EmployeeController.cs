﻿using DemoProjectMVC.DbCon;
using DemoProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoProjectMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbConContext _conContext;

        public EmployeeController(DbConContext conContext)
        {
            _conContext = conContext;
        }

        //public ActionResult Index()
        //{
        //    var data = _conContext.Employees.ToList();

        //    return View(data);
        //}

        public async Task<ActionResult> Index()
        {
            var data = await _conContext.Employees.ToListAsync();

            return View(data);
        }


        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Employee employee) 
        {
            if (!ModelState.IsValid)
            {
                return View(employee);  
                
            }

            _conContext.Employees.Add(employee);
            _conContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }


        public async Task <ActionResult> Edit(int id)
        {
            var employee = await _conContext.Employees.FindAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _conContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await _conContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException) 
            {
                throw;
            }

        }

        public  ActionResult Details(int id)
        {
            var employee =  _conContext.Employees.Find(id);
            return View(employee);
        }


        public IActionResult Delete(int id)
        {
            return View(_conContext.Employees.Find(id));
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employe = _conContext.Employees.Find(id);
            if (employe == null)
            {
                _conContext.Employees.Find(id);
                _conContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employe);
        }


    }
}
