# CS3230Group2HealthcareSystemProject

# Accounts to Login with
## Nurses
### Ashley Davis
Username: adavis
Password: nurse789
### Emily Johnson
Username: ejohnson
Password: nurse123

## Administrators
###
Username: rwilson
Password: admin123
###
Username: johndoe
Password: johndoe123


## Stored Procedures

### By Nick Samples:
DROP PROCEDURE IF EXISTS GetAppointmentsForPatient;

DELIMITER $

CREATE PROCEDURE GetAppointmentsForPatient(IN p_patient_id INT,IN p_today DATE)
BEGIN
    SELECT
        a.appointment_id,
        a.appointment_datetime,
        a.doctor_id,
        CONCAT(p.first_name, ' ', p.last_name) AS doctor_name,
        a.reason,
        (DATE(a.appointment_datetime) > p_today) AS can_edit
    FROM Appointment a
    JOIN Doctor d ON d.id = a.doctor_id
    JOIN Person p ON p.person_id = d.person_id
    WHERE a.patient_id = p_patient_id
    ORDER BY a.appointment_datetime DESC;
END $

DELIMITER ;

### By Mark Rockers:

DELIMITER $

CREATE PROCEDURE InsertIntoAddress(p_street varchar(100), p_city varchar(50), p_zipcode char(5), p_state char(2))
BEGIN
	INSERT INTO address(street, city, zipcode, state) VALUES (p_street, p_city, p_zipcode, p_state);
END $
    
CREATE PROCEDURE InsertIntoPerson(p_first_name varchar(50), p_last_name varchar(50), p_birthdate date, p_phone_number char(10), p_address_id INT, p_gender char(1))
BEGIN
	INSERT INTO person(first_name, last_name, birthdate, phone_number, address_id, gender) VALUES (p_first_name, p_last_name, p_birthdate, p_phone_number, p_address_id, p_gender);
END $
    
CREATE PROCEDURE InsertIntoPatient(p_is_active tinyint, p_person_id INT)
BEGIN
	INSERT INTO patient(isActive, person_id) VALUES (p_is_active, p_person_id);
END $
    
CREATE PROCEDURE AddPatient(
p_street varchar(100), p_city varchar(50), p_zipcode char(5), p_state char(2),
p_first_name varchar(50), p_last_name varchar(50), p_birthdate date, p_phone_number char(10), p_gender char(1),
p_is_active tinyint
)
BEGIN
DECLARE last_address_id INT;
DECLARE last_person_id INT;
DECLARE EXIT HANDLER FOR SQLEXCEPTION
BEGIN
	ROLLBACK;
	RESIGNAL;
END;
	START TRANSACTION;
    CALL InsertIntoAddress(p_street, p_city, p_zipcode, p_state);
	SET last_address_id = LAST_INSERT_ID();
    CALL InsertIntoPerson(p_first_name, p_last_name, p_birthdate, p_phone_number, last_address_id, p_gender);
    SET last_person_id = LAST_INSERT_ID();
    CALL InsertIntoPatient(p_is_active, last_person_id);
    COMMIT;
END $

### By Alec Neal:

### By Kirya Duncan:
