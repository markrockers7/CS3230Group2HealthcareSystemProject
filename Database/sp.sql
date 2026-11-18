DELIMITER $

-- Nick
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
-- End Nick

-- Mark
CREATE PROCEDURE GetAppointmentsByPatientId(IN patientId INT)
BEGIN
	SELECT appointment_id, doctor_id, patient_id, appointment_datetime, reason
    FROM Appointment a
    WHERE a.patient_id = patientId;
END $

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

-- End Mark

-- Kirya
CREATE PROCEDURE AddTestToVisit(
    IN p_appointment_id INT,
    IN p_test_code VARCHAR(20),
    IN p_date_performed DATETIME
)
BEGIN
    DECLARE v_final_diagnosis VARCHAR(500);
    DECLARE v_visit_not_found BOOLEAN DEFAULT FALSE;

    DECLARE CONTINUE HANDLER FOR NOT FOUND
        SET v_visit_not_found = TRUE;

SELECT final_diagnosis
INTO v_final_diagnosis
FROM Visit
WHERE appointment_id = p_appointment_id;

IF v_visit_not_found THEN
        SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'The selected visit could not be found.';
    ELSEIF v_final_diagnosis IS NOT NULL THEN
        SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT =
                'This visit has a final diagnosis, so additional tests can''t be ordered.';
    ELSEIF NOT EXISTS (
        SELECT 1
        FROM VisitTest
        WHERE appointment_id = p_appointment_id
          AND test_code = p_test_code
    ) THEN
        INSERT INTO VisitTest
            (appointment_id, test_code, date_performed, result, isAbnormal)
        VALUES
            (p_appointment_id, p_test_code, p_date_performed, NULL, NULL);
END IF;
END $
-- End Kirya

-- Alec
CREATE PROCEDURE get_most_performed_tests_duringdates(
    IN p_startdate DATE,
    IN p_enddate DATE
)
BEGIN
    SELECT
        vt.test_code,
        t.name AS test_name,
        COUNT(*) AS test_count,
        (SELECT COUNT(*)
         FROM VisitTest
         WHERE DATE(date_performed) BETWEEN p_startdate AND p_enddate
        ) AS total_all_tests,
        SUM(CASE WHEN vt.isAbnormal = TRUE THEN 1 ELSE 0 END) AS abnormal_count,
        SUM(CASE WHEN vt.isAbnormal = FALSE THEN 1 ELSE 0 END) AS normal_count
    FROM VisitTest vt
    JOIN Test t ON vt.test_code = t.test_code
    WHERE DATE(vt.date_performed) BETWEEN p_startdate AND p_enddate
    GROUP BY vt.test_code, t.name
    HAVING COUNT(*) >= 2
    ORDER BY test_count DESC, vt.test_code DESC;
END $
-- End Alec
DELIMITER ;