using System;
using System.Collections.Generic;
using System.Linq;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class SectorConsumoContext : BaseConnection
    {
        public SectorConsumoContext(string connectionString) : base(connectionString)
        {
        }

        public List<SectorConsumo> GetAllSectoresConsumoDetails()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<SectorConsumo> listSectoresConsumo = new List<SectorConsumo>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM sector_consumo INNER JOIN ambiente ON sector_consumo.id_sector_consumo = ambiente.id_sector_consumo ", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SectorConsumo sectorConsumo = listSectoresConsumo.Where(s => s.IdSectorConsumo == reader.GetInt32("id_sector_consumo")).FirstOrDefault();
                            if (sectorConsumo == null)
                            {
                                sectorConsumo = new SectorConsumo
                                {
                                    IdSectorConsumo = reader.GetInt32("id_sector_consumo"),
                                    CodSectorConsumo = reader.GetString("cod_sector_consumo"),
                                    Nombre = reader.GetString("nombre"),
                                    ListAmbientes = new List<Ambiente>()
                                };

                                Ambiente ambiente = new Ambiente
                                {
                                    IdAmbiente = reader.GetInt32("id_ambiente"),
                                    CodAmbiente = reader.GetString("cod_ambiente"),
                                    Nombre = reader.GetString("nombre"),
                                    IdSectorConsumo = reader.GetInt32("id_sector_consumo")
                                };
                                sectorConsumo.ListAmbientes.Add(ambiente);

                                listSectoresConsumo.Add(sectorConsumo);
                            }
                            else
                            {
                                Ambiente ambiente = new Ambiente
                                {
                                    IdAmbiente = reader.GetInt32("id_ambiente"),
                                    CodAmbiente = reader.GetString("cod_ambiente"),
                                    Nombre = reader.GetString("nombre"),
                                    IdSectorConsumo = reader.GetInt32("id_sector_consumo")
                                };
                                sectorConsumo.ListAmbientes.Add(ambiente);
                            }
                        }
                    }

                    return listSectoresConsumo;
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

        public List<SectorConsumo> GetConsumosEnergiaOfSectoresConsumoInPeriod(DateTime fechaInicio, DateTime fechaFin)
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<SectorConsumo> listSectoresConsumo = new List<SectorConsumo>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT sector_consumo.id_sector_consumo,sector_consumo.cod_sector_consumo,sector_consumo.nombre AS nombre_sector_consumo,
                    ambiente.id_ambiente,ambiente.cod_ambiente,ambiente.nombre AS nombre_ambiente,
                    consumo_energia.id_consumo_energia,consumo_energia.cantidad,consumo_energia.fecha
                    FROM sector_consumo INNER JOIN ambiente ON sector_consumo.id_sector_consumo = ambiente.id_sector_consumo
                    INNER JOIN consumo_energia ON ambiente.id_ambiente = consumo_energia.id_ambiente
                    WHERE consumo_energia.fecha BETWEEN CAST(@fechaInicio AS DATE) AND CAST(@fechaFin AS DATE)", connection);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SectorConsumo sectorConsumo = listSectoresConsumo.Where(s => s.IdSectorConsumo == reader.GetInt32("id_sector_consumo")).FirstOrDefault();
                            if (sectorConsumo == null)
                            {
                                sectorConsumo = new SectorConsumo
                                {
                                    IdSectorConsumo = reader.GetInt32("id_sector_consumo"),
                                    CodSectorConsumo = reader.GetString("cod_sector_consumo"),
                                    Nombre = reader.GetString("nombre_sector_consumo"),
                                    ListAmbientes = new List<Ambiente>()
                                };

                                Ambiente ambiente = new Ambiente
                                {
                                    IdAmbiente = reader.GetInt32("id_ambiente"),
                                    CodAmbiente = reader.GetString("cod_ambiente"),
                                    Nombre = reader.GetString("nombre_ambiente"),
                                    IdSectorConsumo = reader.GetInt32("id_sector_consumo"),
                                    ListConsumosEnergia = new List<ConsumoEnergia>()
                                };

                                ConsumoEnergia consumoEnergia = new ConsumoEnergia
                                {
                                    IdConsumoEnergia = reader.GetInt32("id_consumo_energia"),
                                    Cantidad = reader.GetDecimal("cantidad"),
                                    Fecha = reader.GetDateTime("fecha"),
                                    IdAmbiente = reader.GetInt32("id_ambiente")
                                };
                                ambiente.ListConsumosEnergia.Add(consumoEnergia);
                                sectorConsumo.ListAmbientes.Add(ambiente);
                                listSectoresConsumo.Add(sectorConsumo);
                            }
                            else
                            {
                                Ambiente ambiente = sectorConsumo.ListAmbientes.Where(a => a.IdAmbiente == reader.GetInt32("id_ambiente")).FirstOrDefault();
                                if (ambiente == null)
                                {
                                    ambiente = new Ambiente
                                    {
                                        IdAmbiente = reader.GetInt32("id_ambiente"),
                                        CodAmbiente = reader.GetString("cod_ambiente"),
                                        Nombre = reader.GetString("nombre_ambiente"),
                                        IdSectorConsumo = reader.GetInt32("id_sector_consumo"),
                                        ListConsumosEnergia = new List<ConsumoEnergia>()
                                    };

                                    ConsumoEnergia consumoEnergia = new ConsumoEnergia
                                    {
                                        IdConsumoEnergia = reader.GetInt32("id_consumo_energia"),
                                        Cantidad = reader.GetDecimal("cantidad"),
                                        Fecha = reader.GetDateTime("fecha"),
                                        IdAmbiente = reader.GetInt32("id_ambiente")
                                    };
                                    ambiente.ListConsumosEnergia.Add(consumoEnergia);
                                    sectorConsumo.ListAmbientes.Add(ambiente);
                                }
                                else
                                {
                                    ConsumoEnergia consumoEnergia = new ConsumoEnergia
                                    {
                                        IdConsumoEnergia = reader.GetInt32("id_consumo_energia"),
                                        Cantidad = reader.GetDecimal("cantidad"),
                                        Fecha = reader.GetDateTime("fecha"),
                                        IdAmbiente = reader.GetInt32("id_ambiente")
                                    };
                                    ambiente.ListConsumosEnergia.Add(consumoEnergia);
                                }
                            }
                        }
                    }

                    return listSectoresConsumo;
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