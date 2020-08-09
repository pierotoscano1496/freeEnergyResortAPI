using System;
using System.Collections.Generic;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class ProduccionEnergiaContext : BaseConnection
    {
        public ProduccionEnergiaContext(string connectionString) : base(connectionString)
        {
        }

        public List<ProduccionEnergia> GetTotalesProduccionEnergiaInPeriod(DateTime fechaInicio, DateTime fechaFin)
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<ProduccionEnergia> listProduccionesEnergia = new List<ProduccionEnergia>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT SUM(cantidad) AS cantidad,fecha FROM produccion_energia
                    WHERE fecha BETWEEN @fechaInicio AND @fechaFin
                    GROUP BY fecha", connection);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ProduccionEnergia produccionEnergia = new ProduccionEnergia
                            {
                                Cantidad = reader.GetDecimal("cantidad"),
                                Fecha = reader.GetDateTime("fecha")
                            };
                            listProduccionesEnergia.Add(produccionEnergia);
                        }
                    }

                    return listProduccionesEnergia;
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