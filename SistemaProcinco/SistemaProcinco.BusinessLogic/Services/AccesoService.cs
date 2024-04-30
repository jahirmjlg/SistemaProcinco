using SistemaProcinco.BunisessLogic;
using SistemaProcinco.DataAccess.Repository;
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
        public AccesoService(UsuariosRepository usuariosRepository, PantallasRepository pantallasRepository)
        {
            _usuariosRepository = usuariosRepository;
            _pantallasRepository = pantallasRepository;
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

        #endregion

        #region Pantallas Por Roles

        #endregion
    }
}
