-- Una misma consulta puede devolver los mismos registros
-- Pero existen consultas mas eficientes

select * from DEPT;

select * from EMP;

-- Columna a columna es mas eficiente
SELECT DEPT_NO, DNOMBRE, LOC FROM DEPT;

SELECT * FROM EMP ORDER BY SALARIO DESC;
SELECT * FROM EMP SALARIO ORDER BY OFICIO, SALARIO DESC;

/* OPERADORES DE COMPARACION
	> MAYOR
	>= MAYOR IGUAL
	< MENOR
	<= MENOR IGUAL
	= IGUAL
	<> DISTINTO
*/

-- Todo lo que no sea un numero ira entre comillas simples
-- Todos los empleados del departamento 10
SELECT * FROM EMP WHERE DEPT_NO=10;
SELECT * FROM EMP WHERE OFICIO='VENDEDOR';

-- Si deseamos aplicar mas de un filtro necesitamos los operadores relacionales
/* OPERADORES RELACIONALES
	AND: Todos los filtros deben cumplirse
	OR: Recupera cada filtro de la consulta
	NOT: Negamos la consulta (no utilizar)
*/

SELECT * FROM EMP WHERE OFICIO='ANALISTA' AND SALARIO > 30000;

SELECT * FROM EMP WHERE DEPT_NO=10 OR DEPT_NO=20;

-- Queremos todos los empleados que no sean director
SELECT * FROM EMP WHERE NOT OFICIO = 'DIRECTOR'; -- No utilizar nunca NOT, no es eficiente
SELECT * FROM EMP WHERE OFICIO <> 'DIRECTOR';
SELECT * FROM EMP WHERE OFICIO != 'DIRECTOR'; -- No compatible con todos los motores SQL

-- Between busca entre los campos inclusive
SELECT * FROM EMP WHERE SALARIO BETWEEN 104000 AND 195000;
SELECT * FROM EMP WHERE SALARIO >= 104000 AND  SALARIO <= 195000;

-- Operador IN con distintos valores para un campo
-- Mostrar los empleados del departamento 10 y el 20, 40, 55, 66
SELECT * FROM EMP WHERE DEPT_NO = 10 OR DEPT_NO = 20 OR DEPT_NO = 40 OR DEPT_NO = 55 OR DEPT_NO = 66;
SELECT * FROM EMP WHERE DEPT_NO IN (10, 20, 40, 55, 66);

-- Mostrar los empelados que no sean del departamento 10 y 20
SELECT * FROM EMP WHERE DEPT_NO NOT IN (10, 20);
SELECT * FROM EMP WHERE NOT DEPT_NO IN (10, 20); -- Esto no es eficiente

-- Operador LIKE NO ES EFICIENTE
-- Sirve para buscar coincidencias dentro de cadena de caracteres
-- Utiliza comodines para sus busquedas
/*
	_ Un caracter cualquier
	? Un caracter numerico
	% Cualquier caracter y longitud
*/
-- Mostrar todos los empleados cuyo apellido comience por A
SELECT * FROM EMP WHERE APELLIDO LIKE 'A%';
-- Mostrar todos los empleados que contenga A
SELECT * FROM EMP WHERE APELLIDO LIKE '%A%';
-- Mostrar todos los empleados de cuatro letras
SELECT * FROM EMP WHERE APELLIDO LIKE '____';

-- CAMPOS CALCULADOS, son campos que no existen en la tabla
SELECT APELLIDO, SALARIO + COMISION AS TOTAL FROM EMP;

-- No podemos aplicar filtros a los campos calculados
-- WHERE solo filtra sobre campos de la tabla
-- Si queremos filtrar debemos realizar el calculo en el filtro WHERE

-- Mostrar apellido y salario total pero solo los empleados que cobran de salario total mas de 370000
SELECT APELLIDO, SALARIO + COMISION AS TOTAL FROM EMP WHERE SALARIO + COMISION > 370000;
SELECT APELLIDO, SALARIO + COMISION AS TOTAL FROM EMP WHERE SALARIO + COMISION > 370000;

-- Concatenar cadenas NO ES UN ESTANDAR
SELECT APELLIDO + OFICIO AS DESCRIPCION FROM EMP;

-- Clausula DISTINCT, quita los datos repetidos de una columna
SELECT DISTINCT OFICIO FROM EMP;

-- Consultas de AGRUPACION
