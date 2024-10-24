﻿using api.Entities;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace api
{
    public class Repository
    {
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                 dbConnection.Open();
                return await dbConnection.QueryAsync<Usuario>("SELECT * FROM Usuarios");
            }
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                 dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<int> AddAsync(Usuario usuario)
        {
            using (IDbConnection dbConnection = new SqlConnection(_connectionString))
            {
                 dbConnection.Open();
                var sql = "INSERT INTO Usuarios (Nombre, Email, Edad) VALUES (@Nombre, @Email, @Edad); ; SELECT CAST(SCOPE_IDENTITY() as int);";
                return await dbConnection.QuerySingleAsync<int>(sql, usuario);
            }
        }
    }
}
