using System.Collections.Generic;
using System.Data;
using System.Linq;
using ConexionBd;
using Dapper;

using MySqlConnector;

public class UsuarioDAO
{
    private readonly string _connectionString;

    public UsuarioDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Crear un nuevo usuario
    public void CrearUsuario(string nombre, int edad)
    {
        using (IDbConnection db = new MySqlConnection(_connectionString))
        {
            string query = "INSERT INTO Usuarios (Nombre, Edad) VALUES (@Nombre, @Edad)";
            db.Execute(query, new { Nombre = nombre, Edad = edad });
        }
    }

    // Obtener la lista de usuarios
    public List<Usuario> ObtenerUsuarios()
    {
        using (IDbConnection db = new MySqlConnection(_connectionString))
        {
            string query = "SELECT Id, Nombre, Edad FROM Usuarios";
            return db.Query<Usuario>(query).ToList();
        }
    }

    // Obtener un usuario por su ID
    public Usuario ObtenerUsuarioPorId(int id)
    {
        using (IDbConnection db = new MySqlConnection(_connectionString))
        {
            string query = "SELECT Id, Nombre, Edad FROM Usuarios WHERE Id = @Id";
            return db.Query<Usuario>(query, new { Id = id }).FirstOrDefault();
        }
    }

    // Actualizar un usuario existente
    public void ActualizarUsuario(int id, string nombre, int edad)
    {
        using (IDbConnection db = new MySqlConnection(_connectionString))
        {
            string query = "UPDATE Usuarios SET Nombre = @Nombre, Edad = @Edad WHERE Id = @Id";
            db.Execute(query, new { Id = id, Nombre = nombre, Edad = edad });
        }
    }

    // Borrar un usuario (borrado físico)
    public void BorrarUsuario(int id)
    {
        using (IDbConnection db = new MySqlConnection(_connectionString))
        {
            string query = "DELETE FROM Usuarios WHERE Id = @Id";
            db.Execute(query, new { Id = id });
        }
    }
}
