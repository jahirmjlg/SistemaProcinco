using SistemaProcinco.BunisessLogic;
using SistemaProcinco.DataAccess.Repository;
using SistemaProcinco.Entities.Entities;
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
        public ServicesResult InsertarCargos(tbCargos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cargosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarCargos(tbCargos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cargosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarCargos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cargosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult BuscarCargos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cargosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
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

        public ServicesResult BuscarCatergorias(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _categoriasRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarCategorias(tbCategorias item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _categoriasRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServicesResult EditarCategorias(tbCategorias item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _categoriasRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarCategorias(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _categoriasRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
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

        public ServicesResult BuscarContenido(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarContenido(tbContenido item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServicesResult EditarContenido(tbContenido item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServicesResult EliminarContenido(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
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
        public ServicesResult BuscarContenidoPorCursos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _contenidoPorCursoRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarContenidosPorCursos(tbContenidoPorCurso item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoPorCursoRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarContenidosPorCursos(tbContenidoPorCurso item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoPorCursoRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarContenidosPorCursos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _contenidoPorCursoRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
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

        public ServicesResult BuscarCursos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarCursos (tbCursos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarCursos (tbCursos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarCursos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
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

        //DASH
        public ServicesResult CursosImpartidosMes()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.CursosMes();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }



        public ServicesResult BuscarCursosImpartidos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _cursosImpartidosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarCursosImpartidos(tbCursosImpartidos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarCursosImpartidos(tbCursosImpartidos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarCursosImpartidos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _cursosImpartidosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
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

        public ServicesResult BuscarInformeEmpleados(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _informeEmpleadosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarInformeEmpleados(tbInformeEmpleados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _informeEmpleadosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarInformeEmpleados(tbInformeEmpleados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _informeEmpleadosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarInformeEmpleados(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _informeEmpleadosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
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
        public ServicesResult BuscarTitulos(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _titulosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarTitulos(tbTitulos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarTitulos(tbTitulos item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarTitulos(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
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

        public ServicesResult BuscarTitulosEmpleados(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _titulosPorEmpleadosRepository.Find(Id);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }
        public ServicesResult InsertarTitulosPorEmpleados(tbTitulosPorEmpleado item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosPorEmpleadosRepository.Insert(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EditarTitulosPorEmpleados(tbTitulosPorEmpleado item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosPorEmpleadosRepository.Update(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EliminarTitulosPorEmpleados(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosPorEmpleadosRepository.Delete(id);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error(lost);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion
    }
}
