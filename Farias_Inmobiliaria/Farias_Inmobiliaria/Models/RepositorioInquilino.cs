using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Farias_Inmobiliaria.Models
{
    public class RepositorioInquilino : RepositorioBase
    {
        
        public RepositorioInquilino(IConfiguration configuration) : base(configuration)
        {

        }
                
        public int Alta(Inquilino i)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"INSERT into Inquilinos (Nombre, Apellido, Dni,Telefono, Email)
                VALUES ( @nombre, @apellido, @dni, @telefono, @email);
                SELECT Scope_IDENTITY();";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", i.Nombre);
                    comm.Parameters.AddWithValue("@apellido", i.Apellido);
                    comm.Parameters.AddWithValue("@dni", i.Dni);
                    comm.Parameters.AddWithValue("@telefono", i.Telefono);
                    comm.Parameters.AddWithValue("@email", i.Email);

                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    i.IdInquilino = res;
                }

            }
            return res;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Inquilinos WHERE IdInquilino = @id";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@IdInquilino", id);

                    conn.Open();

                    res = comm.ExecuteNonQuery();

                    conn.Close();

                }

            }
            return res;
        }

        public int Modificacion(Inquilino i)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"UPDATE Inquilinos SET Nombre=@nombre, Apellido=@apellido, Dni=@dni, Telefono=@telefono, Email=@email " +
                    $"WHERE IdInquilino = @id";
                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@id", i.IdInquilino);
                    comm.Parameters.AddWithValue("@nombre", i.Nombre);
                    comm.Parameters.AddWithValue("@apellido", i.Apellido);
                    comm.Parameters.AddWithValue("@dni", i.Dni);
                    comm.Parameters.AddWithValue("@telefono", i.Telefono);
                    comm.Parameters.AddWithValue("@email", i.Email);

                    connection.Open();

                    res = comm.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return res;
        }

        virtual public Inquilino ObtenerPorId(int id)
        {
            Inquilino i = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT IdInquilino, Nombre, Apellido, Dni, Telefono, Email FROM Inquilinos" +
                    $" WHERE IdInquilino=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        i = new Inquilino
                        {
                            IdInquilino = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetString(3),
                            Telefono = reader.GetString(4),
                            Email = reader.GetString(5),

                        };
                    }
                    connection.Close();
                }
            }
            return i;
        }

        public IList<Inquilino> ObtenerTodos()
        {
            IList<Inquilino> res = new List<Inquilino>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT IdInquilino, Nombre, Apellido, Dni, Telefono, Email
                FROM Inquilinos;";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Inquilino i = new()
                        {
                            IdInquilino = reader.GetInt32(0),
                            Nombre = (string)reader[nameof(Inquilino.Nombre)],
                            Apellido = (string)reader[nameof(Inquilino.Apellido)],
                            Dni = (string)reader[nameof(Inquilino.Dni)],
                            Telefono = (string)reader[nameof(Inquilino.Telefono)],
                            Email = (string)reader[nameof(Inquilino.Email)],

                        };
                        res.Add(i);

                    }
                    conn.Close();

                }

            }
            return res;
        }


    }
}
