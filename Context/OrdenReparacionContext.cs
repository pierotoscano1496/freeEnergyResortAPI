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
    }
}