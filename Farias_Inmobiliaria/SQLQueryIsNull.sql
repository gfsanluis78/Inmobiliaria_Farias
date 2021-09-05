select MAX(NumeroPago) from Pagos
	where IdPago = 2


SELECT
    ISNULL(MAX (NumeroPago),0)
    FROM 
    Pagos p
    INNER JOIN Contratos c ON p.IdContrato = c.IdContrato           
    WHERE p.IdContrato = 56002 

select * from pagos