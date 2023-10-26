USE Prueba_Brandon_Canux

--A.	Escriba la consulta en SQL que devuelva el nombre del proyecto y sus productos 
--correspondientes del proyecto premia cuyo código es 1
SELECT P.PROYECTO, P.NOMBRE, PR.DESCRIPCION
FROM PROYECTO P
INNER JOIN PRODUCTO_PROYECTO PP
ON PP.PROYECTO = P.PROYECTO
INNER JOIN PRODUCTO PR 
ON PR.PRODUCTO = PP.PRODUCTO
WHERE P.PROYECTO = 1 

-- B. Escriba una consulta SQL que devuelva los distintos mensajes que hay, indicando a qué 
-- proyecto y producto pertenecen
SELECT 
    M.COD_MENSAJE AS 'CÓDIGO MENSAJE',
    P.NOMBRE AS 'NOMBRE PROYECTO',
    PR.DESCRIPCION AS 'DESCRIPCIÓN PRODUCTO',
    F.NOBMRE AS 'FORMATO'
FROM MENSAJE M
INNER JOIN PROYECTO P 
	ON M.PROYECTO = P.PROYECTO
INNER JOIN PRODUCTO_PROYECTO PP 
	ON M.PROYECTO = PP.PROYECTO 
	AND M.PRODUCTO = PP.PRODUCTO
INNER JOIN PRODUCTO PR 
	ON PP.PRODUCTO = PR.PRODUCTO
INNER JOIN FORMATO_MENSAJE F 
	ON M.COD_FORMATO = F.COD_FORMATO;

-- C. Escriba una consulta SQL que devuelva los distintos mensajes que hay, indicando a qué 
-- proyecto y producto pertenecen. Pero si el mensaje está en todos los productos de un 
-- proyecto, en lugar de mostrar cada producto, debe mostrar el nombre del proyecto y un 
-- solo producto que diga “TODOS”
SELECT DISTINCT
    CASE 
        WHEN COUNT(DISTINCT PP.PRODUCTO) = (SELECT COUNT(*) 
					FROM PRODUCTO 
					WHERE PRODUCTO.PRODUCTO = PP.PRODUCTO) 
		THEN 'TODOS'
        ELSE PR.DESCRIPCION
    END AS 'PRODUCTO',
    P.NOMBRE AS 'NOMBRE PROYECTO', 
	F.NOBMRE AS 'FORMATO'
FROM MENSAJE M
INNER JOIN PROYECTO P 
	ON M.PROYECTO = P.PROYECTO
LEFT JOIN PRODUCTO_PROYECTO PP 
	ON M.PROYECTO = PP.PROYECTO
LEFT JOIN PRODUCTO PR 
	ON PP.PRODUCTO = PR.PRODUCTO
INNER JOIN FORMATO_MENSAJE F 
	ON M.COD_FORMATO = F.COD_FORMATO
GROUP BY M.COD_MENSAJE, P.NOMBRE, PR.DESCRIPCION, PP.PRODUCTO, F.NOBMRE
ORDER BY P.NOMBRE;




