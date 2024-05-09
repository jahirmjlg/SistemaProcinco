using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class PantallasAndRolesViewModel
    {
        [NotMapped]
        public int Role_Id { get; set; }
        public int Pant_Id { get; set; }
        public string Pant_Descripcion { get; set; }
    }
}
