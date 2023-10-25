﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositaryPatternEFMVCDemo.Models;
using RepositaryPatternEFMVCDemo.Services;

namespace RepositaryPatternEFMVCDemo.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookService service;
        public BookController(IBookService service)
        {
            this.service = service;       
        }

        // GET: BookController
        public ActionResult Index()
        {
            return View(service.GetBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = service.GetBookById(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int result = service.AddBook(book);
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = service.GetBookById(id);
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int result = service.UpdateBook(book);
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = service.GetBookById(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = service.DeleteBook(id);
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
