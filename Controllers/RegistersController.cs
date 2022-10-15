using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Data;
using WebAppMVC.Models.EFModel;
using WebAppMVC.Models.Service;
using WebAppMVC.Models.ViewModel;

namespace WebAppMVC.Controllers
{
    public class RegistersController : Controller
    {
        private WebAppMVCContext db = new WebAppMVCContext();

        // GET: Registers
        public ActionResult Index()
        {
            return View(db.Registers.ToList());
        }

        // GET: Registers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            try
            {
                var register = new RegisterService().Find(id.Value);
                return View(register);
            }
            catch (Exception)
            {

               return HttpNotFound();
            }


            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Register register = db.Registers.Find(id);
            //if (register == null)
            //{
            //    return HttpNotFound();
            //}
           
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterVM register)
        {
            try
            {
        
                //var data = db.Registers.FirstOrDefault(x => x.Email == register.Email);
                //if (data != null)
                //{
                //   throw new Exception("這個email已經報名過了");
                //}

                //#endregion
                //#region
                //register.CreateTime = DateTime.Now;
                //#endregion
                //db.Registers.Add(register);
                //db.SaveChanges();
                new RegisterService().Create(register.VM2Entity());
            }
            catch (Exception)
            {

                ModelState.AddModelError(string.Empty, "這個Email 已經報名過了 無法在報名");
            }




         



            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(register);
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
