using System;
using System.Collections.Generic;
using System.Linq;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class SectorProduccionContext : BaseConnection
    {
        public SectorProduccionContext(string connectionString) : base(connectionString)
        {
        }

        public List<SectorProduccion> GetAllSectoresProduccion()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<SectorProduccion> listSectoresProduccion = new List<SectorProduccion>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM sector_produccion", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SectorProduccion sectorProduccion = new SectorProduccion
                            {
                                IdSectorProduccion = reader.GetInt32("id_sector_produccion"),
                                CodSectorProduccion = reader.GetString("cod_sector_produccion"),
                                Nombre = reader.GetString("nombre")
                            };
                            listSectoresProduccion.Add(sectorProduccion);
                        }
                    }

                    return listSectoresProduccion;
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

        public List<SectorProduccion> GetAllSectoresProduccionDetails()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<SectorProduccion> listSectoresProduccion = new List<SectorProduccion>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT sector_produccion.id_sector_produccion, sector_produccion.cod_sector_produccion, sector_produccion.nombre AS nombre_sector_produccion,
                    fuente_energia.id_fuente_energia, fuente_energia.cod_fuente_energia, fuente_energia.nombre AS nombre_fuente_energia, fuente_energia.tipo, fuente_energia.potencia
                    FROM sector_produccion INNER JOIN fuente_energia ON sector_produccion.id_sector_produccion = fuente_energia.id_sector_produccion", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SectorProduccion sectorProduccion = listSectoresProduccion.Where(s => s.IdSectorProduccion == reader.GetInt32("id_sector_produccion")).FirstOrDefault();
                            if (sectorProduccion == null)
                            {
                                sectorProduccion = new SectorProduccion
                                {
                                    IdSectorProduccion = reader.GetInt32("id_sector_produccion"),
                                    CodSectorProduccion = reader.GetString("cod_sector_produccion"),
                                    Nombre = reader.GetString("nombre_sector_produccion"),
                                    ListFuentesEnergia = new List<FuenteEnergia>()
                                };

                                FuenteEnergia fuenteEnergia = new FuenteEnergia
                                {
                                    IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                    CodFuenteEnergia = reader.GetString("cod_fuente_energia"),
                                    Nombre = reader.GetString("nombre_fuente_energia"),
                                    Tipo = reader.GetString("tipo"),
                                    Potencia = reader.GetDecimal("potencia"),
                                    IdSectorProduccion = reader.GetInt32("id_sector_produccion")
                                };
                                sectorProduccion.ListFuentesEnergia.Add(fuenteEnergia);

                                listSectoresProduccion.Add(sectorProduccion);
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
                                sectorProduccion.ListFuentesEnergia.Add(fuenteEnergia);
                            }
                        }
                    }

                    return listSectoresProduccion;
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

        public SectorProduccion GetSectorProduccionDetails(int idSectorProduccion)
        {
            using (MySqlConnection connection = GetConnection())
            {
                SectorProduccion sectorProduccion = null;

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT sector_produccion.id_sector_produccion, sector_produccion.cod_sector_produccion, sector_produccion.nombre AS nombre_sector_produccion,
                    fuente_energia.id_fuente_energia, fuente_energia.cod_fuente_energia, fuente_energia.nombre AS nombre_fuente_energia, fuente_energia.tipo, fuente_energia.potencia
                    FROM sector_produccion INNER JOIN fuente_energia ON sector_produccion.id_sector_produccion = fuente_energia.id_sector_produccion
                    WHERE sector_produccion.id_sector_produccion = @idSectorProduccion", connection);
                    command.Parameters.AddWithValue("@idSectorProduccion", idSectorProduccion);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (sectorProduccion == null)
                            {
                                sectorProduccion = new SectorProduccion
                                {
                                    IdSectorProduccion = reader.GetInt32("id_sector_produccion"),
                                    CodSectorProduccion = reader.GetString("cod_sector_produccion"),
                                    Nombre = reader.GetString("nombre_sector_produccion"),
                                    ListFuentesEnergia = new List<FuenteEnergia>()
                                };
                            }

                            FuenteEnergia fuenteEnergia = new FuenteEnergia
                            {
                                IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                CodFuenteEnergia = reader.GetString("cod_fuente_energia"),
                                Nombre = reader.GetString("nombre_fuente_energia"),
                                Tipo = reader.GetString("tipo"),
                                Potencia = reader.GetDecimal("potencia"),
                                IdSectorProduccion = reader.GetInt32("id_sector_produccion")
                            };

                            sectorProduccion.ListFuentesEnergia.Add(fuenteEnergia);
                        }
                    }

                    return sectorProduccion;
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

        public List<SectorProduccion> GetProduccionesEnergiaOfSectoresProduccionInPeriod(DateTime fechaInicio, DateTime fechaFin)
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<SectorProduccion> listSectoresProduccion = new List<SectorProduccion>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT sector_produccion.id_sector_produccion,sector_produccion.cod_sector_produccion,sector_produccion.nombre AS nombre_sector_produccion,
                    fuente_energia.id_fuente_energia,fuente_energia.cod_fuente_energia,fuente_energia.nombre AS nombre_fuente_energia,fuente_energia.tipo,fuente_energia.potencia,
                    produccion_energia.id_produccion_energia,produccion_energia.cantidad,produccion_energia.fecha FROM sector_produccion
                    INNER JOIN fuente_energia ON sector_produccion.id_sector_produccion = fuente_energia.id_sector_produccion
                    INNER JOIN produccion_energia ON fuente_energia.id_fuente_energia = produccion_energia.id_fuente_energia
                    WHERE produccion_energia.fecha BETWEEN CAST(@fechaInicio AS DATE) AND CAST(@fechaFin AS DATE)", connection);
                    command.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@fechaFin", fechaFin);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SectorProduccion sectorProduccion = listSectoresProduccion.Where(s => s.IdSectorProduccion == reader.GetInt32("id_sector_produccion")).FirstOrDefault();
                            if (sectorProduccion == null)
                            {
                                sectorProduccion = new SectorProduccion
                                {
                                    IdSectorProduccion = reader.GetInt32("id_sector_produccion"),
                                    CodSectorProduccion = reader.GetString("cod_sector_produccion"),
                                    Nombre = reader.GetString("nombre_sector_produccion"),
                                    ListFuentesEnergia = new List<FuenteEnergia>()
                                };

                                FuenteEnergia fuenteEnergia = new FuenteEnergia
                                {
                                    IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                    CodFuenteEnergia = reader.GetString("cod_fuente_energia"),
                                    Nombre = reader.GetString("nombre_fuente_energia"),
                                    Tipo = reader.GetString("tipo"),
                                    Potencia = reader.GetDecimal("potencia"),
                                    IdSectorProduccion = reader.GetInt32("id_sector_produccion"),
                                    ListProduccionesEnergia = new List<ProduccionEnergia>()
                                };

                                ProduccionEnergia produccionEnergia = new ProduccionEnergia
                                {
                                    IdProduccionEnergia = reader.GetInt32("id_produccion_energia"),
                                    IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                    Cantidad = reader.GetDecimal("cantidad"),
                                    Fecha = reader.GetDateTime("fecha")
                                };
                                fuenteEnergia.ListProduccionesEnergia.Add(produccionEnergia);
                                sectorProduccion.ListFuentesEnergia.Add(fuenteEnergia);
                                listSectoresProduccion.Add(sectorProduccion);
                            }
                            else
                            {
                                FuenteEnergia fuenteEnergia = sectorProduccion.ListFuentesEnergia.Where(f => f.IdFuenteEnergia == reader.GetInt32("id_fuente_energia")).FirstOrDefault();
                                if (fuenteEnergia == null)
                                {
                                    fuenteEnergia = new FuenteEnergia
                                    {
                                        IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                        CodFuenteEnergia = reader.GetString("cod_fuente_energia"),
                                        Nombre = reader.GetString("nombre_fuente_energia"),
                                        Tipo = reader.GetString("tipo"),
                                        Potencia = reader.GetDecimal("potencia"),
                                        IdSectorProduccion = reader.GetInt32("id_sector_produccion"),
                                        ListProduccionesEnergia = new List<ProduccionEnergia>()
                                    };

                                    ProduccionEnergia produccionEnergia = new ProduccionEnergia
                                    {
                                        IdProduccionEnergia = reader.GetInt32("id_produccion_energia"),
                                        IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                        Cantidad = reader.GetDecimal("cantidad"),
                                        Fecha = reader.GetDateTime("fecha")
                                    };
                                    fuenteEnergia.ListProduccionesEnergia.Add(produccionEnergia);
                                    sectorProduccion.ListFuentesEnergia.Add(fuenteEnergia);
                                }
                                else
                                {
                                    ProduccionEnergia produccionEnergia = new ProduccionEnergia
                                    {
                                        IdProduccionEnergia = reader.GetInt32("id_produccion_energia"),
                                        IdFuenteEnergia = reader.GetInt32("id_fuente_energia"),
                                        Cantidad = reader.GetDecimal("cantidad"),
                                        Fecha = reader.GetDateTime("fecha")
                                    };
                                    fuenteEnergia.ListProduccionesEnergia.Add(produccionEnergia);
                                }
                            }
                        }
                    }

                    return listSectoresProduccion;
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