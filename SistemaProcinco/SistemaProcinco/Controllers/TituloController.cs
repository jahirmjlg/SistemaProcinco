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
    public class TituloController : Controller
    {
        private readonly ProcincoService _procincoService;
        private readonly IMapper _mapper;

        public TituloController(ProcincoService procincoService, IMapper mapper)
        {
            _procincoService = procincoService;
            _mapper = mapper;
        }
        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _procincoService.ListaTitulos();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("TituloCrear")]
        public IActionResult Insert(TitulosViewModel item)
        {
            var model = _mapper.Map<tbTitulos>(item);
            var modelo = new tbTitulos()
            {
                Titl_Descripcion = item.Titl_Descripcion,
                Titl_ValorMonetario = item.Titl_ValorMonetario,
                Titl_UsuarioCreacion = 1,
                Titl_FechaCreacion = DateTime.Now
            };
            var list = _procincoService.InsertarTitulos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("TituloEditar")]
        public IActionResult Edit(TitulosViewModel item)
        {
            var model = _mapper.Map<tbTitulos>(item);
            var modelo = new tbTitulos()
            {
                Titl_Id = item.Titl_Id,
                Titl_Descripcion = item.Titl_Descripcion,
                Titl_ValorMonetario = item.Titl_ValorMonetario,
                Titl_UsuarioModificacion = 1,
                Titl_FechaModificacion = DateTime.Now
            };
            var list = _procincoService.EditarTitulos(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("TitulosEliminar")]
        public IActionResult Delete(int Titl_Id)
        {
            var list = _procincoService.EliminarTitulos(Titl_Id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("TitulosBuscar")]
        public IActionResult Details(int Titl_Id)
        {
            var list = _procincoService.BuscarTitulos(Titl_Id);
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
