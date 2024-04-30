﻿using SistemaProcinco.BusinessLogic.Services;
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
            service.AddScoped<CargosRepository>();
            service.AddScoped<CiudadesRepository>();
            service.AddScoped<EmpleadosRepository>();
            service.AddScoped<EstadosRepository>();
            service.AddScoped<EstadosCivilesRepository>();
            service.AddScoped<PantallasRepository>();
            service.AddScoped<RolesRepository>();
            service.AddScoped<UsuariosRepository>();
            service.AddScoped<CargosRepository>();
            service.AddScoped<CargosRepository>();
            service.AddScoped<CargosRepository>();

            SistemaProcincoContext.BuildConnectionString(conn);

        }

        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<AccesoService>();
            service.AddScoped<GeneralService>();
        }
    }
}
