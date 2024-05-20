using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet("ddl")]
        public IActionResult Lista()
        {
            var listado = _procincoService.ListaCategorias();
            var drop = listado.Data as List<tbCategorias>;
            var cate = drop.Select(x => new SelectListItem
            {
                Text = x.Cate_Descripcion,
                Value = x.Cate_Id.ToString()

            }).ToList();

            cate.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

            return Ok(cate.ToList());
        }


        [HttpPost("CategoriaCrear")]
        public IActionResult Insert(CategoriasViewModel item)
        {
            var model = _mapper.Map<tbCategorias>(item);
            var modelo = new tbCategorias()
            {
                Cate_Imagen = item.Cate_Imagen,
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
                Cate_Imagen = item.Cate_Imagen,
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

        [HttpDelete("CategoriaEliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var list = _procincoService.EliminarCategorias(id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("CategoriaBuscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _procincoService.BuscarCatergorias(id);
            if (list.Success == true)
            {
                return Ok(list.Data);
            }
            else
            {
                return Problem();
            }
        }


    }
}
