using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicloud.emr.api.Data;
using medicloud.emr.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace medicloud.emr.api.DataContextRepo
{
    public interface IPatientRepo
    {
        Task<IQueryable<Patient>> SearchByValue(string searchValue);
        void Close();
        string AddPatient(Patient patient);
        Task<IEnumerable<Patient>> IsPatientRecordExist(string firstname, string lastname, string dob, string mobilePhone, string email, string othername = "", string mothername = "");
        string AddDependantPatient(Patient patient);
        Task<IEnumerable<Patient>> SearchForDependeant(string filter, string filterValue);
        bool SaveRegistrationLink(string link);
        bool getRegistrationLinkStatus(string link);
        string registerPatientFromLink(string link, Patient patientToUpdate);
        bool UpdatePatient(Patient patient);
        Task<IEnumerable<Patient>> searchForPatientToUpdate(string filter, string filterValue);
    }

    public class PatientRepo : IPatientRepo
    {
        private IDataContextRepo<Patient> _db;
        private DataContext ctx;

        public PatientRepo()
        {
            _db = new DataContextRepo<Patient>();
            ctx = new DataContext();
        }

        private string generatePatientId()
        {
            string _query = "[patient_reg_no_generate]";
            _db.ExecutStoredProcedure(_query, out var patientId);

            return patientId;
           

        }

        private string generateFamilyNumber()
        {
            string _query = "[patient_fmaily_no_generate]";
            _db.ExecutStoredProcedure(_query, out var familyNumber);
            return familyNumber;
        }

        public Task<IEnumerable<Patient>> IsPatientRecordExist(string firstname, string lastname, string dob, string mobilePhone, string email, string othername = "", string mothername = "")
        {
            //string formattedQuery = $"'%{firstname}%'";

            Task<IEnumerable<Patient>> searchForRecord = new Task<IEnumerable<Patient>>(() =>
            {
                string _query = $"select * from [Patient] where (firstname = '{firstname}' and lastname = '{lastname}') or (firstname = '{firstname}' and lastname = '{lastname}' and mobilephone = '{mobilePhone}') or (firstname = '{firstname}' and lastname = '{lastname}' and dob = '{dob}' and mobilephone = '{mobilePhone}') or (othername = '{othername}' and firstname = '{firstname}' and lastname = '{lastname}' and dob = '{dob}' and mobilephone = '{mobilePhone}') or ( mothername = '{mothername}' and othername = '{othername}' and firstname = '{firstname}' and lastname = '{lastname}' and dob = '{dob}' and mobilephone = '{mobilePhone}')";
                var found = _db.ExecuteRawSql(_query);

                return found.AsEnumerable();
            });
            searchForRecord.Start();
            return searchForRecord;
            
        }
        public Task<IQueryable<Patient>> SearchByValue(string searchValue)
        {
            string formattedQuery = $"'%{searchValue}%'";
            string query = $"select * from [Patient] where (firstname is not null and firstname like {formattedQuery} or patientid is not null and patientid like {formattedQuery} or lastname is not null and lastname like {formattedQuery} or othername is not null and othername like {formattedQuery} or address is not null and address like {formattedQuery} or mothername is not null and mothername like {formattedQuery} or mobilephone is not null and mobilephone like {formattedQuery} or email is not null and email like {formattedQuery} or employername is not null and employername like {formattedQuery})";
            //string query = $"select * from [Patient] where firstname like %" + searchValue + "%";
            // $"select * from [Patient] where firstname like {formattedQuery}"
            //var result = _db.ExecuteRawSql(query);
            var result = ctx.Patient.FromSqlRaw(query).Include(x => x.Gender);

            return Task.FromResult<IQueryable<Patient>>(result);
        }

        //public Task<IQueryable<Patient>> SearchByValue(string searchValue)
        //{

        //    Task<IQueryable<Patient>> searchTask = new Task<IQueryable<Patient>>(() =>
        //    {
        //        //var getAll = _db.GetAll();

        //        // provided some data are not null
        //        var returnedDataFromSearch = _db.GetAll(x=>x.Mobilephone.Contains(searchValue) 
        //       || x.Lastname.Contains(searchValue) || x.Guardianname.Contains(searchValue) || x.Employername.Contains(searchValue)
        //       || x.Email.Contains(searchValue) || x.Patientid.Contains(searchValue) || (x.Lastname + " " + x.Firstname + " " + x.Othername).Contains(searchValue)
        //      );


        //        // var returnedDataFromSearch = _db.GetAll(x => x.Address.Contains(searchValue) ||  
        //        //x.Mobilephone.Contains(searchValue) || x.Mothername.Contains(searchValue) || x.Nokphonenumber.Contains(searchValue)
        //        //|| x.State.Statename.Contains(searchValue) || x.Othername.Contains(searchValue) || x.Firstname.Contains(searchValue)
        //        //|| x.Lastname.Contains(searchValue) || x.Guardianname.Contains(searchValue) || x.Employername.Contains(searchValue)
        //        //|| x.Email.Contains(searchValue) || x.Accountcategory.Contains(searchValue) || x.City.Contains(searchValue) ||
        //        //x.Gender.Gendername.Contains(searchValue));

        //        var listOfReturnedData = new List<Patient>();

        //        ////    // for perfomance reason this will not be the best...i think there is other way
        //        //foreach (Patient currentPatient in getAll)
        //        //{
        //        //    if ((currentPatient.Mobilephone != null && currentPatient.Mobilephone.Contains(searchValue))

        //        //        || (currentPatient.Email != null && currentPatient.Email.Contains(searchValue))
        //        //        || (currentPatient.Accountcategory != null && currentPatient.Accountcategory.Contains(searchValue))
        //        //        || (currentPatient.Lastname != null && currentPatient.Lastname.Contains(searchValue))
        //        //        || (currentPatient.Firstname != null && currentPatient.Firstname.Contains(searchValue))
        //        //        || (currentPatient.Address != null && currentPatient.Address.Contains(searchValue)) ||
        //        //        (currentPatient.Othername != null && currentPatient.Othername.Contains(searchValue)) ||
        //        //        (currentPatient.Patientid != null && currentPatient.Patientid.Contains(searchValue))

        //        //            )
        //        //    {
        //        //        listOfReturnedData.Add(currentPatient);
        //        //    }
        //        //}
        //        ////var shapedData = returnedDataFromSearch.Select(x => new
        //        ////{
        //        ////    Picture = x.Photopath,
        //        ////    FullName = x.Title + x.Lastname + "" + x.Firstname + "" + x.Othername,
        //        ////    AgeGender = getAge(x.Dob) + "/" + x.Gender.Gendername,
        //        ////    MobileNumber = x.Mobilephone,
        //        ////    Company = x.Employername

        //        ////});

        //       // return listOfReturnedData.AsQueryable<Patient>();

        //        return returnedDataFromSearch;
        //    });

        //    searchTask.Start();

        //    return searchTask;


        //}

        public static string getAge(DateTime? date)
        {
            if (date.HasValue)
            {
                var now = Math.Abs(DateTime.Now.Year - date.Value.Year);

                return now.ToString();

            }

            return "";
        }

        public void Close()
        {
            this._db.CloseConnection();
        }

        public string AddDependantPatient(Patient patient)
        {
            try
            {
                string newPatientId = generatePatientId();
              //  string familyNumber = generateFamilyNumber();
                patient.Patientid = newPatientId;
              
                if (_db.AddNew(patient))
                {
                    return newPatientId;
                }

                return null;
            }
            catch (Exception es)
            {

                throw es;
            }
        }
        public string AddPatient(Patient patient)
        {
            try
            {
                string newPatientId =  generatePatientId();
                string familyNumber = generateFamilyNumber();
                patient.Patientid = newPatientId;
                patient.FamilyNumber = familyNumber;
                if(_db.AddNew(patient))
                {
                    return newPatientId+":"+ familyNumber;
                }

                return null;
            }
            catch (Exception es)
            {

                throw es;
            }
        }

        public Task<IEnumerable<Patient>> searchForPatientToUpdate(string filter, string filterValue)
        {
            string formattedQuery = $"'%{filterValue}%'";
            string query = $"select * from [Patient] where (firstname is not null and firstname like {formattedQuery} or patientid is not null and patientid like {formattedQuery} or lastname is not null and lastname like {formattedQuery} or othername is not null and othername like {formattedQuery} or address is not null and address like {formattedQuery} or mothername is not null and mothername like {formattedQuery} or mobilephone is not null and mobilephone like {formattedQuery} or email is not null and email like {formattedQuery} or employername is not null and employername like {formattedQuery})";
            //string query = $"select * from [Patient] where firstname like %" + searchValue + "%";
            // $"select * from [Patient] where firstname like {formattedQuery}"
            //var result = _db.ExecuteRawSql(query);

            //return Task.FromResult(result);
            IEnumerable<Patient> result = null;
            switch (filter)
            {
                case "patientId":
                    query = $"select * from [Patient] where patientid is not null and patientid like {formattedQuery}";
                    // result = _db.ExecuteRawSql(query);
                    result = ctx.Patient.FromSqlRaw(query).Include(x => x.Gender).Include(x=>x.PayorTypes);
                    break;
                case "phoneNumber":
                    query = $"select * from [Patient] where mobilephone is not null and mobilephone like {formattedQuery} or workphone is not null and workphone like {formattedQuery} or homephone is not null and homephone like {formattedQuery}";
                    //result = _db.ExecuteRawSql(query);
                    result = ctx.Patient.FromSqlRaw(query).Include(x => x.Gender).Include(x => x.PayorTypes);
                    break;
                case "lastName":
                    query = $"select * from [Patient] where lastname is not null and lastname like {formattedQuery}";
                    // result = _db.ExecuteRawSql(query);
                    result = ctx.Patient.FromSqlRaw(query).Include(x => x.Gender).Include(x => x.PayorTypes);
                    break;
            }

            return Task.FromResult<IEnumerable<Patient>>(result);
        }
        public Task<IEnumerable<Patient>> SearchForDependeant(string filter, string filterValue)
        {
            string formattedQuery = $"'%{filterValue}%'";
            string query = $"select * from [Patient] where (firstname is not null and firstname like {formattedQuery} or patientid is not null and patientid like {formattedQuery} or lastname is not null and lastname like {formattedQuery} or othername is not null and othername like {formattedQuery} or address is not null and address like {formattedQuery} or mothername is not null and mothername like {formattedQuery} or mobilephone is not null and mobilephone like {formattedQuery} or email is not null and email like {formattedQuery} or employername is not null and employername like {formattedQuery})";
            //string query = $"select * from [Patient] where firstname like %" + searchValue + "%";
            // $"select * from [Patient] where firstname like {formattedQuery}"
            //var result = _db.ExecuteRawSql(query);

            //return Task.FromResult(result);
            IEnumerable<Patient> result = null;
            switch(filter)
            {
                case "patientId":
                    query = $"select * from [Patient] where patientid is not null and patientid like {formattedQuery}";
                    // result = _db.ExecuteRawSql(query);
                    result = ctx.Patient.FromSqlRaw(query).Include(x => x.Gender);
                    break;
                case "phoneNumber":
                    query = $"select * from [Patient] where mobilephone is not null and mobilephone like {formattedQuery} or workphone is not null and workphone like {formattedQuery} or homephone is not null and homephone like {formattedQuery}";
                    //result = _db.ExecuteRawSql(query);
                    result = ctx.Patient.FromSqlRaw(query).Include(x => x.Gender);
                    break;
                case "lastName":
                    query = $"select * from [Patient] where lastname is not null and lastname like {formattedQuery}";
                    // result = _db.ExecuteRawSql(query);
                    result = ctx.Patient.FromSqlRaw(query).Include(x => x.Gender);
                    break;
            }

            return Task.FromResult<IEnumerable<Patient>>(result);
        }

        public bool SaveRegistrationLink(string link)
        {
            string regLink = $"{link}";
            string patientId = generatePatientId();
            string familyId = generateFamilyNumber();
            var patient = new Patient()
            {
                Patientid = patientId,
                FamilyNumber = familyId,
                Reglink = regLink
                
            };

            return _db.AddNew(patient);
        }

        public string registerPatientFromLink(string link, Patient patientToUpdate)
        {
            ctx = null;
            string newLink = $"{link}_1";

            Patient getSingle = _db.GetSingle(x => x.Reglink == link+"_0");
            _db.CloseConnection();
            if(getSingle == null)
            {
                return null;
            }
           
            patientToUpdate.Reglink = newLink;
            patientToUpdate.FamilyNumber = getSingle.FamilyNumber;
            patientToUpdate.Patientid = generatePatientId();
            // patientToUpdate.Autoid = getSingle.Autoid;
            //var result =  _db.Update(patientToUpdate);

            //ctx.Entry<Patient>(patientToUpdate).State = EntityState.Modified;
            //ctx.Entry<Patient>(patientToUpdate).Property(x => x.Autoid).IsModified = false;
            bool result = false;
            result = _db.AddNew(patientToUpdate);
            
          
            if(!result)
            {
                return null;
            }
            _db.CloseConnection();
            var deleted = _db.Delete(x => x.Reglink == link + "_0" || x.Patientid == getSingle.Patientid);

            return patientToUpdate.Patientid + ":" + patientToUpdate.FamilyNumber;
        }
        public bool getRegistrationLinkStatus(string link)
        {
            var find = _db.GetSingle(x => x.Reglink == link);

            if(find == null)
            {
                return false;
            }

            var split_input = link.Split("_");
            string status = split_input[1];

            if(status == "1")
            {
                return false;
            }

            return true;
        }

        public bool UpdatePatient(Patient patient)
        {
            ctx.Entry<Patient>(patient).State = EntityState.Modified;
            ctx.Entry<Patient>(patient).Property(x => x.Autoid).IsModified = false;
            return ctx.SaveChanges() > 0;
            //return _db.Update(patient);
        }
    }
}
