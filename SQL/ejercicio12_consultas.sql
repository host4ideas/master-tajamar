-- 1) Seleccionar el apellido, oficio, salario, numero de departamento y su nombre de todos los empleados cuyo salario sea mayor de 300000
SELECT APELLIDO, OFICIO, SALARIO, EMP.DEPT_NO, DEPT.DNOMBRE AS 'DEPARTAMENTO' 
FROM EMP INNER JOIN DEPT
ON EMP.DEPT_NO = DEPT.DEPT_NO
WHERE EMP.SALARIO > 300000;

-- 2) Mostrar todos los nombres de Hospital con sus nombres de salas correspondientes.
SELECT SALA.NOMBRE SALA, HOSPITAL.NOMBRE HOSPITAL
FROM HOSPITAL INNER JOIN SALA
ON HOSPITAL.HOSPITAL_COD = SALA.HOSPITAL_COD
GROUP BY HOSPITAL.NOMBRE, SALA.NOMBRE;

-- 3) Buscar aquellas ciudades con cuatro o más personas trabajando.
SELECT DEPT.LOC, COUNT(EMP.EMP_NO) 'Nº de Personas'
FROM DEPT FULL JOIN EMP
ON EMP.DEPT_NO = DEPT.DEPT_NO
GROUP BY DEPT.LOC
HAVING (COUNT(EMP.EMP_NO)) > 4;

-- 4) Mostrar los doctores junto con el nombre de hospital en el que ejercen, la dirección y el teléfono del mismo.
SELECT DOCTOR.APELLIDO, HOSPITAL.NOMBRE, HOSPITAL.DIRECCION, HOSPITAL.TELEFONO
FROM DOCTOR INNER JOIN HOSPITAL
ON DOCTOR.HOSPITAL_COD = HOSPITAL.HOSPITAL_COD;

-- 5) Se quiere dar de alta un departamento de RRHH situado en Soria y otro departamento de Informática en Alicante.
INSERT INTO DEPT VALUES (60, 'RRHH', 'SORIA');
INSERT INTO DEPT VALUES (70, 'INFORMATICA', 'ALICANTE');

-- 6) El departamento de Ventas por motivos de peseteros se traslada a Tabarnia, realizar dicha modificación. 
UPDATE DEPT SET LOC = 'TABARNIA'
WHERE DEPT.LOC = (SELECT DEPT.LOC FROM DEPT WHERE DEPT.DNOMBRE = 'VENTAS');

SELECT * FROM DEPT;

-- 7) En el departamento anterior (VENTAS) se dan de alta dos empleados: Julián Romeral y Luis Campayo.  Su salario base es de 80000 Pts. y cobrarán una comisión del 15% de su salario.
INSERT INTO EMP VALUES ((SELECT MAX(EMP.EMP_NO) FROM EMP) + 1, 'ROMERAL', 'VENDEDOR', '7456', GETDATE(), 80000, (80000 * 0.15), (SELECT DEPT.DEPT_NO FROM DEPT WHERE DEPT.DNOMBRE = 'VENTAS') );
INSERT INTO EMP VALUES ((SELECT MAX(EMP.EMP_NO) FROM EMP) + 1, 'CAMPAYO', 'VENDEDOR', '7456', GETDATE(), 80000, (80000 * 0.15), (SELECT DEPT.DEPT_NO FROM DEPT WHERE DEPT.DNOMBRE = 'VENTAS') );

-- 8) Modificar la comisión de los empleados de la empresa, de forma que todos tengan un incremento del 10% del salario.
UPDATE EMP SET COMISION = COMISION + (COMISION * 0.10);

-- 9) Incrementar en 10000 el salario de los interinos de la plantilla que trabajen en el turno de noche.
UPDATE PLANTILLA SET SALARIO = (SALARIO + 10000)
WHERE PLANTILLA.EMPLEADO_NO IN 
(SELECT PLANTILLA.EMPLEADO_NO FROM PLANTILLA WHERE PLANTILLA.T='N' AND PLANTILLA.FUNCION='Interino');

-- 10) Ha llegado un nuevo doctor a la Paz.  Su apellido es House y su especialidad es Diagnostico.   Introducir el siguiente número de doctor disponible.
INSERT INTO DOCTOR VALUES (
(SELECT HOSPITAL.HOSPITAL_COD FROM HOSPITAL WHERE HOSPITAL.NOMBRE='La Paz'),
(SELECT MAX(DOCTOR.DOCTOR_NO) FROM DOCTOR),
'House',
'Diagnostico',
500000);

-- 11) Incrementar el salario de los empleados del departamento de ventas de modo que cobren 5000 más que el empleado que menos cobre con oficio EMPLEADO.
UPDATE EMP SET SALARIO = 
(SELECT MIN(SALARIO) FROM EMP WHERE OFICIO='EMPLEADO')
+ 5000;

-- 12) Borrar los empleados cuyo nombre de departamento sea I+D.
DELETE FROM EMP WHERE EMP.DEPT_NO=
(SELECT DEPT.DEPT_NO FROM DEPT WHERE DEPT.DNOMBRE = 'I+D');
