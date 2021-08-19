using BiznisLogika.Klase;
using Data.UnitOfWork;
using Domen;
using LetWebApp.Filteri;
using LetWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetWebApp.Controllers
{
    [LoggedUserFillter]
    public class KorisnikController : Controller
    {
        private KorisnikServis servis;

        public KorisnikController()
        {
            servis = new KorisnikServis(new LetUnitOfWork(new LetContext()));
        }
        public IActionResult SignIn()
        {
            return View("Sign in");
        }
       public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(Korisnik korisnik)
        {
            servis.Add(korisnik);
            return View(korisnik);
        }
    
       
        [HttpPost]
        public IActionResult SignIn(Korisnik korisnik)
        {
            try
            {
                TipKorisnika tip = servis.SignIn(korisnik);
                switch (tip)
                {
                    case TipKorisnika.Administrator:
                        HttpContext.Session.SetInt32("tipKorisnika",0);

                        return RedirectToAction("ShowFlights", "Let");
                    case TipKorisnika.Agent:

                        HttpContext.Session.SetInt32("tipKorisnika",1);
                        return RedirectToAction("CreateFlight","Let");

                    case TipKorisnika.Posetilac:

                        return RedirectToAction("Reservation","Rezervacija");
                    default:

                        return View();
                }
            }
            catch (Exception se)
            {

                ModelState.AddModelError(string.Empty, se.Message);
                return View("Sign in");
            }
          
        }
    }
}
