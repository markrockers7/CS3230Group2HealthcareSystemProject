using HealthcareSystemProjectCS3230.DAL;
using HealthcareSystemProjectCS3230.model;
using System.Globalization;

namespace HealthcareSystemProjectCS3230.controler;

public class AppointmentController
{
        private AppointmentsDAL appointmentsDAL = new AppointmentsDAL();
        private DoctorDAL doctorDAL = new DoctorDAL();
        private PersonDAL personDAL = new PersonDAL();
        private TestDAL testDAL = new TestDAL();

    /// <summary>
    /// Retrieves a list of all doctors in the system.
    /// </summary>
    /// <returns>List of Doctor objects</returns>
    public List<Doctor> GetDoctors()
    {
        return doctorDAL.GetAllDoctors();
    }

    /// <summary>
    /// Retrieves a list of all doctors in the system, along with their first and last names.
    /// </summary>
    /// <returns>List of DoctorView objects, which contain the doctor's ID, first name, last name, and full name.</returns>
    public List<DoctorView> GetDoctorsWithNames()
    {
        var doctorViews = new List<DoctorView>();

        foreach (var doctor in GetDoctors())
        {
            var person = personDAL.GetPersonByID(doctor.personId);
            if (person != null)
            {
                doctorViews.Add(new DoctorView
                {
                    DoctorId = doctor.id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    FullName = $"{person.FirstName} {person.LastName}"
                });
            }
        }

        return doctorViews;
    }

    /// <summary>
    /// Retrieves a list of all tests in the system.
    /// </summary>
    /// <returns>List of Test objects</returns>
    public List<Test> GetTests()
    {
        return testDAL.GetTests();
    }

    /// <summary>
    /// Gets a patient's visits that have at least one ordered test, with the doctor's name.
    /// </summary>
    /// <param name="patientId">The ID of the patient</param>
    /// <returns>List of VisitSummary objects, newest first</returns>
    public List<VisitSummary> GetVisitsWithTestsForPatient(int patientId)
    {
        return testDAL.GetVisitSummariesForPatient(patientId);
    }

    /// <summary>
    /// Gets the tests ordered for a visit, with normal ranges and any results entered so far.
    /// </summary>
    /// <param name="appointmentId">The ID of the visit (appointment)</param>
    /// <returns>List of VisitTestResult objects</returns>

    public List<VisitTestResult> GetVisitTestResults(int appointmentId)
    {
        return testDAL.GetVisitTestResults(appointmentId);
    }

    /// <summary>
    /// Works out whether a test result is abnormal.
    /// If the test has a low and/or high value, the result must be a number and is normal only if it's within [low, high].
    /// If the test has no low or high value, the nurse's manual choice is used.
    /// </summary>
    /// <param name="test">The ordered test</param>
    /// <param name="result">The result the nurse entered</param>
    /// <param name="manualAbnormal">The nurse's choice, used only when the test has no range</param>
    /// <returns>true if the result is abnormal</returns>
    public bool DetermineIsAbnormal(VisitTestResult test, string result, bool manualAbnormal)
    {
        if (!test.HasNormalRange)
        {
            return manualAbnormal;
        }

        if (!decimal.TryParse(result.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal value))
        {
            throw new ArgumentException($"{test.TestName} has a normal range, so the result must be a number.");
        }

        bool belowRange = test.LowValue.HasValue && value < test.LowValue.Value;
        bool aboveRange = test.HighValue.HasValue && value > test.HighValue.Value;
        return belowRange || aboveRange;
    }

    /// <summary>
    /// Validates and saves the result of one ordered test.
    /// </summary>
    /// <param name="visit">The visit the test belongs to</param>
    /// <param name="test">The ordered test</param>
    /// <param name="datePerformed">When the test was performed</param>
    /// <param name="result">The result the nurse entered</param>
    /// <param name="manualAbnormal">The nurse's abnormal choice, used only when the test has no range</param>
    /// <exception cref="ArgumentException">Thrown when the visit is finalized or the input is invalid.</exception>
    public void SaveTestResult(VisitSummary visit, VisitTestResult test, DateTime datePerformed, string result, bool manualAbnormal)
    {
        if (visit.IsLocked)
        {
            throw new ArgumentException("This visit has a final diagnosis, so its test results can't be changed.");
        }

        if (string.IsNullOrWhiteSpace(result))
        {
            throw new ArgumentException("Please enter the test result.");
        }

       

        if (datePerformed.Date < visit.AppointmentDateTime.Date)
        {
            throw new ArgumentException("The test can't be performed before the visit date.");
        }

        bool isAbnormal = DetermineIsAbnormal(test, result, manualAbnormal);

        bool saved = testDAL.SaveTestResult(test.AppointmentId, test.TestCode, datePerformed, result.Trim(), isAbnormal);
        if (!saved)
        {
            throw new InvalidOperationException("The result could not be saved. The visit may have just been finalized.");
        }
    }

    /// <summary>
    /// Saves the visit and any selected tests. Database access remains in the DAL.
    /// </summary>
    /// <param name="appointmentId">The ID of the appointment</param>
    /// <param name="systolic">The systolic blood pressure</param>
    /// <param name="diastolic">The diastolic blood pressure</param>
    /// <param name="pulse">The pulse rate</param>
    /// <param name="bodyTemperature">The body temperature</param>
    /// <param name="height">The height</param>
    /// <param name="weight">The weight</param>
    /// <param name="symptoms">The symptoms</param>
    /// <param name="initialDiagnosis">The initial diagnosis</param>
    /// <param name="selectedTests">The selected tests</param>
    public void SaveVisitAndTests(
        int appointmentId,
        int systolic,
        int diastolic,
        int pulse,
        decimal bodyTemperature,
        decimal height,
        decimal weight,
        string symptoms,
        string? initialDiagnosis,
        string? finalDiagnosis,
        IReadOnlyCollection<Test> selectedTests)
    {
        if (appointmentId <= 0) throw new ArgumentException("Please select a valid appointment.");

        if (systolic <= 0 || diastolic <= 0 || pulse <= 0)
            throw new ArgumentException("Systolic, diastolic, and pulse must be greater than zero.");

        if (bodyTemperature <= 0 || height <= 0 || weight <= 0)
            throw new ArgumentException("Body temperature, height, and weight must be greater than zero.");

        if (string.IsNullOrWhiteSpace(symptoms)) throw new ArgumentException("Please enter the patient's symptoms.");

        if (selectedTests == null) throw new ArgumentNullException(nameof(selectedTests));

        testDAL.SaveVisitAndTests(
            appointmentId,
            systolic,
            diastolic,
            pulse,
            bodyTemperature,
            height,
            weight,
            symptoms.Trim(),
            initialDiagnosis,
            finalDiagnosis,
            selectedTests);
    }

    /// <summary>
    /// Retrieves a specific appointment by its ID.
    /// </summary>
    /// <param name="appointmentId">The ID of the appointment to retrieve</param>
    /// <returns>The Appointment object if found, null otherwise</returns>
    public Appointment? GetAppointmentById(int appointmentId)
    {
        return appointmentsDAL.GetAppointmentById(appointmentId);
    }

    /// <summary>
    /// Checks if an appointment can be edited based on its date and time.
    /// </summary>
    /// <param name="appointmentDateTime">The date and time of the appointment to check</param>
    /// <returns>true if the appointment can be edited, false otherwise</returns>
    public bool CanEditAppointment(DateTime appointmentDateTime)
    {
        return DateTime.Today < appointmentDateTime.Date;
    }
        public List<AppointmentSummary> GetAppointmentsForPatient(int patientId)
        {
            return appointmentsDAL.GetAppointmentsForPatient(patientId, DateTime.Today);
        }

    /// <summary>
    /// Retrieves a list of available appointment slots for a specific doctor on a specific date.
    /// </summary>
    /// <param name="doctorId">The ID of the doctor</param>
    /// <param name="date">The date to check for available slots</param>
    /// <param name="excludeAppointmentId">Optional parameter to exclude a specific appointment from the check (useful when updating an appointment)</param>
    /// <returns>List of available TimeSpan slots</returns>
    public List<TimeSpan> GetAvailableSlots(int doctorId, DateTime date, int? excludeAppointmentId = null)
    {
            List<TimeSpan> allSlots = AppointmentSlotRules.GetDailySlots();
            HashSet<TimeSpan> bookedSlots = appointmentsDAL
            .GetBookedSlotsForDoctorDate(doctorId, date, excludeAppointmentId)
            .ToHashSet();

        return allSlots.Where(slot => !bookedSlots.Contains(slot)).ToList();
    }
    /// <summary>
    /// Books a new appointment for a patient with a specific doctor at a specific date and time.
    /// </summary>
    /// <param name="patientId">The ID of the patient</param>
    /// <param name="doctorId">The ID of the doctor</param>
    /// <param name="appointmentDateTime">The date and time of the appointment</param>
    /// <param name="reason">The reason for the appointment</param>
    public void BookAppointment(int patientId, int doctorId, DateTime appointmentDateTime, string reason)
    {
        ValidateAppointment(patientId, appointmentDateTime, reason);
        EnsureSlotIsFree(doctorId, appointmentDateTime);

            bool saved = appointmentsDAL.AddAppointment(patientId, appointmentDateTime, doctorId, reason.Trim());
        if (!saved)
        {
            throw new InvalidOperationException("The appointment could not be saved. The time may have just been booked. Please choose another time.");
        }
    }
    /// <summary>
    /// Updates an existing appointment with new details.
    /// </summary>
    /// <param name="appointmentId">The ID of the appointment to update</param>
    /// <param name="patientId">The new patient ID</param>
    /// <param name="doctorId">The new doctor ID</param>
    /// <param name="appointmentDateTime">The new date and time of the appointment</param>
    /// <param name="reason">The new reason for the appointment</param>
    public void UpdateAppointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDateTime, string reason)
    {
            Appointment? currentAppointment = appointmentsDAL.GetAppointmentById(appointmentId);
            if (currentAppointment == null)
            {
                throw new ArgumentException("The appointment could not be found.");
            }

            if (!CanEditAppointment(currentAppointment.DateTime))
            {
                throw new ArgumentException("This appointment can no longer be edited.");
            }

            ValidateAppointment(patientId, appointmentDateTime, reason);
            EnsureSlotIsFree(doctorId, appointmentDateTime, appointmentId);

            bool saved = appointmentsDAL.UpdateAppointment(appointmentId, patientId, appointmentDateTime, doctorId, reason.Trim());
            if (!saved)
            {
                throw new InvalidOperationException("The appointment could not be saved. The time may have just been booked. Please choose another time.");
            }
    }

    /// <summary>
    /// Gets a list of appointment views for a specific patient, excluding past appointments and those with scheduled visits.
    /// </summary>
    /// <param name="patientId">The ID of the patient</param>
    /// <exception cref="ArgumentException">Thrown when no appointments are found for the given patient ID.</exception>
    /// <returns>A list of appointment views for the specified patient</returns>
    public List<AppointmentView> GetAppointmentsByPatientId(int patientId)
    {
        var appointments = appointmentsDAL.GetAppointmentsByPatientId(patientId);
        if (appointments == null || appointments.Count == 0)
        {
            throw new ArgumentException("No appointments found for the given patient ID.");
        }
        var appointmentViews = new List<AppointmentView>();
        var doctorNames = GetDoctorsWithNames();
        foreach (var appt in appointments)
        {
            var appointmentView = new AppointmentView
            {
                AppointmentId = appt.AppointmentId,
                PatientId = appt.PatientId,
                DoctorId = appt.DoctorId,
                DateTime = appt.DateTime,
                Reason = appt.Reason,
                DoctorName = doctorNames.FirstOrDefault(d => d.DoctorId == appt.DoctorId)?.FullName ?? "Unknown"
            };
            appointmentViews.Add(appointmentView);
        }
        return appointmentViews;
    }

    /// <summary>
    /// Determines whether every ordered test in a visit has a nonblank result.
    /// If the visit has no ordered tests, this returns true because no test lacks a result.
    /// </summary>
    /// <param name="appointmentId">The ID of the appointment associated with the visit.</param>
    /// <returns>True if every retrieved test has a nonblank result; otherwise false.</returns>
    public bool DoAllTestsInVisitHaveAResult(int appointmentId)
    {
        var allTests = testDAL.GetVisitTestResults(appointmentId);
        return allTests.All(test => !string.IsNullOrWhiteSpace(test.Result));
    }

    private void EnsureSlotIsFree(int doctorId, DateTime appointmentDateTime, int? excludeAppointmentId = null)
    {
        var freeSlots = GetAvailableSlots(doctorId, appointmentDateTime.Date, excludeAppointmentId);
        if (!freeSlots.Contains(appointmentDateTime.TimeOfDay))
        {
            throw new ArgumentException("That time was just booked. Please choose another time.");
        }
    }

    private static void ValidateAppointment(int patientId, DateTime appointmentDateTime, string reason)
    {
            if (patientId <= 0)
            {
                throw new ArgumentException("Please enter a valid patient ID.");
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                throw new ArgumentException("Please enter a reason for the visit.");
            }

            if (appointmentDateTime < DateTime.Now)
            {
                throw new ArgumentException("Appointments can't be booked in the past.");
            }

            if (!AppointmentSlotRules.IsValidSlotDateTime(appointmentDateTime))
            {
                throw new ArgumentException(
                    "Appointment times must be in 15-minute slots between 8:00 AM and 4:45 PM.");
            }
    }

    /// <summary>
    /// Gets all the visits that either have no tests or all of the tests are completed for a specific patient.
    /// </summary>
    /// <param name="patientId">The ID of the patient</param>
    /// <returns>A list of Visit objects that meet the criteria</returns>
    public List<Visit> GetVisitsWithCompleteOrNoTestsForPatient(int patientId)
    {
        return testDAL.GetVisitsWithCompleteOrNoVisitTests(patientId);
    }

    /// <summary>
    /// Gets the name of the doctor associated with a visit.
    /// </summary>
    /// <param name="visitId">The ID of the visit</param>
    /// <returns>The name of the doctor associated with the visit</returns>
    public string GetDoctorNameFromVisit(int visitId)
    {
        var doctors = GetDoctorsWithNames();
        var appointment = GetAppointmentById(visitId);
        if (appointment == null)
        {
            throw new ArgumentException("Appointment not found.");
        }
        var scheduledDoctor = doctors.FirstOrDefault(doctor => doctor.DoctorId == appointment.DoctorId);
        return scheduledDoctor == null ? throw new ArgumentException("Doctor not found.") : scheduledDoctor.FullName;
    }

    /// <summary>
    /// Updates the Final Diagnosis for a visit.
    /// </summary>
    /// <param name="visitId">The ID of the visit to update</param>
    /// <param name="finalDiagnosis">The new final diagnosis</param>
    /// <returns>true if the update was successful, false otherwise</returns>
    public bool UpdateFinalDiagnosis(string finalDiagnosis, int visitId)
    {
        return testDAL.GetVisitSummariesForPatient(patientId, onlyWithTests: false);
    }

     /// <summary>
     /// Gets every visit for a patient and its associated tests.
     /// </summary>
     /// <param name="patientId">The ID of the patient.</param>
     /// <returns>
     /// A dictionary mapping each visit to its test results. Visits without ordered tests have
     /// an empty list, and visits are represented by their <see cref="VisitSummary"/>.
     /// </returns>
    public Dictionary<VisitSummary, List<VisitTestResult>> GetAllVisitsAndTheirTestsForPatient(int patientId)
    {
        return testDAL.GetAllVisitsAndTheirTestsForPatient(patientId);
    }

    /// <summary>
    /// Gets one visit's checkup details and diagnoses.
    /// </summary>
    /// <param name="appointmentId">The ID of the visit (appointment)</param>
    /// <returns>The Visit, or null if it doesn't exist</returns>
    public Visit? GetVisitById(int appointmentId)
    {
        return testDAL.GetVisitById(appointmentId);
    }
}

/// <summary>
/// Represents a view model for an appointment, including the doctor's name for display purposes
/// </summary>
public class AppointmentView
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public DateTime DateTime { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
}