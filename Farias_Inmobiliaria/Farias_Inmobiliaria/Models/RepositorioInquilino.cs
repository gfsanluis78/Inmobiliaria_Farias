using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class RepositorioInquilino
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Farias_inmonbiliaria_BD;Trusted_Connection=True;MultipleActiveResultSets=true";

        public RepositorioInquilino()
        {

        }

        // agrego los metodos

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
                    i.Id = res;
                }

            }
            return res;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Inquilinos WHERE Id = @id";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@Id", id);

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
                    $"WHERE Id = @id";
                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@id", i.Id);
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
                string sql = $"SELECT Id, Nombre, Apellido, Dni, Telefono, Email FROM Inquilinos" +
                    $" WHERE Id=@id";
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
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Dni = reader.GetInt32(3),
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
                string sql = @"SELECT Id, Nombre, Apellido, Dni, Telefono, Email
                FROM Inquilinos;";
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Inquilino i = new()
                        {
                            Id = reader.GetInt32(0),
                            Nombre = (string)reader[nameof(Inquilino.Nombre)],
                            Apellido = (string)reader[nameof(Inquilino.Apellido)],
                            Dni = (int)reader[nameof(Inquilino.Dni)],
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
