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

### By Alec Neal:

### By Kirya Duncan:
