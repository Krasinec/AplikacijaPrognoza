//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KartaTest.Klase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Statistika
    {
        public System.DateTime datum { get; set; }
        public int grad { get; set; }
        public double temperatura { get; set; }
        public double pritisak { get; set; }
        public double vlaznost { get; set; }
        public double kisa { get; set; }
        public double snijeg { get; set; }
        public double brzinaVjetra { get; set; }
        public double smjerVjetra { get; set; }
    
        public virtual Gradovi Gradovi { get; set; }
    }
}