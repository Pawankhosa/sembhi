using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LLRM.Areas.Auth.Models;
using Admin2.Models;
namespace Sembhi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        dbcontext db = new dbcontext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult ServiceDetails(int id)
        {
            Service ss = db.Services.Where(x => x.id == id).FirstOrDefault();
            return View(ss);
        }
        public ActionResult Album()
        {
            
            return View(db.Albums.ToList());
        }
        // GET: Home/Details/5
        public ActionResult Gallery(int id)
        {

            return View(db.Galleries.Where(x=>x.Albumid==id).ToList());
        }

        // GET: Home/Create
        public ActionResult ContactUs()
        {
            Contact cc = db.Contacts.ToList().FirstOrDefault();
            return View(cc);
        }

        // POST: Home/Create
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

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
