using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class PantallasPorRolesViewModel
    {
        public int PaPr_Id { get; set; }
        public int Pant_Id { get; set; }
        [NotMapped]
        public string Pantalla { get; set; }
        public int Role_Id { get; set; }
        [NotMapped]
        public string Rol { get; set; }
        public int? PaPr_UsuarioCreacion { get; set; }
        public DateTime? PaPr_FechaCreacion { get; set; }
        public int? PaPr_UsuarioModificacion { get; set; }
        public DateTime? PaPr_FechaModificacion { get; set; }
        public bool? PaPr_Estado { get; set; }

        [NotMapped]
        public string Creacion { get; set; }

        [NotMapped]
        public string Modificacion { get; set; }
    }
}
