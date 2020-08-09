using System;
using System.Collections.Generic;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class FuenteEnergiaContext : BaseConnection
    {
        public FuenteEnergiaContext(string connectionString) : base(connectionString)
        {
        }

        public List<FuenteEnergia> GetFuentesEnergiaBySectorProduccion(int idSectorProduccion)
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<FuenteEnergia> listFuentesEnergia = new List<FuenteEnergia>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM fuente_energia WHERE id_sector_produccion = @idSectorProduccion", connection);
                    command.Parameters.AddWithValue("@idSectorProduccion", idSectorProduccion);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            FuenteEnergia fuenteEnergia = new FuenteEnergia
                            {
                                IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                CodFuenteEnergia = reader.GetString("cod_fuente_energia"),
                                Nombre = reader.GetString("nombre"),
                                Tipo = reader.GetString("tipo"),
                                Potencia = reader.GetDecimal("potencia"),
                                IdSectorProduccion = reader.GetInt32("id_sector_produccion")
                            };
                            listFuentesEnergia.Add(fuenteEnergia);
                        }
                    }

                    return listFuentesEnergia;
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

        public FuenteEnergia GetFuenteEnergia(int idFuenteEnergia)
        {
            using (MySqlConnection connection = GetConnection())
            {
                FuenteEnergia fuenteEnergia = null;

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM fuente_energia WHERE id_fuente_energia = @idSectorProduccion", connection);
                    command.Parameters.AddWithValue("@idSectorProduccion", idFuenteEnergia);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fuenteEnergia = new FuenteEnergia
                            {
                                IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                CodFuenteEnergia = reader.GetString("cod_fuente_energia"),
                                Nombre = reader.GetString("nombre"),
                                Tipo = reader.GetString("tipo"),
                                Potencia = reader.GetDecimal("potencia"),
                                IdSectorProduccion = reader.GetInt32("id_sector_produccion")
                            };
                        }
                    }

                    return fuenteEnergia;
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