using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class ContenidoPorCursoViewModel
    {
        public int ConPc_Id { get; set; }
        public int? Cont_Id { get; set; }
        public int? Curso_Id { get; set; }
        public int ConPc_UsuarioCreacion { get; set; }
        public DateTime ConPc_FechaCreacion { get; set; }
        public int? ConPc_UsuarioModificacion { get; set; }
        public DateTime? ConPc_FechaModificacion { get; set; }
        public bool? ConPc_Estado { get; set; }
    }
}
