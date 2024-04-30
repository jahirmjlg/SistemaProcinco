using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class CursosImpartidosViewModel
    {
        public int CurIm_Id { get; set; }
        public int? Curso_Id { get; set; }
        public int? Empl_Id { get; set; }
        public DateTime? CurIm_FechaInicio { get; set; }
        public DateTime? CurIm_FechaFin { get; set; }
        public int CurIm_UsuarioFinalizacion { get; set; }
        public bool? CurIm_Finalizar { get; set; }
        public int CurIm_UsuarioCreacion { get; set; }
        public DateTime CurIm_FechaCreacion { get; set; }
        public int? CurIm_UsuarioModificacion { get; set; }
        public DateTime? CurIm_FechaModificacion { get; set; }
        public bool? CurIm_Estado { get; set; }
    }
}
