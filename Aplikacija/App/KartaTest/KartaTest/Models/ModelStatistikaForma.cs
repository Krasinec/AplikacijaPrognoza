using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KartaTest.Models
{
    public class ModelStatistikaForma
    {
        [Required(ErrorMessage ="Morate Odabrati grad.")]
        [Display(Name ="Grad:")]
        public string grad { get; set; }
        [Required(ErrorMessage ="Morate Odabrati statistiku.")]
        [Display(Name = "Statistika:")]
        public string statistika { get; set; }
        [Display(Name ="Podatak:")]
        [Required(ErrorMessage = "Morate Odabrati podatak.")]
        public string podatakStat { get; set; }
        [Required(ErrorMessage = "Morate Odabrati za koje razdoblje je statistika.")]
        [Display(Name = "Statistika za:")]
        public string statistikaZa { get; set; }
        [Required(ErrorMessage = "Morate Odabrati godinu.")]
        [Display(Name = "Godina:")]
        public int godina { get; set; }
        [Range(1,12,ErrorMessage ="Vrijednost mora biti između 1 i 12.")]
        [Display(Name = "Mjesec:")]
        public int mjesec { get; set; }

        
    }
    



}