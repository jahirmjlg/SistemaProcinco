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

    public class EmpresaController : Controller
    {

        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public EmpresaController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("ddl")]
        public IActionResult Lista()
        {
            var listado = _generalService.ListEmpresas();
            var drop = listado.Data as List<tbEmpresas>;
            var cate = drop.Select(x => new SelectListItem
            {
                Text = x.Empre_Descripcion,
                Value = x.Empre_Id.ToString()

            }).ToList();

            cate.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

            return Ok(cate.ToList());
        }



        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _generalService.ListEmpresas();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }


        [HttpPost("EmpresaCrear")]
        public IActionResult Insert(EmpresasViewModel item)
        {
            var model = _mapper.Map<tbEmpresas>(item);
            var modelo = new tbEmpresas()
            {
                Empre_Descripcion = item.Empre_Descripcion,
                Empre_Direccion = item.Empre_Direccion,
                Ciud_Id = item.Ciud_Id,
                Empre_UsuarioCreacion = 1,
                Empre_FechaCreacion = DateTime.Now
            };

            var list = _generalService.InsertarEmpresa(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("EmpresaEditar")]
        public IActionResult Edit(EmpresasViewModel item)
        {
            var model = _mapper.Map<tbEmpresas>(item);
            var modelo = new tbEmpresas()
            {
                Empre_Id = item.Empre_Id,
                Empre_Descripcion = item.Empre_Descripcion,
                Empre_Direccion = item.Empre_Direccion,
                Ciud_Id = item.Ciud_Id,
                Empre_UsuarioModificacion = 1,
                Empre_FechaModificacion = DateTime.Now


            };
            var list = _generalService.EditarEmpresa(modelo);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpDelete("EmpresaEliminar/{id}")]
        public IActionResult Delete(int id)
        {
            var list = _generalService.EliminarEmpresas(id);
            if (list.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }

        }

        [HttpGet("EmpresaBuscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _generalService.BuscarEmpresa(id);
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
