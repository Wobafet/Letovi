using BiznisLogika.Klase;
using Data.UnitOfWork;
using Domen;
using LetWebApp.Filteri;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LetWebApp.Controllers
{
    [LoggedUserFillter]
    public class LetController : Controller
    {

        private LetServis servis;

        public LetController()
        {
            servis = new LetServis(new LetUnitOfWork(new LetContext()));
        }
        public IActionResult Index()
        {
            return View("Letovi",null);
        }
        public IActionResult ShowFlights()
        {
            var letovi = servis.GetAll();
            return View("Letovi",letovi);
        } 
        public IActionResult CreateFlight()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFlight(Let let)
        {
            servis.Add(let);
            return View(let);
        }
        [HttpGet]
       public List<Let> GetFlightsByCriteria(Mesto mestoPolaska,Mesto mestoDolaska)
        {
            var letovi = servis.GetByCondition(l => l.MestoPolaska == mestoPolaska && l.MestoDolaska == mestoDolaska
                                                && l.BrojMesta>0);

            
            return letovi;
        }


    }
}
