﻿using Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerReperatieShop.Data.DAL;

namespace ComputerReperatieShop.Web.Controllers
{
    public class RepairOrderController : Controller
    {
        IMockDB db;

        public RepairOrderController()
        {
            db = new MockDB();
        }

        // GET: ReperatieOpdrachten
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        // GET: ReperatieOpdrachten/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReperatieOpdrachten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReperatieOpdrachten/Create
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

        // GET: ReperatieOpdrachten/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReperatieOpdrachten/Edit/5
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

        // GET: ReperatieOpdrachten/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReperatieOpdrachten/Delete/5
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
