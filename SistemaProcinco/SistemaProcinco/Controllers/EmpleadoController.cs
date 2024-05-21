using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaProcinco.BunisessLogic;
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
    public class EmpleadoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly GeneralService _generalService;

        private readonly ProcincoService _procincoService;


        public EmpleadoController(IMapper mapper, GeneralService generalService, ProcincoService procincoService)
        {
            _mapper = mapper;
            _generalService = generalService;
            _procincoService = procincoService;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            var listado = _generalService.ListaEmpleados();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPost("EmpleadoCrear")]
        public IActionResult Insert([FromBody] RoleWithScreens1 data)
        {

            var result = new ServicesResult();
            var pantallas = data.Screens;

            var modelo = new tbEmpleados()
            {
                Empl_DNI = data.Empl_DNI,
                Carg_Id = data.Carg_Id,
                Empl_Nombre = data.Empl_Nombre,
                Empl_Apellido = data.Empl_Apellido,
                Empl_Correo = data.Empl_Correo,
                Empl_FechaNacimiento = data.Empl_FechaNacimiento,
                Empl_Sexo = data.Empl_Sexo,
                Estc_Id = data.Estc_Id,
                Empl_Direccion = data.Empl_Direccion,
                Ciud_Id = data.Ciud_Id,
                Empl_UsuarioCreacion = 1,
                Empl_FechaCreacion = DateTime.Now


            };
            (var list, int Empl_IdScope) = _generalService.InsertaEmpleados(modelo);

            foreach (var pantalla in pantallas)
            {
                var modelo2 = new tbTitulosPorEmpleado()
                {
                    Titl_Id = pantalla.titl_Id,
                    Empl_Id = Empl_IdScope,
                    TitPe_UsuarioCreacion = 1
                };

                result = _procincoService.InsertarTitulosPorEmpleados(modelo2);

            }


            if (result.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        [HttpPut("EmpleadoEditar")]
        public IActionResult Edit([FromBody] RoleWithScreens1 data)
        {
            var result = new ServicesResult();
            var dni = data.Empl_DNI;
            var cargo = data.Carg_Id;
            var nombre = data.Empl_Nombre;
            var apellido = data.Empl_Apellido;
            var correo = data.Empl_Correo;
            var fechaNacimiento = data.Empl_FechaNacimiento;
            var sexo = data.Empl_Sexo;
            var estadoCivil = data.Estc_Id;
            var direccion = data.Empl_Direccion;
            var ciudad = data.Ciud_Id;

            var titulos = data.Screens;

            var modelo = new tbEmpleados()
            {
                Empl_Id = data.Empl_Id,
                Empl_DNI = data.Empl_DNI,
                Carg_Id = cargo,
                Empl_Nombre = nombre,
                Empl_Apellido = apellido,
                Empl_Correo = correo,
                Empl_FechaNacimiento = fechaNacimiento,
                Empl_Sexo = sexo,
                Estc_Id = estadoCivil,
                Empl_Direccion = direccion,
                Ciud_Id = ciudad,
                Empl_UsuarioModificacion = 1,
                Empl_FechaModificacion = DateTime.Now


            };
            var list = _generalService.EditarEmpleados1(modelo);

            var limpiar = _procincoService.EliminarTitulosPorEmpleados(data.Empl_Id);


            foreach (var titulo in titulos)
            {
                var modelo2 = new tbTitulosPorEmpleado()
                {
                    Titl_Id = titulo.titl_Id,
                    Empl_Id = data.Empl_Id,
                    TitPe_UsuarioModificacion = 1
                };

                result = _procincoService.InsertarTitulosPorEmpleados(modelo2);

            }

            if (result.Success == true)
            {
                return Ok(list);
            }
            else
            {
                return Problem();
            }
        }

        //[HttpDelete("EmpleadoEliminar/{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var list = _generalService.EliminarEmpleados(id);
        //    if (list.Success == true)
        //    {
        //        return Ok(list);
        //    }
        //    else
        //    {
        //        return Problem();
        //    }

        //}



    

        [HttpGet("EmpleadoBuscar/{id}")]
        public IActionResult Details(int id)
        {
            var list = _generalService.BuscarEmpleados(id);
            if (list.Success == true)
            {
                return Json(list.Data);

            }
            else
            {
                return Problem();
            }
        }

        [HttpGet("ddl")]
        public IActionResult Lista()
        {
            var listado = _generalService.ListaEmpleados();
            var drop = listado.Data as List<tbEmpleados>;
            var esta = drop.Select(x => new SelectListItem
            {
                Text = x.Empl_Nombre,
                Value = x.Empl_Id.ToString()

            }).ToList();

            esta.Insert(0, new SelectListItem { Text = "--SELECCIONE--", Value = "0" });

            return Ok(esta.ToList());
        }

        //////////////////////////////
        //

        
        [HttpGet("ListadoTitulos")]
        public IActionResult ListaTitulos()
        {
            var listado = _generalService.ListaTitulosPorEmpleados();
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }


        [HttpGet("FiltrarTitulos/{id}")]
        public IActionResult FiltrarTitulos(int id)
        {
            var listado = _generalService.ListarTitulosFiltrado(id);
            if (listado.Success == true)
            {
                return Ok(listado);
            }
            else
            {
                return Problem();
            }
        }



        //BUSQUEDA DRAG
        [HttpGet("TitulosEmpleado/{id}")]
        public IActionResult ListadoFiltro(int id)
        {
            var listado = _procincoService.ListaTitulosEmpleado(id);
            if (listado.Success == true)
            {
                return Ok(listado.Data);
            }
            else
            {
                return Problem();
            }
        }



        [HttpGet("Buscar/{id}")]
        public IActionResult Detailss(int id)
        {
            var list = _generalService.BuscarEmpleadoss(id);
            if (list.Success == true)
            {
                return Json(list.Data);
            }
            else
            {
                return Problem();
            }
        }



        [HttpDelete("EmpleadoEliminar/{Empl_id}")]
        public IActionResult Deletee(int Empl_id)
        {
            var list = _generalService.EliminarEmpleadoss(Empl_id);
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
