using Data.Implementacija.Interfejsi;
using Data.Implementacija.Repozitorijumi;
using Data.UnitOfWork;
using Domen;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.MoqClass
{
    public class MoqKlasa
    {
        private  static List<Let> letovi =new  List<Let>()
            {
                new Let()
        {
            LetId = 1,
                MestoDolaska = Mesto.Beograd,
                MestoPolaska = Mesto.Kraljevo,
                BrojMesta = 10,
                BrojPresedanja = 2,
                Datum = DateTime.Now
                },
                 new Let()
        {
            LetId = 2,
                MestoDolaska = Mesto.Beograd,
                MestoPolaska = Mesto.Nis,
                BrojMesta = 20,
                BrojPresedanja = 0,
                Datum = new DateTime(2021, 9, 10)
                },
                  new Let()
        {
            LetId = 3,
                MestoDolaska = Mesto.Pristina,
                MestoPolaska = Mesto.Nis,
                BrojMesta = 30,
                BrojPresedanja = 10,
                Datum = new DateTime(2018, 4, 11)
                }


    };
        public static List<Korisnik> Korisnici()
        {
            return new List<Korisnik>()
            {
                new Korisnik()
                {
                    KorisnikId=1,
                    Email="marko",
                    Sifra="123",
                    TipKorisnika=TipKorisnika.Posetilac

                },
                new Korisnik()
                {
                    KorisnikId=2,
                    Email="ana",
                    Sifra="123",
                    TipKorisnika=TipKorisnika.Posetilac

                },
                new Korisnik()
                {
                    KorisnikId=3,
                    Email="agent",
                    Sifra="123",
                    TipKorisnika=TipKorisnika.Agent

                },
                new Korisnik()
                {
                    KorisnikId=4,
                    Email="admin",
                    Sifra="123",
                    TipKorisnika=TipKorisnika.Administrator

                }

            };
        }
       
        public static Mock<IKorisnik> GetMockKorisnikRepository()
        {
            var customers = new List<Korisnik>();
            var mockKorisnikRepo = new Mock<IKorisnik>();

            mockKorisnikRepo.Setup(r => r.Find(It.IsAny<Predicate<Korisnik>>())).Returns((Predicate<Korisnik> p) =>
            {
                return Korisnici().Find(p);
            });

            mockKorisnikRepo.Setup(r => r.Add(It.IsAny<Korisnik>())).Callback((Korisnik k) =>
            {
                k.KorisnikId = 20;
                Korisnici().Add(k);
            }).Verifiable();

            return mockKorisnikRepo;
        }
        public static Mock<ILet> GetMockLetRepository()
        {
            var mockLetRepository = new Mock<ILet>();

            mockLetRepository.Setup(x => x.Add(It.IsAny<Let>())).Callback((Let let) =>
            {
                letovi.Add(let);
            });
            //mockLetRepository.Setup(x => x. (It.IsAny<string>())).Returns((string title) =>
            //{
            //    return Books().FindAll(b => b.Title.Contains(title));
            //});

            //mockLetRepository.Setup(x => x.Find(It.IsAny<Predicate<Book>>())).Returns((Predicate<Book> p) =>
            //{
            //    return Books().Find(p);
            //});

            return mockLetRepository;
        }
 
        public static Mock<IUnitOfWork> GetMockUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(uow => uow.RepositoryKorisnik).Returns(GetMockKorisnikRepository().Object);
            mockUnitOfWork.Setup(uow => uow.RepositoryLet).Returns(GetMockLetRepository().Object);

            mockUnitOfWork.Setup(uow => uow.Commit()).Verifiable();

            return mockUnitOfWork;
        }
        
    }
}
