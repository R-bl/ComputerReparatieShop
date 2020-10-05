﻿using ComputerRepairShop.Data.DAL;
using ComputerRepairShop.Classes.Helpers;
using ComputerRepairShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerRepairShop.ViewModels;

namespace ComputerRepairShop.Web.Controllers
{
    public class RepairOrderController : Controller
    {
        private readonly IReparatieShopData db;

        public RepairOrderController(IReparatieShopData db)
        {
            this.db = db;
        }

        // GET: RepairOrder
        public ActionResult Index()
        {
            var repairOrders = db.GetAll();

            IDictionary<RepairOrderStatus, int> statusCount = new Dictionary<RepairOrderStatus, int>();
            statusCount.Add(RepairOrderStatus.Done, 0);
            statusCount.Add(RepairOrderStatus.Pending, 0);
            statusCount.Add(RepairOrderStatus.Underway, 0);
            statusCount.Add(RepairOrderStatus.WaitingForParts, 0);


            foreach (var repairOrder in repairOrders)
            {
                switch (repairOrder.Status)
                {
                    case RepairOrderStatus.Done:
                        statusCount[RepairOrderStatus.Done]++;
                        break;
                    case RepairOrderStatus.Pending:
                        statusCount[RepairOrderStatus.Pending]++;
                        break;
                    case RepairOrderStatus.Underway:
                        statusCount[RepairOrderStatus.Underway]++;
                        break;
                    case RepairOrderStatus.WaitingForParts:
                        statusCount[RepairOrderStatus.WaitingForParts]++;
                        break;
                    default:
                        break;
                }
            }
            var model = new RepairOrderViewModel();

            model.RepairOrders = db.GetAll();
            model.statusCount = statusCount;
            return View(model);
        }

        // GET: RepairOrder/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RepairOrder/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairOrder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RepairOrder repairOrder, FormCollection collection)
        {
                // TODO: Uncomment bottom redirect to go to unimplemented details views.
            db.Add(repairOrder);
            return RedirectToAction("Index");
            //return RedirectToAction("Details", new { id = repairOrder.Id });
        }

        // GET: RepairOrder/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: RepairOrder/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RepairOrder repairOrder, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(repairOrder);
                    // TODO: Uncomment "Details" redirect when implemented
                    // return RedirectToAction("Details", new { id = repairOrder.Id });
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(repairOrder);
        }

        // GET: RepairOrder/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // POST: RepairOrder/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
