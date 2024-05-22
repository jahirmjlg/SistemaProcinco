﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbTitulosPorEmpleado
    {

        [NotMapped]
        public string Creacion { get; set; }
        [NotMapped]
        public string Modificacion { get; set; }


        [NotMapped]
        public string Titulo { get; set; }
        [NotMapped]
        public string Titl_Descripcion { get; set; }
        [NotMapped]
        public string Titl_ValorMonetario { get; set; }
        [NotMapped]
        public string Empleado { get; set; }
        public int TitPe_Id { get; set; }
        public int? Titl_Id { get; set; }
        public int? Empl_Id { get; set; }
        public int TitPe_UsuarioCreacion { get; set; }
        public DateTime TitPe_FechaCreacion { get; set; }
        public int? TitPe_UsuarioModificacion { get; set; }
        public DateTime? TitPe_FechaModificacion { get; set; }
        public bool? TitPe_Estado { get; set; }

        public virtual tbEmpleados Empl { get; set; }
        public virtual tbUsuarios TitPe_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios TitPe_UsuarioModificacionNavigation { get; set; }
        public virtual tbTitulos Titl { get; set; }
    }
}