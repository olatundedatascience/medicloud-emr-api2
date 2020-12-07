using medicloud.emr.api.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace medicloud.emr.api.DTOs
{
    public class BloodGroupDTO
    {
        public int Bloodgroupid { get; set; }
        public string Bloodgroupname { get; set; }
        public string Dateadded { get; set; }

        public static explicit operator BloodGroup(BloodGroupDTO dt)
        {
            return JsonConvert.DeserializeObject<BloodGroup>(JsonConvert.SerializeObject(dt));
        }
    }

    public class GenotypeDTO
    {
        public int Genotypeid { get; set; }
        public string Genotypename { get; set; }
        public DateTime? Dateadded { get; set; }
        public static explicit operator GenoType(GenotypeDTO dt)
        {
            return JsonConvert.DeserializeObject<GenoType>(JsonConvert.SerializeObject(dt));
        }
    }


    public class PatientTypeDTO
    {
        public int PatienttypeId { get; set; }
        public string Name { get; set; }
        public DateTime? Dateadded { get; set; }

        public static explicit operator PatientType(PatientTypeDTO dt)
        {
            return JsonConvert.DeserializeObject<PatientType>(JsonConvert.SerializeObject(dt));
        }
    }
    public class MaritalStatusDTO
    {
        public int Maritalstatusid { get; set; }
        public string Maritalstatusname { get; set; }
        public DateTime? Dateadded { get; set; }

        public static explicit operator Maritalstatus(MaritalStatusDTO dt)
        {
            return JsonConvert.DeserializeObject<Maritalstatus>(JsonConvert.SerializeObject(dt));
        }
    }

    public class GenderDTO
    {
        public int Genderid { get; set; }
        public string Gendername { get; set; }
        public DateTime? Dateadded { get; set; }

        public static explicit operator Gender(GenderDTO dt)
        {
            return JsonConvert.DeserializeObject<Gender>(JsonConvert.SerializeObject(dt));
        }
    }

    public class LeadSourceDTO
    {
        public int Leadid { get; set; }
        public string Leadname { get; set; }
        public DateTime? Dateadded { get; set; }

        public static explicit operator LeadSource(LeadSourceDTO dt)
        {
            return JsonConvert.DeserializeObject<LeadSource>(JsonConvert.SerializeObject(dt));
        }
    }

    public class StateDTO
    {
        public int Stateid { get; set; }
        public string Statename { get; set; }
        public int? Countryid { get; set; }
        public DateTime DateAdded { get; set; }

        public static explicit operator State(StateDTO dt)
        {
            return JsonConvert.DeserializeObject<State>(JsonConvert.SerializeObject(dt));
        }

    }

    //public class ProviderDTO
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Address { get; set; }
    //    public string Tin { get; set; }
    //    public string Network { get; set; }
    //    public DateTime? CreatedAt { get; set; }
    //    public string Contactphone { get; set; }
    //    public string Contactname { get; set; }
    //    public string Contactemail { get; set; }
    //    public string Hmoproviderid { get; set; }
    //    public bool? Isreferral { get; set; }
    //    public string Accountnumber { get; set; }

    //    public static explicit operator Provider(ProviderDTO dt)
    //    {
    //        return JsonConvert.DeserializeObject<Provider>(JsonConvert.SerializeObject(dt));
    //    }
    //}

    public class IdentificationDTO
    {
        public int IdentificationModeid { get; set; }
        public string IdentificationModename { get; set; }
        public DateTime? Dateadded { get; set; }
    }

    public class AccountCategoryDTO
    {
        public int Accountcatid { get; set; }
        public string Accountcattype { get; set; }
        public DateTime? Dateadded { get; set; }

        public static explicit operator AccountCategory(AccountCategoryDTO dt)
        {
            return JsonConvert.DeserializeObject<AccountCategory>(JsonConvert.SerializeObject(dt));
        }
    }

    public class HmoTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Dateadded { get; set; }
        public bool? IsActive { get; set; }
        public int? Providerid { get; set; }


        public static explicit operator HmoType(HmoTypeDTO dt)
        {
            return JsonConvert.DeserializeObject<HmoType>(JsonConvert.SerializeObject(dt));
        }
    }

    public class ReferalTypeDTO
    {
        public int Refid { get; set; }
        public string Reftype { get; set; }
        public DateTime? Dateadded { get; set; }

        public static explicit operator Referral(ReferalTypeDTO dt)
        {
            return JsonConvert.DeserializeObject<Referral>(JsonConvert.SerializeObject(dt));
        }
    }
    public class PatientLookUpDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Othername { get; set; }
        public string dob { get; set; }
        public string mobilephone { get; set; }
        public string mothername { get; set; }
        public string email { get; set; }
    }
    public class HealthCareFacilitatorDTO
    {
        public int Facilitatorid { get; set; }
        public string Facilitatorname { get; set; }
        public DateTime? Dateadded { get; set; }

        public static explicit operator HealthCareFacilitator(HealthCareFacilitatorDTO dt)
        {
            return JsonConvert.DeserializeObject<HealthCareFacilitator>(JsonConvert.SerializeObject(dt));
        }
    }

    public class CountryDTO
    {
        public int Countryid { get; set; }
        public string Countryname { get; set; }
        public DateTime? Dateadded { get; set; }

        public static explicit operator Country(CountryDTO dt)
        {
            return JsonConvert.DeserializeObject<Country>(JsonConvert.SerializeObject(dt));
        }

    }
    public class PatientDTO
    {
        public string Patientid { get; set; }
        public string payor { get; set; }
        public string Title { get; set; }
        public int? identificationtypeid { get; set; }
        public string identificationnumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Othername { get; set; }
        public DateTime? Dob { get; set; }
        public string Securityid { get; set; }
        public string Securitynumber { get; set; }
        public string Address { get; set; }
        public int? Stateid { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool IsDependant { get; set; }
        public string FamilyNumber { get; set; }
        public string Postalcode { get; set; }
        //[Required]
        public string Mothername { get; set; }
        public string Guardianname { get; set; }
        //[Required]
        public string Emergencycontact { get; set; }
        //[Required]
        public string Emergencyphone { get; set; }
        //[Required]
        public string Nokrelationship { get; set; }
        //[Required]
        public string Nokoccupation { get; set; }
       // [Required]
        public string Nokworkaddress { get; set; }
        public string Homephone { get; set; }
        public string Workphone { get; set; }
        //[Required]
        public string Mobilephone { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Photopath { get; set; }
        public string Employername { get; set; }
        public string Employeraddress { get; set; }
        public string Employercity { get; set; }
        public int? Employerstateid { get; set; }
        public string Employercountry { get; set; }
        public DateTime? Dateofdeath { get; set; }
        public string Deathcause { get; set; }
        public string Hmoclass1 { get; set; }
        public string Hmoname1 { get; set; }
        public string Hmoclass2 { get; set; }
        public string Hmoname2 { get; set; }
        public string Hmoclass3 { get; set; }
        public string Hmoname3 { get; set; }
        public string Principalcode { get; set; }
        public string Relationship { get; set; }
        public DateTime? Dateadded { get; set; }
        public bool? Inactive { get; set; }
        public int? Cardtypeid { get; set; }
        public DateTime? Datedeactivated { get; set; }
        public string Hmonumber { get; set; }
        public string Genotype { get; set; }
        public int? ProviderId { get; set; }
        public string AlternateId1 { get; set; }
        public string AlternateId2 { get; set; }
        // public int? Autoid { get; set; }
        public string Servicetype { get; set; }
        public string Plantype { get; set; }
        public int? Maritalstatusid { get; set; }
        public string Nationality { get; set; }
        public string Nokinname { get; set; }
        public string Nokphonenumber { get; set; }
        public string Accountcategory { get; set; }
        public int? Genderid { get; set; }
        public int? Genotypeid { get; set; }
        public int? Bloodgroupid { get; set; }
        public int? Sponsid { get; set; }
        public int? Facilitatorid { get; set; }
        public int? Refid { get; set; }
        public int? Leadid { get; set; }
        public string enrolleeno { get; set; }
        public string employeenumber { get; set; }
        public string status { get; set; }
        public long? referalby { get; set; }
        public string dependantrelationship { get; set; }
        public List<PatientPayorTypes> payors { get; set; }

        public static explicit operator Patient(PatientDTO dt)
        {

            return JsonConvert.DeserializeObject<Patient>(JsonConvert.SerializeObject(dt));
        }
    }
}
