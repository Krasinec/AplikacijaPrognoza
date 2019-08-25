using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KartaTest.Models
{
    public class ModelPrognozaForma
    {
        [Display(Name ="Mjesto:")]
        [Required(ErrorMessage = "Trebate unijeti mjesto za koje želite prognozu.")]
        [MaxLength(60,ErrorMessage ="Unjeli ste prviše dugo ime mjesta.")]
        [MinLength(3,ErrorMessage = "Unjeli ste nedovoljno dugo ime mjesta.")]
        [RegularExpression("^([a-zA-Z-šŠđĐćĆčČžŽ]+ ?)+$",ErrorMessage ="Unjeli ste nedozvoljene znakove.")]
        public string trazeniGrad { get; set; }
        [Required(ErrorMessage ="Trebate odabrati vrstu prognoze")]
        [Display(Name ="Vrsta prognoze:")]
        public string VrstaPrognoze { get; set; }
    }
}