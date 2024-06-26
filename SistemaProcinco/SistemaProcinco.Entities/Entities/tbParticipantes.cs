﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaProcinco.Entities.Entities
{
    public partial class tbParticipantes
    {
        public tbParticipantes()
        {
            tbParticipantesPorCursoo = new HashSet<tbParticipantesPorCursoo>();
        }

        [NotMapped]
        public string UsuarioCreacion { get; set; }

        [NotMapped]
        public string UsuarioModificacion { get; set; }

        [NotMapped]
        public string Esta_Id { get; set; }
        [NotMapped]
        public string Ciud_Descripcion { get; set; }
        [NotMapped]
        public string Sexo { get; set; }

        [NotMapped]
        public string EstadoCivil { get; set; }

        [NotMapped]
        public string Empre_Descripcion { get; set; }


        public int Part_Id { get; set; }
        public string Part_DNI { get; set; }
        public int? Empre_Id { get; set; }
        public string Part_Nombre { get; set; }
        public string Part_Apellido { get; set; }
        public string Part_Correo { get; set; }
        public DateTime? Part_FechaNacimiento { get; set; }
        public string Part_Sexo { get; set; }
        public int? Estc_Id { get; set; }
        public string Part_Direccion { get; set; }
        public string Ciud_Id { get; set; }
        public int? Part_UsuarioCreacion { get; set; }
        public DateTime? Part_FechaCreacion { get; set; }
        public int? Part_UsuarioModificacion { get; set; }
        public DateTime? Part_FechaModificacion { get; set; }
        public bool? Part_Estado { get; set; }

        public virtual tbCiudades Ciud { get; set; }
        public virtual tbEmpresas Empre { get; set; }
        public virtual tbEstadosCiviles Estc { get; set; }
        public virtual tbUsuarios Part_UsuarioCreacionNavigation { get; set; }
        public virtual tbUsuarios Part_UsuarioModificacionNavigation { get; set; }
        public virtual ICollection<tbParticipantesPorCursoo> tbParticipantesPorCursoo { get; set; }
    }
}