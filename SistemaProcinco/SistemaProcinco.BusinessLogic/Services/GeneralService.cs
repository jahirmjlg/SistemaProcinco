﻿using SistemaProcinco.BunisessLogic;
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
        public readonly EmpleadosRepository _empleadosRepository;
        public GeneralService(CiudadesRepository ciudadesRepository, EstadosRepository estadosRepository, EstadosCivilesRepository estadosCivilesRepository, EmpleadosRepository empleadosRepository)
        {
            _ciudadesRepository = ciudadesRepository;
            _estadosRepository = estadosRepository;
            _estadosCivilesRepository = estadosCivilesRepository;
            _empleadosRepository = empleadosRepository;

        }

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

        public ServicesResult BuscarCiudades(string Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _ciudadesRepository.FindDetalle(Id);
                if(list.Count() > 0)
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
        public IEnumerable<tbEstadosCiviles> BuscarEstadosCiviles(int Id)
        {
            var result = new ServicesResult();
            try
            {
                return _estadosCivilesRepository.Find(Id);
            }
            catch
            {
                return Enumerable.Empty<tbEstadosCiviles>();
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

        public ServicesResult InsertarEmpleados(tbEmpleados item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _empleadosRepository.Insert(item);
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
    }
}
