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
    public class FeaturesController : Controller
    {
        private dbcontext db = new dbcontext();
        public static string img;
        // GET: Auth/Features
        public async Task<ActionResult> Index()
        {
            return View(await db.Features.ToListAsync());
        }

        // GET: Auth/Features/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = await db.Features.FindAsync(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // GET: Auth/Features/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auth/Features/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Name,Image")] Feature feature,HttpPostedFileBase file,Helper Help)
        {
            if (ModelState.IsValid)
            {
                feature.Image = Help.Resize(file, 500, 800);
                db.Features.Add(feature);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(feature);
        }

        // GET: Auth/Features/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = await db.Features.FindAsync(id);
            img = feature.Image;
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // POST: Auth/Features/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Name,Image")] Feature feature,HttpPostedFileBase file,Helper Help)
        {
            if (ModelState.IsValid)
            {
                feature.Image = file != null ? Help.Resize(file, 500, 800) : img;
                db.Entry(feature).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(feature);
        }

        // GET: Auth/Features/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feature feature = await db.Features.FindAsync(id);
            if (feature == null)
            {
                return HttpNotFound();
            }
            return View(feature);
        }

        // POST: Auth/Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Feature feature = await db.Features.FindAsync(id);
            db.Features.Remove(feature);
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
