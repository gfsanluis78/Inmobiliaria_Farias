select MAX(NumeroPago) from Pagos
	where IdPago = 2


SELECT
    ISNULL(MAX (NumeroPago),0) as Maximo, c.MontoAlquiler as Monto
    FROM 
    Pagos p
    right JOIN Contratos c ON p.IdContrato = c.IdContrato           
    WHERE p.IdContrato = 56003 
    Group by C.MontoAlquiler 
    
    Group by NumeroPago

SELECT
    NumeroPago, Importe, c.MontoAlquiler as Monto
    FROM 
    Pagos p
    right JOIN Contratos c ON p.IdContrato = c.IdContrato           
    WHERE p.IdContrato = 56003 
    group by Importe


    


SELECT
    IdContrato, MontoAlquiler
    From 
    Contratos
    WHERE IdContrato = 56003
Union

SELECT
    ISNULL(MAX (NumeroPago),0) as Maximo, Importe
    FROM 
    Pagos p
    INNER JOIN Contratos c ON p.IdContrato = c.IdContrato           
    WHERE p.IdContrato = 56003
    Group by Importe


SELECT
    IdContrato, MontoAlquiler
    From 
    Contratos
    WHERE IdContrato = 52002
Union

SELECT
    ISNULL(MAX (NumeroPago),0) as Maximo, Importe
    FROM 
    Pagos p
    INNER JOIN Contratos c ON p.IdContrato = c.IdContrato           
    WHERE p.IdContrato = 52002
    Group by Importe


SELECT
    IdContrato, MontoAlquiler
    From 
    Contratos
    WHERE IdContrato = 56003
Union

SELECT
    ISNULL(MAX (NumeroPago),0) as Maximo, Importe
    FROM 
    Pagos p
    INNER JOIN Contratos c ON p.IdContrato = c.IdContrato           
    WHERE p.IdContrato = 56003
    Group by Importe


    select * from Contratos


SELECT
    MAX(NumeroPago) as Maximo
FROM 
    Pagos
WHERE 
    IdContrato= 52002 

 




select * from pagos

select * from contratos

SELECT 
                                   
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
                                    Pagos p 
                               INNER JOIN 
                                    Contratos c  ON p.IdContrato = c.IdContrato 
                               INNER JOIN 
                                    Inquilinos i ON c.IdInquilino = i.IdInquilino
                               INNER JOIN Inmuebles inm ON c.IdInmueble = inm.IdInmueble
                               WHERE p.IdPago=@id

                               SELECT 
                                   
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
                             INNER JOIN 
                                    Contratos c ON p.IdContrato = c.IdContrato 
                             INNER JOIN 
                                    Inquilinos i ON c.IdInquilino = i.IdInquilino
                             INNER JOIN 
                                    Inmuebles inm ON c.IdInmueble = inm.IdInmueble