/*
	• COUNT(CAMPO): Cuenta el número de registros sin incluir NULOS
	• COUNT(*): Cuenta el número de registros incluyendo datos nulos.
	• SUM(NUMERO): Suma los datos de una columna
	• AVG(NUMERO): Media de los datos de una columna
	• MAX(CAMPO): Devuelve el máximo valor de una columna
	• MIN(CAMPO): Devuelve el mínimo valor de una columna
*/

SELECT COUNT(DEPT_NO) AS NUMEROREGISTROS FROM DEPT;

SELECT MAX(SALARIO) AS MAXIMOSALARIO,
MIN(SALARIO) AS MINIMOSALARIO FROM EMP;

-- Las agrupaciones pueden realizarse por uno o mas campos
-- Mostrar el numero de empleados por cada oficio
-- Se utiliza la clausula group by con cada campo que deseemos agrupar
-- Truco: poner en cada group by cada columna qu eno sea una funcion de agrupacion en el select
SELECT COUNT(*) AS NUMEROEMPLEADOS, OFICIO FROM EMP
GROUP BY OFICIO;
-- Mostrar el maximo salario por cada oficio
SELECT MAX(SALARIO) AS MAXIMOSALARIO, OFICIO
FROM EMP
GROUP BY OFICIO;

/* FILTROS EN COLUMNAS DE AGRUPACION
	WHERE: se aplica a columnas de la tabla, antes del GROUP BY
	HAVING: se aplica a columnas de la tabla y tambien de funciones despues del GROUP BY
			es mas eficiente si filtramos por campos del SELECT
*/
-- Mostrar el maximo salario de los que no son directores por departamentos
SELECT MAX(SALARIO) AS MAXIMOSALARIO, OFICIO, DEPT_NO
FROM EMP
WHERE OFICIO <> 'DIRECTOR'
GROUP BY OFICIO, DEPT_NO;

-- Mostrar el nuero de personas por departamento, solamete contar los que sean directores
SELECT COUNT(*) AS DIRECTORES, DEPT_NO
FROM EMP
WHERE OFICIO = 'DIRECTOR'
GROUP BY DEPT_NO;

-- Mostrar el numero de personas por departamento, solamente los departamentos 10 y 20
SELECT COUNT(*) AS DIRECTORES, DEPT_NO
FROM EMP
WHERE DEPT_NO IN (10, 20)
GROUP BY DEPT_NO;
-- Mas eficiente con el HAVING
SELECT COUNT(*) AS DIRECTORES, DEPT_NO
FROM EMP
GROUP BY DEPT_NO
HAVING DEPT_NO IN (10, 20);

-- Mostrar el numero de personas por departamento, solamente los departamentos con dos o mas personas
SELECT COUNT(*) AS PERSONAS, DEPT_NO
FROM EMP
GROUP BY DEPT_NO
HAVING COUNT(*) >= 2;