using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Farias_Inmobiliaria.Models
{
    public class RepositorioPago : RepositorioBase
    {
        public RepositorioPago(IConfiguration configuration) : base(configuration)
        {

        }

        public int Alta(Pago p)
        {
            int res = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                INSERT into Pagos(
                                    IdContrato, 
                                    NumeroPago, 
                                    Importe, 
                                    Fecha)
                                VALUES(
                                    @idContrato, 
                                    @numeroPago, 
                                    @importe, 
                                    @fecha);
                                SELECT Scope_IDENTITY();";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@idContrato", p.IdContrato);
                    comm.Parameters.AddWithValue("@numeroPago", p.NumeroPago);
                    comm.Parameters.AddWithValue("@importe", p.Importe);
                    comm.Parameters.AddWithValue("@fecha", p.Fecha);

                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    p.IdPago = res;
                }
            }

            return res;
        }

        // ####### Baja ##########
        public int Baja(int id)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM Pagos WHERE IdPago = @id";

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

        // ####### MOdificacion #####
        public int Modificacion(Pago p)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                UPDATE Pagos 
                                SET 
                                    Importe=@importe, 
                                    Fecha=@fecha
                                   
                               WHERE IdPago = @id";

                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@importe", p.Importe);
                    comm.Parameters.AddWithValue("@fecha", p.Fecha);

                    comm.Parameters.AddWithValue("@id", p.IdPago);

                    connection.Open();

                    res = comm.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return res;
        }

        // ##### Obtener por id #####

        public Pago ObtenerPorId(int id)
        {
            Pago p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT 
                                   
                                    NumeroPago, 
                                    Importe, 
                                    Fecha,
                                    c.IdContrato, 
                                    c.MontoAlquiler,
                                    i.IdInquilino,                                 
                                    i.Nombre,
                                    i.Apellido,
                                    inm.IdInmueble,
                                    inm.Tipo,
                                    inm.Direccion,
                                    IdPago,
                                    p.IdContrato
                               FROM 
                                    Pagos p 
                               INNER JOIN 
                                    Contratos c  ON p.IdContrato = c.IdContrato 
                               INNER JOIN 
                                    Inquilinos i ON c.IdInquilino = i.IdInquilino
                               INNER JOIN 
                                    Inmuebles inm ON c.IdInmueble = inm.IdInmueble
                               WHERE p.IdPago=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        p = new Pago
                        {
                            NumeroPago = reader.GetInt32(0),
                            Importe = reader.GetString(1),
                            Fecha = reader.GetDateTime(2),
                            Contrato = new Contrato
                            {
                                IdContrato = reader.GetInt32(3),
                                MontoAlquiler = reader.GetString(4),
                                Inquilino = new Inquilino
                                {
                                    IdInquilino = reader.GetInt32(5),
                                    Nombre = reader.GetString(6),
                                    Apellido = reader.GetString(7)
                                },
                                Inmueble = new Inmueble
                                {
                                    IdInmueble = reader.GetInt32(8),
                                    Tipo = reader.GetString(9),
                                    Direccion = reader.GetString(10)
                                }
                            },
                            IdPago = reader.GetInt32(11),
                            IdContrato = reader.GetInt32(12)
                        };
                    }
                    connection.Close();
                }
            }
            return p;
        }

        // ##### Obtener todos

        public IList<Pago> ObtenerTodos()
        {
            IList<Pago> res = new List<Pago>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT 
                                   
                                    NumeroPago, 
                                    Importe, 
                                    Fecha,
                                    c.IdContrato, 
                                    c.MontoAlquiler,
                                    i.IdInquilino,                                    
                                    i.Nombre,
                                    i.Apellido,
                                    inm.IdInmueble,
                                    inm.Tipo,
                                    inm.Direccion,
                                    IdPago,
                                    p.IdContrato
                             FROM 
                                    Pagos p 
                             INNER JOIN 
                                    Contratos c ON p.IdContrato = c.IdContrato 
                             INNER JOIN 
                                    Inquilinos i ON c.IdInquilino = i.IdInquilino
                             INNER JOIN 
                                    Inmuebles inm ON c.IdInmueble = inm.IdInmueble
                             ";


                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())

                    {
                        Pago p = new()
                        {
                            NumeroPago = reader.GetInt32(0),
                            Importe = reader.GetString(1),
                            Fecha = reader.GetDateTime(2),
                            Contrato = new Contrato
                            {
                                IdContrato = reader.GetInt32(3),
                                MontoAlquiler = reader.GetString(4),
                                Inquilino = new Inquilino
                                {
                                    IdInquilino = reader.GetInt32(5),
                                    Nombre = reader.GetString(6),
                                    Apellido = reader.GetString(7)
                                },
                                Inmueble = new Inmueble
                                {
                                    IdInmueble = reader.GetInt32(8),
                                    Tipo = reader.GetString(9),
                                    Direccion = reader.GetString(10)
                                }

                            },
                            IdPago = reader.GetInt32(11)
                        };
                        res.Add(p);
                    }
                    conn.Close();
                }
            }
            return res;
        }

        public IList<Pago> ObtenerTodosDeUnContrato(Contrato c)
        {
            IList<Pago> res = new List<Pago>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT 
                                   
                                    NumeroPago, 
                                    Importe, 
                                    Fecha,
                                    c.IdContrato, 
                                    c.MontoAlquiler,
                                    i.IdInquilino,                                    
                                    i.Nombre,
                                    i.Apellido,
                                    inm.IdInmueble,
                                    inm.Tipo,
                                    inm.Direccion,
                                    IdPago,
                                    p.IdContrato
                             FROM 
                                    Pagos p 
                             INNER JOIN 
                                    Contratos c ON p.IdContrato = c.IdContrato 
                             INNER JOIN 
                                    Inquilinos i ON c.IdInquilino = i.IdInquilino
                             INNER JOIN 
                                    Inmuebles inm ON c.IdInmueble = inm.IdInmueble
                             WHERE
                                    c.IdContrato = @id";


                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.Add("@id", SqlDbType.Int).Value = c.IdContrato;
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())

                    {
                        Pago p = new()
                        {
                            NumeroPago = reader.GetInt32(0),
                            Importe = reader.GetString(1),
                            Fecha = reader.GetDateTime(2),
                            Contrato = new Contrato
                            {
                                IdContrato = reader.GetInt32(3),
                                MontoAlquiler = reader.GetString(4),
                                Inquilino = new Inquilino
                                {
                                    IdInquilino = reader.GetInt32(5),
                                    Nombre = reader.GetString(6),
                                    Apellido = reader.GetString(7)
                                },
                                Inmueble = new Inmueble
                                {
                                    IdInmueble = reader.GetInt32(8),
                                    Tipo = reader.GetString(9),
                                    Direccion = reader.GetString(10)
                                }

                            },
                            IdPago = reader.GetInt32(11)
                        };
                        res.Add(p);
                    }
                    conn.Close();
                }
            }
            return res;
        }



        public BusquedaSiguiente NumeroPagoSiguiente(int contrato)
        {
            BusquedaSiguiente b = null;
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"
                              SELECT
                                    ISNULL(MAX (NumeroPago),0) as Maximo, c.MontoAlquiler as Monto
                              FROM 
                                    Pagos p
                              INNER JOIN 
                                    Contratos c ON p.IdContrato = c.IdContrato           
                              WHERE 
                                    p.IdContrato = @idContrato 
                              Group by c.MontoAlquiler;";

                    using (SqlCommand comm = new SqlCommand(sql, connection))
                    {
                        comm.Parameters.Add("@idContrato", SqlDbType.Int).Value = contrato;
                        comm.CommandType = CommandType.Text;
                        connection.Open();
                        var reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            b = new BusquedaSiguiente
                            {
                                NumeroSiguiente = reader.GetInt32(0) + 1,
                                Monto = reader.GetString(1),
                                //MontoAlquiler = reader.GetString(2)
                            };
                        }
                        else
                        {
                            b = new()
                            {
                                NumeroSiguiente = 1,
                                Monto = "0",
                                //MontoAlquiler = "0"

                            };
                        }
                        connection.Close();
                    }
                }
            }
            return b;
        }

        public int ObtenerElMayor(int contrato)
        {
            int res = -1;
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"
                             SELECT
                                 MAX(NumeroPago) as Maximo
                             FROM 
                                Pagos
                            WHERE 
                                IdContrato= @idContrato"; 
                             

                    using (SqlCommand comm = new SqlCommand(sql, connection))
                    {
                        comm.Parameters.Add("@idContrato", SqlDbType.Int).Value = contrato;
                        comm.CommandType = CommandType.Text;
                        connection.Open();
                        var reader = comm.ExecuteReader();
                        if (reader.Read())
                        {
                            res = reader.GetInt32(0);
                        }
                        else
                        {
                            res = 0;
                        }
                        connection.Close();
                    }
                }
            }
            return res;
        }
    }
}
