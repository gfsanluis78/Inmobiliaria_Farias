select i.IdInmueble, c.IdContrato, c.FechaInicio, c.FechaFin from Inmuebles i left join
Contratos c On i.IdInmueble = c.IdInmueble;
