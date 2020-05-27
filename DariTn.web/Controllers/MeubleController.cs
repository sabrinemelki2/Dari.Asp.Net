using Dari.Domain.Entities;
using Dari.service;
using Dari.Service;
using DariTn.web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DariTn.web.Controllers
{
    public class MeubleController : Controller
    {
        
        ICategorieService  serviceCat;
        IMeubleService Service = null;

        public MeubleController()
        {
            Service = new MeubleService();
            serviceCat = new CategorieService();
            
        }
        // GET: Meuble
        public ActionResult Index()
        {
            return View(Service.GetMany());
        }

        // GET: Meuble/Details/5
        public ActionResult Details(int id)
        {
            return View(Service.GetById(id));
        }

        // GET: Meuble/Create
        public ActionResult Create()
        {
            ViewBag.CategoryMeubId = new SelectList(serviceCat.GetAll(), "CategoryMeubId", "Name");
            return View();

        }

        // POST: Meuble/Create
        [HttpPost]
        public ActionResult Create(Meuble MVM, HttpPostedFileBase file)
        {
            try
            {
               
                    MVM.Image = file.FileName;
                if (file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/"), file.FileName);
                    file.SaveAs(path);
                }
                Service.Add(MVM);
                Service.Commit();

                return RedirectToAction("Index");
            
               
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

        }

        // GET: Meuble/Edit/5
        public ActionResult Edit(int id)
        {


            ViewBag.CategoryId = new SelectList(serviceCat.GetAll(), "CategoryMeubId", "Name");

            if (id > 0)
            {
                ViewBag.Title = "Edit";
                return View(Service.GetById(id));
            }
            ViewBag.Title = "Create";
            return View();
        }

        // POST: Meuble/Edit/5
        [HttpPost]
        public ActionResult Edit(Meuble MVM, HttpPostedFileBase Image) // FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (!string.IsNullOrEmpty(Image.FileName))
                {
                    MVM.Image = Image.FileName;
                    var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                    Image.SaveAs(path);
                }
                Service.Update(MVM);
                Service.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Meuble/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Service.GetById(id));
        }

        // POST: Meuble/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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

        public ActionResult statistique()
        {




            int A = 0;
            int B = 0;
            int C = 0;

            var MyCategory = serviceCat.GetAll();
            List<CategorieMeub> cc = new List<CategorieMeub>();
            foreach (var item in MyCategory)
            {
                cc.Add(item);
            }
            List<Meuble> p1 = new List<Meuble>();
            List<Meuble> p2 = new List<Meuble>();
            List<Meuble> p3 = new List<Meuble>();
            foreach (var itemm in Service.GetAll().Where(e => e.CategoryMeubId == cc[0].CategoryMeubId))
            {
                p1.Add(itemm);
            }
            foreach (var itemm in Service.GetAll().Where(e => e.CategoryMeubId == cc[1].CategoryMeubId))
            {
                p2.Add(itemm);
            }
            foreach (var itemm in Service.GetAll().Where(e => e.CategoryMeubId == cc[2].CategoryMeubId))
            {
                p3.Add(itemm);
            }



            ViewData["countA"] = p1.Count;
            ViewData["countB"] = p2.Count;
            ViewData["countC"] = p3.Count;





            return View();
        }


        [HttpPost]
        public ActionResult Index(string rech)
        {

            var list = Service.GetAll();

            if (!String.IsNullOrEmpty(rech))
            { 
                list = list.Where(m => m.Titre.Contains(rech)).ToList();
                
            }

                return View(list);
            
        }
    }

   
}
