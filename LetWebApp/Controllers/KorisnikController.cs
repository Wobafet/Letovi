using BiznisLogika.Klase;
using Data.UnitOfWork;
using Domen;
using LetWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetWebApp.Controllers
{
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
            return View("CreateUser");
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

                        return RedirectToAction("Index","Let");
                    case TipKorisnika.Agent:

                        return View("Agent");

                    case TipKorisnika.Posetilac:

                        return View("Posetilac");
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
