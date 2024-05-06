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
        private readonly PantallasPorRolesRepostory _pantallasPorRolesRepostory;
        public AccesoService(UsuariosRepository usuariosRepository, PantallasRepository pantallasRepository, RolesRepository rolesRepository, PantallasPorRolesRepostory pantallasPorRolesRepostory)
        {
            _usuariosRepository = usuariosRepository;
            _pantallasRepository = pantallasRepository;
            _rolesRepository = rolesRepository;
            _pantallasPorRolesRepostory = pantallasPorRolesRepostory;
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

        public ServicesResult BuscarUsuarios(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _usuariosRepository.Find(Id);
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

        public ServicesResult InsertarUsuarios(tbUsuarios item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _usuariosRepository.Insert(item);

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

        public ServicesResult EditarUsuarios(tbUsuarios item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _usuariosRepository.Update(item);
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

        public ServicesResult EliminarUsuarios(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _usuariosRepository.Delete(id);
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

        public ServicesResult Login(string Usuario, string Contra)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _usuariosRepository.Login(Usuario, Contra);
                if (lost != null)
                {
                    return result.Ok(lost);

                }
                else
                {
                    return result.Error();
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult EnviarCodigo(string corus)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _usuariosRepository.EnviarCodigo(corus);
                return result.Ok(lost);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult Implementarcodigo(string codigo, int usuarioId)
        {
            var result = new ServicesResult();
            try
            {
                var list = _usuariosRepository.IngresarCodigo(codigo, usuarioId);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult ValidarCodigo(string codigo)
        {
            var result = new ServicesResult();
            try
            {
                var list = _usuariosRepository.ValidarCodigo(codigo);
                if (list.Count() > 0)
                {
                    return result.Ok(list);
                }
                else
                {
                    return result.Error(list);
                }
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServicesResult RestablecerContrasenia(tbUsuarios item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _usuariosRepository.RestablecerContra(item);
                if (lost.CodeStatus > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error();
                }
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
                if (lost.Count() > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error();
                }

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult BuscarPantallas(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _pantallasRepository.Find(Id);
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

        public ServicesResult InsertarPantallas(tbPantallas item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasRepository.Insert(item);
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

        public ServicesResult EditarPantallas(tbPantallas item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasRepository.Update(item);
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

        public ServicesResult EliminarPantallas(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasRepository.Delete(id);
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

        public (ServicesResult, int) InsertarRoles(tbRoles item)
        {
            var result = new ServicesResult();
            int rolid = 0;
            try
            {
                var lost = _rolesRepository.Insert(item);
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
        public ServicesResult ListaPantallasPorRoles(int Role_Id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasPorRolesRepostory.List1(Role_Id);
                if (lost.Count() > 0)
                {
                    return result.Ok(lost);
                }
                else
                {
                    return result.Error();
                }

            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);

            }
        }

        public ServicesResult BuscarPantallasPorRoles(int Id)
        {
            var result = new ServicesResult();
            try
            {
                var list = _pantallasPorRolesRepostory.Find(Id);
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

        public ServicesResult InsertarPantallasPorRoles(tbPantallasPorRoles item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasPorRolesRepostory.Insert(item);
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

        public ServicesResult EditarPantallasPorRoles(tbPantallasPorRoles item)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasPorRolesRepostory.Update(item);
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

        public ServicesResult EliminarPantallasPorRoles(int id)
        {
            var result = new ServicesResult();
            try
            {
                var lost = _pantallasPorRolesRepostory.Delete(id);
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
