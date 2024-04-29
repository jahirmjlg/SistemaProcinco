using SistemaProcinco.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProcinco.DataAcces;
using SistemaProcinco.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using SistemaProcinco.DataAccess.Repository;

namespace SistemaProcinco.BusinessLogic
{
    public static class ServicesConfiguration
    {
        public static void DataAccess(this IServiceCollection service, string conn)
        {
            service.AddScoped<BlanckRepository>();

            SistemaProcincoContext.BuildConnectionString(conn);

        }

        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<AccesoService>();
        }
    }
}
