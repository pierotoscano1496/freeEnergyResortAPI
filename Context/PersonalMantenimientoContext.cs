using System;
using System.Collections.Generic;
using freeEnergyResortAPI.Models;
using MySql.Data.MySqlClient;

namespace freeEnergyResortAPI.Context
{
    public class PersonalMantenimientoContext : BaseConnection
    {
        public PersonalMantenimientoContext(string connectionString) : base(connectionString)
        {
        }

        public List<PersonalMantenimiento> GetPersonalesMantenimientoDisponibles()
        {
            using (MySqlConnection connection = GetConnection())
            {
                List<PersonalMantenimiento> listPersonalesMantenimiento = new List<PersonalMantenimiento>();

                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"SELECT * FROM personal_mantenimiento WHERE condicion = 1", connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PersonalMantenimiento personalMantenimiento = new PersonalMantenimiento
                            {
                                IdPersonalMantenimiento = reader.GetInt32("id_personal_mantenimiento"),
                                CodPersonalMantenimiento = reader.GetString("cod_personal_mantenimiento"),
                                Dni = reader.GetString("dni"),
                                Nombres = reader.GetString("nombres"),
                                Apellidos = reader.GetString("apellidos"),
                                Condicion = reader.GetInt32("condicion")
                            };
                            listPersonalesMantenimiento.Add(personalMantenimiento);
                        }
                    }

                    return listPersonalesMantenimiento;
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

        public int SetPersonalMantenimientoCondicion(int idPersonalMantenimiento, PersonalMantenimiento personalMantenimiento)
        {
            using (MySqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(@"UPDATE personal_mantenimiento SET condicion = @condicion WHERE id_personal_mantenimiento = @idPersonalMantenimiento", connection);
                    command.Parameters.AddWithValue("@condicion", personalMantenimiento.Condicion);
                    command.Parameters.AddWithValue("@idPersonalMantenimiento", idPersonalMantenimiento);

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