﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class EmpleadosViewModel
    {
        public int Empl_Id { get; set; }
        public string Empl_DNI { get; set; }
        public int? Carg_Id { get; set; }
        public string Empl_Nombre { get; set; }
        public string Empl_Apellido { get; set; }
        public string Empl_Correo { get; set; }
        public DateTime? Empl_FechaNacimiento { get; set; }
     
        public string Empl_Sexo { get; set; }
        [NotMapped]
        public string Sexo { get; set; }
        public int? Estc_Id { get; set; }
        [NotMapped]
        public string EstadoCivil { get; set; }
        public string Empl_Direccion { get; set; }
        public string Ciud_Id { get; set; }
        [NotMapped]
        public string Ciud_Descripcion { get; set; }
        public int? Empl_UsuarioCreacion { get; set; }
        public DateTime? Empl_FechaCreacion { get; set; }
        public int? Empl_UsuarioModificacion { get; set; }
        public DateTime? Empl_FechaModificacion { get; set; }
        public decimal? Empl_SalarioHora { get; set; }

        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }

        [NotMapped]
        public string Esta_Id { get; set; }

        [NotMapped]
        public string Titl_Descripcion { get; set; }
        [NotMapped]
        public int Titl_Id { get; set; }
    }
}
