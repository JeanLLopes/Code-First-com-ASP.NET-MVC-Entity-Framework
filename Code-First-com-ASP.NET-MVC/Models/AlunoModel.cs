using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Code_First_com_ASP.NET_MVC.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CursoID { get; set; }

        [ForeignKey("CursoID")]
        public virtual CursoModel Curso { get; set; }
    }
}