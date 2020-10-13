using System;
using System.Collections.Generic;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class OrdenReparacionContext : BaseConnection
    {
        public OrdenReparacionContext(string connectionString) : base(connectionString)
        {
        }

        public OrdenReparacion GetOrdenReparacion(int idOrdenReparacion)
        {
            using (MySqlConnection connection = GetConnection())
            {
                OrdenReparacion ordenReparacion = null;

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM orden_reparacion WHERE id_orden_reparacion = @idOrdenReparacion", connection);
                    command.Parameters.AddWithValue("@idOrdenReparacion", idOrdenReparacion);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ordenReparacion = new OrdenReparacion
                            {
                                IdOrdenReparacion = reader.GetInt32("id_orden_reparacion"),
                                IdAmbiente = reader.IsDBNull(reader.GetOrdinal("id_ambiente")) ? (int?)null : reader.GetInt32("id_ambiente"),
                                IdPersonalMantenimiento = reader.GetInt32("id_personal_mantenimiento"),
                                IdCircuito = reader.IsDBNull(reader.GetOrdinal("id_circuito")) ? (int?)null : reader.GetInt32("id_circuito"),
                                IdFuenteEnergia = reader.IsDBNull(reader.GetOrdinal("id_fuente_energia")) ? (int?)null : reader.GetInt32("id_fuente_energia"),
                                IdUsuario = reader.GetInt32("id_usuario"),
                                Fecha = reader.GetDateTime("fecha"),
                                Estado = reader.GetInt32("estado")
                            };
                        }
                    }

                    return ordenReparacion;
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

        public List<OrdenReparacion> GetOrdenesReparacionPendientes()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<OrdenReparacion> listOrdenesReparacion = new List<OrdenReparacion>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM orden_reparacion WHERE estado = 1", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OrdenReparacion ordenReparacion = new OrdenReparacion
                            {
                                IdOrdenReparacion = reader.GetInt32("id_orden_reparacion"),
                                IdAmbiente = reader.IsDBNull(reader.GetOrdinal("id_ambiente")) ? (int?)null : reader.GetInt32("id_ambiente"),
                                IdPersonalMantenimiento = reader.GetInt32("id_personal_mantenimiento"),
                                IdCircuito = reader.IsDBNull(reader.GetOrdinal("id_circuito")) ? (int?)null : reader.GetInt32("id_circuito"),
                                IdFuenteEnergia = reader.IsDBNull(reader.GetOrdinal("id_fuente_energia")) ? (int?)null : reader.GetInt32("id_fuente_energia"),
                                IdUsuario = reader.GetInt32("id_usuario"),
                                Fecha = reader.GetDateTime("fecha"),
                                Estado = reader.GetInt32("estado")
                            };
                            listOrdenesReparacion.Add(ordenReparacion);
                        }
                    }

                    return listOrdenesReparacion;
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

        public List<OrdenReparacion> GetOrdenesReparacionPendientesForAmbientes()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<OrdenReparacion> listOrdenesReparacion = new List<OrdenReparacion>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM orden_reparacion WHERE estado = 1 AND id_ambiente IS NOT NULL", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OrdenReparacion ordenReparacion = new OrdenReparacion
                            {
                                IdOrdenReparacion = reader.GetInt32("id_orden_reparacion"),
                                IdAmbiente = reader.IsDBNull(reader.GetOrdinal("id_ambiente")) ? (int?)null : reader.GetInt32("id_ambiente"),
                                IdPersonalMantenimiento = reader.GetInt32("id_personal_mantenimiento"),
                                IdCircuito = reader.IsDBNull(reader.GetOrdinal("id_circuito")) ? (int?)null : reader.GetInt32("id_circuito"),
                                IdFuenteEnergia = reader.IsDBNull(reader.GetOrdinal("id_fuente_energia")) ? (int?)null : reader.GetInt32("id_fuente_energia"),
                                IdUsuario = reader.GetInt32("id_usuario"),
                                Fecha = reader.GetDateTime("fecha"),
                                Estado = reader.GetInt32("estado")
                            };
                            listOrdenesReparacion.Add(ordenReparacion);
                        }
                    }

                    return listOrdenesReparacion;
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

        public List<OrdenReparacion> GetOrdenesReparacionPendientesForFuentesEnergia()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<OrdenReparacion> listOrdenesReparacion = new List<OrdenReparacion>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM orden_reparacion WHERE estado = 1 AND id_fuente_energia IS NOT NULL", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OrdenReparacion ordenReparacion = new OrdenReparacion
                            {
                                IdOrdenReparacion = reader.GetInt32("id_orden_reparacion"),
                                IdAmbiente = reader.IsDBNull(reader.GetOrdinal("id_ambiente")) ? (int?)null : reader.GetInt32("id_ambiente"),
                                IdPersonalMantenimiento = reader.GetInt32("id_personal_mantenimiento"),
                                IdCircuito = reader.IsDBNull(reader.GetOrdinal("id_circuito")) ? (int?)null : reader.GetInt32("id_circuito"),
                                IdFuenteEnergia = reader.IsDBNull(reader.GetOrdinal("id_fuente_energia")) ? (int?)null : reader.GetInt32("id_fuente_energia"),
                                IdUsuario = reader.GetInt32("id_usuario"),
                                Fecha = reader.GetDateTime("fecha"),
                                Estado = reader.GetInt32("estado")
                            };
                            listOrdenesReparacion.Add(ordenReparacion);
                        }
                    }

                    return listOrdenesReparacion;
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

        public List<OrdenReparacion> GetOrdenesReparacionByPersonalMantenimiento(int idPersonalMantenimiento, int estado)
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<OrdenReparacion> listOrdenesReparacion = new List<OrdenReparacion>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT orden_reparacion.id_orden_reparacion, orden_reparacion.fecha, orden_reparacion.estado,
                    ambiente.id_ambiente, ambiente.cod_ambiente, ambiente.nombre AS nombre_ambiente,
                    circuito.id_circuito, circuito.cod_circuito, circuito.nombre AS nombre_circuito,
                    fuente_energia.id_fuente_energia, fuente_energia.cod_fuente_energia, fuente_energia.nombre AS nombre_fuente_energia, fuente_energia.tipo, fuente_energia.potencia, fuente_energia.id_sector_produccion,
                    usuario.id_usuario, usuario.user_name, usuario.dni, usuario.nombres AS nombres_usuario, usuario.apellidos, usuario.correo, usuario.id_rol_usuario
                    FROM orden_reparacion LEFT JOIN ambiente ON orden_reparacion.id_ambiente = ambiente.id_ambiente
                    LEFT JOIN circuito ON orden_reparacion.id_circuito = circuito.id_circuito
                    LEFT JOIN personal_mantenimiento ON orden_reparacion.id_personal_mantenimiento = personal_mantenimiento.id_usuario
                    LEFT JOIN fuente_energia ON orden_reparacion.id_fuente_energia = fuente_energia.id_fuente_energia
                    LEFT JOIN usuario ON orden_reparacion.id_usuario = usuario.id_usuario
                    WHERE orden_reparacion.id_personal_mantenimiento = @idPersonalMantenimiento
                    AND orden_reparacion.estado = @estado", connection);
                    command.Parameters.AddWithValue("@idPersonalMantenimiento", idPersonalMantenimiento);
                    command.Parameters.AddWithValue("@estado", estado);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OrdenReparacion ordenReparacion = new OrdenReparacion
                            {
                                IdOrdenReparacion = reader.GetInt32("id_orden_reparacion"),
                                Fecha = reader.GetDateTime("fecha"),
                                Estado = reader.GetInt32("estado")
                            };

                            if (reader.IsDBNull(reader.GetOrdinal("id_fuente_energia")))
                            {
                                Ambiente ambiente = new Ambiente
                                {
                                    IdAmbiente = reader.GetInt32("id_ambiente"),
                                    CodAmbiente = reader.GetString("cod_ambiente"),
                                    Nombre = reader.GetString("nombre_ambiente")
                                };

                                Circuito circuito = new Circuito
                                {
                                    IdCircuito = reader.GetInt32("id_circuito"),
                                    CodCircuito = reader.GetString("cod_circuito"),
                                    Nombre = reader.GetString("nombre_circuito")
                                };

                                ordenReparacion.Ambiente = ambiente;
                                ordenReparacion.Circuito = circuito;
                            }
                            else
                            {
                                FuenteEnergia fuenteEnergia = new FuenteEnergia
                                {
                                    IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                    CodFuenteEnergia = reader.GetString("cod_fuente_energia"),
                                    Nombre = reader.GetString("nombre_fuente_energia"),
                                    Tipo = reader.GetString("tipo"),
                                    Potencia = reader.GetDecimal("potencia"),
                                    IdSectorProduccion = reader.GetInt32("id_sector_produccion")
                                };

                                ordenReparacion.FuenteEnergia = fuenteEnergia;
                            }

                            Usuario usuario = new Usuario
                            {
                                IdUsuario = reader.GetInt32("id_usuario"),
                                UserName = reader.GetString("user_name"),
                                Dni = reader.GetString("dni"),
                                Nombres = reader.GetString("nombres_usuario"),
                                Apellidos = reader.GetString("apellidos"),
                                Correo = reader.GetString("correo"),
                                IdRolUsuario = reader.GetInt32("id_rol_usuario")
                            };

                            ordenReparacion.Usuario = usuario;
                            listOrdenesReparacion.Add(ordenReparacion);
                        }
                    }

                    return listOrdenesReparacion;
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

        public int AddOrdenReparacion(OrdenReparacion ordenReparacion)
        {
            int lastIdOrdenReparacion = 0;
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"INSERT INTO orden_reparacion(id_ambiente,id_personal_mantenimiento,id_circuito,id_fuente_energia,id_usuario,fecha,estado) VALUES (@IdAmbiente,@IdPersonalMantenimiento,@IdCircuito,@IdFuenteEnergia,@IdUsuario,@Fecha,@Estado);
                    SELECT MAX(id_orden_reparacion) AS id_orden_reparacion FROM orden_reparacion", connection);
                    command.Parameters.AddWithValue("@IdAmbiente", ordenReparacion.IdAmbiente);
                    command.Parameters.AddWithValue("@IdPersonalMantenimiento", ordenReparacion.IdPersonalMantenimiento);
                    command.Parameters.AddWithValue("@IdCircuito", ordenReparacion.IdCircuito);
                    command.Parameters.AddWithValue("@IdFuenteEnergia", ordenReparacion.IdFuenteEnergia);
                    command.Parameters.AddWithValue("@IdUsuario", ordenReparacion.IdUsuario);
                    command.Parameters.AddWithValue("@Fecha", ordenReparacion.Fecha);
                    command.Parameters.AddWithValue("@Estado", ordenReparacion.Estado);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lastIdOrdenReparacion = reader.GetInt32("id_orden_reparacion");
                        }
                    }

                    return lastIdOrdenReparacion;
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

        public int AddListOrdenesReparaciones(List<OrdenReparacion> listOrdenesReparacion)
        {
            int createdItems = 0;
            foreach (OrdenReparacion ordenReparacion in listOrdenesReparacion)
            {
                int lastIdOrdenReparacion = AddOrdenReparacion(ordenReparacion);
                if (lastIdOrdenReparacion != 0)
                {
                    createdItems++;
                }
            }

            return createdItems;
        }

        public int SetOrdenReparacionEstado(int idOrdenReparacion, OrdenReparacion ordenReparacion)
        {
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"UPDATE orden_reparacion SET estado = @estado WHERE id_orden_reparacion = @idOrdenReparacion", connection);
                    command.Parameters.AddWithValue("@estado", ordenReparacion.Estado);
                    command.Parameters.AddWithValue("@idOrdenReparacion", idOrdenReparacion);

                    return command.ExecuteNonQuery();
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