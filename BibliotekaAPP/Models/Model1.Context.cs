﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BibliotekaDBEntities : DbContext
    {
        public BibliotekaDBEntities()
            : base("name=BibliotekaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Iznajmljivanje> Iznajmljivanjes { get; set; }
        public virtual DbSet<Knjige> Knjiges { get; set; }
        public virtual DbSet<Korisnici> Korisnicis { get; set; }
    }
}
