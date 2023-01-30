-- Esto solo funcionara si tenemos permisos sobre la vista
CREATE VIEW V_EMPLEADOS_SIMPLE
AS
	SELECT EMP_NO, APELLIDO, OFICIO, DIR, FECHA_ALT, DEPT_NO FROM EMP
GO

-- DROP VIEW
-- ALTER VIEW

SELECT * FROM V_EMPLEADOS_SIMPLE;
SELECT * FROM EMP;

-- En las consultas de accion, nunca se almacenan datos en la vista, sino que se comunica con la tabla
INSERT INTO V_EMPLEADOS_SIMPLE VALUES (1112, 'VISTA', 'VENDEDOR', 7802, GETDATE(), 30);
-- Update
UPDATE V_EMPLEADOS_SIMPLE SET OFICIO = 'VENDEDORA'
WHERE EMP_NO = 1112;
-- Delete
DELETE FROM V_EMPLEADOS_SIMPLE
WHERE EMP_NO = 1112;

-- Vamos a crear vistas compuestas para simplificar consultas (join)
CREATE VIEW V_EMPLEADOS_DEPARTAMENTO
AS
	SELECT EMP.EMP_NO, EMP.APELLIDO, EMP.SALARIO, EMP.COMISION, DEPT.DNOMBRE, DEPT.LOC, DEPT.DEPT_NO
	FROM EMP INNER JOIN DEPT
	ON EMP.DEPT_NO = DEPT.DEPT_NO;
GO

SELECT * FROM V_EMPLEADOS_DEPARTAMENTO
WHERE LOC = 'MADRID';

-- Modificar el salario de todos los empleados de Madrid
UPDATE V_EMPLEADOS_DEPARTAMENTO SET SALARIO = SALARIO + 1
WHERE LOC = 'MADRID';

-- Modificar el nombre de departamento y salrio de todos los empleados de madrid
-- Si la consulta afecta a mas de una tabla no puedes hacerla
UPDATE V_EMPLEADOS_DEPARTAMENTO SET DNOMBRE = 'LUNES', SALARIO = SALARIO + 1
WHERE LOC = 'MADRID';

-- Eliminar todos los empelados de madrid
-- No funciona porque la vista no sabe de donde borrar where LOC
DELETE FROM V_EMPLEADOS_DEPARTAMENTO WHERE LOC = 'MADRID';
-- Eliminar al empleado 1112
DELETE FROM V_EMPLEADOS_DEPARTAMENTO WHERE EMP_NO = 1112;

-- SE PUEDEN CREAR TRIGGERS PARA PERMITIR CONSUTLAS DE ACCION (UPDATE, DELETE, CREATE) EN CASO DE SER UNA VISTA CON VARIAS TABLAS
