//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotekaAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Iznajmljivanje
    {
        public int IznajmljivanjeID { get; set; }
        public int KorisnikID { get; set; }
        public int KnjigaID { get; set; }
        public System.DateTime DatumIznajmljivanja { get; set; }
    
        public virtual Knjige Knjige { get; set; }
        public virtual Korisnici Korisnici { get; set; }
    }
}