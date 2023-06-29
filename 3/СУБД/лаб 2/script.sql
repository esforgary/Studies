DROP TABLE staff;
DROP TABLE pharmacys;

DELETE FROM staff;
DELETE FROM pharmacys;

SET SERVEROUTPUT ON;

/* �������� ������� ����� */

CREATE TABLE pharmacys (
   id NUMBER(10) PRIMARY KEY,
   name VARCHAR2(50) NOT NULL,
   address VARCHAR2(100) NOT NULL,
   staff NUMBER(10) NOT NULL,
   status VARCHAR2(10) NOT NULL,
   work_time VARCHAR2(20) NOT NULL,
   medicine_capacity NUMBER(10) NOT NULL
); 

ALTER TABLE pharmacys ADD CONSTRAINT pharmacys_status_check CHECK (status IN ('³��', '���'));


/* ------------------------------------- ���������� ------------------------------------- */
 
INSERT INTO pharmacys(id, name, address, staff, status, work_time, medicine_capacity) 
VALUES (1, '������ ���������', '�������� �����������, 38', 0, '³��', '9:00 - 22:00', 0);

INSERT INTO pharmacys(id, name, address, staff, status, work_time, medicine_capacity) 
VALUES (2, '������ ������� ���', '�������� �����������, 41/37', 0, '���', '00:00 - 24:00', 0);

INSERT INTO pharmacys(id, name, address, staff, status, work_time, medicine_capacity) 
VALUES (3, '��������� ������ �15', '�������� �����������, 24', 0, '³��', '11:00 - 17:00', 0);

INSERT INTO pharmacys(id, name, address, staff, status, work_time, medicine_capacity) 
VALUES (4, '̳���� ������', '������ ˳���, 1/1', 0, '���', '9:00 - 19:30', 0);
   
   
/* �������� ������� ��������� */

CREATE TABLE staff (
   id NUMBER(10) PRIMARY KEY,
   name VARCHAR2(50) NOT NULL,
   job_title VARCHAR2(50) NOT NULL,
   pharmacy_id NUMBER(10) NOT NULL,
   Date_of_Birth DATE NOT NULL,
   age NUMBER(3),
   CONSTRAINT staff_pharmacy_fk FOREIGN KEY (pharmacy_id) REFERENCES pharmacys(id)
);

CREATE OR REPLACE TRIGGER update_staff_count
AFTER INSERT OR DELETE ON staff
FOR EACH ROW
BEGIN
  IF INSERTING THEN
    UPDATE pharmacys
    SET staff = staff + 1
    WHERE id = :new.pharmacy_id;
  ELSIF DELETING THEN
    UPDATE pharmacys
    SET staff = staff - 1
    WHERE id = :old.pharmacy_id;
  END IF;
END;
/

CREATE OR REPLACE TRIGGER calculate_age
BEFORE INSERT OR UPDATE ON staff
FOR EACH ROW
BEGIN
   :NEW.age := FLOOR(MONTHS_BETWEEN(SYSDATE, :NEW.Date_of_Birth)/12);
END;
/

ALTER TABLE staff ADD CONSTRAINT age_check CHECK (age >= 18);

/* ------------------------------------- ���������� ------------------------------------- */

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (1, '�������� �. �.', '����', 1, TO_DATE('1969-03-12', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (2, '������ �. �.', '������������', 1, TO_DATE('1990-12-11', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (3, '����� �. �.', '���������', 1, TO_DATE('1996-01-09', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (4, '������� �. �.', '���������', 1, TO_DATE('1991-09-01', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (5, '������ �. �.', '����', 2, TO_DATE('1977-04-25', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (6, '���������� �. �.', '������������', 2, TO_DATE('2000-05-14', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (7, '�������� �. �.', '���������', 2, TO_DATE('1980-11-11', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (8, '�������� �. �.', '����', 3, TO_DATE('1950-11-09', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (9, '��������� �. �.', '���������', 3, TO_DATE('2002-12-06', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (10, '����� �. �.', '����', 4, TO_DATE('1978-07-10', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (11, '����� �. �.', '������������', 4, TO_DATE('2003-11-25', 'yyyy-mm-dd'), NULL);

INSERT INTO staff (id, name, job_title, pharmacy_id, Date_of_Birth, age) 
VALUES (12, '���� �. �.', '���������', 4, TO_DATE('1996-10-07', 'yyyy-mm-dd'), NULL);


/* �������� ������� ������������ */

CREATE TABLE pharmacy_medicines (
   id NUMBER(10) PRIMARY KEY,
   pharmacy_id NUMBER(10) NOT NULL,
   medicine_name VARCHAR2(50) NOT NULL,
   medicine_quantity NUMBER(10) NOT NULL,
   date_of_manufacture DATE NOT NULL,
   best_before_date DATE NOT NULL,
   FOREIGN KEY (pharmacy_id) REFERENCES pharmacys(id)
);

ALTER TABLE pharmacy_medicines
ADD CONSTRAINT medicine_quantity_check CHECK (medicine_quantity >= 0);

CREATE OR REPLACE TRIGGER update_medicine_capacity
AFTER INSERT ON pharmacy_medicines
FOR EACH ROW
BEGIN
  UPDATE pharmacys
  SET medicine_capacity = medicine_capacity + 1
  WHERE id = :new.pharmacy_id;
END;



INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (1, 1, 'ͳ�����', 50, TO_DATE('2021-10-07', 'yyyy-mm-dd'), TO_DATE('2025-10-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (2, 1, '�������', 30, TO_DATE('2022-12-04', 'yyyy-mm-dd'), TO_DATE('2024-12-04', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (3, 1, '�����������', 20, TO_DATE('2022-10-03', 'yyyy-mm-dd'), TO_DATE('2025-10-03', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (4, 2, '��������', 30, TO_DATE('2020-08-07', 'yyyy-mm-dd'), TO_DATE('2023-08-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (5, 2, '�������', 32, TO_DATE('2023-04-01', 'yyyy-mm-dd'), TO_DATE('2026-04-01', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (6, 2, '��������', 51, TO_DATE('2023-01-07', 'yyyy-mm-dd'), TO_DATE('2024-01-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (7, 2, '��������', 15, TO_DATE('2021-10-07', 'yyyy-mm-dd'), TO_DATE('2025-10-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (8, 3, 'ͳ�����', 28, TO_DATE('2023-02-17', 'yyyy-mm-dd'), TO_DATE('2025-02-17', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (9, 3, '����� ������', 18, TO_DATE('2021-10-07', 'yyyy-mm-dd'), TO_DATE('2025-10-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (10, 3, '���� ������', 14, TO_DATE('2023-01-07', 'yyyy-mm-dd'), TO_DATE('2024-01-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (11, 4, 'ͳ�����', 4, TO_DATE('2023-01-14', 'yyyy-mm-dd'), TO_DATE('2024-01-14', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (12, 4, '�������', 26, TO_DATE('2021-10-07', 'yyyy-mm-dd'), TO_DATE('2025-10-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (13, 4, '������� ������', 7, TO_DATE('2021-10-30', 'yyyy-mm-dd'), TO_DATE('2025-10-30', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (14, 4, '���������', 67, TO_DATE('2022-09-07', 'yyyy-mm-dd'), TO_DATE('2024-09-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (15, 4, '�������', 26, TO_DATE('2021-10-07', 'yyyy-mm-dd'), TO_DATE('2025-10-07', 'yyyy-mm-dd'));

INSERT INTO pharmacy_medicines (id, pharmacy_id, medicine_name, medicine_quantity, date_of_manufacture, best_before_date)
VALUES (16, 4, '�������', 26, TO_DATE('2020-10-07', 'yyyy-mm-dd'), TO_DATE('2022-10-07', 'yyyy-mm-dd'));


/* �������� ���������, �� ������ ����� ������: */

CREATE OR REPLACE PROCEDURE get_pharmacy_staff(
p_pharmacy_id IN pharmacys.id%TYPE,
p_min_age IN staff.age%TYPE
)
IS
CURSOR staff_cursor IS
SELECT id, name, job_title, age
FROM staff
WHERE pharmacy_id = p_pharmacy_id AND age >= p_min_age;
v_staff_id staff.id%TYPE;
v_staff_name staff.name%TYPE;
v_job_title staff.job_title%TYPE;
v_age staff.age%TYPE;
BEGIN
OPEN staff_cursor;
LOOP
FETCH staff_cursor INTO v_staff_id, v_staff_name, v_job_title, v_age;
EXIT WHEN staff_cursor%NOTFOUND;
DBMS_OUTPUT.PUT_LINE('Staff ID: ' || v_staff_id || ', Name: ' || v_staff_name || ', Job Title: ' || v_job_title || ', Age: ' || v_age);
END LOOP;
CLOSE staff_cursor;
END;

BEGIN
get_pharmacy_staff(2, 20);
END;

/* �������� ������� �� ����-��� �� ������� �����-�����: */

CREATE OR REPLACE FUNCTION get_oldest_medicine
RETURN pharmacy_medicines.medicine_name%TYPE
IS
v_oldest_medicine pharmacy_medicines.medicine_name%TYPE;
BEGIN
SELECT medicine_name INTO v_oldest_medicine
FROM pharmacy_medicines
WHERE date_of_manufacture = (SELECT MIN(date_of_manufacture) FROM pharmacy_medicines);
RETURN v_oldest_medicine;
END;

SELECT get_oldest_medicine() as oldest_medicine FROM dual;


/* ��'������ ��������� �� ������� � �����: */

CREATE OR REPLACE PACKAGE pharmacy_pkg AS
PROCEDURE get_staff_age(
p_staff_id IN staff.id%TYPE
);
FUNCTION get_oldest_medicine
RETURN pharmacy_medicines.medicine_name%TYPE;
END pharmacy_pkg;
/

CREATE OR REPLACE PACKAGE BODY pharmacy_pkg AS
PROCEDURE get_staff_age(
p_staff_id IN staff.id%TYPE
)
IS
v_staff_age staff.age%TYPE;
BEGIN
SELECT age INTO v_staff_age
FROM staff
WHERE id = p_staff_id;
DBMS_OUTPUT.PUT_LINE('Staff ID ' || p_staff_id || ' is ' || v_staff_age || ' years old.');
END;

FUNCTION get_oldest_medicine
RETURN pharmacy_medicines.medicine_name%TYPE
IS
v_oldest_medicine pharmacy_medicines.medicine_name%TYPE;
BEGIN
SELECT medicine_name INTO v_oldest_medicine
FROM pharmacy_medicines
WHERE date_of_manufacture = (SELECT MIN(date_of_manufacture) FROM pharmacy_medicines);
RETURN v_oldest_medicine;
END;
END pharmacy_pkg;
/

DECLARE
oldest_medicine pharmacy_medicines.medicine_name%TYPE;
BEGIN
oldest_medicine := pharmacy_pkg.get_oldest_medicine();
DBMS_OUTPUT.PUT_LINE('The oldest medicine is ' || oldest_medicine);
pharmacy_pkg.get_staff_age(1);
END;


/* ------------------------------------- ������� ------------------------------------- */

/* 1. ������� �������� ������ � ���������� �����������, � ������� ���� �������� � ������� ������: */
SELECT p.name, COUNT(*) AS num_birthday_this_month
FROM pharmacys p 
JOIN staff s ON p.id = s.pharmacy_id
WHERE EXTRACT(MONTH FROM s.Date_of_Birth) = EXTRACT(MONTH FROM SYSDATE)
GROUP BY p.name;

/* 2. ������� ������ ���� ��������, ������� ���� ����������� ����� ���� ����� � ��� �� ����������, ��������������� �� ���� ������������: */
SELECT medicine_name, date_of_manufacture 
FROM pharmacy_medicines 
WHERE date_of_manufacture < ADD_MONTHS(TRUNC(SYSDATE), -12) AND best_before_date > TRUNC(SYSDATE) 
ORDER BY date_of_manufacture;

/* 3. ������� ������ ������������ � �������, ���� ������������ ������� ����� 01.01.2022: */
SELECT pm.medicine_name, p.name, pm.medicine_quantity, pm.date_of_manufacture
FROM pharmacy_medicines pm
JOIN pharmacys p ON p.id = pm.pharmacy_id
WHERE pm.date_of_manufacture > TO_DATE('01-01-2022', 'DD-MM-YYYY');

/* 4. ������� �������� ������, ����� � ���������� ������������, ������� ���� ����������� � ������� ����: */
SELECT p.name, p.address, pm.medicine_name, pm.medicine_quantity
FROM pharmacys p
JOIN pharmacy_medicines pm ON pm.pharmacy_id = p.id
WHERE EXTRACT(YEAR FROM pm.date_of_manufacture) = EXTRACT(YEAR FROM SYSDATE);

/* 5. ������� �������� ������, ����� � ���������� ������������, � ������� ���� �������� ���������� � ��������� ����: */
SELECT p.name, pm.medicine_name, pm.medicine_quantity
FROM pharmacys p
JOIN pharmacy_medicines pm ON pm.pharmacy_id = p.id
WHERE TRUNC(pm.best_before_date, 'YYYY') = TRUNC(ADD_MONTHS(SYSDATE, 12), 'YYYY');

/* 6. ������� �������� ������, ����� � ���������� ������������, ������������� � ������ �������� �������� ����: */
SELECT p.name, p.address, SUM(pm.medicine_quantity)
FROM pharmacys p
JOIN pharmacy_medicines pm ON pm.pharmacy_id = p.id
WHERE EXTRACT(YEAR FROM pm.date_of_manufacture) = EXTRACT(YEAR FROM SYSDATE) AND EXTRACT(MONTH FROM pm.date_of_manufacture) <= 6
GROUP BY p.name, p.address;

/* 7. ������� ������ ������������, ���������� ������� � ������ ������ ��������� ������� �������� ���������� ����� ����������� �� ���� �������: */
SELECT pm.medicine_name, AVG(pm.medicine_quantity) AS avg_quantity
FROM pharmacy_medicines pm
GROUP BY pm.medicine_name
HAVING AVG(pm.medicine_quantity) < (
   SELECT AVG(medicine_quantity) FROM pharmacy_medicines
)

/* 8. ������� ������ �����, ��� ������� ������� ����������� ������ 40 ���: */
SELECT p.name, p.address, AVG(EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM s.date_of_birth)) AS avg_age
FROM pharmacys p
JOIN staff s ON s.pharmacy_id = p.id
GROUP BY p.name, p.address
HAVING AVG(EXTRACT(YEAR FROM SYSDATE) - EXTRACT(YEAR FROM s.date_of_birth)) < 40;

/* 9. ������� ������ ������������, �������� ������, ��� ������ � ���� ��������� �����, � ������� ���� �������� ���������� ����� ������ �����, �� ��� ��� ��� ���� � �������: */
SELECT DISTINCT p.name, s.name, pm.medicine_name, pm.best_before_date
FROM pharmacy_medicines pm
JOIN pharmacys p ON pm.pharmacy_id = p.id
JOIN staff s ON p.staff = s.id
WHERE pm.best_before_date < ADD_MONTHS(TRUNC(SYSDATE), -1);

/* 10. ������� ������ �����, ��� �������� ���� �� ���� ��������� ������ 50 ���, ��������������� �� ���������� ����������� � ������ � ������� ��������: */
SELECT p.name, COUNT(s.id) as num_staff
FROM pharmacys p
JOIN staff s ON s.pharmacy_id = p.id
WHERE s.age > 50
GROUP BY p.name
ORDER BY num_staff DESC;