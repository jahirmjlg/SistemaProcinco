using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class InformeEmpleadosViewModel
    {
        public int InfoE_Id { get; set; }
        public int? InfoE_Calificacion { get; set; }
        public int? Empl_Id { get; set; }
        [NotMapped]
        public string Nombre { get; set; }
        public int? Curso_Id { get; set; }
        [NotMapped]
        public string Cursos { get; set; }
        public string InfoE_Observaciones { get; set; }
        public int? InfoE_UsuarioCreacion { get; set; }
        public DateTime? InfoE_FechaCreacion { get; set; }
        public int? InfoE_UsuarioModificacion { get; set; }
        public DateTime? InfoE_FechaModificacion { get; set; }
        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }
    }
}
