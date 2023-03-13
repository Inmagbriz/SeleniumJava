using OAF.A3.Infra.Test;
using OAF.A3.Infra.Test.A3InfraSteps;
using OAF.A3.Retail.Lib.API.Actions;
using OAF.Common.Test.Common.Utils;
using OAF.Common.Test.Common.Utils.Models;
using System;

namespace OAF.A3.Infra.DataObjectFactories
{
    class PatientFactory
    {
        public static CommonPatientDataMethods PatientDataMethods { get; set; }

        public static void CreatePatient(APIContext context, int? age=null, string lang=null)
        {
            PatientDataMethods = new CommonPatientDataMethods(context);

            Patient randomer = _generateRandomPatient();
            if (age.HasValue)
            {
                randomer.DateOfBirth = DateTimeUtils.GenerateDateXYearsAgo(age.Value);
            }
            if (!string.IsNullOrEmpty(lang))
            {
                randomer.Language = lang;
            }

            _createPatientAndStoreId(randomer, context);
        }

        public static void CreatePatientWithUniqueName(APIContext context)
        {
            A3RetailAPIPatientSearchActions SearchPatientDriver
                = (A3RetailAPIPatientSearchActions)context.DriverFactory.GetDriver<A3RetailAPIPatientSearchActions>();

            bool hasUniqueName = false;
            Patient randomer = new Patient();

            PatientDataMethods = new CommonPatientDataMethods(context);

            while (!hasUniqueName)
            {
                randomer = _generateRandomPatient();
                SearchPatientDriver.SearchPatients($"{randomer.FirstName} {randomer.LastName}");
                if (SearchPatientDriver.DataNodeCount() == 0)
                {
                    hasUniqueName = true;
                }
                else
                {
                    Console.WriteLine("Patient already exists with that name");
                }
            }
            _createPatientAndStoreId(randomer, context);
        }

        internal static Patient GenerateRandomPatientDetails(APIContext context)
        {
            PatientDataMethods = new CommonPatientDataMethods(context);
            Patient patientDetails = _generateRandomPatient();
            return PatientDataMethods.DoPatientLookups(patientDetails);
        }

        private static Patient _generateRandomPatient()
        {
            RandomA3PatientGenerator rand = new RandomA3PatientGenerator();
            Patient randomer = rand.GenerateRandomPatient();
            Console.WriteLine($"Generated random patient: {randomer}");
            return randomer;
        }

        private static void _createPatientAndStoreId(Patient patient, APIContext _context)
        {
            A3RetailAPIPostPatientWithFeedbackActions CreatePatientDriver
                = (A3RetailAPIPostPatientWithFeedbackActions)_context.DriverFactory.GetDriver<A3RetailAPIPostPatientWithFeedbackActions>();

            _context.patientDataObjects.patientObj = PatientDataMethods.DoPatientLookups(patient);
            _context.PatientName = patient.FirstName + " " + patient.LastName;
            _context.PatientDateOfBirth = patient.DateOfBirth;
            _context.patientDataObjects.account = new CommonPatientAccount { AccountType = 1, CreditLimit = 200, LastStatementDate = DateTime.Today };
            CreatePatientDriver.CreatePatientWithAddressAndContacts(testPatient: _context.patientDataObjects.patientObj,
                                                                    _account: _context.patientDataObjects.account,
                                                                    contacts: _context.patientDataObjects.patientContactListObj);

            _context.SetCurrentDriver(CreatePatientDriver.GetType());

            try
            {
                _context.PatientId = CreatePatientDriver.GetPatientId();
                _context.PatientAccountId = CreatePatientDriver.CreatedPatientAccountId();
                if (_context.patientDataObjects.patientContactListObj.Count > 0)
                {
                    var allContacts = CreatePatientDriver.CreatedPatientContactsIdsReferences();
                    foreach (var contact in _context.patientDataObjects.patientContactListObj)
                    {
                        contact.Id = _context.ReverseLookupGuid(allContacts, contact.ContactReference);
                        contact.EntityContactId = CreatePatientDriver.ContactEntityIdForContactId(contact.Id);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Could not retrieve patient details, perhaps create failed");
            }
            Console.WriteLine($"Using randomly created patient with id {_context.PatientId}");
        }

    }
}
