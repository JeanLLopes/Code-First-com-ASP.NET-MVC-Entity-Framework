using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Code_First_com_ASP.NET_MVC.Models
{
    public class CursoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UniversidadeID { get; set; }


        [ForeignKey("UniversidadeID")]
        public virtual UniversidadeModel Universidade { get; set; }
    }
}