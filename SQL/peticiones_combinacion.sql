-- Mostrar el apellido y el nombre del departamento de los empleados
SELECT EMP.APELLIDO, DEPT.DNOMBRE
FROM EMP
INNER JOIN DEPT
ON EMP.DEPT_NO = DEPT.DEPT_NO;

-- Podemos utilizar alias para las tablas
SELECT E.APELLIDO, D.DNOMBRE
FROM EMP E
INNER JOIN DEPT D
ON E.DEPT_NO = D.DEPT_NO;