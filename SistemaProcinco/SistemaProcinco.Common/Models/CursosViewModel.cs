using System;
using System.Collections.Generic;
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
        public int Curso_UsuarioCreacion { get; set; }
        public DateTime Curso_FechaCreacion { get; set; }
        public int? Curso_UsuarioModificacion { get; set; }
        public DateTime? Curso_FechaModificacion { get; set; }
        public bool? Curso_Estado { get; set; }
    }
}
