using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin2.Models;
using LLRM.Areas.Auth.Models;
using onlineportal.Areas.AdminPanel.Models;

namespace Sembhi.Areas.Auth.Controllers
{
    public class ServicesController : Controller
    {
        private dbcontext db = new dbcontext();
        public static string img;
        // GET: Auth/Services
        public async Task<ActionResult> Index()
        {
            return View(await db.Services.ToListAsync());
        }

        // GET: Auth/Services/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Services.FindAsync(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Auth/Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auth/Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Name,Description,ShortDescription,Image,Thumbnail,Keyword,MetaDescription")] Service service,HttpPostedFileBase file,Helper Help)
        {
            if (ModelState.IsValid)
            {
                service.Image = Help.Resize(file, 500, 800);
                db.Services.Add(service);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: Auth/Services/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Services.FindAsync(id);
            img = service.Image;
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Auth/Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Name,Description,ShortDescription,Image,Thumbnail,Keyword,MetaDescription")] Service service,HttpPostedFileBase file,Helper Help)
        {
            if (ModelState.IsValid)
            {
                service.Image = file != null ? Help.Resize(file, 500, 800) : img;
                db.Entry(service).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        // GET: Auth/Services/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = await db.Services.FindAsync(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Auth/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Service service = await db.Services.FindAsync(id);
            db.Services.Remove(service);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
