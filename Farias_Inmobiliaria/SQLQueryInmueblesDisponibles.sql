

SELECT i.IdInmueble, i.Direccion 
FROM Inmuebles i 
	left join Contratos c on i.IdInmueble = c.idInmueble 
	and ((c.FechaInicio between '2021/09/28' and '2022/09/28') or (c.FechaFin between '2021/09/28' and '2022/09/28')) and c.idInmueble!=0
where 
c.idInmueble = 1021 
or c.idInmueble = 1021  
and i.Disponibilidad = 0





/* Libres Ahora con fecha*/
Select i.Direccion,i.IdInmueble,i.Tipo, c.IdContrato, c.FechaInicio, c.FechaFin
	from Inmuebles i 
		left join Contratos c On c.IdInmueble = i.IdInmueble
		/*and '2021-09-13' NOT BETWEEN c.FechaInicio and c.FechaFin*/
		where '2021-09-13' NOT BETWEEN c.FechaInicio and c.FechaFin
		or c.IdInmueble is null;

/* Libres Ahora con GetDate()*/
Select i.Direccion,i.IdInmueble,i.Tipo, c.IdContrato, c.FechaInicio, c.FechaFin
	from Inmuebles i 
		left join Contratos c On c.IdInmueble = i.IdInmueble
		/*and '2021-09-13' NOT BETWEEN c.FechaInicio and c.FechaFin*/
		where GETDATE() NOT BETWEEN c.FechaInicio and c.FechaFin
		or c.IdInmueble is null;


/* Todas */
select * from Inmuebles;		


/* Traer ahora */
select GETDATE()


/* Disponibles en determinada fecha*/
SELECT i.IdInmueble, i.Direccion, i.Tipo, i.Ambientes, i.MontoAlquilerPropuesto 
FROM Inmuebles i 
	left join Contratos c on i.IdInmueble = c.IdInmueble
	and ((c.FechaInicio between '2021/04/20' and '2021/10/20') or (c.FechaFin between '2021/04/20' and '2021/10/20')) and c.idInmueble!=0
where 
c.idInmueble is null 
and i.Disponibilidad = 1


SELECT Count(idInmueble)
from  Contratos c
Where Idinmueble = 1009


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


select Max(IdInmueble) as IdInmueble from contratos
group by IdInmueble


SELECT                                                                                                          i.IdInmueble,
                                    i.Direccion,
                                    i.Superficie,
                                    i.Latitud,
                                    i.Longitud,
                                    i.Uso,
                                    i.Tipo,
                                    i.Ambientes,
                                    i.PrecioAproximado,
                                    i.MontoAlquilerPropuesto,
                                    i.Disponibilidad,
                                    i.IdPropietario,
                                    P.Nombre ,  
                                    P.Apellido
                              FROM 
                                    (SELECT * FROM 
                                        Inmuebles i LEFT JOIN 
                                            (SELECT  idInmueble 
                                                FROM Contratos c 
                                                WHERE ((c.fechaDesde between now  AND "21/10/2021" OR (c.fechaHasta between now and "21/10/2021")) 
                                                AND c.idInmueble != 0) /*inmueble ON (i.IdInmueble = inmueble.IdInmueble)
                               WHERE inmueble.IdInmueble IS NULL and i.Disponibilidad = 0) i  INNER JOIN Propietarios P ON i.idPropietario = P.idPropietario; */


/*Tocada busca disponible entre dos fechas*/                              

SELECT                                                                                                           i.IdInmueble,
                                    i.Direccion,
                                    i.Superficie,
                                    i.Latitud,
                                    i.Longitud,
                                    i.Uso,
                                    i.Tipo,
                                    i.Ambientes,
                                    i.PrecioAproximado,
                                    i.MontoAlquilerPropuesto,
                                    i.Disponibilidad,
                                    i.IdPropietario,
                                    P.Nombre ,  
                                    P.Apellido
                              FROM Inmuebles i 
	                          LEFT JOIN Contratos c on i.IdInmueble = c.IdInmueble
                              LEFT JOIN Propietarios p on i.IdInmueble = p.IdInmueble
	                          AND ((c.FechaInicio between '2021/04/20' and '2021/10/20')
                              OR (c.FechaFin between '2021/04/20' and '2021/10/20')) 
                              AND c.idInmueble!=0
                              WHERE c.idInmueble is null 
                              AND i.Disponibilidad = 1;