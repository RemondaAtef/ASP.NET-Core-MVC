using Microsoft.AspNetCore.Mvc;
using ProjectExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectExample.BL.Repository;
using System.Diagnostics;

namespace ProjectExample.Controllers
{
    public class UsersController : Controller
    {
        private UserRep Users = new UserRep();

        public IActionResult Index()
        {
            var data = Users.Get();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsersVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Users.Add(dpt);
                    return RedirectToAction("Index", "Users");
                }
                return View(dpt);
            }
            catch(Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
               
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var data = Users.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(UsersVM dpt)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Users.Edit(dpt);
                    return RedirectToAction("Index", "Users");
                }
                return View(dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var data = Users.GetById(id);
            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                    Users.Delete(id);
                    return RedirectToAction("Index", "Users");
                              
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }
        }
    }
}
