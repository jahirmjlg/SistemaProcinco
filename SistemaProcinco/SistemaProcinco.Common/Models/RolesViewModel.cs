using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{

    public class ScreenDTO
    {
        public int pant_Id { get; set; }
        public string pant_Descripcion { get; set; }
    }

    public class RoleWithScreens
    {
        public int role_Id { get; set; }
        public string role_Descripcion { get; set; }
        public bool? Role_Imprimir { get; set; }
        public bool? Role_Finalizar { get; set; }
        public List<ScreenDTO> Screens { get; set; }
    }
    public class RolesViewModel
    {
        public bool? Role_Imprimir { get; set; }
        public bool? Role_Finalizar { get; set; }
        public int Role_Id { get; set; }
        public string Role_Descripcion { get; set; }
        public int? Role_UsuarioCreacion { get; set; }
        public DateTime? Role_FechaCreacion { get; set; }
        public int? Role_UsuarioModificacion { get; set; }
   
        public DateTime? Role_FechaModificacion { get; set; }
        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }

        [NotMapped]
        public int? Pant_Id { get; set; }
        [NotMapped]
        public string Pant_Descripcion { get; set; }
    }
}
