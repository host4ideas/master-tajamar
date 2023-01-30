-- Transact SQL
DECLARE @TEXTO NVARCHAR(50)
DECLARE @NUMERO INT
DECLARE @FECHA DATETIME

-- Asignar valores estaticos
SET @TEXTO = 'HOY ES LUNES'
SET @NUMERO = 14

-- Asignar valores mediante funciones
SET @FECHA = GETDATE();

-- Representar los valores
/*
	1) Consultas select. Podriamos hacer un select
	   con las variables y recuperarlo en cualquier app
*/
SELECT @TEXTO AS TEXTO, @NUMERO AS NUMERO, @FECHA AS FECHA;

/*
	2) Mensajes de servidor. Print. Un mensaje de servidor
	   solamente sirve par ala base de datos. Es util cuando 
	   escribimos mucho codigo en los procedimietos para seguir
	   la secuencia. Tambien para mostrar posibles mensajes
*/
PRINT @TEXTO;
-- PRINT @TEXTO + @NUMERO -- Esto da error, hay que hacer el casting
PRINT @TEXTO + ', @NUMERO: ' + CAST(@NUMERO AS NVARCHAR) + ' FECHA: ' + CAST(@FECHA AS NVARCHAR)

---------------------------------------------------------------------

-- Mostrar los datos del empleado mas antiguo de la empresa
SELECT * FROM EMP WHERE FECHA_ALT=
(SELECT MIN(FECHA_ALT) FROM EMP)

-- La solucion es utilizar una variable para almacenar la minima fecha y utilizarla en la consulta
-- SELECT @VARIABLE = CAMPO1, @VARIABLE = CAMPO2, @VARIABLE = CAMPO3 FROM TABLA
DECLARE @FECHAALT DATETIME
SELECT @FECHAALT = MIN(FECHA_ALT) FROM EMP;
SELECT * FROM EMP WHERE FECHA_ALT = @FECHAALT;

-- Los condicionales nos permiten poder ejecutar multiples codigos o consultas
/*
	IF(CONDICION)
	BEGIN
		-- CONDICIONES TRUE
	END
	ELSE IF (OTRA CONDICION)
	BEGIN
		-- INSTRUCCIONES
	END
	ELSE
	BEGIN
		-- INSTRUCCIONES ELSE
	END
*/
DECLARE @NUM INT = -1
IF(@NUM >= 0) BEGIN
	SELECT * FROM EMP;
END
ELSE BEGIN
	SELECT * FROM DEPT;
END

-- Mostrar los empleados del departamento de ventas, si el departamento no existe, mostramos un mesaje, si existe mostramos los empleados
DECLARE @DEPTNO INT
SELECT @DEPTNO = DEPT_NO FROM DEPT
WHERE DNOMBRE = 'DFHDFGH';

IF (@DEPTNO IS NULL) BEGIN
	PRINT 'NO EXISTE EL DEPARTAMENTO'
END
ELSE BEGIN
	SELECT * FROM EMP WHERE DEPT_NO = @DEPTNO
END

/*
	Incrementar en 10.000 el salario de Sancha si cobra menos de 150.000,
	si cobra mas de 250.000 bajar sueldo en 2.000
*/
DECLARE @SALARIO_ACTUAL INT
SELECT @SALARIO_ACTUAL = SALARIO FROM EMP WHERE APELLIDO = 'SANCHA';

IF(@SALARIO_ACTUAL < 150000) BEGIN
	UPDATE EMP SET SALARIO = SALARIO + 10000
	WHERE APELLIDO = 'SANCHA';
	PRINT 'SALARIO AUMENTADO EN 10000';
END
ELSE IF(@SALARIO_ACTUAL > 250000) BEGIN
	UPDATE EMP SET SALARIO = SALARIO - 2000
	WHERE APELLIDO = 'SANCHA';
	PRINT 'SALARIO DISMINUIDO EN 2000';
END
ELSE BEGIN
	PRINT 'SALARIO SIN MODIFICAR'
END

SELECT * FROM EMP WHERE APELLIDO = 'SANCHA';

-- Modificar el salario de la plantilla de la paz
-- Si la suma salarial supera 1.000.000 bajar el sueldo en 10.000
-- si no supera la cantidad subir en 10.000
DECLARE @SUELDO_TOTAL INT
DECLARE @HOSPITALCOD INT

SELECT @HOSPITALCOD = HOSPITAL_COD FROM HOSPITAL WHERE NOMBRE = 'La Paz';

SELECT @SUELDO_TOTAL = SUM(CAST(SALARIO AS int)) FROM PLANTILLA
WHERE HOSPITAL_COD = @HOSPITALCOD;

IF(@SUELDO_TOTAL > 1000000) BEGIN
	UPDATE PLANTILLA SET SALARIO = SALARIO - 10000 WHERE HOSPITAL_COD = @HOSPITALCOD;
	PRINT 'DISMINUCION SALARIO EN 10000'
END
ELSE BEGIN
	UPDATE PLANTILLA SET SALARIO = SALARIO + 10000 WHERE HOSPITAL_COD = @HOSPITALCOD;
	PRINT 'AUMENTO SALARIO EN 10000'
END

/*
	Alter table plantilla alter column salario int
	sintaxis de bucles, los bucles no se llevan bien con ningna base de datos,
	excepto para recorrer cursores
*/
DECLARE @CONTADOR INT
SET @CONTADOR = 1

WHILE (@CONTADOR <= 10)
BEGIN
	PRINT '@CONTADOR ' + CAST(@CONTADOR AS NVARCHAR)
	SET @CONTADOR = @CONTADOR + 1
END

-- Los bucles no se utilizan para tareas programaticas en BBDD
DECLARE @APE NVARCHAR(50)
SELECT @APE = APELLIDO FROM EMP;
PRINT @APE

SELECT APELLIDO FROM EMP;

-- Exite una variable CURSOR que permite almacenar consultas
DECLARE @APELLIDO AS NVARCHAR(50)
DECLARE @OFICIO AS NVARCHAR(50)

-- 1) Declarar cursor con la consulta
DECLARE QUERY CURSOR FOR
SELECT APELLIDO, OFICIO FROM EMP;
-- 2) Abrir cursor
OPEN QUERY
-- 3) Almacenar los datos de la primera fila en nuestra variable
--  FETCH NEXT FROM QUERY INTO @APELLIDO, @OFICIO;
/**
	4) Para saber si existen datos, existe una variable de sistema @@FETCH_STATUS que nos permite recorrer los datos del cursor.
	   Si su valor es 0 contiene registros
**/
WHILE(@@FETCH_STATUS = 0)
BEGIN
	-- Nunca cambiara el estado de @@FETCH_STATUS, a no ser que hagamos le FETCH NEXT
	FETCH NEXT FROM QUERY INTO @APELLIDO, @OFICIO;
	PRINT @APELLIDO + ', ' + @OFICIO;
END
-- 5) Cerrar cursor
CLOSE QUERY
-- 6) Liberar la memoria
DEALLOCATE QUERY

-- Necesitamos incrementar el salario de los doctores con un valor aleatorio hasta 10.000
-- ALTER TABLE DOCTOR ALTER COLUMN SALARIO INT;
DECLARE @INCREMENTO INT
SET @INCREMENTO = RAND() * 10000
UPDATE DOCTOR SET SALARIO = SALARIO + @INCREMENTO
SELECT * FROM DOCTOR

-- Necesitamos incrementar el salario de los doctores con un valor aleatorio hasta 10.000 cada uno, dibujamos el apellido y el nuevo salario
DECLARE @INCREMENTO INT;
DECLARE @SALARIO INT;
DECLARE @APELLIDO NVARCHAR(50);
DECLARE @NUEVO_SALARIO INT;

DECLARE QUERY CURSOR FOR
SELECT APELLIDO, SALARIO FROM DOCTOR;

OPEN QUERY
FETCH NEXT FROM QUERY INTO @APELLIDO, @SALARIO;
WHILE(@@FETCH_STATUS = 0)
BEGIN
	SET @INCREMENTO = RAND() * 10000;
	SET @NUEVO_SALARIO = @INCREMENTO + @SALARIO;
	UPDATE DOCTOR SET SALARIO = @NUEVO_SALARIO WHERE APELLIDO = @APELLIDO;
	PRINT 'NUEVO SALARIO DE ' + @APELLIDO + ' ES: ' + CAST(@NUEVO_SALARIO AS NVARCHAR(50))
	FETCH NEXT FROM QUERY INTO @APELLIDO, @SALARIO;
END

CLOSE QUERY
DEALLOCATE QUERY

SELECT * FROM DOCTOR;

/*
	Modificar el salario de los empleados de cada departamento. Todo mediante una unica accion/script
	Si la suma del departamento supera 1.000.000 bajamos en 10.000
	Si la suma no supera, subimos 10.000
*/
DECLARE @DEPTNUM INT
DECLARE @DEPTNOM NVARCHAR(50)
DECLARE @SALARIO_TOTAL INT
DECLARE @SALARIO INT

DECLARE CONSULTA CURSOR FOR
SELECT DEPT.DEPT_NO, DEPT.DNOMBRE FROM DEPT;

OPEN CONSULTA
FETCH NEXT FROM CONSULTA INTO @DEPTNUM, @DEPTNOM;
WHILE(@@FETCH_STATUS = 0)
BEGIN
	SELECT @SALARIO_TOTAL = SUM(EMP.SALARIO) FROM EMP WHERE EMP.DEPT_NO = @DEPTNUM;

	PRINT 'SALARIO TOTAL DE ' + @DEPTNOM + ' ES ' +  CAST(@SALARIO_TOTAL AS NVARCHAR(50))
	
	IF(@SALARIO_TOTAL > 1000000) BEGIN
		UPDATE EMP SET EMP.SALARIO = EMP.SALARIO - 10000 WHERE EMP.DEPT_NO = @DEPTNUM;
		PRINT 'BAJANDO SALARIOS A ' + @DEPTNOM;
	END
	ELSE BEGIN
		UPDATE EMP SET EMP.SALARIO = EMP.SALARIO + 10000 WHERE EMP.DEPT_NO = @DEPTNUM;
		PRINT 'SUBIENDO SALARIOS A ' + @DEPTNOM;
	END
	FETCH NEXT FROM CONSULTA INTO @DEPTNUM, @DEPTNOM;
END

CLOSE CONSULTA
DEALLOCATE CONSULTA

