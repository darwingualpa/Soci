using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soci.Data;
using Soci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soci.Controllers
{
    public class SociosController : Controller

    {


        private readonly ApplicationDbContext _applicationDbContext;

        public SociosController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
       
        public ActionResult Index()
        {
            List<Socio> socios = new List<Socio>();

            socios = _applicationDbContext.Socio.ToList();

            return View(socios);
        }

      
        public ActionResult Details(string id)
        {
            Socio socio = _applicationDbContext.Socio.FirstOrDefault(D => D.Cedula == id);
            return View();
        }

     
        public ActionResult Create()

        {
            

            return View();
        }

      
        [HttpPost]
     
        public ActionResult Create(Socio socio)
        {
            try
            {
                _applicationDbContext.Add(socio);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return View();
            }
          

            return RedirectToAction("Index");
        }

     
        public ActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {

                return RedirectToAction("Index");
            }
            Socio socio = _applicationDbContext.Socio.Where(d => d.Cedula == id).FirstOrDefault();
            if(socio == null)
                return RedirectToAction("Index");
            return View(socio);
        }

       
        [HttpPost]
     
        public ActionResult Edit(string id, Socio socio)
        {
            if (string.IsNullOrEmpty(id) )
                return RedirectToAction("Index");
            try
            {
                _applicationDbContext.Update(socio);
                _applicationDbContext.SaveChanges();

            }
            catch(Exception)
            {
                return View(socio);
            }
            return RedirectToAction("Index");
        }

       
        public ActionResult Delete(int id)
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Desactivar(string id)
        {
            if (string.IsNullOrEmpty(id))

                return RedirectToAction("Index");
            Socio socio = _applicationDbContext.Socio.Where(D => D.Cedula == id).FirstOrDefault();
            try
            {
                socio.Estado = 0;
                _applicationDbContext.Update(socio);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return RedirectToActionPermanent("Index");
            }

            return RedirectToActionPermanent("Index");

        }
       
        public IActionResult Activar(string id)
        {
            if (string.IsNullOrEmpty(id))

                return RedirectToAction("Index");
            Socio socio = _applicationDbContext.Socio.Where(D => D.Cedula == id).FirstOrDefault();
            try
            {
                socio.Estado = 1;
                _applicationDbContext.Update(socio);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return RedirectToActionPermanent("Index");
            }

            return RedirectToActionPermanent("Index");

        }
    }
}
