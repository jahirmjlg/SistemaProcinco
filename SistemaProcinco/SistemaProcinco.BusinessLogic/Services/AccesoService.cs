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
    public class AccesoService
    {
        private readonly UsuariosRepository _usuariosRepository;
        private readonly PantallasRepository _pantallasRepository;
        private readonly RolesRepository _rolesRepository;
        public AccesoService(UsuariosRepository usuariosRepository, PantallasRepository pantallasRepository, RolesRepository rolesRepository)
        {
            _usuariosRepository = usuariosRepository;
            _pantallasRepository = pantallasRepository;
            _rolesRepository = rolesRepository;
        }

        #region Usuarios
        public ServicesResult ListaUsuarios()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _usuariosRepository.List();
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        #endregion

        #region Pantallas
        public ServicesResult ListaPantallas()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        #endregion

        #region Roles
        public ServicesResult ListaRoles()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _rolesRepository.List();

                return result.Ok(lost);

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }
        public ServicesResult BuscarRoles(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _rolesRepository.Find(Id);
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

        public ServicesResult InsertarRoles(tbRoles item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _rolesRepository.Insert(item);
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

        public ServicesResult EditarRoles(tbRoles item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _rolesRepository.Update(item);
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
        public ServicesResult EliminarRoles(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _rolesRepository.Delete(id);
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

        #region Pantallas Por Roles
        public ServicesResult ListaPantallasPorRoles()
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasRepository.List();

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
