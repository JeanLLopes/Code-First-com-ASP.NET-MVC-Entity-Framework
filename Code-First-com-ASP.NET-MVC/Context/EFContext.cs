using Code_First_com_ASP.NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Code_First_com_ASP.NET_MVC.Context
{
    public class EFContext : DbContext
    {
        //ctor
        public EFContext() : base("EntitiFramewordConnection")
        {
            
            
        }

        public DbSet<UniversidadeModel> Universidades { get; set; }
        public DbSet<CursoModel> Cursos { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }

        //DESABILITAR A PLURALIZAÇAÕ DOS TABELAS QUE SERÃO CRIADAS
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}