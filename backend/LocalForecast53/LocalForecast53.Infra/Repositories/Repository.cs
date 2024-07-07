using Dapper;
using LocalForecast53.Core.Entities;
using LocalForecast53.Core.Interfaces;
using LocalForecast53.Infra.Contexts;
using LocalForecast53.Shared.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Text;

namespace LocalForecast53.Infra.Repositories
{
    public class Repository<TEntity> : AbstractRepository<TEntity>, IRepository<TEntity> where TEntity : BaseEntity
    {
        protected IDbConnection DbConnection { get; private set; }

        public Repository(DatabaseConfiguration databaseConfiguration)
        {
            DbConnection = new SQLDbContext(databaseConfiguration.ProviderName)
                .GetDbContext(databaseConfiguration.ConnectionString);
        }

        public void Add(TEntity entity)
        {
            DbConnection.Open();
            try
            {
                string tableName = GetTableName();
                string columns = GetColumns();
                string properties = GetPropertyNames();
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({properties})";
                DbConnection.Execute(query, entity);
            }
            finally { DbConnection.Close(); }
        }

        public IEnumerable<TEntity> GetAll()
        {
            DbConnection.Open();
            try
            {
                string tableName = GetTableName();
                string query = $"SELECT * FROM {tableName}";

                return DbConnection.Query<TEntity>(query);
            }

            finally { DbConnection.Close(); }
        }

        public TEntity? GetByField(string field, object value)
        {
            DbConnection.Open();
            try
            {
                string tableName = GetTableName();
                string query = $"SELECT * FROM {tableName} WHERE {field} = @Value";

                // Executa a consulta e retornar os resultados
                return DbConnection.QueryFirstOrDefault<TEntity>(query, new
                {
                    Value = value
                });
            }
            finally { DbConnection.Close(); }
        }

        public TEntity? GetById(object id)
        {
            DbConnection.Open();
            try
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string query = $"SELECT * FROM {tableName} WHERE {keyColumn} = @Value";

                return DbConnection.QueryFirstOrDefault<TEntity>(query, new
                {
                    Value = id
                });
            }
            finally { DbConnection.Close(); }
        }

        public void Remove(object id)
        {
            try
            {
                var entity = GetById(id);
                if (entity != null)
                {
                    Remove(entity);
                }
            }
            finally { DbConnection.Close(); }
        }

        public void Remove(TEntity entity)
        {
            DbConnection.Open();
            int rowsEffected = 0;
            try
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string keyProperty = GetKeyPropertyName();
                string query = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";
                rowsEffected = DbConnection.Execute(query, entity.Id);
            }
            finally { DbConnection.Close(); }
        }

        public void Update(TEntity entity)
        {
            DbConnection.Open();
            try
            {
                string tableName = GetTableName();
                string keyColumn = GetKeyColumnName();
                string keyProperty = GetKeyPropertyName();

                StringBuilder query = new StringBuilder();
                query.Append($"UPDATE {tableName} SET ");

                foreach (var property in GetProperties(true))
                {
                    var columnAttr = property.GetCustomAttribute<ColumnAttribute>();
                    string propertyName = property.Name;
                    string columnName = columnAttr.Name;

                    query.Append($"{columnName} = @{propertyName},");
                }

                query.Remove(query.Length - 1, 1);
                query.Append($" WHERE {keyColumn} = @{keyProperty}");

                DbConnection.Execute(query.ToString(), entity);
            }
            finally { DbConnection.Close(); }
        }

        public void UpdateFields(object id, Dictionary<string, object> fields)
        {
            DbConnection.Open();
            try
            {
                string tableName = GetTableName();

                // Montar a parte SET da consulta
                string setClause = string.Join(", ", fields.Select(p => $"{p.Key} = @{p.Key}"));
                var valores = fields.ToDictionary(k => k.Key, v => v.Value);
                valores.Add("@Id", id);

                // Montar a consulta completa
                string sqlQuery = $"UPDATE {tableName} SET {setClause} WHERE Id = @Id";

                DbConnection.Execute(sqlQuery, valores);
            }
            finally { DbConnection.Close(); }
        }
    }
}
