﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbPantallasPorRoles
    {

        //NOTMAPPED
        [NotMapped]
        public string Rol { get; set; }
        [NotMapped]
        public string Pantalla { get; set; }
        [NotMapped]
        public string Creacion { get; set; }

        [NotMapped]
        public string Modificacion { get; set; }


        public int PaPr_Id { get; set; }
        public int Pant_Id { get; set; }
        public int Role_Id { get; set; }
        public int? PaPr_UsuarioCreacion { get; set; }
        public DateTime? PaPr_FechaCreacion { get; set; }
        public int? PaPr_UsuarioModificacion { get; set; }
        public DateTime? PaPr_FechaModificacion { get; set; }
        public bool? PaPr_Estado { get; set; }

        public virtual tbUsuarios PaPr_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios PaPr_UsuarioModificacionNavigation { get; set; }
        public virtual tbPantallas Pant { get; set; }
        public virtual tbRoles Role { get; set; }
    }
}