using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlyreiserApp.Models
{
    public class DbInit : DropCreateDatabaseAlways<FlyreiserContext>
    {
        protected override void Seed(FlyreiserContext context)
        {
           
            //Strekninger


            var OsloLondon = new Strekning
            {
                Fra = "Oslo (OSL)",
                Til = "London (LHR)",
                Dato = "20.10.2017",
                Avgangstid = "14.50",
                Reisetid = "1.55",
                AntallPlasser = 180,
                Pris = 499
            };
            context.Strekning.Add(OsloLondon);

            var LondonOslo = new Strekning
            {
                Fra = "London (LHR)",
                Til = "Oslo (OSL)",
                Dato = "08.10.2017",
                Avgangstid = "18.30",
                Reisetid = "1.50",
                AntallPlasser = 180,
                Pris = 599
            };
            context.Strekning.Add(LondonOslo);
            
            var OsloParis = new Strekning
            {
                Fra = "Oslo (OSL)",
                Til = "Paris (CDG)",
                Dato = "06.10.2017",
                Avgangstid = "11.00",
                Reisetid = "2.50",
                AntallPlasser = 200,
                Pris = 699
            };
            context.Strekning.Add(OsloParis);

            var ParisOslo = new Strekning
            {
                Fra = "Paris (CDG)",
                Til = "London (LHR)",
                Dato = "10.10.2017",
                Avgangstid = "20.45",
                Reisetid = "2.10",
                AntallPlasser = 200,
                Pris = 699
            };
            context.Strekning.Add(ParisOslo);
            
            var OsloFrankfurt = new Strekning
            {
                Fra = "Oslo (TRF)",
                Til = "Frankfurt (FRA)",
                Dato = "11.10.2017",
                Avgangstid = "09.00",
                Reisetid = "2.05",
                AntallPlasser = 200,
                Pris = 499
            };
            context.Strekning.Add(OsloFrankfurt);
            
            var FrankfurtOslo = new Strekning
            {
                Fra = "Frankfurt (FRA)",
                Til = "Oslo (OSL)",
                Dato = "15.10.2017",
                Avgangstid = "18.55",
                Reisetid = "2.05",
                AntallPlasser = 200,
                Pris = 499
            };
            context.Strekning.Add(FrankfurtOslo);
            
            var OsloMadrid = new Strekning
            {
                Fra = "Oslo (OSL)",
                Til = "Madrid (MAD)",
                Dato = "12.10.2017",
                Avgangstid = "08.55",
                Reisetid = "2.45",
                AntallPlasser = 200,
                Pris = 499
            };
            context.Strekning.Add(OsloMadrid);

            var MadridOslo = new Strekning
            {
                Fra = "Madrid (MAD)",
                Til = "Oslo (OSL)",
                Dato = "16.10.2017",
                Avgangstid = "19.55",
                Reisetid = "2.45",
                AntallPlasser = 200,
                Pris = 499
            };
            context.Strekning.Add(MadridOslo);

            base.Seed(context);
            context.SaveChanges();
        }
    }
}