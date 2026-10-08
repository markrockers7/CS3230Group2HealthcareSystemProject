use cs3230f26_g2; 

CREATE TABLE Address (
    address_id  INT AUTO_INCREMENT PRIMARY KEY,
    street      VARCHAR(100) NOT NULL,
    city        VARCHAR(50)  NOT NULL,
    zipcode     CHAR(5)      NOT NULL,
    state       CHAR(2)      NOT NULL
);

CREATE TABLE Person (
    person_id     INT AUTO_INCREMENT PRIMARY KEY,
    first_name    VARCHAR(50) NOT NULL,
    last_name     VARCHAR(50) NOT NULL,
    birthdate     DATE        NOT NULL,
    phone_number  CHAR(10)    NOT NULL,
    address_id    INT         NOT NULL,
    CONSTRAINT person_fk_address FOREIGN KEY (address_id) REFERENCES Address(address_id)
);

CREATE TABLE Account (
    username  VARCHAR(50)  PRIMARY KEY,
    password  VARCHAR(255) NOT NULL,
    type      VARCHAR(20)  NOT NULL
);

CREATE TABLE Doctor (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    person_id  INT NOT NULL,
    CONSTRAINT doctor_fk_person FOREIGN KEY (person_id) REFERENCES Person(person_id),
    CONSTRAINT uq_doctor_person_id UNIQUE (person_id)
);

CREATE TABLE Nurse (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    person_id  INT         NOT NULL,
    username   VARCHAR(50) NOT NULL,
    CONSTRAINT nurse_fk_person  FOREIGN KEY (person_id) REFERENCES Person(person_id),
    CONSTRAINT nurse_fk_account FOREIGN KEY (username)  REFERENCES Account(username),
    CONSTRAINT uq_nurse_person_id UNIQUE (person_id),
    CONSTRAINT uq_nurse_username  UNIQUE (username)
);

CREATE TABLE Administrator (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    person_id  INT         NOT NULL,
    username   VARCHAR(50) NOT NULL,
    CONSTRAINT administrator_fk_person  FOREIGN KEY (person_id) REFERENCES Person(person_id),
    CONSTRAINT administrator_fk_account FOREIGN KEY (username)  REFERENCES Account(username),
    CONSTRAINT uq_administrator_person_id UNIQUE (person_id),
    CONSTRAINT uq_administrator_username  UNIQUE (username)
);

CREATE TABLE Patient (
    id         INT AUTO_INCREMENT PRIMARY KEY,
    isActive   BOOLEAN NOT NULL DEFAULT TRUE,
    person_id  INT     NOT NULL,
    CONSTRAINT patient_fk_person FOREIGN KEY (person_id) REFERENCES Person(person_id),
    CONSTRAINT uq_patient_person_id UNIQUE (person_id)
);

CREATE TABLE Specialty (
    specialty       VARCHAR(20) PRIMARY KEY,
    specialty_name  VARCHAR(50) NOT NULL
);

CREATE TABLE DoctorSpecialties (
    doctor_id  INT         NOT NULL,
    specialty  VARCHAR(20) NOT NULL,
    PRIMARY KEY (doctor_id, specialty),
    CONSTRAINT doctorspecialties_fk_doctor    FOREIGN KEY (doctor_id) REFERENCES Doctor(id),
    CONSTRAINT doctorspecialties_fk_specialty FOREIGN KEY (specialty) REFERENCES Specialty(specialty)
);

CREATE TABLE Appointment (
    appointment_id  		INT AUTO_INCREMENT PRIMARY KEY,
    doctor_id       		INT          NOT NULL,
    appointment_datetime    DATETIME     NOT NULL,
    patient_id     			INT          NOT NULL,
    reason          		VARCHAR(255) NOT NULL,
    CONSTRAINT appointment_fk_doctor  FOREIGN KEY (doctor_id)  REFERENCES Doctor(id),
    CONSTRAINT appointment_fk_patient FOREIGN KEY (patient_id) REFERENCES Patient(id)
);

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

CREATE TABLE Test (
    test_code            VARCHAR(20)   PRIMARY KEY,
    name                 VARCHAR(100)  NOT NULL,
    low_value            DECIMAL(10,2),
    high_value           DECIMAL(10,2),
    unit_of_measurement  VARCHAR(20)
);

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