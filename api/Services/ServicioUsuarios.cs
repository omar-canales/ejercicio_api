using api.Entities;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using api.Connection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Specialized;

namespace api.Services
{
    public class ServicioUsuarios : IUsuarios
    {
        
        private readonly IConnection _connection;

        public ServicioUsuarios(IConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            IDbConnection conn = _connection.GetConnection;

            using (IDbConnection dbConnection = conn)
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();
                return await dbConnection.QueryAsync<Usuario>("SELECT * FROM Usuarios");
            }



        }
            public async Task<Usuario> GetByIdAsync(int id)
        {
            IDbConnection conn = _connection.GetConnection;

            using (IDbConnection dbConnection = conn)
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Usuario>("SELECT * FROM Usuarios WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task<int> AddAsync(Usuario usuario)
        {
            IDbConnection conn = _connection.GetConnection;

            using (IDbConnection dbConnection = conn)
            {
                if (dbConnection.State == ConnectionState.Closed)
                    dbConnection.Open();
                var sql = "INSERT INTO Usuarios (Nombre, Email, Edad) VALUES (@Nombre, @Email, @Edad); ; SELECT CAST(SCOPE_IDENTITY() as int);";
                return await dbConnection.QuerySingleAsync<int>(sql, usuario);
            }
        }

        public string Usuario()
        {
            return "Usuario Creado";
        }
    }
}
