
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
SELECT i.IdInmueble, i.Direccion 
FROM Inmuebles i 
	left join Contratos c on i.IdInmueble = c.IdInmueble 
	and ((c.FechaInicio between '2021/04/20' and '2021/10/20') or (c.FechaFin between '2021/04/20' and '2021/10/20')) and c.idInmueble!=0
where 
c.idInmueble is null 
and i.Disponibilidad = 1
