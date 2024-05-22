using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Clases
{
    public class FormDataParticipantes
    {
        public int CurIm_Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int Curso_Id { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]

        public int txtCurso { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public int txtempleado { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime txtfechainicio { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        public DateTime txtfechafinal { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
  


        public List<int> participantesSeleccionados { get; set; }
    }
}
