﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public string Cursos { get; set; }
        [NotMapped]
        public string Empre_Descripcion { get; set; }
        [NotMapped]
        public string Part_Nombre { get; set; }
        [NotMapped]
        public string Empl_DNI { get; set; }
        [NotMapped]
        public string Empl_Nombre { get; set; }
        [NotMapped]
        public int Curso_DuracionHoras { get; set; }
        [NotMapped]
        public string Cate_Descripcion { get; set; }
        [NotMapped]
        public string Curso_Descripcion { get; set; }
        [NotMapped]
        public decimal? PagoEmpleado { get; set; }
        [NotMapped]
        public string Curso_Imagen { get; set; }
        [NotMapped]
        public int? Part_Id { get; set; }

        [NotMapped]
        public string Nombre { get; set; }


        public DateTime? CurIm_FechaInicio { get; set; }
        public DateTime? CurIm_FechaFin { get; set; }
        public int CurIm_UsuarioFinalizacion { get; set; }
        public bool? CurIm_Finalizar { get; set; }
        public int CurIm_UsuarioCreacion { get; set; }
        public DateTime CurIm_FechaCreacion { get; set; }
        public int? CurIm_UsuarioModificacion { get; set; }
        public DateTime? CurIm_FechaModificacion { get; set; }
        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }

        [NotMapped]
        public int Year { get; set; }
        [NotMapped]
        public int Month { get; set; }
        [NotMapped]
        public int TotalCursos { get; set; }

    }
}
