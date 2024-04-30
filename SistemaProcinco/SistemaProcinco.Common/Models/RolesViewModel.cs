﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.Common.Models
{
    public class RolesViewModel
    {
        public int Role_Id { get; set; }
        public string Role_Descripcion { get; set; }
        public int? Role_UsuarioCreacion { get; set; }
        public DateTime? Role_FechaCreacion { get; set; }
        public int? Role_UsuarioModificacion { get; set; }
        public DateTime? Role_FechaModificacion { get; set; }
        public bool? Role_Estado { get; set; }
        [NotMapped]
        public string Creacion { get; set; }

        [NotMapped]
        public string Modificacion { get; set; }
    }
}