using System;
using System.Collections.Generic;
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
            List<Ambiente> listAmbientes = new List<Ambiente>();

            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM ambiente", conn);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Ambiente ambiente = new Ambiente();
                        ambiente.IdAmbiente = reader.GetInt32("id_ambiente");
                        ambiente.CodAmbiente = reader.GetString("cod_ambiente");
                        ambiente.IdUbicacion = reader.GetInt32("id_ubicacion");
                        ambiente.IdTipoAmbiente = reader.GetInt32("id_tipo_ambiente");
                        ambiente.Nombre = reader.GetString("nombre");

                        listAmbientes.Add(ambiente);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                return listAmbientes;
            }
        }
    }
}