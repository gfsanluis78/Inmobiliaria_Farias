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
                string sql = $"DELETE FROM Pagos WHERE IdPagos = @id";

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
                                    IdContrato=@idContrato, 
                                    NumeroPago=@numeroPago, 
                                    Importe=@importe, 
                                    Fecha=@fecha
                                   
                               WHERE IdPago = @id";

                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@idContrato", p.IdContrato);
                    comm.Parameters.AddWithValue("@numeroPago", p.NumeroPago);
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
                                    inm.Direccion
                                                                                                                    FROM 
                                    Pagos p INNER JOIN Contratos c INNER JOIN Inquilinos i INNER JOIN Inmuebles inm
                               ON 
                                    p.IdContrato = c.IdContrato 
                                    and c.IdInquilino = i.IdInquilino
                                    and c.IdInmueble = inm.IdInmueble

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

                            }


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

                                    IdPago 
                                                                                                                        FROM 
                                    Pagos p 
                             INNER JOIN Contratos c ON p.IdContrato = c.IdContrato 
                             INNER JOIN Inquilinos i ON c.IdInquilino = i.IdInquilino
                             INNER JOIN Inmuebles inm ON c.IdInmueble = inm.IdInmueble
                             ;";


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

        public int NumeroPagoSiguiente(int contrato)
        {
            int res = -1;

            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"
                               SELECT
                                 ISNULL(MAX (NumeroPago),0)
                                 FROM 
                                 Pagos p
                                 INNER JOIN Contratos c ON p.IdContrato = c.IdContrato           
                                 WHERE p.IdContrato = @idContrato";

                     using (SqlCommand comm = new SqlCommand(sql, connection))
                    {
                        comm.CommandType = CommandType.Text;
                        comm.Parameters.AddWithValue("@idContrato", contrato);
                        connection.Open();
                        res = Convert.ToInt32(comm.ExecuteScalar());
                        connection.Close();

                        if (res == 0)
                        {
                            res = 1;
                        }
                        else
                        {
                            res++;
                        }
                        
                        connection.Close();
                        
                    }
                }
            }
       

            return res;
        }
    }
}
