﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbCargos
    {
        public tbCargos()
        {
            tbEmpleados = new HashSet<tbEmpleados>();
        }

        public int Carg_Id { get; set; }
        public string Carg_Descripcion { get; set; }
        public int Carg_UsuarioCreacion { get; set; }
        public DateTime Carg_FechaCreacion { get; set; }
        public int? Carg_UsuarioModificacion { get; set; }
        public DateTime? Carg_FechaModificacion { get; set; }
        public bool? Carg_Estado { get; set; }

        public virtual tbUsuarios Carg_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Carg_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
    }
}