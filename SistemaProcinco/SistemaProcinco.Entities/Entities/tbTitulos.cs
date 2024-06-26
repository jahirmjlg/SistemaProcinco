﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbTitulos
    {
        public tbTitulos()
        {
            tbTitulosPorEmpleado = new HashSet<tbTitulosPorEmpleado>();
        }

        [NotMapped]
        public string UsuarioCreacion { get; set; }
        [NotMapped]
        public string UsuarioModificacion { get; set; }

        public int Titl_Id { get; set; }
        public string Titl_Descripcion { get; set; }
        public decimal? Titl_ValorMonetario { get; set; }
        public int Titl_UsuarioCreacion { get; set; }
        public DateTime Titl_FechaCreacion { get; set; }
        public int? Titl_UsuarioModificacion { get; set; }
        public DateTime? Titl_FechaModificacion { get; set; }
        public bool? Titl_Estado { get; set; }

        public virtual tbUsuarios Titl_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Titl_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbTitulosPorEmpleado> tbTitulosPorEmpleado { get; set; }
    }
}