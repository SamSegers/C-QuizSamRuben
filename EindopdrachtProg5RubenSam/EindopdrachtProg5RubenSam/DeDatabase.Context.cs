﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EindopdrachtProg5RubenSam
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EindopdrachtQuizDbEntities : DbContext
    {
        public EindopdrachtQuizDbEntities()
            : base("name=EindopdrachtQuizDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Antwoord> Antwoords { get; set; }
        public virtual DbSet<Quiz> Quizs { get; set; }
        public virtual DbSet<Vraag> Vraags { get; set; }
    }
}
