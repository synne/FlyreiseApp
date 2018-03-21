using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlyreiserApp.Models
{
    public class Kunder
    {
        public int Id { get; set; }
     
        [Display(Name = "Fornavn")]
        [Required(ErrorMessage = "Fornavn må oppgis")]
        [RegularExpression(@"[A-Za-zÆØÅæøåéäö .\-]{2,20}", ErrorMessage = "Fornavn kan kun inneholde bokstaver")]
        public string Fornavn { get; set; }

        [Display(Name = "Etternavn")]
        [Required(ErrorMessage = "Etternavn må oppgis")]
        [RegularExpression(@"[A-Za-zÆØÅæøåéäö .\-]{2,20}", ErrorMessage = "Etternavn kan kun inneholde bokstaver")]
        public string Etternavn { get; set; }

        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Telefonnummer må oppgis")]
        [RegularExpression(@"[0-9]{8}", ErrorMessage = "Telefonnummer må være åtte siffer")]
        public string Telefonnr { get; set; }

        [Display(Name = "E-post")]
        [Required(ErrorMessage = "E-post må oppgis")]
        [RegularExpression(@"([\w\.\-]+)@([\w\-.]+)((\.(\w){2,3})+)", ErrorMessage = "E-post må være en gyldig adresse på formatet example@example.com")]
        public string Epost { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Adresse må oppgis")]
        [RegularExpression(@"[A-Za-zæøåÆØÅ0-9]+(?:\s[A-Za-z0-9æøåÆØÅ'_-]+)", ErrorMessage = "Adresse må inneholdet bokstaver og tall, f.eks Osloveien 82")]
        public string Adresse { get; set; }

        [Display(Name = "Kortnummer")]
        [Required(ErrorMessage = "Kortnummer må oppgis")]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Kortnummer må inneholde 11 siffer")]
        public long Kortnummer { get; set; }

        [Display(Name = "Utløpsdato (MMYY)")]
        [Required(ErrorMessage = "Utløpsdato må oppgis")]
        [RegularExpression(@"[0-1][0-9][1-2][0-9]", ErrorMessage = "Utløpsdato må bestå av gyldig måned og år og oppgis i riktig format(MMYY)")]
        public int Utlopsdato { get; set; }

        [Display(Name = "CVC")]
        [Required(ErrorMessage = "CVV/CVC/CID må oppgis")]
        [RegularExpression(@"[0-9]{3}", ErrorMessage = "CVV/CVC/CID på 3 siffer må oppgis")]
        public int CVC { get; set; }

        [Display(Name = "Postadresse")]
        public virtual Poststeder Postnr { get; set; }
        public virtual List<Reise> Reise { get; set; }


    }
}