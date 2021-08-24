using BiznisLogika.Klase;
using Data.UnitOfWork;
using Domen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Test
{
    [TestClass]
    public class KorisnikServisTest
    {
        private Mock<IUnitOfWork> uow;
        private KorisnikServis service;

        [TestInitialize]
        public void Initialize()
        {
            uow = MoqClass.MoqKlasa.GetMockUnitOfWork();
            service = new KorisnikServis(uow.Object);
        }
        [TestCleanup]
        public void CleanUp()
        {
            uow = null;
            service = null;
        }
        [TestMethod]
        public void Test_SignIn()
        {
            Korisnik korisnik = new Korisnik() { Email = "marko", Sifra = "123" };
            var vracenKorisnik = service.SignIn(korisnik);


            Assert.IsNotNull(vracenKorisnik);
            Assert.AreEqual(korisnik.Email, vracenKorisnik.Email);
        } 
        [TestMethod]
        [DataRow("marko123","1234")]
        [DataRow("ana123","1234")]
        public void Test_SignInException(string email,string password)
        {
            Korisnik korisnik = new Korisnik() { Email = email, Sifra = password};
            
            Assert.ThrowsException<Exception>(() =>service.SignIn(korisnik));
        }
    }
}
