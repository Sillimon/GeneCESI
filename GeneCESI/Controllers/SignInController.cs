﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneCESI.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        // GET: SignIn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignIn/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ReturnList()
        {
            List<GeneCESI.Lib.Objects.Exam> exams = new List<Lib.Objects.Exam>();
            exams.Add(new Lib.Objects.Exam("test", 2, 30, new DateTime(2022, 11, 22), 2, 0));
            return View(exams);
        }
        // POST: SignIn/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SignIn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignIn/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SignIn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignIn/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
