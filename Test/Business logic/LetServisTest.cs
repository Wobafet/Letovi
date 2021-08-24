using BiznisLogika.Exceptions;
using BiznisLogika.Klase;
using Data.UnitOfWork;
using Domen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Business_logic
{
    [TestClass]
   public class LetServisTest
    {
        private Mock<IUnitOfWork> uow;
        private LetServis service;

        [TestInitialize]
        public void Initialize()
        {
            uow = MoqClass.MoqKlasa.GetMockUnitOfWork();
            service = new LetServis(uow.Object);
        }
        [TestCleanup]
        public void CleanUp()
        {
            uow = null;
            service = null;
        }
        [TestMethod]
        [DataRow(Mesto.Beograd)]
        [DataRow(Mesto.Kraljevo)]
        [DataRow(Mesto.Nis)]
        public void Test_AddDestinationException(Mesto mesto)
        {
            Let let = new Let()
            {
                MestoDolaska = mesto,
                MestoPolaska = mesto,
            };

            Assert.ThrowsException<DestinationException>(()=>service.Add(let));
          
        }
        [TestMethod]
        public void Test_AddDateException()
        {
            Let let = new Let()
            {
                MestoDolaska = Mesto.Nis,
                MestoPolaska = Mesto.Beograd,
                Datum = DateTime.Now
            };

            Assert.ThrowsException<DateException>(() => service.Add(let));

        }
    }
}
