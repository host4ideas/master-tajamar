-- 4) Visualizar cuantas personas realizan cada oficio en cada departamento mostrando el nombre del departamento.
SELECT DEPT.DNOMBRE, COUNT(EMP.EMP_NO), EMP.OFICIO
FROM EMP FULL JOIN DEPT
ON EMP.DEPT_NO = DEPT.DEPT_NO
GROUP BY DEPT.DNOMBRE, EMP.OFICIO;

-- 5) Contar cuantas salas hay en cada hospital, mostrando el nombre de las salas y el nombre del hospital.
SELECT HOSPITAL.NUM_CAMA, SALA.NOMBRE, HOSPITAL.NOMBRE
FROM HOSPITAL INNER JOIN SALA
ON HOSPITAL.HOSPITAL_COD = SALA.HOSPITAL_COD;

-- 9) Visualizar el Apellido de los empleados de la plantilla junto con el nombre de la sala, el nombre del hospital y el número de camas libres de cada una de ellas.
SELECT P.APELLIDO, S.NOMBRE, H.NOMBRE, S.NUM_CAMA
FROM PLANTILLA P
INNER JOIN SALA S
ON P.SALA_COD = S.SALA_COD
INNER JOIN HOSPITAL H
ON S.HOSPITAL_COD = H.HOSPITAL_COD;

-- 10) Averiguar la combinación de que salas podría haber por cada uno de los hospitales.
SELECT S.NOMBRE, H.NOMBRE
FROM SALA S 
CROSS JOIN HOSPITAL H;