-- 1) Encontrar el salario medio de los analistas, mostrando el número de los empleados con oficio analista.
SELECT EMP.EMP_NO, (MAX(SALARIO) / COUNT(EMP.EMP_NO)) AS SALARIO_MEDIO
FROM EMP
WHERE EMP.OFICIO = 'ANALISTA'
GROUP BY EMP.EMP_NO;

-- 2) Encontrar el salario mas alto, mas bajo y la diferencia entre ambos de todos los empleados con oficio EMPLEADO.
SELECT MAX(EMP.SALARIO) AS SALARIO_MINIMO, MIN(EMP.SALARIO) AS SALARIO_MAXIMO, (MAX(EMP.SALARIO) - MIN(EMP.SALARIO)) AS DIFERENCIA
FROM EMP WHERE EMP.OFICIO = 'EMPLEADO';

-- 3) Visualizar los salarios mayores para cada oficio.
SELECT MAX(EMP.SALARIO) AS SALARIO_MAYOR, EMP.OFICIO
FROM EMP
GROUP BY EMP.OFICIO;

-- 4) Visualizar el número de personas que realizan cada oficio en cada departamento.
SELECT COUNT(EMP.EMP_NO) AS NºPERSONAS, EMP.OFICIO
FROM EMP
GROUP BY EMP.OFICIO;

-- 5) Buscar aquellos departamentos con cuatro o mas personas trabajando.
SELECT DEPT.DNOMBRE, COUNT(EMP.EMP_NO) AS NºPERSONAS
FROM DEPT INNER JOIN EMP
ON EMP.DEPT_NO = DEPT.DEPT_NO
GROUP BY DEPT.DNOMBRE
HAVING (COUNT(EMP.EMP_NO)) > 4;

-- 6) Mostrar el número de directores que existen por departamento.
SELECT COUNT(EMP.EMP_NO), EMP.DEPT_NO
FROM EMP 
WHERE EMP.OFICIO = 'DIRECTOR'
GROUP BY EMP.DEPT_NO;

-- 7) Visualizar el número de enfermeros, enfermeras e interinos que hay en la plantilla, ordenados por la función.
SELECT COUNT(PLANTILLA.EMPLEADO_NO) NºEMPLEADOS, PLANTILLA.FUNCION
FROM PLANTILLA
WHERE PLANTILLA.FUNCION in ('Enfermero', 'Enfermera', 'Interino')
GROUP BY PLANTILLA.FUNCION
ORDER BY PLANTILLA.FUNCION;

-- 8) Visualizar departamentos, oficios y número de personas, para aquellos departamentos que tengan dos o más personas trabajando en el mismo oficio.
SELECT EMP.DEPT_NO, EMP.OFICIO, COUNT(EMP.EMP_NO) NºPERSONAS
FROM EMP
GROUP BY EMP.OFICIO, EMP.DEPT_NO
HAVING COUNT(EMP.EMP_NO) >= 2;

-- 9) Calcular el salario medio, Diferencia, Máximo y Mínimo de cada oficio. Indicando el oficio y el número de empleados de cada oficio.
SELECT (SUM(EMP.SALARIO) / COUNT(EMP.EMP_NO)) SALARIO_MEDIO, (MAX(EMP.SALARIO) - MIN(EMP.SALARIO)) DIFERENCIA, MAX(EMP.SALARIO) MAXIMO, MIN(EMP.SALARIO) MINIMO, EMP.OFICIO, COUNT(EMP.EMP_NO) NºEMPLEADOS
FROM EMP
GROUP BY EMP.OFICIO;

-- 10) Calcular el valor medio de las camas que existen para cada nombre de sala. Indicar el nombre de cada sala y el número de cada una de ellas.
SELECT (SUM(CAST(SALA.NUM_CAMA AS int)) / COUNT(CAST(SALA.NUM_CAMA AS int))), SALA.NOMBRE, SALA.SALA_COD
FROM SALA
GROUP BY SALA.NOMBRE, SALA.SALA_COD;

-- 12) Averiguar los últimos empleados que se dieron de alta en la empresa en cada uno de los oficios, ordenados por la fecha.
 SELECT * FROM EMP
    WHERE FECHA_ALT IN (SELECT DISTINCT MAX(FECHA_ALT) FROM EMP GROUP BY OFICIO)
    ORDER BY FECHA_ALT DESC;

-- 14) Mostrar la suma total del salario que cobran los empleados de la plantilla para cada función y turno.
SELECT SUM(CAST(PLANTILLA.SALARIO AS int)), PLANTILLA.FUNCION, PLANTILLA.T
FROM PLANTILLA
GROUP BY PLANTILLA.T, PLANTILLA.FUNCION;