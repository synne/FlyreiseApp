using FlyreiserApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace FlyreiserApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Session["Strekning"] = new Strekning();
            return View();
        }
     
        //Returnerer index-view hvor brukeren kan velge strekning
        [HttpPost]
        public ActionResult settStrekning(Strekning valgtStrekning)
        {
            Session["Strekning"] = valgtStrekning;
            return RedirectToAction("FinnReise");
        }

        //Returnerer viewt som lar brukeren legge inn kundeinformasjon og bekrefte reisen.
        public ActionResult FinnReise()
        {
            return View();
        }

        
        //Kundeopplysninger fylles i i FinnReise-viewt og lagres til databasen her
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LagreKunde(Kunder model, Strekning model2)
        {
            model2 = (Strekning)Session["Strekning"];
              using (FlyreiserContext db = new FlyreiserContext())
                {
                    try
                    {
                        Kunder nyKunde = new Kunder();
                        nyKunde.Fornavn = model.Fornavn;
                        nyKunde.Etternavn = model.Etternavn;
                        nyKunde.Epost = model.Epost;
                        nyKunde.Adresse = model.Adresse;
                        nyKunde.Telefonnr = model.Telefonnr;
                        nyKunde.Postnr = model.Postnr;
                        nyKunde.Kortnummer = model.Kortnummer;
                        nyKunde.Utlopsdato = model.Utlopsdato;
                        nyKunde.CVC = model.CVC;

                        db.Kunder.Add(nyKunde);
                        db.SaveChanges();

                        Reise nyReise = new Reise();
                        nyReise.Kunde = nyKunde;
                        nyReise.ValgtStrekning = model2;  //her blir det opprettet en ny strekning

                        db.Reise.Add(nyReise);
                        db.SaveChanges();

                        return RedirectToAction("VisInfo");
                    }
                    catch (Exception feil)
                    {
                        //legge noe annet her?
                        return RedirectToAction("VisInfo");
                        
                    }
                }
            }
         
        //Viser reiseinformasjon
        public ActionResult VisInfo()
        {
            return View();
        }

        //henter strekningen og gjør den om til en json-streng
        public string hentStrekning(string Fra, string Til)
        {
            using (var db = new FlyreiserContext())
            {
                List<Strekning> alleStrekninger = db.Strekning.Where(
                    s => s.Til == Til && s.Fra == Fra).ToList();

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleStrekninger);
            }
        }

        //kalles på fra Index-viewet, brukes til å hente alle Fra-flyplasser
        public string hentAlleFraFlyplasser()
        {
            using (var db = new FlyreiserContext())
            {
                List<Strekning> alleFly = db.Strekning.ToList();

                var alleFraFly = new List<string>();

                foreach (Strekning f in alleFly)
                {
                    string funnetStrekning = alleFraFly.FirstOrDefault(fl => fl.Contains(f.Fra));
                    if (funnetStrekning == null)
                    {
                        // ikke funnet strekning i listen, legg den inn i listen
                        alleFraFly.Add(f.Fra);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFraFly);
            }
        }


        //kalles på fra Index-viewet. Brukes til å hente alle til-flyplasser
        public string hentAlleTilFlyplasser(string fraFlyplass)
        {
            using (var db = new FlyreiserContext())
            {
                List<Strekning> alleFly = db.Strekning.ToList();

                var alleTilFly = new List<string>();

                foreach (Strekning f in alleFly)
                {
                    if (f.Fra == fraFlyplass)
                    {
                        string funnetStrekning = alleTilFly.FirstOrDefault(fl => fl.Contains(f.Til));
                        if (funnetStrekning == null)
                        {
                            // ikke funnet strekning i listen, legg den inn i listen
                            alleTilFly.Add(f.Til);
                        }
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleTilFly);
            }
        }

    }
}
