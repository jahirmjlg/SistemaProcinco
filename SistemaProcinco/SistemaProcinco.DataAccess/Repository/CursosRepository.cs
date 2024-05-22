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
    public class CursosRepository : IRepository<tbCursos>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.CursosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Curso_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbCursos> Find(int? id)
        {
            string sql = ScriptsDatabase.CursosBuscar;
            List<tbCursos> result = new List<tbCursos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Curso_Id", id);
                result = db.Query<tbCursos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public IEnumerable<tbCursos> FindCattegoria(int? id)
        {
            string sql = ScriptsDatabase.CursosPorCategoriaBuscar;
            List<tbCursos> result = new List<tbCursos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Cate_Id", id);
                result = db.Query<tbCursos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }



        public RequestStatus Insert(tbCursos item)
        {
            string sql = ScriptsDatabase.CursosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Curso_Descripcion", item.Curso_Descripcion);
                parametro.Add("@Curso_DuracionHoras", item.Curso_DuracionHoras);
                parametro.Add("@Curso_Imagen", item.Curso_Imagen);
                parametro.Add("@Cate_Id", item.Cate_Id);
                parametro.Add("@Empre_Id", item.Empre_Id);

                parametro.Add("@Curso_UsuarioCreacion", item.Curso_UsuarioCreacion);
                parametro.Add("@Curso_FechaCreacion", item.Curso_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        //public int Insert(tbRoles item)
        //{
        //    const string sql = "[Pro].[SP_Curso1_Insertar]";
        //    using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
        //    {
        //        var parametro = new DynamicParameters();
        //        parametro.Add("@Curso_Descripcion", item.Role_Rol);
        //        parametro.Add("@Curso_DuracionHoras", item.Role_UsuarioCreacion);
        //        parametro.Add("@Curso_Imagen", item.Role_FechaCreacion);
        //        parametro.Add("@ID", DbType.Int32, direction: ParameterDirection.Output);


        //        var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
        //        int id = parametro.Get<int>("@ID");


        //        return id;
        //    }
        //}




        public IEnumerable<tbCursos> List()
        {
            string sql = ScriptsDatabase.CursosListar;

            List<tbCursos> result = new List<tbCursos>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbCursos>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }



        //public RequestStatus Update(tbRoles item)
        //{
        //    string sql = ScriptsDatabase.RolesActualizar;

        //    using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@Role_Id", item.Role_Id);
        //        parameter.Add("@Role_Rol", item.Role_Rol);
        //        parameter.Add("@Role_UsuarioModificacion", item.Role_UsuarioModificacion);
        //        parameter.Add("@Role_FechaModificacion", item.Role_FechaModificacion);

        //        var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
        //        string mensaje = (result == 1) ? "exito" : "error";
        //        return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

        //    }
        //}






        public RequestStatus Update1(tbCursos item)
        {
            string sql = ScriptsDatabase.CursosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@Curso_Descripcion", item.Curso_Descripcion);
                parametro.Add("@Curso_DuracionHoras", item.Curso_DuracionHoras);
                parametro.Add("@Curso_Imagen", item.Curso_Imagen);
                parametro.Add("@Cate_Id", item.Cate_Id);
                parametro.Add("@Empre_Id", item.Empre_Id);
                parametro.Add("@Curso_UsuarioModificacion", item.Curso_UsuarioModificacion);
                parametro.Add("@Curso_FechaModificacion", item.Curso_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                string mensaje = (result == 1) ? "exito" : "error";
                return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

            }
        }




        public int Insert1(tbCursos item)
        {
            const string sql = "[Pro].[SP_Curso1_Insertar]";

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                try
                {
                    var parametro = new DynamicParameters();
                    parametro.Add("@Curso_Descripcion", item.Curso_Descripcion);
                    parametro.Add("@Curso_DuracionHoras", item.Curso_DuracionHoras);
                    parametro.Add("@Curso_Imagen", item.Curso_Imagen);
                    parametro.Add("@Cate_Id", item.Cate_Id);
                    parametro.Add("@Empre_Id", item.Empre_Id);
                    parametro.Add("@Curso_UsuarioCreacion", item.Curso_UsuarioCreacion);
                    parametro.Add("@Curso_FechaCreacion", DateTime.Now);
                    parametro.Add("@ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                    int id = parametro.Get<int>("@ID");
                    return id;
                }
                catch (Exception ex)
                {
                    // Log or handle exception as needed
                    throw new Exception($"Error al insertar el curso: {ex.Message}", ex);
                }
            }
        }





        public tbCursos Fill1(int id)
        {

            tbCursos result = new tbCursos();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Curso_Id", id);
                result = db.QueryFirst<tbCursos>(ScriptsDatabase.CursosBuscar, parameter, commandType: CommandType.StoredProcedure);
                return result;
            }

        }

        public RequestStatus Update(tbCursos item)
        {
            string sql = ScriptsDatabase.CursosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Curso_Id", item.Curso_Id);
                parametro.Add("@Curso_Descripcion", item.Curso_Descripcion);
                parametro.Add("@Curso_DuracionHoras", item.Curso_DuracionHoras);
                parametro.Add("@Curso_Imagen", item.Curso_Imagen);
                parametro.Add("@Cate_Id", item.Cate_Id);
                parametro.Add("@Curso_UsuarioModificacion", item.Curso_UsuarioModificacion);
                parametro.Add("@Curso_FechaModificacion", item.Curso_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }


        public (RequestStatus, int) InsertId(tbCursos item)
        {
            string sql = ScriptsDatabase.CursosCrearId;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Curso_Descripcion", item.Curso_Descripcion);
                parametro.Add("@Curso_DuracionHoras", item.Curso_DuracionHoras);
                parametro.Add("@Curso_Imagen", item.Curso_Imagen);
                parametro.Add("@Cate_Id", item.Cate_Id);
                parametro.Add("@Empre_Id", item.Empre_Id);

                parametro.Add("@Curso_UsuarioCreacion", item.Curso_UsuarioCreacion);
                parametro.Add("@Curso_FechaCreacion", item.Curso_FechaCreacion);
                parametro.Add("@Curso_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                int curso_Id = parametro.Get<int>("@Curso_Id");

                string mensaje = (result == 1) ? "exito" : "error";
                return (new RequestStatus { CodeStatus = result, MessageStatus = "" }, curso_Id);
            }
        }



        public RequestStatus Delete1(string Curso_Id)
        {
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parameter = new DynamicParameters();
                parameter.Add("Curso_Id", Curso_Id);

                var result = db.QueryFirstOrDefault<dynamic>(ScriptsDatabase.CursosEliminar, parameter, commandType: CommandType.StoredProcedure);

                if (result == null)
                {
                    return new RequestStatus { CodeStatus = 0, MessageStatus = "Error: No se recibió un resultado del procedimiento almacenado" };
                }

                return new RequestStatus
                {
                    CodeStatus = result.Resultado,
                    MessageStatus = (result.Resultado == 1) ? "Exito" : "Error"
                };
            }
        }




        public IEnumerable<tbCursos> ListContenidos1()
        {
            const string sql = "[Pro].[SP_Contenido_Seleccionar]";

            List<tbCursos> result = new List<tbCursos>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbCursos>(sql, commandType: CommandType.Text).ToList();

                return result;
            }
        }






        //public int Insert(tbRoles item)
        //{
        //    const string sql = "[Pro].[SP_Curso1_Insertar]";



        //    using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
        //    {
        //        var parametro = new DynamicParameters();
        //        parametro.Add("@Curso_Descripcion", item.Role_Rol);
        //        parametro.Add("@Curso_DuracionHoras", item.Role_UsuarioCreacion);
        //        parametro.Add("@Curso_Imagen", item.Role_FechaCreacion);
        //        parametro.Add("@ID", DbType.Int32, direction: ParameterDirection.Output);


        //        var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
        //        int id = parametro.Get<int>("@ID");


        //        return id;
        //    }
        //}

        //public IEnumerable<tbRoles> List()
        //{
        //    const string sql = "Acce.sp_Roles_listar";

        //    List<tbRoles> result = new List<tbRoles>();

        //    using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
        //    {
        //        result = db.Query<tbRoles>(sql, commandType: CommandType.Text).ToList();

        //        return result;
        //    }
        //}

        //public tbRoles Fill(int id)
        //{

        //    tbRoles result = new tbRoles();
        //    using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("Role_Id", id);
        //        result = db.QueryFirst<tbRoles>(ScriptsDatabase.Rolesllenar, parameter, commandType: CommandType.StoredProcedure);
        //        return result;
        //    }

        //}

        //public RequestStatus Update(tbRoles item)
        //{
        //    string sql = ScriptsDatabase.RolesActualizar;

        //    using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("@Role_Id", item.Role_Id);
        //        parameter.Add("@Role_Rol", item.Role_Rol);
        //        parameter.Add("@Role_UsuarioModificacion", item.Role_UsuarioModificacion);
        //        parameter.Add("@Role_FechaModificacion", item.Role_FechaModificacion);

        //        var result = db.Execute(sql, parameter, commandType: CommandType.StoredProcedure);
        //        string mensaje = (result == 1) ? "exito" : "error";
        //        return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };

        //    }
        //}











        //public RequestStatus Delete(string Role_Id)
        //{
        //    using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
        //    {
        //        var parameter = new DynamicParameters();
        //        parameter.Add("Role_Id", Role_Id);

        //        var result = db.QueryFirst(ScriptsDatabase.RolesEliminar, parameter, commandType: CommandType.StoredProcedure);
        //        return new RequestStatus { CodeStatus = result.Resultado, MessageStatus = (result.Resultado == 1) ? "Exito" : "Error" };
        //    }
        //}







        //public IEnumerable<tbRoles> Listpantallas()
        //{
        //    const string sql = "Acce.sp_Pantallas_listar ";

        //    List<tbRoles> result = new List<tbRoles>();

        //    using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
        //    {
        //        result = db.Query<tbRoles>(sql, commandType: CommandType.Text).ToList();

        //        return result;
        //    }
        //}
    }
}
