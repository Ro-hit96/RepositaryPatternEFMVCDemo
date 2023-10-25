﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositaryPatternEFMVCDemo.Models;
using RepositaryPatternEFMVCDemo.Services;

namespace RepositaryPatternEFMVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(service.GetEmployees());
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = service.GetEmployeeById(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                int result = service.AddEmployee(employee);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));//List
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = service.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                int result = service.UpdateEmployee(employee);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));//List
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = service.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteEmployee(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));//List
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
