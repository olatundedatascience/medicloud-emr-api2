using System;
using System.Collections.Generic;

namespace medicloud.emr.api.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            Admission = new HashSet<Admission>();
            Bill = new HashSet<Bill>();
            BillPayable = new HashSet<BillPayable>();
            Biometric = new HashSet<Biometric>();
            BirthRegister = new HashSet<BirthRegister>();
            ConsultationCheck = new HashSet<ConsultationCheck>();
            ConsultationComplaints = new HashSet<ConsultationComplaints>();
            ConsultationDental = new HashSet<ConsultationDental>();
            ConsultationDentalProcedure = new HashSet<ConsultationDentalProcedure>();
            ConsultationDiagnosis = new HashSet<ConsultationDiagnosis>();
            ConsultationLaboratory = new HashSet<ConsultationLaboratory>();
            ConsultationOtherDiagnosis = new HashSet<ConsultationOtherDiagnosis>();
            ConsultationPrescription = new HashSet<ConsultationPrescription>();
            ConsultationProblem = new HashSet<ConsultationProblem>();
            ConsultationProcedure = new HashSet<ConsultationProcedure>();
            Fingerprint = new HashSet<Fingerprint>();
            Insurance = new HashSet<Insurance>();
            PatientMedicalHistory = new HashSet<PatientMedicalHistory>();
            PatientOrder = new HashSet<PatientOrder>();
            PatientQuestionnaire = new HashSet<PatientQuestionnaire>();
            Photo = new HashSet<Photo>();
            QueueManager = new HashSet<QueueManager>();
            ReferenceMaterial = new HashSet<ReferenceMaterial>();
            VerificationLog = new HashSet<VerificationLog>();
        }

        public string Patientid { get; set; }
        public string Title { get; set; }
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
        public string Postalcode { get; set; }
        public string Mothername { get; set; }
        public string Guardianname { get; set; }
        public string Emergencycontact { get; set; }
        public string Emergencyphone { get; set; }
        public string Nokrelationship { get; set; }
        public string Nokoccupation { get; set; }
        public string Nokworkaddress { get; set; }
        public string Homephone { get; set; }
        public string Workphone { get; set; }
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
        public int Autoid { get; set; }
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
        public bool? IsDependant { get; set; }
        public string FamilyNumber { get; set; }
        public int? Identificationtypeid { get; set; }
        public string Identificationnumber { get; set; }
        public string Payor { get; set; }
        public string Enrolleeno { get; set; }
        public string Employeenumber { get; set; }
        public string Status { get; set; }
        public long? Referalby { get; set; }
        public string Dependantrelationship { get; set; }
        public string Reglink { get; set; }

        public virtual BloodGroup Bloodgroup { get; set; }
        public virtual EnrolleeType Cardtype { get; set; }
        public virtual HealthCareFacilitator Facilitator { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual GenoType GenotypeNavigation { get; set; }
        public virtual LeadSource Lead { get; set; }
        public virtual Maritalstatus Maritalstatus { get; set; }
        public virtual AccountManager Provider { get; set; }
        public virtual Referral Ref { get; set; }
        public virtual Sponsor Spons { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Admission> Admission { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
        public virtual ICollection<BillPayable> BillPayable { get; set; }
        public virtual ICollection<PatientPayorTypes> PayorTypes { get; set; }
        public virtual ICollection<Biometric> Biometric { get; set; }
        public virtual ICollection<BirthRegister> BirthRegister { get; set; }
        public virtual ICollection<ConsultationCheck> ConsultationCheck { get; set; }
        public virtual ICollection<ConsultationComplaints> ConsultationComplaints { get; set; }
        public virtual ICollection<ConsultationDental> ConsultationDental { get; set; }
        public virtual ICollection<ConsultationDentalProcedure> ConsultationDentalProcedure { get; set; }
        public virtual ICollection<ConsultationDiagnosis> ConsultationDiagnosis { get; set; }
        public virtual ICollection<ConsultationLaboratory> ConsultationLaboratory { get; set; }
        public virtual ICollection<ConsultationOtherDiagnosis> ConsultationOtherDiagnosis { get; set; }
        public virtual ICollection<ConsultationPrescription> ConsultationPrescription { get; set; }
        public virtual ICollection<ConsultationProblem> ConsultationProblem { get; set; }
        public virtual ICollection<ConsultationProcedure> ConsultationProcedure { get; set; }
        public virtual ICollection<Fingerprint> Fingerprint { get; set; }
        public virtual ICollection<Insurance> Insurance { get; set; }
        public virtual ICollection<PatientMedicalHistory> PatientMedicalHistory { get; set; }
        public virtual ICollection<PatientOrder> PatientOrder { get; set; }
        public virtual ICollection<PatientQuestionnaire> PatientQuestionnaire { get; set; }
        public virtual ICollection<Photo> Photo { get; set; }
        public virtual ICollection<QueueManager> QueueManager { get; set; }
        public virtual ICollection<ReferenceMaterial> ReferenceMaterial { get; set; }
        public virtual ICollection<VerificationLog> VerificationLog { get; set; }
    }
}
