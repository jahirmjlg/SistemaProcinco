using AutoMapper;
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
    public class ContenidoController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public ContenidoController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }
        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaContenido();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }
        [HttpPost("ContenidoCrear")]
        public IActionResult Insert(ContenidoViewModel item)
        {
            var model = _mapper.Map<tbContenido>(item);
            var modelo = new tbContenido()
            {
                Cont_Descripcion = item.Cont_Descripcion,
                Cont_DuracionHoras = item.Cont_DuracionHoras,
                Cate_Id = item.Cate_Id,
                Cont_UsuarioCreacion = 1,
                Cont_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarContenido(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }


        [HttpGet("ContenidoPorCategoriaBuscar/{id}")]
        public IActionResult DetailsContenidoPorCategoria(int id)
        {
            var list = _procincoService.BuscarContenidoPorCategoria(id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }


        [HttpPut("ContenidoEditar")]
        public IActionResult Edit(ContenidoViewModel item)
        {
            var model = _mapper.Map<tbContenido>(item);
            var modelo = new tbContenido()
            {
                Cont_Id = item.Cont_Id,
                Cont_Descripcion = item.Cont_Descripcion,
                Cont_DuracionHoras = item.Cont_DuracionHoras,
                Cont_UsuarioModificacion = 1,
                Cont_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarContenido(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("ContenidoEliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var list = _procincoService.EliminarContenido(id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("ContenidoBuscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _procincoService.BuscarContenido(id);
            if (list.Success == true)
            {
                return Json(list.Data);

            }
            else
            {
                return Problem();
            }
        }

    }
}
