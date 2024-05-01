using SistemaProcinco.BunisessLogic;
using SistemaProcinco.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.BusinessLogic.Services
{
    public class ProcincoService
    {
        public readonly CargosRepository _cargosRepository;
        public readonly CategoriasRepository _categoriasRepository;
        public readonly ContenidoRepository _contenidoRepository;
        public readonly ContenidoPorCursoRepository _contenidoPorCursoRepository;
        public readonly CursosRepository _cursosRepository;
        public readonly CursosImpartidosRepository _cursosImpartidosRepository;
        public readonly InformeEmpleadosRepository _informeEmpleadosRepository;
        public readonly TitulosRepository _titulosRepository;
        public readonly TitulosPorEmpleadosRepository _titulosPorEmpleadosRepository;
        public ProcincoService(CargosRepository cargosRepository, CategoriasRepository categoriasRepository, ContenidoRepository contenidoRepository,
            ContenidoPorCursoRepository contenidoPorCursoRepository, CursosRepository cursosRepository, CursosImpartidosRepository cursosImpartidosRepository,
            InformeEmpleadosRepository informeEmpleadosRepository, TitulosRepository titulosRepository, TitulosPorEmpleadosRepository titulosPorEmpleadosRepository)
        {
            _cargosRepository = cargosRepository;
            _categoriasRepository = categoriasRepository;
            _contenidoRepository = contenidoRepository;
            _contenidoPorCursoRepository = contenidoPorCursoRepository;
            _cursosRepository = cursosRepository;
            _cursosImpartidosRepository = cursosImpartidosRepository;
            _informeEmpleadosRepository = informeEmpleadosRepository;
            _titulosRepository = titulosRepository;
            _titulosPorEmpleadosRepository = titulosPorEmpleadosRepository;
        }

        #region Cargos 
        public ServicesResult ListaCargos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cargosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region Categorias
        public ServicesResult ListaCategorias()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _categoriasRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region Contenido
        public ServicesResult ListaContenido()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region ContenidoPorCursos
        public ServicesResult ListaContenidoPorCursos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoPorCursoRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region Cursos
        public ServicesResult ListaCursos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region Cursos Impartidos
        public ServicesResult ListaCursosImpartidos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region Informes Empleados
        public ServicesResult ListaInformesEmpleados()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _informeEmpleadosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        #endregion

        #region Titulos
        public ServicesResult ListaTitulos()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region Titulos Por Empleados
        public ServicesResult ListaTitulosPorEmpleados()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosPorEmpleadosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion
    }
}
