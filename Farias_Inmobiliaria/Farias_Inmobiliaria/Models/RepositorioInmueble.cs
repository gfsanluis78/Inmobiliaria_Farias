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
            using (SqlConnection conn = new(connectionString))
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
                                    MontoAlquilerPropuesto,
                                    Disponibilidad,
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
                                    @montoAlquilerPropuesto,    
                                    @disponibilidad,
                                    @idPropietario);
                                SELECT Scope_IDENTITY();";

                using SqlCommand comm = new(sql, conn);
                comm.Parameters.AddWithValue("@direccion", i.Direccion);
                comm.Parameters.AddWithValue("@superficie", i.Superficie);
                comm.Parameters.AddWithValue("@latitud", i.Latitud);
                comm.Parameters.AddWithValue("@longitud", i.Longitud);
                comm.Parameters.AddWithValue("@uso", i.Uso);
                comm.Parameters.AddWithValue("@tipo", i.Tipo);
                comm.Parameters.AddWithValue("@ambientes", i.Ambientes);
                comm.Parameters.AddWithValue("@precioAproximado", i.PrecioAproximado);
                comm.Parameters.AddWithValue("@montoAlquilerPropuesto", i.MontoAlquilerPropuesto);
                comm.Parameters.AddWithValue("@disponibilidad", i.Disponibilidad);
                comm.Parameters.AddWithValue("@idPropietario", i.IdPropietario);

                conn.Open();
                res = Convert.ToInt32(comm.ExecuteScalar());
                conn.Close();
                i.IdInmueble = res;
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
                                    MontoAlquilerPropuesto=@montoAlquilerPropuesto,
                                    Disponibilidad=@disponibilidad,    
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
                    comm.Parameters.AddWithValue("@montoAlquilerPropuesto", i.MontoAlquilerPropuesto);
                    comm.Parameters.AddWithValue("@disponibilidad", i.Disponibilidad);
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
                                    MontoalquilerPropuesto,
                                    Disponibilidad,
                                    p.IdPropietario,
                                    p.Nombre,
                                    p.Apellido,
                                    Imagen
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
                            MontoAlquilerPropuesto = reader.GetString(9),
                            Disponibilidad = reader.GetBoolean(10),
                            Duenio = new Propietario
                            {
                                IdPropietario = reader.GetInt32(11),
                                Nombre = reader.GetString(12),
                                Apellido = reader.GetString(13)

                            },
                            Imagen = reader.GetString(14)
                        };
                    }
                    connection.Close();
                }
            }
            return i;
        }

        public IList<DisponiblesEntreFechas> ObtenerDisponiblesPorFecha(BuscarEntreFecha buscar)
        {
            IList<DisponiblesEntreFechas> lista = new List<DisponiblesEntreFechas>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @" 
                                SELECT i.IdInmueble, i.Direccion, i.Tipo, i.Ambientes, i.MontoAlquilerPropuesto
                                FROM Inmuebles i
                                LEFT JOIN Contratos c on i.IdInmueble = c.IdInmueble
                                AND((c.FechaInicio between @desde and @hasta) 
                                OR(c.FechaFin between @desde and @hasta))   
                                AND c.idInmueble != 0
                                WHERE c.idInmueble is null
                                AND i.Disponibilidad = 1";


                               //     (SELECT * FROM 
                               //         Inmuebles i LEFT JOIN 
                               //             (SELECT  c.idInmueble 
                               //                 FROM Contratos c 
                               //                 WHERE ((c.FechaInicio between @desde  AND @hasta) 
                               //                 OR (c.FechaFin between @desde and @hasta)) 
                               //                 AND c.idInmueble != @id) x ON (i.IdInmueble = x.IdInmueble)
                               //WHERE x.IdInmueble IS NULL and i.Disponibilidad = 0) i  INNER JOIN Propietarios P ON i.idPropietario = P.idPropietario;";

                using (SqlCommand com = new SqlCommand(sql, connection))
                {
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("@desde", SqlDbType.Date).Value = buscar.Desde;
                    com.Parameters.Add("@hasta", SqlDbType.Date).Value = buscar.Hasta;
                    com.Parameters.AddWithValue("@id", 0);
                    connection.Open();
                    var reader = com.ExecuteReader();
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            DisponiblesEntreFechas i = new DisponiblesEntreFechas
                            {
                                Id = reader.GetInt32(0),
                                Direccion = reader.GetString(1),
                                Tipo = reader.GetString(2),
                                Ambientes = reader.GetInt32(3),
                                MontoAlquilerPropuesto = reader.GetString(4),
                                
                            };

                            lista.Add(i);
                        }
                    }
                    connection.Close();
                }
            }
            return lista;
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
                                    MontoAlquilerPropuesto,
                                    Disponibilidad,
                                    i.IdPropietario, 
                                    p.Nombre, 
                                    p.Apellido 
                                FROM Inmuebles i 
                                INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario
                                Order By IdInmueble DESC;";
                
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
                            MontoAlquilerPropuesto = reader.GetString(9),
                            Disponibilidad = reader.GetBoolean(10),
                            Duenio = new Propietario
                            {
                                IdPropietario = reader.GetInt32(11),
                                Nombre = reader.GetString(12),
                                Apellido = reader.GetString(13)

                            },
                        };
                        res.Add(i);
                    }
                    conn.Close();
                }
            }
            return res;
        }

        // Busca todos los que tienen contrato
        public IList<Inmueble> ObtenerTodosConContrato()
        {
            IList<Inmueble> res = new List<Inmueble>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                            SELECT 
                                    i.IdInmueble, 
                                    i.Direccion, 
                                    Superficie, 
                                    Latitud, 
                                    Longitud, 
                                    Uso, 
                                    Ambientes, 
                                    Tipo, 
                                    PrecioAproximado,
                                    MontoAlquilerPropuesto,
                                    Disponibilidad,
                                    i.IdPropietario, 
                                    p.Nombre, 
                                    p.Apellido
                                                                 
                                FROM Inmuebles i 
                                INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario
                                RIGHT JOIN Contratos c ON i.IdInmueble = c.IdInmueble";

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
                            MontoAlquilerPropuesto = reader.GetString(9),
                            Disponibilidad = reader.GetBoolean(10),
                            Duenio = new Propietario
                            {
                                IdPropietario = reader.GetInt32(11),
                                Nombre = reader.GetString(12),
                                Apellido = reader.GetString(13)

                            },
                           
                        };
                        res.Add(i);
                    }
                    conn.Close();
                }
            }
            return res;
        }

        // Todos los Inmbuebles de un propietario
        public IList<Inmueble> ObtenerTodosPorId(int idDuenio)
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
                                    MontoAlquilerPropuesto,
                                    Disponibilidad,
                                    i.IdPropietario, 
                                    p.Nombre, 
                                    p.Apellido 
                                FROM Inmuebles i INNER JOIN Propietarios p 
                                ON i.IdPropietario = p.IdPropietario
                                WHERE i.IdPropietario = @id";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.Add("@id", SqlDbType.Int).Value = idDuenio;
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
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
                            MontoAlquilerPropuesto = reader.GetString(9),
                            Disponibilidad = reader.GetBoolean(10),
                            Duenio = new Propietario
                            {
                                IdPropietario = reader.GetInt32(11),
                                Nombre = reader.GetString(12),
                                Apellido = reader.GetString(13)

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
