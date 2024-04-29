using SistemaProcinco.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.BusinessLogic.Services
{
    public class GeneralService
    {
        public readonly BlanckRepository _blanckRepository;
        public GeneralService(BlanckRepository blanckRepository)
        {
            blanckRepository = _blanckRepository;
        }

    }
}
