using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Farias_Inmobiliaria.Models
{
    public class RepositorioContrato : RepositorioBase
    {
        public RepositorioContrato(IConfiguration configuration) : base(configuration)
        {

        }

        // ##### Alta #####

        public int Alta(Contrato c)
        {
            int res = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                INSERT into Contratos(
                                    IdGarante, 
                                    IdInmueble, 
                                    IdInquilino, 
                                    FechaInicio, 
                                    FechaFin,
                                    MontoAlquiler)
                                VALUES(
                                    @idGarante, 
                                    @idInmueble, 
                                    @idInquilino, 
                                    @fechaInicio,  
                                    @fechaFin, 
                                    @montoAlquiler);
                                SELECT Scope_IDENTITY();";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@idGarante", c.IdGarante);
                    comm.Parameters.AddWithValue("@idInmueble", c.IdInmueble);
                    comm.Parameters.AddWithValue("@idInquilino", c.IdInquilino);
                    comm.Parameters.AddWithValue("@fechaInicio", c.FechaInicio);
                    comm.Parameters.AddWithValue("@fechaFin", c.FechaFin);
                    comm.Parameters.AddWithValue("@montoAlquiler", c.MontoAlquiler);


                    conn.Open();
                    res = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    c.IdContrato = res;
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
                string sql = $"DELETE FROM Contratos WHERE IdContrato = @id";

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

        public int Modificacion(Contrato c)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                UPDATE Contratos 
                                SET 
                                    IdGarante=@idGarante, 
                                    IdInmueble=@idInmueble, 
                                    IdInquilino=@idInquilino, 
                                    FechaInicio=@fechaInicio, 
                                    FechaFin=@fechaFin, 
                                    MontoAlquiler=@montoAlquiler
                                 WHERE IdContrato = @id";

                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@idGarante", c.IdGarante);
                    comm.Parameters.AddWithValue("@idInmueble", c.IdInmueble);
                    comm.Parameters.AddWithValue("@idInquilino", c.IdInquilino);
                    comm.Parameters.AddWithValue("@fechaInicio", c.FechaInicio);
                    comm.Parameters.AddWithValue("@fechaFin", c.FechaFin);
                    comm.Parameters.AddWithValue("@montoAlquiler", c.MontoAlquiler);

                    comm.Parameters.AddWithValue("@id", c.IdContrato);


                    connection.Open();

                    res = comm.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return res;
        }

        // #################################################
        // Renovar contrato
        // #################################################

        public int Cancelar(Contrato c)
        {
            int res = -1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                UPDATE Contratos 
                                SET 
                                    FechaFin=@fechaFin,
                                    EstadoCancelado=@estadoCancelado
                                WHERE IdContrato = @id";

                using (SqlCommand comm = new SqlCommand(sql, connection))
                {
                    comm.CommandType = CommandType.Text;

                    comm.Parameters.AddWithValue("@fechaFin", c.FechaFin);
                    comm.Parameters.AddWithValue("@estadoCancelado", true);

                    comm.Parameters.AddWithValue("@id", c.IdContrato);


                    connection.Open();

                    res = comm.ExecuteNonQuery();

                    connection.Close();
                }
            }
            return res;
        }

        // ##### Obtener por Id #####

        public Contrato ObtenerPorId(int id)
        {
            Contrato c = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = @"
                                SELECT 
                                    con.IdGarante,
                                    g.Nombre,
                                    g.Apellido,
                                    con.IdInmueble,
                                    i.Direccion,
                                    i.Tipo,
                                    p.IdPropietario,
                                    p.Nombre,
                                    p.Apellido,
                                    p.Telefono,
                                    con.IdInquilino,
                                    inq.Nombre,
                                    inq.Apellido,
                                    inq.Telefono,
                                    FechaInicio, 
                                    FechaFin,
                                    MontoAlquiler,
                                    g.Trabajo,
                                    g.Dni,
                                    g.Telefono,
                                    g.Email,
                                    p.Dni,
                                    p.Email,
                                    i.Uso,
                                    i.Ambientes,
                                    i.Superficie,
                                    inq.Dni,
                                    inq.Email,
                                    EstadoCancelado
                                FROM 
                                    Contratos AS con 
                                INNER JOIN Garantes g ON con.IdGarante = g.IdGarante 
                                INNER JOIN Inmuebles i ON con.IdInmueble = i.IdInmueble
                                INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario
                                INNER JOIN Inquilinos inq ON con.IdInquilino = inq.IdInquilino
                                WHERE con.IdContrato=@id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        c = new Contrato
                        {
                            Garante = new Garante
                            {
                                IdGarante = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Trabajo = reader.GetString(17),
                                Dni = reader.GetString(18),
                                Telefono = reader.GetString(19),
                                Email = reader.GetString(20),
                            },

                            Inmueble = new Inmueble
                            {
                                IdInmueble = reader.GetInt32(3),
                                Direccion = reader.GetString(4),
                                Tipo = reader.GetString(5),
                                Duenio = new Propietario
                                {
                                    IdPropietario = reader.GetInt32(6),
                                    Nombre = reader.GetString(7),
                                    Apellido = reader.GetString(8),
                                    Telefono = reader.GetString(9),
                                    Dni = reader.GetString(21),
                                    Email = reader.GetString(22),
                                },
                                Uso = reader.GetString(23),
                                Ambientes = reader.GetInt32(24),
                                Superficie = reader.GetString(25),
                            },

                            Inquilino = new Inquilino
                            {
                                IdInquilino = reader.GetInt32(10),
                                Nombre = reader.GetString(11),
                                Apellido = reader.GetString(12),
                                Telefono = reader.GetString(13),
                                Dni = reader.GetString(26),
                                Email = reader.GetString(27),
                            },

                            FechaInicio = reader.GetDateTime(14),
                            FechaFin = reader.GetDateTime(15),
                            MontoAlquiler = reader.GetString(16),
                            IdContrato = id,
                            EstadoCancelado = reader.GetBoolean(28)
                        };
                    }
                    connection.Close();
                }
            }
            return c;
        }

        public TieneContrato obtenerPorInmueble(int idInmueble)
        {
            TieneContrato tiene = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                SELECT Count(idInmueble)
                    from Contratos c
                    Where Idinmueble = @id";


                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = idInmueble;
                    command.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        bool res = false;
                        if (reader.HasRows)
                        {
                            res = true;
                        }

                        tiene = new TieneContrato()
                        {
                            Tiene = res
                        };


                    }
                }
            }

            return tiene;
        }


        // ##### Obtener todos #####

        public IList<Contrato> ObtenerTodos()
        {
            IList<Contrato> res = new List<Contrato>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                               SELECT 
                                    con.IdGarante,
                                    g.Nombre,
                                    g.Apellido,
                                    con.IdInmueble,
                                    i.Direccion,
                                    i.Tipo,
                                    p.IdPropietario,
                                    p.Nombre,
                                    p.Apellido,
                                    p.Telefono,
                                    con.IdInquilino,
                                    inq.Nombre,
                                    inq.Apellido,
                                    inq.Telefono,
                                    con.IdContrato,
                                    FechaInicio, 
                                    FechaFin,
                                    MontoAlquiler,
                                    EstadoCancelado
                                FROM 
                                    Contratos con 
                                INNER JOIN Garantes g ON con.IdGarante = g.IdGarante 
                                INNER JOIN Inmuebles i ON con.IdInmueble = i.IdInmueble
                                INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario
                                INNER JOIN Inquilinos inq ON con.IdInquilino = inq.IdInquilino";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())

                    {
                        Contrato c = new()
                        {
                            Garante = new Garante
                            {
                                IdGarante = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                            },

                            Inmueble = new Inmueble
                            {
                                IdInmueble = reader.GetInt32(3),
                                Direccion = reader.GetString(4),
                                Tipo = reader.GetString(5),
                                Duenio = new Propietario
                                {
                                    IdPropietario = reader.GetInt32(6),
                                    Nombre = reader.GetString(7),
                                    Apellido = reader.GetString(8),
                                    Telefono = reader.GetString(9),
                                }
                            },

                            Inquilino = new Inquilino
                            {
                                IdInquilino = reader.GetInt32(10),
                                Nombre = reader.GetString(11),
                                Apellido = reader.GetString(12),
                                Telefono = reader.GetString(13),
                            },

                            IdContrato = reader.GetInt32(14),
                            FechaInicio = reader.GetDateTime(15),
                            FechaFin = reader.GetDateTime(16),
                            MontoAlquiler = reader.GetString(17),
                            EstadoCancelado = reader.GetBoolean(18)
                            //EstadoCancelado = reader[nameof(Contrato.EstadoCancelado)] == DBNull.Value ? null : reader.GetBoolean(18)
                        };
                        res.Add(c);
                    }
                    conn.Close();
                }
            }
            return res;
        }

        // ##### Obtener todos vigentes #####

        public IList<Contrato> ObtenerTodosVigentes()
        {
            IList<Contrato> res = new List<Contrato>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                               SELECT 
                                    con.IdGarante,
                                    g.Nombre,
                                    g.Apellido,
                                    con.IdInmueble,
                                    i.Direccion,
                                    i.Tipo,
                                    p.IdPropietario,
                                    p.Nombre,
                                    p.Apellido,
                                    p.Telefono,
                                    con.IdInquilino,
                                    inq.Nombre,
                                    inq.Apellido,
                                    inq.Telefono,
                                    con.IdContrato,
                                    FechaInicio, 
                                    FechaFin,
                                    MontoAlquiler,
                                    EstadoCancelado
                                FROM 
                                    Contratos con 
                                INNER JOIN Garantes g ON con.IdGarante = g.IdGarante 
                                INNER JOIN Inmuebles i ON con.IdInmueble = i.IdInmueble
                                INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario
                                INNER JOIN Inquilinos inq ON con.IdInquilino = inq.IdInquilino
                                WHERE 
                                    con.FechaInicio <= GETDATE() and  con.FechaFin >= GETDATE()";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())

                    {
                        Contrato c = new()
                        {
                            Garante = new Garante
                            {
                                IdGarante = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                            },

                            Inmueble = new Inmueble
                            {
                                IdInmueble = reader.GetInt32(3),
                                Direccion = reader.GetString(4),
                                Tipo = reader.GetString(5),
                                Duenio = new Propietario
                                {
                                    IdPropietario = reader.GetInt32(6),
                                    Nombre = reader.GetString(7),
                                    Apellido = reader.GetString(8),
                                    Telefono = reader.GetString(9),
                                }
                            },

                            Inquilino = new Inquilino
                            {
                                IdInquilino = reader.GetInt32(10),
                                Nombre = reader.GetString(11),
                                Apellido = reader.GetString(12),
                                Telefono = reader.GetString(13),
                            },

                            IdContrato = reader.GetInt32(14),
                            FechaInicio = reader.GetDateTime(15),
                            FechaFin = reader.GetDateTime(16),
                            MontoAlquiler = reader.GetString(17),
                            EstadoCancelado = reader.GetBoolean(18)
                        };
                        res.Add(c);
                    }
                    conn.Close();
                }
            }
            return res;
        }


        // ##### Obtener el ultimo contrato de un inmueble #######


        public IList<Contrato> ObtenerUltimosContrato()
        {
            IList<Contrato> res = new List<Contrato>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                               select 
                                    Max(IdInmueble) from contratos
                               Group by IdInmueble";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Contrato c = new()
                        {
                            Inmueble = new Inmueble
                            {
                                IdInmueble = reader.GetInt32(0),

                            },
                        };
                        res.Add(c);
                    }
                    conn.Close();
                }
            }
            return res;
        }




        // ##### Obtener todos de un inmueble #####

        public IList<Contrato> ObtenerTodosDeUnInmueble(int id)
        {
            IList<Contrato> res = new List<Contrato>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                               SELECT 
                                    con.IdGarante,
                                    g.Nombre,
                                    g.Apellido,
                                    con.IdInmueble,
                                    i.Direccion,
                                    i.Tipo,
                                    p.IdPropietario,
                                    p.Nombre,
                                    p.Apellido,
                                    p.Telefono,
                                    con.IdInquilino,
                                    inq.Nombre,
                                    inq.Apellido,
                                    inq.Telefono,
                                    con.IdContrato,
                                    FechaInicio, 
                                    FechaFin,
                                    MontoAlquiler,
                                    EstadoCancelado
                                FROM 
                                    Contratos con 
                                INNER JOIN Garantes g ON con.IdGarante = g.IdGarante 
                                INNER JOIN Inmuebles i ON con.IdInmueble = i.IdInmueble
                                INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario
                                INNER JOIN Inquilinos inq ON con.IdInquilino = inq.IdInquilino
                                WHERE 
                                    con.IdInmueble = @id";

                using (SqlCommand comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())

                    {
                        Contrato c = new()
                        {
                            Garante = new Garante
                            {
                                IdGarante = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                            },

                            Inmueble = new Inmueble
                            {
                                IdInmueble = reader.GetInt32(3),
                                Direccion = reader.GetString(4),
                                Tipo = reader.GetString(5),
                                Duenio = new Propietario
                                {
                                    IdPropietario = reader.GetInt32(6),
                                    Nombre = reader.GetString(7),
                                    Apellido = reader.GetString(8),
                                    Telefono = reader.GetString(9),
                                }
                            },

                            Inquilino = new Inquilino
                            {
                                IdInquilino = reader.GetInt32(10),
                                Nombre = reader.GetString(11),
                                Apellido = reader.GetString(12),
                                Telefono = reader.GetString(13),
                            },

                            IdContrato = reader.GetInt32(14),
                            FechaInicio = reader.GetDateTime(15),
                            FechaFin = reader.GetDateTime(16),
                            MontoAlquiler = reader.GetString(17)
                        };
                        res.Add(c);
                    }
                    conn.Close();
                }
            }
            return res;
        }

        // Disponible entre dos fechas?
        //SELECT i.IdInmueble, i.Direccion 
        //        FROM Inmuebles i
        //            left join Contratos c on i.IdInmueble = c.idInmueble
        //            and((c.FechaInicio between '2021/04/20' and '2021/10/20') or(c.FechaFin between '2021/04/20' and '2021/10/20')) and c.idInmueble!=0
        //where
        //      c.idInmueble is null 
        //and i.Disponibilidad = 0

        public IList<Contrato> ObtenerPorfechas(BuscarEntreFecha buscar)
        {

            IList<Contrato> res = new List<Contrato>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                SELECT i.IdInmueble, i.Direccion 
                                FROM Inmuebles i
                                    left join Contratos c on i.IdInmueble = c.idInmueble
                                    and((c.FechaInicio between @desde and @hasta) or(c.FechaFin between           @desde and @hasta)) and c.idInmueble!=0
                                WHERE
                                    c.idInmueble = @id 
                                OR c.idInmueble = @id  
                                AND i.Disponibilidad = 0";


                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.Add("@desde", SqlDbType.Date).Value = buscar.Desde;
                    command.Parameters.Add("@hasta", SqlDbType.Date).Value = buscar.Hasta;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = buscar.Inmueble;

                    command.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())

                    {
                        Contrato c = new()
                        {
                            Inmueble = new Inmueble
                            {
                                IdInmueble = reader.GetInt32(0),
                                Direccion = reader.GetString(1),
                            },
                        };
                        res.Add(c);
                    }
                    conn.Close();
                }
            }
            return res;
        }

        public bool ObtenerPorfechasInm(BuscarEntreFecha buscar)
        {

            bool res = true;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = @"
                                SELECT c.* FROM Contratos c
                                WHERE (c.FechaInicio BETWEEN @desde AND @hasta
                                OR c.FechaFin BETWEEN @desde AND @hasta)
                                AND c.IdInmueble = @id;";


                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.Add("@desde", SqlDbType.Date).Value = buscar.Desde;
                    command.Parameters.Add("@hasta", SqlDbType.Date).Value = buscar.Hasta;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = buscar.Inmueble;

                    command.CommandType = CommandType.Text;
                    conn.Open();
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        res = false;
                    }
                }
                conn.Close();

            }
            return res;
        }
    }
}
