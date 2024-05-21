using Dapper;
using Microsoft.Data.SqlClient;
using SistemaProcinco.DataAcces.Repository;
using SistemaProcinco.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProcinco.DataAccess.Repository
{
    public class TitulosPorEmpleadosRepository : IRepository<tbTitulosPorEmpleado>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.titulosPorEmpleadoEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Empl_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbTitulosPorEmpleado> Find(int? id)
        {
            string sql = ScriptsDatabase.TitulosPorEmpleadosBuscar;
            List<tbTitulosPorEmpleado> result = new List<tbTitulosPorEmpleado>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("TitPe_Id", id);
                result = db.Query<tbTitulosPorEmpleado>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbTitulosPorEmpleado item)
        {
            string sql = ScriptsDatabase.TitulosPorEmpleadosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Titl_Id", item.Titl_Id);
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@TitPe_UsuarioCreacion", 1);
                parametro.Add("@TitPe_FechaCreacion", DateTime.Now);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbTitulosPorEmpleado> List()
        {
            string sql = ScriptsDatabase.TitulosPorEmpleadosListar;

            List<tbTitulosPorEmpleado> result = new List<tbTitulosPorEmpleado>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbTitulosPorEmpleado>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbTitulosPorEmpleado item)
        {
            string sql = ScriptsDatabase.TitulosPorEmpleadosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@TitPe_Id", item.TitPe_Id);
                parametro.Add("@Titl_Id", item.Titl_Id);
                parametro.Add("@Empl_Id", item.Empl_Id);
                parametro.Add("@TitPe_UsuarioModificacion", item.TitPe_UsuarioModificacion);
                parametro.Add("@TitPe_FechaModificacion", item.TitPe_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }




















        //treeviewwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww


        public RequestStatus Insert1(tbTitulosPorEmpleado item)
        {
            const string sql = "[Pro].[SP_TituloPorEmpleado_Insertar]";

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Titl_Id", item.Titl_Id);
                parametro.Add("@Empl_Id ", item.Empl_Id);
                parametro.Add("@TitPe_UsuarioCreacion ", 1);
                parametro.Add("@TitPe_FechaCreacion ", DateTime.Now);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "Exito" : "Error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
            }
        }

        public IEnumerable<tbTitulos> List1(int Emple_Id)
        {
            string sql = ScriptsDatabase.TitulosPorEmpleadosFiltrado1;

            List<tbTitulos> result = new List<tbTitulos>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Empl_Id", Emple_Id);
                result = db.Query<tbTitulos>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }







        public RequestStatus Delete1(int Titl_Id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Empl_Id", Titl_Id);
                var result = db.QueryFirst(ScriptsDatabase.TitulosPorEmpleadosEliminar, parameter, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
            }
        }











    }
}
