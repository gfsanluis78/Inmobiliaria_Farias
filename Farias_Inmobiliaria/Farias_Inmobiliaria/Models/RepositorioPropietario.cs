using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Farias_Inmobiliaria.Models
{
    public class RepositorioPropietario : RepositorioBase
    {

        // Se agrega Iconfiguration y configuration, que se lo pasa del constructor base configuration
        public RepositorioPropietario(IConfiguration configuration) : base(configuration)
        {

        }

        // agrego los metodos
        public int Alta(Propietario p)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                INSERT into Propietarios (
                                    Nombre, 
                                    Apellido, 
                                    Dni,
                                    Telefono, 
                                    Email, 
                                    Password)
                                VALUES ( 
                                    @nombre, 
                                    @apellido, 
                                    @dni, 
                                    @telefono, 
                                    @email, 
                                    @password);
                                SELECT Scope_IDENTITY();";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", p.Nombre);
                    comm.Parameters.AddWithValue("@apellido", p.Apellido);
                    comm.Parameters.AddWithValue("@dni", p.Dni);
                    comm.Parameters.AddWithValue("@telefono", p.Telefono);
                    comm.Parameters.AddWithValue("@email", p.Email);
                    comm.Parameters.AddWithValue("@password", p.Password);

                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    p.IdPropietario = res;
                }

            }
            return res;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Propietarios WHERE IdPropietario = @id";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", id);

                    conn.Open();

                    res = comm.ExecuteNonQuery();

                    conn.Close();
                }
            }
            return res;
        }

        public int Modificacion(Propietario p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                UPDATE Propietarios 
                                SET 
                                    Nombre=@nombre, 
                                    Apellido=@apellido, 
                                    Dni=@dni, 
                                    Telefono=@telefono, 
                                    Email=@email, 
                                    Password=@password
                                WHERE IdPropietario = @id";

                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@id", p.IdPropietario);
                    comm.Parameters.AddWithValue("@nombre", p.Nombre);
                    comm.Parameters.AddWithValue("@apellido", p.Apellido);
                    comm.Parameters.AddWithValue("@dni", p.Dni);
                    comm.Parameters.AddWithValue("@telefono", p.Telefono);
                    comm.Parameters.AddWithValue("@email", p.Email);
                    comm.Parameters.AddWithValue("@password", p.Password);

                    connection.Open();

                    res = comm.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return res;
        }

        virtual public Propietario ObtenerPorId(int id)
        {
            Propietario p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                SELECT 
                                    IdPropietario, 
                                    Nombre, 
                                    Apellido, 
                                    Dni, 
                                    Telefono, 
                                    Email, 
                                    Password 
                                FROM Propietarios
                                WHERE IdPropietario=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Propietario
                        {
                            IdPropietario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            Email = reader.GetString(5),
                            Password = reader.GetString(6),
                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

        public IList<Propietario> ObtenerTodos()
        {
            IList<Propietario> res = new List<Propietario>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                SELECT 
                                    IdPropietario, 
                                    Nombre, 
                                    Apellido, 
                                    Dni, 
                                    Telefono, 
                                    Email, 
                                    Password
                                FROM Propietarios;";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Propietario p = new()
                        {
                            IdPropietario = reader.GetInt32(0),
                            Nombre = (string)reader[nameof(Propietario.Nombre)],
                            Apellido = (string)reader[nameof(Propietario.Apellido)],
                            Dni = (string)reader[nameof(Propietario.Dni)],
                            Telefono = (string)reader[nameof(Propietario.Telefono)],
                            Email = (string)reader[nameof(Propietario.Email)],
                            Password = (string)reader[nameof(Propietario.Password)]
                        };
                        res.Add(p);
                    }
                    conn.Close();
                }
            }
            return res;
        }
    }
}
