using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_First_com_ASP.NET_MVC.Models
{
    public class UniversidadeModel
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
        public string Cidade{ get; set; }
        public string UF { get; set; }

        public virtual ICollection<CursoModel> Cursos { get; set; }
    }
}