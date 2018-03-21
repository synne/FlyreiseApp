using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyreiserApp.Models
{
    public class Poststeder
    {
        [Key]
        [Display(Name = "Postnr")]
        [Required(ErrorMessage = "Postnr må oppgis")]
        [RegularExpression(@"[0-9]{4}", ErrorMessage = "Postnr må være fire siffer")]
        public string Postnr { get; set; }
        [Display(Name ="Poststed")]
        [Required(ErrorMessage ="Poststed må oppgis")]
        [RegularExpression(@"[A-Za-zÆØÅæøåéäö .\-]{2,20}", ErrorMessage = "Poststed kan kun inneholde bokstaver")]
        public string Poststed { get; set; }

        public virtual List<Kunder> Kunder { get; set; }
    }
}