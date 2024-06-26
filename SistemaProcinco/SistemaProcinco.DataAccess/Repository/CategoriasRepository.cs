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
    public class CategoriasRepository : IRepository<tbCategorias>
    {
        public RequestStatus Delete(int? id)
        {
            string sql = ScriptsDatabase.CategoriasEliminar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Cate_Id", id);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbCategorias> Find(int? id)
        {
            string sql = ScriptsDatabase.CategoriasBuscar;
            List<tbCategorias> result = new List<tbCategorias>();
            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("Cate_Id", id);
                result = db.Query<tbCategorias>(sql, parametro, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public RequestStatus Insert(tbCategorias item)
        {
            string sql = ScriptsDatabase.CategoriasCrear;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Cate_Descripcion", item.Cate_Descripcion);
                parametro.Add("@Cate_Imagen", item.Cate_Imagen);
                parametro.Add("@Cate_UsuarioCreacion", item.Cate_UsuarioCreacion);
                parametro.Add("@Cate_FechaCreacion", item.Cate_FechaCreacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }

        public IEnumerable<tbCategorias> List()
        {
            string sql = ScriptsDatabase.CategoriasListar;

            List<tbCategorias> result = new List<tbCategorias>();

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                result = db.Query<tbCategorias>(sql, commandType: System.Data.CommandType.Text).ToList();
                return result;
            }
        }

        public RequestStatus Update(tbCategorias item)
        {
            string sql = ScriptsDatabase.CategoriasActualizar;

            using (var db = new SqlConnection(SistemaProcincoContext.ConnectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@Cate_Id", item.Cate_Id);
                parametro.Add("@Cate_Descripcion", item.Cate_Descripcion);
                parametro.Add("@Cate_Imagen", item.Cate_Imagen);
                parametro.Add("@Cate_UsuarioModificacion", item.Cate_UsuarioModificacion);
                parametro.Add("@Cate_FechaModificacion", item.Cate_FechaModificacion);
                var result = db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);

                return new RequestStatus { CodeStatus = result, MessageStatus = "" };
            }
        }
    }
}
