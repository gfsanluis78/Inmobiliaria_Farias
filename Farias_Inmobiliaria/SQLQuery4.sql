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
                                    p.Apellido,
                                    c.IdContrato,
                                    c.IdInquilino,
                                    inq.Nombre,
                                    inq.Apellido,
                                    inq.Email
                                       
                                FROM Inmuebles i 
                                left JOIN Propietarios p ON i.IdPropietario = p.IdPropietario
                                left join Contratos c ON i.IdInmueble = c.IdInmueble
                                left JOIN Inquilinos inq ON c.IdInquilino = inq.IdInquilino
                                Order By c.IdInmueble
                                Group By i.IdInmueble

                                
                                
                               

SELECT 
                                    i.IdInmueble, 
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
                                    p.Apellido,
                                    ( SELECT
                                            COUNT(IdContrato) as cantidad
                                            FROM 
                                            Inmuebles i
                                            INNER JOIN Contratos c ON I.IdInmueble = c.IdInmueble
                                            
                                            group by I.IdInmueble)
                                FROM Inmuebles i 
                                INNER JOIN Propietarios p ON i.IdPropietario = p.IdPropietario
                                LEFT JOIN Contratos c ON i.IdInmueble = c.IdInmueble



    SELECT
    NumeroPago, Importe, c.MontoAlquiler as Monto
    FROM 
    Pagos p
    right JOIN Contratos c ON p.IdContrato = c.IdContrato           
    WHERE p.IdContrato = 56003 
    group by Importe

    
    
SELECT 
                                    i.IdInmueble, 
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
                                    p.Apellido,
                                    c.IdContrato
                                FROM Contratos C 
                                INNER JOIN Propietarios p ON c.IdPropietario = p.IdPropietario
                                LEFT JOIN  Inmuebles i ON i.IdInmueble = c.IdContrato
                                