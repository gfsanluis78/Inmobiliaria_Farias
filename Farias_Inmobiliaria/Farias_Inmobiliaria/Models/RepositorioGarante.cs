using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class RepositorioGarante : RepositorioBase
    {
        public RepositorioGarante(IConfiguration configuration) : base(configuration)
        {

        }

        // ##### Alta #####
        public int Alta(Garante g)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                INSERT into Garantes (
                                    Nombre, 
                                    Apellido,
                                    Trabajo,
                                    Dni,
                                    Telefono, 
                                    Email)
                                VALUES (
                                    @nombre, 
                                    @apellido,
                                    @trabajo,
                                    @dni, 
                                    @telefono, 
                                    @email);
                                SELECT Scope_IDENTITY();";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@nombre", g.Nombre);
                    comm.Parameters.AddWithValue("@apellido", g.Apellido);
                    comm.Parameters.AddWithValue("@trabajo", g.Trabajo);
                    comm.Parameters.AddWithValue("@dni", g.Dni);
                    comm.Parameters.AddWithValue("@telefono", g.Telefono);
                    comm.Parameters.AddWithValue("@email", g.Email);

                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    g.IdGarante = res;
                }
            }
            return res;
        }

        // ##### Baja #####
        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Garantes WHERE IdGarante = @id";

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
        // ##### Modificacion #####

        public int Modificacion(Garante g)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                UPDATE Garantes 
                                SET 
                                    Nombre=@nombre, 
                                    Apellido=@apellido,
                                    Trabajo=@trabajo,
                                    Dni=@dni, 
                                    Telefono=@telefono, 
                                    Email=@email
                                WHERE IdGarante = @id";

                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@id", g.IdGarante);
                    comm.Parameters.AddWithValue("@nombre", g.Nombre);
                    comm.Parameters.AddWithValue("@apellido", g.Apellido);
                    comm.Parameters.AddWithValue("@trabajo", g.Trabajo);
                    comm.Parameters.AddWithValue("@dni", g.Dni);
                    comm.Parameters.AddWithValue("@telefono", g.Telefono);
                    comm.Parameters.AddWithValue("@email", g.Email);

                    connection.Open();

                    res = comm.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return res;
        }

        // ##### Obtener por id #####

        virtual public Garante ObtenerPorId(int id)
        {
            Garante g = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                SELECT 
                                    IdGarante, 
                                    Nombre, 
                                    Apellido,
                                    Trabajo,
                                    Dni, 
                                    Telefono, 
                                    Email 
                                FROM Garantes 
                                WHERE IdGarante=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        g = new Garante
                        {
                            IdGarante = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Trabajo = reader.GetString(3),
                            Dni = reader.GetString(4),
                            Telefono = reader.GetString(5),
                            Email = reader.GetString(6),

                        };
                    }
                    connection.Close();
                }
            }
            return g;
        }

        // ##### Obtener todos #####

        public IList<Garante> ObtenerTodos()
        {
            IList<Garante> res = new List<Garante>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                SELECT 
                                    IdGarante, 
                                    Nombre, 
                                    Apellido, 
                                    Trabajo,
                                    Dni, 
                                    Telefono, 
                                    Email
                                FROM Garantes;";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Garante g = new()
                        {
                            IdGarante = reader.GetInt32(0),
                            Nombre = (string)reader[nameof(Garante.Nombre)],
                            Apellido = (string)reader[nameof(Garante.Apellido)],
                            Trabajo = (string)reader[nameof(Garante.Trabajo)],
                            Dni = (string)reader[nameof(Garante.Dni)],
                            Telefono = (string)reader[nameof(Garante.Telefono)],
                            Email = (string)reader[nameof(Garante.Email)],

                        };
                        res.Add(g);

                    }
                    conn.Close();

                }

            }
            return res;
        }
    }
}
