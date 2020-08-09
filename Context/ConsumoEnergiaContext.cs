using System;
using System.Collections.Generic;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class ConsumoEnergiaContext : BaseConnection
    {
        public ConsumoEnergiaContext(string connectionString) : base(connectionString)
        {
        }

        public List<ConsumoEnergia> GetTotalesConsumoEnergiaInPeriod(DateTime fechaInicio, DateTime fechaFin)
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<ConsumoEnergia> listConsumosEnergia = new List<ConsumoEnergia>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT SUM(cantidad) AS cantidad,fecha FROM consumo_energia
                    WHERE fecha BETWEEN @fechaInicio AND @fechaFin
                    GROUP BY fecha", connection);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ConsumoEnergia consumoEnergia = new ConsumoEnergia
                            {
                                Cantidad = reader.GetDecimal("cantidad"),
                                Fecha = reader.GetDateTime("fecha")
                            };
                            listConsumosEnergia.Add(consumoEnergia);
                        }
                    }

                    return listConsumosEnergia;
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