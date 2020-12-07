using medicloud.emr.api.DataContextRepo;
using medicloud.emr.api.DTOs;
using medicloud.emr.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicloud.emr.api.Services
{
    public interface IPatientServices
    {
        string addNewPatient(PatientDTO patient);
        IEnumerable<Patient> isPatientExist(string firstname, string lastname, string dob, string mobilePhone, string email, string othername="", string mothername="");
        string AddDepentdantData(string familyNumber, PatientDTO patient);

        Task<bool> updatePatientInfo(Patient patient);
    }


    public class PatientService : IPatientServices
    {
        // this is class is for logging and other purposes

        private IPatientRepo _repo;
        public PatientService()
        {
            _repo = new PatientRepo();
        }
        public string addNewPatient(PatientDTO patient)
        {
            try
            {
                var patientModelObject = (Patient)patient;
                string result = _repo.AddPatient(patientModelObject);

                // to implement logging Later
                return result;

            }
            catch (Exception es)
            {

                throw es;
            }
        }


        public string AddDepentdantData(string familyNumber, PatientDTO patient)
        {
            try
            {
                var patientModelObject = (Patient)patient;
                patientModelObject.FamilyNumber = familyNumber;
                string result = _repo.AddDependantPatient(patientModelObject);

                // to implement logging Later
                return result;

            }
            catch (Exception es)
            {

                throw es;
            }
        }

        public IEnumerable<Patient> isPatientExist(string firstname, string lastname, string dob, string mobilePhone, string email, string othername = "", string mothername = "")
        {
            try
            {
                return _repo.IsPatientRecordExist(firstname, lastname, dob, mobilePhone, email, othername, mothername).Result;

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> updatePatientInfo(Patient patient)
        {
            return await Task.Factory.StartNew(() => _repo.UpdatePatient(patient));
        }
    }
}
