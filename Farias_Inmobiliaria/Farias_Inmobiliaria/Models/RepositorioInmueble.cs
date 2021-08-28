using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Farias_Inmobiliaria.Models
{
    public class RepositorioInmueble : RepositorioBase
    {

        public RepositorioInmueble(IConfiguration configuration) : base(configuration)
        {
        }
        // agrego los metodos

        public int Alta(Inmueble i)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                INSERT into Inmuebles(
                                    Direccion, 
                                    Superficie, 
                                    Latitud, 
                                    Longitud, 
                                    Uso,
                                    Tipo, 
                                    Ambientes, 
                                    PrecioAproximado, 
                                    IdPropietario)
                                VALUES  
                                    (@direccion, 
                                    @superficie, 
                                    @latitud, 
                                    @longitud,  
                                    @uso, 
                                    @tipo, 
                                    @ambientes, 
                                    @precioAproximado, 
                                    @idPropietario);
                                SELECT Scope_IDENTITY();";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@direccion", i.Direccion);
                    comm.Parameters.AddWithValue("@superficie", i.Superficie);
                    comm.Parameters.AddWithValue("@latitud", i.Latitud);
                    comm.Parameters.AddWithValue("@longitud", i.Longitud);
                    comm.Parameters.AddWithValue("@uso", i.Uso);
                    comm.Parameters.AddWithValue("@tipo", i.Tipo);
                    comm.Parameters.AddWithValue("@ambientes", i.Ambientes);
                    comm.Parameters.AddWithValue("@precioAproximado", i.PrecioAproximado);
                    comm.Parameters.AddWithValue("@idPropietario", i.IdPropietario);

                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    i.IdInmueble = res;
                }
            }
            return res;
        }

        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Inmuebles WHERE IdInmueble = @id";

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

        public int Modificacion(Inmueble i)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                UPDATE Inmuebles 
                                SET Direccion=@direccion, 
                                    Superficie=@superficie, 
                                    Latitud=@latitud, 
                                    Longitud=@longitud, 
                                    Uso=@uso, 
                                    Tipo=@tipo,
                                    Ambientes=@ambientes, 
                                    PrecioAproximado=@precioAproximado, 
                                    IdPropietario=@idPropietario
                               WHERE IdInmueble = @id";

                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@direccion", i.Direccion);
                    comm.Parameters.AddWithValue("@superficie", i.Superficie);
                    comm.Parameters.AddWithValue("@Latitud", i.Latitud);
                    comm.Parameters.AddWithValue("@Longitud", i.Longitud);
                    comm.Parameters.AddWithValue("@uso", i.Uso);
                    comm.Parameters.AddWithValue("@tipo", i.Tipo);
                    comm.Parameters.AddWithValue("@ambientes", i.Ambientes);
                    comm.Parameters.AddWithValue("@precioAproximado", i.PrecioAproximado);
                    comm.Parameters.AddWithValue("@idPropietario", i.IdPropietario);

                    comm.Parameters.AddWithValue("@id", i.IdInmueble);


                    connection.Open();

                    res = comm.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return res;
        }

        public Inmueble ObtenerPorId(int id)
        {
            Inmueble i = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT 
                                    IdInmueble, 
                                    Direccion, 
                                    Superficie, 
                                    Latitud, 
                                    Longitud, 
                                    Uso, 
                                    Tipo, 
                                    Ambientes, 
                                    PrecioAproximado,
                                    p.IdPropietario,
                                    p.Nombre,
                                    p.Apellido
                               FROM Inmuebles i INNER JOIN Propietarios p ON p.IdPropietario = i.IdPropietario
                               WHERE i.IdInmueble=@id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        i = new Inmueble
                        {
                            IdInmueble = reader.GetInt32(0),
                            Direccion = reader.GetString(1),
                            Superficie = reader.GetString(2),
                            Latitud = reader.GetString(3),
                            Longitud = reader.GetString(4),
                            Uso = reader.GetString(5),
                            Tipo = reader.GetString(6),
                            Ambientes = reader.GetInt32(7),
                            PrecioAproximado = reader.GetString(8),
                            Duenio = new Propietario
                            {
                                IdPropietario = reader.GetInt32(9),
                                Nombre = reader.GetString(10),
                                Apellido = reader.GetString(11)

                            },
                        };
                    }
                    connection.Close();
                }
            }
            return i;
        }

        public IList<Inmueble> ObtenerTodos()
        {
            IList<Inmueble> res = new List<Inmueble>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                SELECT 
                                    IdInmueble, 
                                    Direccion, 
                                    Superficie, 
                                    Latitud, 
                                    Longitud, 
                                    Uso, 
                                    Ambientes, 
                                    Tipo, 
                                    PrecioAproximado, 
                                    i.IdPropietario, 
                                    p.Nombre, 
                                    p.Apellido 
                                FROM Inmuebles i INNER JOIN Propietarios p 
                                ON i.IdPropietario = p.IdPropietario";
                
                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    // Ver tema de agregar el inquilino de cada inmubele si lo hay, con inner join a izquierda o derecha
                    {
                        Inmueble i = new()
                        {
                            IdInmueble = reader.GetInt32(0),
                            Direccion = reader.GetString(1),
                            Superficie = reader.GetString(2),
                            Latitud = reader.GetString(3),
                            Longitud = reader.GetString(4),
                            Uso = reader.GetString(5),
                            Ambientes = reader.GetInt32(6),
                            Tipo = reader.GetString(7),
                            PrecioAproximado = reader.GetString(8),
                            Duenio = new Propietario
                            {
                                IdPropietario = reader.GetInt32(9),
                                Nombre = reader.GetString(10),
                                Apellido = reader.GetString(11)

                            },
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
