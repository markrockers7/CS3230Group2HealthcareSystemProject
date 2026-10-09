use cs3230f26_g2;

CREATE TABLE Address (
    address_id  INT AUTO_INCREMENT PRIMARY KEY,
    street      VARCHAR(100) NOT NULL,
    city        VARCHAR(50)  NOT NULL,
    zipcode     CHAR(5)      NOT NULL,
    state       CHAR(2)      NOT NULL
);

INSERT INTO Address (address_id, street, city, zipcode, state) VALUES
(1,  '120 Maple Street',    'Carrollton',   '30117', 'GA'),
(2,  '45 Oak Avenue',       'Carrollton',   '30116', 'GA'),
(3,  '782 Pine Road',       'Villa Rica',   '30180', 'GA'),
(4,  '19 Cedar Lane',       'Carrollton',   '30117', 'GA'),
(5,  '300 Birch Drive',     'Bremen',       '30110', 'GA'),
(6,  '56 Elm Court',        'Newnan',       '30263', 'GA'),
(7,  '901 Walnut Way',      'Carrollton',   '30118', 'GA'),
(8,  '14 Willow Street',    'Douglasville', '30134', 'GA'),
(9,  '233 Peachtree Lane',  'Carrollton',   '30117', 'GA'),
(10, '87 Magnolia Drive',   'Villa Rica',   '30180', 'GA'),
(11, '410 Dogwood Circle',  'Temple',       '30179', 'GA'),
(12, '65 Hickory Road',     'Bowdon',       '30108', 'GA'),
(13, '22 Main Street',      'Carrollton',   '30117', 'GA'),
(14, '510 Lakeview Drive',  'Carrollton',   '30116', 'GA');

CREATE TABLE Person (
    person_id     INT AUTO_INCREMENT PRIMARY KEY,
    first_name    VARCHAR(50) NOT NULL,
    last_name     VARCHAR(50) NOT NULL,
    birthdate     DATE        NOT NULL,
    phone_number  CHAR(10)    NOT NULL,
    address_id    INT         NOT NULL,
    CONSTRAINT person_fk_address FOREIGN KEY (address_id) REFERENCES Address(address_id)
);

INSERT INTO Person (person_id, first_name, last_name, birthdate, phone_number, address_id) VALUES
(1,  'Sarah',   'Mitchell',  '1975-04-12', '7705550101', 1),
(2,  'James',   'Carter',    '1968-09-30', '7705550102', 2),
(3,  'Priya',   'Patel',     '1982-01-22', '7705550103', 3),
(4,  'Emily',   'Johnson',   '1990-06-15', '7705550104', 4),
(5,  'Marcus',  'Brown',     '1987-11-03', '6785550105', 5),
(6,  'Ashley',  'Davis',     '1994-02-28', '6785550106', 6),
(7,  'Robert',  'Wilson',    '1979-08-19', '7705550107', 7),
(8,  'Linda',   'Thompson',  '1958-03-07', '4045550108', 8),
(9,  'Michael', 'Garcia',    '1985-12-25', '7705550109', 9),
(10, 'Jessica', 'Martinez',  '1996-07-14', '6785550110', 10),
(11, 'David',   'Lee',       '2015-05-09', '7705550111', 11),
(12, 'Karen',   'White',     '1949-10-31', '7705550112', 12),
(13, 'Jane',    'Doe',       '1992-03-18', '7705550113', 13),
(14, 'John',    'Doe',       '1984-07-04', '7705550114', 14);

CREATE TABLE Account (
    username  VARCHAR(50)  PRIMARY KEY,
    password  VARCHAR(255) NOT NULL,
    type      VARCHAR(20)  NOT NULL
);

INSERT INTO Account (username, password, type) VALUES
('ejohnson', 'nurse123',   'nurse'),
('mbrown',   'nurse456',   'nurse'),
('adavis',   'nurse789',   'nurse'),
('janedoe',  'janedoe123', 'nurse'),
('rwilson',  'admin123',   'administrator'),
('johndoe',  'johndoe123', 'administrator');

CREATE TABLE Doctor (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    person_id  INT NOT NULL,
    CONSTRAINT doctor_fk_person FOREIGN KEY (person_id) REFERENCES Person(person_id),
    CONSTRAINT uq_doctor_person_id UNIQUE (person_id)
);

INSERT INTO Doctor (id, person_id) VALUES
(1, 1),
(2, 2),
(3, 3);

CREATE TABLE Nurse (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    person_id  INT         NOT NULL,
    username   VARCHAR(50) NOT NULL,
    CONSTRAINT nurse_fk_person  FOREIGN KEY (person_id) REFERENCES Person(person_id),
    CONSTRAINT nurse_fk_account FOREIGN KEY (username)  REFERENCES Account(username),
    CONSTRAINT uq_nurse_person_id UNIQUE (person_id),
    CONSTRAINT uq_nurse_username  UNIQUE (username)
);

INSERT INTO Nurse (id, person_id, username) VALUES
(1, 4,  'ejohnson'),
(2, 5,  'mbrown'),
(3, 6,  'adavis'),
(4, 13, 'janedoe');

CREATE TABLE Administrator (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    person_id  INT         NOT NULL,
    username   VARCHAR(50) NOT NULL,
    CONSTRAINT administrator_fk_person  FOREIGN KEY (person_id) REFERENCES Person(person_id),
    CONSTRAINT administrator_fk_account FOREIGN KEY (username)  REFERENCES Account(username),
    CONSTRAINT uq_administrator_person_id UNIQUE (person_id),
    CONSTRAINT uq_administrator_username  UNIQUE (username)
);

INSERT INTO Administrator (id, person_id, username) VALUES
(1, 7,  'rwilson'),
(2, 14, 'johndoe');

CREATE TABLE Patient (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    isActive   BOOLEAN NOT NULL DEFAULT TRUE,
    person_id  INT     NOT NULL,
    CONSTRAINT patient_fk_person FOREIGN KEY (person_id) REFERENCES Person(person_id),
    CONSTRAINT uq_patient_person_id UNIQUE (person_id)
);

INSERT INTO Patient (id, isActive, person_id) VALUES
(1, TRUE,  8),
(2, TRUE,  9),
(3, TRUE,  10),
(4, TRUE,  11),
(5, FALSE, 12);

CREATE TABLE Specialty (
    specialty       VARCHAR(20) PRIMARY KEY,
    specialty_name  VARCHAR(50) NOT NULL
);

INSERT INTO Specialty (specialty, specialty_name) VALUES
('FAM',  'Family Medicine'),
('IM',   'Internal Medicine'),
('CARD', 'Cardiology'),
('PED',  'Pediatrics'),
('DERM', 'Dermatology');

CREATE TABLE DoctorSpecialties (
    doctor_id  INT         NOT NULL,
    specialty  VARCHAR(20) NOT NULL,
    PRIMARY KEY (doctor_id, specialty),
    CONSTRAINT doctorspecialties_fk_doctor    FOREIGN KEY (doctor_id) REFERENCES Doctor(id),
    CONSTRAINT doctorspecialties_fk_specialty FOREIGN KEY (specialty) REFERENCES Specialty(specialty)
);

INSERT INTO DoctorSpecialties (doctor_id, specialty) VALUES
(1, 'FAM'),
(1, 'IM'),
(2, 'CARD'),
(3, 'PED');

CREATE TABLE Appointment (
    appointment_id        INT AUTO_INCREMENT PRIMARY KEY,
    doctor_id             INT          NOT NULL,
    appointment_datetime  DATETIME     NOT NULL,
    patient_id            INT          NOT NULL,
    reason                VARCHAR(255) NOT NULL,
    CONSTRAINT appointment_fk_doctor  FOREIGN KEY (doctor_id)  REFERENCES Doctor(id),
    CONSTRAINT appointment_fk_patient FOREIGN KEY (patient_id) REFERENCES Patient(id)
);

INSERT INTO Appointment (appointment_id, doctor_id, appointment_datetime, patient_id, reason) VALUES
(1, 1, '2026-09-15 09:00:00', 1, 'Annual physical'),
(2, 2, '2026-09-22 10:30:00', 2, 'Chest tightness during exercise'),
(3, 3, '2026-10-01 14:00:00', 4, 'Sore throat and fever'),
(4, 1, '2026-10-05 11:00:00', 3, 'Persistent headaches'),
(5, 1, '2026-10-14 09:00:00', 2, 'Blood pressure check'),
(6, 2, '2026-10-14 13:30:00', 1, 'Cardiology consultation'),
(7, 3, '2026-10-16 10:00:00', 4, 'Follow-up visit'),
(8, 1, '2026-10-20 15:00:00', 3, 'Lab results review');

CREATE TABLE Visit (
    appointment_id     INT          PRIMARY KEY,
    systolic_bp        INT          NOT NULL,
    diastolic_bp       INT          NOT NULL,
    pulse              INT          NOT NULL,
    body_temperature   DECIMAL(4,1) NOT NULL,
    height             DECIMAL(5,2) NOT NULL,
    weight             DECIMAL(5,2) NOT NULL,
    symptoms           VARCHAR(500) NOT NULL,
    initial_diagnosis  VARCHAR(500),
    final_diagnosis    VARCHAR(500),
    CONSTRAINT visit_fk_appointment FOREIGN KEY (appointment_id) REFERENCES Appointment(appointment_id)
);

INSERT INTO Visit (appointment_id, systolic_bp, diastolic_bp, pulse, body_temperature, height, weight, symptoms, initial_diagnosis, final_diagnosis) VALUES
(1, 128, 82, 72, 98.6,  64.00, 172.50, 'No complaints; routine annual exam',              'Healthy adult',          'High cholesterol'),
(2, 142, 91, 88, 98.4,  70.50, 210.00, 'Chest tightness during exercise',                 'Possible hypertension',  'Stage 2 hypertension'),
(3, 108, 68, 96, 101.8, 56.00, 82.40,  'Sore throat, fever, difficulty swallowing',       'Suspected strep throat', 'Strep throat'),
(4, 118, 76, 70, 98.7,  65.25, 140.00, 'Headaches for two weeks, worse in the afternoon', 'Tension headache',       NULL);

CREATE TABLE Test (
    test_code            VARCHAR(20)   PRIMARY KEY,
    name                 VARCHAR(100)  NOT NULL,
    low_value            DECIMAL(10,2),
    high_value           DECIMAL(10,2),
    unit_of_measurement  VARCHAR(20)
);

INSERT INTO Test (test_code, name, low_value, high_value, unit_of_measurement) VALUES
('GLU',   'Glucose (fasting)', 70.00, 99.00,  'mg/dL'),
('A1C',   'Hemoglobin A1C',    4.00,  5.60,   '%'),
('CHOL',  'Total Cholesterol', 0.00,  199.00, 'mg/dL'),
('HGB',   'Hemoglobin',        12.00, 17.50,  'g/dL'),
('K',     'Potassium',         3.50,  5.00,   'mmol/L'),
('STREP', 'Rapid Strep Test',  NULL,  NULL,   NULL);

CREATE TABLE VisitTest (
    appointment_id  INT         NOT NULL,
    test_code       VARCHAR(20) NOT NULL,
    date_performed  DATETIME,
    result          VARCHAR(100),
    isAbnormal      BOOLEAN,
    PRIMARY KEY (appointment_id, test_code),
    CONSTRAINT visittest_fk_visit FOREIGN KEY (appointment_id) REFERENCES Visit(appointment_id),
    CONSTRAINT visittest_fk_test  FOREIGN KEY (test_code)      REFERENCES Test(test_code)
);

INSERT INTO VisitTest (appointment_id, test_code, date_performed, result, isAbnormal) VALUES
(1, 'GLU',   '2026-09-15 09:30:00', '92',       FALSE),
(1, 'CHOL',  '2026-09-15 09:30:00', '225',      TRUE),
(1, 'A1C',   '2026-09-15 09:30:00', '5.4',      FALSE),
(2, 'K',     '2026-09-22 11:00:00', '4.2',      FALSE),
(2, 'CHOL',  '2026-09-22 11:00:00', '198',      FALSE),
(3, 'STREP', '2026-10-01 14:20:00', 'Positive', TRUE),
(4, 'HGB',   '2026-10-05 11:30:00', '13.1',     FALSE),
(4, 'GLU',   NULL,                  NULL,       NULL);