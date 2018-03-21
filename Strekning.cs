using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyreiserApp.Models
{

    public class Strekning
    {
        public int Id { get; set; }
        public string Fra { get; set; }
        public string Til { get; set; }
        public string Dato { get; set; }
        public string Avgangstid { get; set; }
        public string Reisetid { get; set; }
        // public string Ankomsttid {get; set;}
        public int AntallPlasser { get; set; }
        public int Pris { get; set; }

        public virtual List<Reise> Reise { get; set; }
        
    }
}