using BiznisLogika.Exceptions;
using BiznisLogika.Klase;
using Data.UnitOfWork;
using Domen;
using LetWebApp.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetWebApp.Controllers
{
    public class RezervacijaController : Controller
    {
        private IHubContext<LetHub> context;
        private RezervacijaServis servis;

        public RezervacijaController(IHubContext<LetHub> context)
        {
            this.context = context;
            servis = new RezervacijaServis(new LetUnitOfWork(new LetContext()));
        }
        public IActionResult Reservation()
        {
            return View();
        }
        public string FlightReserve(int id,int brojMesta)
        {
          int ?korisnikId =  HttpContext.Session.GetInt32("korisnikId");
            try
            {
                servis.CheckDate(id);
                Rezervacija rezervacija = new Rezervacija()
                {
                    KorisnikId = (int)korisnikId,
                    LetId = id,
                    StatusLeta = StatusLeta.NaCekanju,
                    BrojMesta = brojMesta
                };

                servis.Add(rezervacija);
                Rezervacija rez = servis.Find(r => r.KorisnikId == rezervacija.KorisnikId && r.LetId == rezervacija.LetId);

                var noviObjekat = new
                {
                    korisnikId = rez.KorisnikId,
                    letId = rez.LetId,
                    mestoDolaska = rez.Let.MestoDolaska.ToString(),
                    mestoPolaska = rez.Let.MestoPolaska.ToString(),
                    brojMesta = rez.BrojMesta,
                    datum = rez.Let.Datum.ToShortDateString(),
                    email = rez.Korisnik.Email
                };
                context.Clients.All.SendAsync("addNewReservation", noviObjekat);
                return null;
            }
            catch (DateException de)
            {
                return de.Message;
            }
            catch (ReservationException re)
            {
                return re.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IActionResult ShowReservation()
        {
            int ?korisnikId = HttpContext.Session.GetInt32("korisnikId");
            var rezervacije = servis.GetByCondition(r => r.KorisnikId == korisnikId);

            return View("UserReservations",rezervacije);
        }

      public IActionResult ShowAllReservation()
        {

            var rezervacije = servis.GetAll();
            return View("AllReservations", rezervacije);
        }
        [HttpPut]
       public void  AllowReservation(int letId,int korisnikId)
        {
            servis.ChangeStatus(letId, korisnikId);
            context.Clients.All.SendAsync("updateStatus",letId,korisnikId);
        }
    }
}
