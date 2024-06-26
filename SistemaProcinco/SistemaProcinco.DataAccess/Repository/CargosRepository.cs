﻿using Dapper;
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
    public class CargosRepository : IRepository<tbCargos>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.CargosEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Carg_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbCargos> Find(int? id)
        {
            string sql = ScriptsDatabase.CargosBuscar;
            List<tbCargos> result = new List<tbCargos>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Carg_Id", id);
                result = db.Query<tbCargos>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbCargos item)
        {
            string sql = ScriptsDatabase.CargosCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Carg_Descripcion", item.Carg_Descripcion);
                parametro.Add("@Carg_UsuarioCreacion", item.Carg_UsuarioCreacion);
                parametro.Add("@Carg_FechaCreacion", item.Carg_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbCargos> List()
        {
            string sql = ScriptsDatabase.CargosListar;

            List<tbCargos> result = new List<tbCargos>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbCargos>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbCargos item)
        {
            string sql = ScriptsDatabase.CargosActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Carg_Id", item.Carg_Id);
                parametro.Add("@Carg_Descripcion", item.Carg_Descripcion);
                parametro.Add("@Carg_UsuarioModificacion", item.Carg_UsuarioModificacion);
                parametro.Add("@Carg_FechaModificacion", item.Carg_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
