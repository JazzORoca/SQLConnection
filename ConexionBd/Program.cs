


class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Database=Usuarios_db;User ID=root;Password=2002;SslMode=Preferred;AllowPublicKeyRetrieval=True;";

        var usuarioDAO = new UsuarioDAO(connectionString);

        // Crear usuario
        Console.WriteLine("Creando usuarios...");
        usuarioDAO.CrearUsuario("Juan Perez", 30);
        usuarioDAO.CrearUsuario("Ana García", 25);

        // Obtener lista de usuarios
        Console.WriteLine("\nLista de usuarios:");
        var usuarios = usuarioDAO.ObtenerUsuarios();
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"ID: {usuario.id}, Nombre: {usuario.nombre}, Edad: {usuario.edad}");
        }

        // Obtener usuario por ID
        Console.WriteLine("\nObteniendo usuario con ID 1:");
        var usuarioPorId = usuarioDAO.ObtenerUsuarioPorId(1);
        if (usuarioPorId != null)
        {
            Console.WriteLine($"Usuario encontrado: ID: {usuarioPorId.id}, Nombre: {usuarioPorId.nombre}, Edad: {usuarioPorId.edad}");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado.");
        }

        // Actualizar usuario
        Console.WriteLine("\nActualizando usuario con ID 1...");
        usuarioDAO.ActualizarUsuario(1, "Juan Actualizado", 35);

        // Verificar actualización
        var usuarioActualizado = usuarioDAO.ObtenerUsuarioPorId(1);
        Console.WriteLine($"Usuario actualizado: ID: {usuarioActualizado.id}, Nombre: {usuarioActualizado.nombre}, Edad: {usuarioActualizado.edad}");

        // Borrar usuario
        Console.WriteLine("\nBorrando usuario con ID 2...");
        usuarioDAO.BorrarUsuario(2);

        // Verificar borrado
        Console.WriteLine("\nLista actualizada de usuarios:");
        usuarios = usuarioDAO.ObtenerUsuarios();
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"ID: {usuario.id}, Nombre: {usuario.nombre}, Edad: {usuario.edad}");
        }
    }
}

