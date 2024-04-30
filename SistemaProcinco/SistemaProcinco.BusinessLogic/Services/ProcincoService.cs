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

        public ProcincoService(CargosRepository cargosRepository)
        {
            _cargosRepository = cargosRepository;
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

    }
}
