using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class ParticipanteViewModel
    {
        public int Part_Id { get; set; }
        public string Part_DNI { get; set; }
        public int? Empre_Id { get; set; }
        public string Part_Nombre { get; set; }
        public string Part_Apellido { get; set; }
        public string Part_Correo { get; set; }
        public DateTime? Part_FechaNacimiento { get; set; }
        public string Part_Sexo { get; set; }
        public int? Estc_Id { get; set; }
        public string Part_Direccion { get; set; }
        public string Ciud_Id { get; set; }
        public int? Part_UsuarioCreacion { get; set; }
        public DateTime? Part_FechaCreacion { get; set; }
        public int? Part_UsuarioModificacion { get; set; }
        public DateTime? Part_FechaModificacion { get; set; }
        public bool? Part_Estado { get; set; }





        [NotMapped]
        public string UsuarioCreacion { get; set; }

        [NotMapped]
        public string UsuarioModificacion { get; set; }

        [NotMapped]
        public string Esta_Id { get; set; }
        [NotMapped]
        public string Ciud_Descripcion { get; set; }
        [NotMapped]
        public string Sexo { get; set; }

        [NotMapped]
        public string EstadoCivil { get; set; }

        [NotMapped]
        public string Empre_Descripcion { get; set; }
    }
}
