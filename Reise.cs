using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlyreiserApp.Models
{
    public class Reise
    {
        public int Id { get; set; }
        public Strekning ValgtStrekning { get; set; }
        public Kunder  Kunde { get; set; }



    }
}