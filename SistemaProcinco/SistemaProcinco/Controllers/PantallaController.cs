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
    public class PantallaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly AccesoService _accesoService;
        public PantallaController(IMapper mapper, AccesoService accesoService)
        {
            _mapper = mapper;
            _accesoService = accesoService;
        }

        [HttpGet("PantallasListado")]
        public IActionResult Index(int Role_Id)
        {
            var listado = _accesoService.ListaPantallas(Role_Id);
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("PantallasCrear")]
        public IActionResult Insert(PantallasViewModel item)
        {
            var model = _mapper.Map<tbPantallas>(item);
            var modelo = new tbPantallas()
            {
                Pant_Descripcion = item.Pant_Descripcion,
                Pant_UsuarioCreacion = 1,
                Pant_FechaCreacion = DateTime.Now


            };
            var list = _accesoService.InsertarPantallas(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }


        [HttpPut("PantallaEditar")]
        public IActionResult Edit(PantallasViewModel item)
        {
            var model = _mapper.Map<tbPantallas>(item);
            var modelo = new tbPantallas()
            {
                Pant_Id = item.Pant_Id,
                Pant_Descripcion = item.Pant_Descripcion,
                Pant_UsuarioModificacion = 1,
                Pant_FechaModificacion = DateTime.Now
            };
            var list = _accesoService.EditarPantallas(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("PantallaEliminar")]
        public IActionResult Delete(int Pant_Id)
        {
            var list = _accesoService.EliminarPantallas(Pant_Id);
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
