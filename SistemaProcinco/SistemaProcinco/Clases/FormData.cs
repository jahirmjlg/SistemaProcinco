using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Clases
{
    public class FormData
    {
        public int Curso_Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]

        public string txtCurso { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int txtxEmpresa { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int txtxHoras { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public string txtImagen { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int txtCategoria { get; set; }


        public List<int> contenidosSeleccionados { get; set; }
    }
}
