using BiznisLogika.Exceptions;
using BiznisLogika.Klase;
using Data.UnitOfWork;
using Domen;
using LetWebApp.Filteri;
using LetWebApp.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        private IHubContext<LetHub> context;
        public LetController(IHubContext<LetHub> context)
        {
            this.context = context;
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
            try
            {
                servis.Add(let);
            }
            catch (DestinationException )
            {
                let.LetId = -1;
            }
            catch (DateException )
            {
                let.LetId = -2;
            }

            return View(let);
        }
        [HttpGet]
        public List<Let> GetFlightsByCriteria(Mesto mestoPolaska,Mesto mestoDolaska)
        {
            var letovi = servis.GetByCondition(l => l.MestoPolaska == mestoPolaska && l.MestoDolaska == mestoDolaska
                                                && l.BrojMesta>0);

            return letovi;
        }

        [HttpDelete]
        public void DeleteFlight(int letId)
        {
            var let = servis.Find(l => l.LetId == letId);
            servis.Delete(let);

            context.Clients.All.SendAsync("deleteFlight", letId);
        }

    }
}
