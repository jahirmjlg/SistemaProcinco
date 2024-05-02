using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class CursosViewModel
    {
        public int Curso_Id { get; set; }
        public string Curso_Descripcion { get; set; }
        public int? Curso_DuracionHoras { get; set; }
        public string Curso_Imagen { get; set; }
        public int? Cate_Id { get; set; }
        [NotMapped]
        public string Categoria { get; set; }
        public int Curso_UsuarioCreacion { get; set; }
        public DateTime Curso_FechaCreacion { get; set; }
        public int? Curso_UsuarioModificacion { get; set; }
        public DateTime? Curso_FechaModificacion { get; set; }
        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }
    }
}
