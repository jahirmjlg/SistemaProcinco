﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaProcinco.BusinessLogic.Services;
using SistemaProcinco.Common.Models;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaProcinco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public CategoriaController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaCategorias();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }


        [HttpPost("CategoriaCrear")]
        public IActionResult Insert(CategoriasViewModel item)
        {
            var model = _mapper.Map<tbCategorias>(item);
            var modelo = new tbCategorias()
            {
                Cate_Descripcion = item.Cate_Descripcion,
                Cate_UsuarioCreacion = 1,
                Cate_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarCategorias(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("CategoriaEditar")]
        public IActionResult Edit(CategoriasViewModel item)
        {
            var model = _mapper.Map<tbCategorias>(item);
            var modelo = new tbCategorias()
            {
                Cate_Id = item.Cate_Id,
                Cate_Descripcion = item.Cate_Descripcion,
                Cate_UsuarioModificacion = 1,
                Cate_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarCategorias(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("CategoriaEliminar/{Cate_Id}")]
        public IActionResult Delete(int Cate_Id)
        {
            var list = _procincoService.EliminarCategorias(Cate_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("CategoriaBuscar/{Cate_Id}")]
        public IActionResult Details(int Cate_Id)
        {
            var list = _procincoService.BuscarCatergorias(Cate_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }
    }
}
