﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComputerRepairShop.Data.Models;
using ComputerRepairShop.Classes.Helpers;

namespace ComputerRepairShop.Data.DAL
{
    public class MockDB : IMockDB
    {
        List<RepairOrder> repairOrders;

        public MockDB()
        {
            repairOrders = new List<RepairOrder>()
            {
                new RepairOrder {Id = 0, Name = "Name0", Description = "Description0", Status = RepairOrderStatus.Done, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
                new RepairOrder {Id = 1, Name = "Name1", Description = "Description1", Status = RepairOrderStatus.Pending, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
                new RepairOrder {Id = 2, Name = "Name2", Description = "Description2", Status = RepairOrderStatus.WaitingForParts, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
                new RepairOrder {Id = 3, Name = "Name3", Description = "Description3", Status = RepairOrderStatus.Underway, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
                new RepairOrder {Id = 4, Name = "Name4", Description = "Description4", Status = RepairOrderStatus.Done, StartDate = DateTime.Today, EndDate = DateTime.Today, Visible = false },
            };
        }

        public IEnumerable<RepairOrder> GetAll()
        {
            return repairOrders.OrderBy(r => r.EndDate.Ticks);
        }
    }
}
