using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace medicloud.emr.api.Helpers
{
    public class ApiRoutes
    {
        public const string baseUrl = "api/[controller]";
        public const string searchForPatient = baseUrl + "/" + Patient.searchForPatient;
        public const string newPatientRegistration = baseUrl + "/" + Patient.registerNewPatient;
        public const string isPatientExistBefore = baseUrl + "/" + Patient.checkIfPatientExist;
        public const string registerDependant = baseUrl + "/" + Patient.registerDependantPatient;
        public const string saveRegistrationLink = baseUrl + "/" + Patient.saveRegistrationLink;
        public const string SetUp = "api/setup";

        public class BloodGroupOperations
        {
            public const string addNew = baseUrl + "/" + nameof(bloodgroup) + "/" + bloodgroup.add;
            public const string deleteExisting = baseUrl + "/" + nameof(bloodgroup) + "/" + bloodgroup.delete;
            public const string updateExisting = baseUrl + "/" + nameof(bloodgroup) + "/" + bloodgroup.update;
            public const string getAllBloodGroups = baseUrl + "/" + nameof(bloodgroup) + "/" + bloodgroup.getall;
            public const string getBloodGroupById = baseUrl + "/" + nameof(bloodgroup) + "/" + bloodgroup.getSingle;

        }

        public class TitleOperations
        {
            public const string addNew = baseUrl + "/" + nameof(title) + "/" + title.add;
            public const string deleteExisting = baseUrl + "/" + nameof(title) + "/" + title.delete;
            public const string updateExisting = baseUrl + "/" + nameof(title) + "/" + title.update;
            public const string getAll = baseUrl + "/" + nameof(title) + "/" + title.getall;
            public const string getById = baseUrl + "/" + nameof(title) + "/" + title.getSingle;

        }


        private class Patient
        {
            public const string searchForPatient = "getPatientBy/{searchValue}";
            public const string registerNewPatient = "newPatient";
            public const string checkIfPatientExist = "lookUpPatient";
            public const string registerDependantPatient = "registerDependantPatient";
            public const string saveRegistrationLink = "saveRegistrationLink/{link}";
        }
        private class bloodgroup
        {
            public const string add = "addBloodGroup";
            public const string delete = "deleteBloodGroup/{id}";
            public const string update = "update/{id}";
            public const string getall = "all";
            public const string getSingle = "getSingle/{id}";
        }

        private class title
        {
            public const string add = "add";
            public const string delete = "delete/{id}";
            public const string update = "update/{id}";
            public const string getall = "all";
            public const string getSingle = "getSingle/{id}";
        }

       
    }
}
