using Dari.Domain.Entities;
using Dari.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DariTn.web.Controllers
{
    public class CategorieMeubController : Controller
    {
        ICategorieService Service = null;
        public CategorieMeubController()
        {
            Service = new CategorieService();
           

        }
        // GET: CategorieMeub
        public ActionResult Index()
        {
            return View(Service.GetMany());
        }

        // GET: CategorieMeub/Details/5
        public ActionResult Details(int id)
        {
            return View(Service.GetById(id));
        }

        // GET: CategorieMeub/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: CategorieMeub/Create
        [HttpPost]
        public ActionResult Create(CategorieMeub cat)
        {
            try
            {
                // TODO: Add insert logic here

                Service.Add(cat);
                Service.Commit();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        // GET: CategorieMeub/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Service.GetById(id));
        }

        // POST: CategorieMeub/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategorieMeub cat)

        {
            try
            {
                // TODO: Add update logic here
                Service.Update(cat);
                Service.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieMeub/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Service.GetById(id));
        }

        // POST: CategorieMeub/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                // TODO: Add delete logic here
                Service.Delete(Service.GetById(id));
                Service.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
