using System;
using System.Collections.Generic;
using System.Linq;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class AmbienteContext : BaseConnection
    {
        public AmbienteContext(string connectionString) : base(connectionString)
        {
        }

        public List<Ambiente> GetAllAmbientes()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<Ambiente> listAmbientes = new List<Ambiente>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM ambiente", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Ambiente ambiente = new Ambiente();
                            ambiente.IdAmbiente = reader.GetInt32("id_ambiente");
                            ambiente.CodAmbiente = reader.GetString("cod_ambiente");
                            ambiente.Nombre = reader.GetString("nombre");
                            ambiente.IdSectorConsumo = reader.GetInt32("id_sector_consumo");
                            listAmbientes.Add(ambiente);
                        }
                    }

                    return listAmbientes;
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

        public List<Ambiente> GetAllAmbientesDetails()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<Ambiente> listAmbientes = new List<Ambiente>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM ambiente INNER JOIN circuito ON ambiente.id_ambiente = circuito.id_ambiente", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Ambiente ambiente = listAmbientes.Where(a => a.IdAmbiente == reader.GetInt32("id_ambiente")).FirstOrDefault();
                            if (ambiente == null)
                            {
                                ambiente = new Ambiente();
                                ambiente.IdAmbiente = reader.GetInt32("id_ambiente");
                                ambiente.CodAmbiente = reader.GetString("cod_ambiente");
                                ambiente.Nombre = reader.GetString("nombre");
                                ambiente.IdSectorConsumo = reader.GetInt32("id_sector_consumo");
                                ambiente.ListCircuitos = new List<Circuito>();

                                Circuito circuito = new Circuito();
                                circuito.IdCircuito = reader.GetInt32("id_circuito");
                                circuito.CodCircuito = reader.GetString("cod_circuito");
                                circuito.Nombre = reader.GetString("nombre");
                                circuito.IdAmbiente = reader.GetInt32("id_ambiente");
                                ambiente.ListCircuitos.Add(circuito);

                                listAmbientes.Add(ambiente);
                            }
                            else
                            {
                                Circuito circuito = new Circuito();
                                circuito.IdCircuito = reader.GetInt32("id_circuito");
                                circuito.CodCircuito = reader.GetString("cod_circuito");
                                circuito.Nombre = reader.GetString("nombre");
                                circuito.IdAmbiente = reader.GetInt32("id_ambiente");
                                ambiente.ListCircuitos.Add(circuito);
                            }
                        }
                    }

                    return listAmbientes;
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

        public Ambiente GetAmbiente(int idAmbiente)
        {
            using (MySqlConnection connection = GetConnection())
            {
                Ambiente ambiente = null;

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM ambiente WHERE id_ambiente = @idAmbiente", connection);
                    command.Parameters.AddWithValue("@idAmbiente", idAmbiente);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ambiente = new Ambiente
                            {
                                IdAmbiente = reader.GetInt32("id_ambiente"),
                                CodAmbiente = reader.GetString("cod_ambiente"),
                                Nombre = reader.GetString("nombre"),
                                IdSectorConsumo = reader.GetInt32("id_sector_consumo")
                            };
                        }
                    }

                    return ambiente;
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