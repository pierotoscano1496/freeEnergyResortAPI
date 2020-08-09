using System;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class UsuarioContext : BaseConnection
    {
        public UsuarioContext(string connectionString) : base(connectionString)
        {
        }

        public Usuario Login(Usuario usuario)
        {
            using (MySqlConnection connection = GetConnection())
            {
                Usuario usuarioLogged = null;

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM usuario
                    INNER JOIN rol_usuario ON usuario.id_rol_usuario = rol_usuario.id_rol_usuario
                    WHERE correo = @correo AND contrasena = @contrasena", connection);
                    command.Parameters.AddWithValue("@correo", usuario.Correo);
                    command.Parameters.AddWithValue("@contrasena", usuario.Contrasena);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            usuarioLogged = new Usuario
                            {
                                IdUsuario = reader.GetInt32("id_usuario"),
                                UserName = reader.GetString("user_name"),
                                Dni = reader.GetString("dni"),
                                Nombres = reader.GetString("nombres"),
                                Apellidos = reader.GetString("apellidos"),
                                Correo = reader.GetString("correo"),
                                RolUsuario = new RolUsuario
                                {
                                    IdRolUsuario = reader.GetInt32("id_rol_usuario"),
                                    Tipo = reader.GetInt32("tipo"),
                                    Nombre = reader.GetString("nombre"),
                                    Descripcion = reader.GetString("descripcion")
                                }
                            };
                        }
                    }

                    return usuarioLogged;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}