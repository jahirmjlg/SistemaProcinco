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
    public class GeneralService
    {
        public readonly CiudadesRepository _ciudadesRepository;
        public readonly EstadosRepository _estadosRepository;
        public readonly EstadosCivilesRepository _estadosCivilesRepository;
        public readonly EmpresasRepository _empresasRepository;
        public readonly EmpleadosRepository _empleadosRepository;
        public readonly TitulosPorEmpleadosRepository _titulosporempleadosRepository;


        public GeneralService(CiudadesRepository ciudadesRepository, EmpresasRepository empresasRepository,
            EstadosRepository estadosRepository, EstadosCivilesRepository estadosCivilesRepository, EmpleadosRepository empleadosRepository,
            TitulosPorEmpleadosRepository titulosPorEmpleadosRepository)
        {
            _ciudadesRepository = ciudadesRepository;
            _estadosRepository = estadosRepository;
            _estadosCivilesRepository = estadosCivilesRepository;
            _empleadosRepository = empleadosRepository;
            _empresasRepository = empresasRepository;

            _titulosporempleadosRepository = titulosPorEmpleadosRepository;



        }
        #region empresas
        public ServicesResult ListEmpresas()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empresasRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region Ciudades
        public ServicesResult ListaCiudades()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _ciudadesRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult GetCiudadesPorEstados(string Esta_Id)
        {
            var resul = new ServicesResult();
            try
            {
                var list = _ciudadesRepository.GetMunicipiosPorEstado(Esta_Id);
                if (list.Count() > 0)
                {
                    return resul.Ok(list);
                }
                else
                {
                    return resul.Error();
                }

            }
            catch (Exception ex)
            {
                return resul.Error(ex.Message);
            }
        }

        public ServicesResult BuscarCiudades(string Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _ciudadesRepository.FindDetalle(Id);
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

        public ServicesResult InsertarCiudades(tbCiudades item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _ciudadesRepository.Insert(item);
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

        public ServicesResult EditarCiudades(tbCiudades item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _ciudadesRepository.Update(item);
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

        public ServicesResult EliminarCiudades(string id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _ciudadesRepository.Delete1(id);
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

        #region Estados
        public ServicesResult ListaEstados()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        public ServicesResult BuscarEstados(string Id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosRepository.Find1(Id);
                if (lost.Count() > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.NotFound();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }

        public ServicesResult InsertarEstados(tbEstados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosRepository.Insert(item);
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

        public ServicesResult EditarEstados(tbEstados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosRepository.Update(item);
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

        public ServicesResult EliminarEstados(string id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosRepository.Delete1(id);
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

        #region Estados Civiles
        public ServicesResult ListaEstadosCiviles()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosCivilesRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        public ServicesResult BuscarEstadosCiviles(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosCivilesRepository.Find(Id);
                if (lost.Count() > 0)
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
                return result.Error(ex);
            }
        }
        public ServicesResult InsertarEstadosCiviles(tbEstadosCiviles item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosCivilesRepository.Insert(item);
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
        public ServicesResult EditarEstadosCiviles(tbEstadosCiviles item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosCivilesRepository.Update(item);
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

        public ServicesResult EliminarEstadosCiviles(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _estadosCivilesRepository.Delete(id);
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

        #region Empleados
        public ServicesResult ListaEmpleados()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empleadosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        public ServicesResult BuscarEmpleados(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empleadosRepository.Find(Id);
                if (lost.Count() > 0)
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
                return result.Error(ex);
            }
        }

        public (ServicesResult, int) InsertaEmpleados(tbEmpleados item)
        {
            var result = new ServicesResult();
            int rolid = 0;
            try
            {

                var lost = _empleadosRepository.Insert1(item);
                rolid = lost.Item2;

                if (lost.Item1.CodeStatus > 0)
                {
                    return (result.Ok(lost), rolid);

                }
                else
                {
                    return (result.Error(lost), rolid);
                }
            }
            catch (Exception ex)
            {
                return (result.Error(ex.Message), rolid);
            }
        }

        public ServicesResult EditarEmpleados(tbEmpleados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empleadosRepository.Update(item);
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

        public ServicesResult EliminarEmpleados(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empleadosRepository.Delete(id);
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












        //treviewwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww


        #region empleados
        public ServicesResult ListaEmpleados1()
        {
            var result = new ServicesResult();
            try
            {
                var list = _empleadosRepository.List1();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }




        public ServicesResult EditarEmpleados1(tbEmpleados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empleadosRepository.Update1(item);
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

        public ServicesResult EliminarEmpleados1(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empleadosRepository.Delete1(id);
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








        public (ServicesResult, int) InsertarEmpleados1(tbEmpleados item)
        {
            var result = new ServicesResult();
            int rolid = 0;
            try
            {
                var lost = _empleadosRepository.Insert1(item);
                rolid = lost.Item2;

                if (lost.Item1.CodeStatus > 0)
                {
                    return (result.Ok(lost), rolid);

                }
                else
                {
                    return (result.Error(lost), rolid);
                }
            }
            catch (Exception ex)
            {
                return (result.Error(ex.Message), rolid);
            }
        }

        public ServicesResult BuscarEmpleados1(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empleadosRepository.Find1(Id);
                if (lost.Count() > 0)
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
                return result.Error(ex);
            }
        }



        public ServicesResult obterRol(int id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _empleadosRepository.Fill1(id);

                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex);
            }
        }







        public ServicesResult ListadoTitulos()
        {
            var result = new ServicesResult();
            try
            {
                var list = _empleadosRepository.List();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }

        public ServicesResult ListadoTitulosFiltrado()
        {
            var result = new ServicesResult();
            try
            {
                var list = _empleadosRepository.List1();
                return result.Ok(list);
            }

            catch (Exception ex)
            {

                return result.Error(ex.Message);
            }
        }




        #endregion




        #region TITULOS POR EMPLEADO

        public ServicesResult ListaTitulosPorEmpleados()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosporempleadosRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult ListarTitulosFiltrado(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosporempleadosRepository.List1(id);
                return result.Ok(lost);
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
                var lost = _titulosporempleadosRepository.Delete1(id);
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


        public ServicesResult InsertarTitulosPorEmpleados(tbTitulosPorEmpleado item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _titulosporempleadosRepository.Insert1(item);
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
