DELETE FROM EMP WHERE DEPT_NO = 50;

-- Eliminar todos los empleados del departamento produccion
DELETE FROM EMP WHERE DEPT_NO = 
(SELECT DEPT_NO FROM DEPT WHERE DNOMBRE = 'PRODUCCION');

-- Borrar todos los departamentos con dept_no mayor que 50
DELETE FROM DEPT WHERE DEPT_NO > 50;

-- El de departamento 50 se traslada a valencia
-- y tendra el nombre de I+D
UPDATE DEPT SET DNOMBRE = 'I+D', LOC = 'VALENCIA'
WHERE DEPT_NO = 50;
SELECT * FROM DEPT;

-- Podemos utilizar valores de las columnas que ya existan como referencia para el set
-- Incrementar en 1 el salario de todos los directores
UPDATE EMP SET SALARIO = SALARIO + 1
WHERE OFICIO = 'DIRECTOR';

SELECT * FROM EMP WHERE OFICIO = 'DIRECTOR';

-- Modificamos el salario de los empleados de Barcelona y les ponemos el mismo salario que el apellido Alonso
UPDATE EMP SET SALARIO =
(SELECT SALARIO FROM EMP WHERE EMP.APELLIDO = 'ALONSO')
WHERE EMP.DEPT_NO IN 
(SELECT DEPT.DEPT_NO FROM DEPT WHERE DEPT.LOC = 'BARCELONA');

SELECT * FROM EMP WHERE APELLIDO <> 'ALONSO';
