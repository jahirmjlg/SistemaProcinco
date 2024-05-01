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
            service.AddScoped<CargosRepository>();
            service.AddScoped<CiudadesRepository>();
            service.AddScoped<EmpleadosRepository>();
            service.AddScoped<EstadosRepository>();
            service.AddScoped<EstadosCivilesRepository>();
            service.AddScoped<PantallasRepository>();
            service.AddScoped<PantallasPorRolesRepostory>();
            service.AddScoped<RolesRepository>();
            service.AddScoped<UsuariosRepository>();
            service.AddScoped<InformeEmpleadosRepository>();
            service.AddScoped<TitulosRepository>();
            service.AddScoped<TitulosPorEmpleadosRepository>();
            service.AddScoped<CategoriasRepository>();
            service.AddScoped<ContenidoRepository>();
            service.AddScoped<ContenidoPorCursoRepository>();
            SistemaProcincoContext.BuildConnectionString(conn);

        }

        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<AccesoService>();
            service.AddScoped<GeneralService>();
            service.AddScoped<ProcincoService>();
        }
    }
}
