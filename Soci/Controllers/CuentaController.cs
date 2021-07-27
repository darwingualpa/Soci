using Microsoft.AspNetCore.Mvc;
using Soci.Data;
using Soci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soci.Controllers
{
    public class CuentaController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CuentaController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            List<Cuentum> cuentas = new List<Cuentum>();

            cuentas = _applicationDbContext.Cuentum.ToList();

            return View(cuentas);
        }
        public ActionResult Create()

        {


            return View();
        }


        [HttpPost]

        public ActionResult Create(Cuentum cuenta)
        {
            try
            {
                _applicationDbContext.Add(cuenta);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return View();
            }


            return RedirectToAction("Index");
        }

    }

}