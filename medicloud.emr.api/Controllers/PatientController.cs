using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medicloud.emr.api.Helpers;
using medicloud.emr.api.DataContextRepo;
using medicloud.emr.api.DTOs;
using medicloud.emr.api.Services;
using medicloud.emr.api.Entities;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace medicloud.emr.api.Controllers
{
    
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientRepo patientRepo;
        private BaseResponse _reponse;
        private IPatientServices ps;
        private IDataContextRepo<PatientPayorTypes> patientPayorTypes;
        private IDataContextRepo<Patient> patientDB;
        //private IBloodGroupRepo bloodGroupRepo;

        public PatientController(IPatientRepo patientRepo, 
            //IBloodGroupRepo bloodGroupRepo,
            ITitleRepo titleRepo,
            IPatientServices ps)
        {
            this.patientRepo = patientRepo;
            this.ps = ps;
            patientPayorTypes = new DataContextRepo<PatientPayorTypes>();
            patientDB = new DataContextRepo<Patient>();
            //this.bloodGroupRepo = bloodGroupRepo;


        }

        [Route("updatePatient/{regno}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromRoute] string regno, [FromBody]PatientDTO patient)
        {

            if (patient.payors.Count > 0)
            {
                var listOfPayors = new List<PatientPayorTypes>();
                foreach (var k in patient.payors)
                {
                    var current = k;
                    current.Patientid = regno;
                    listOfPayors.Add(current);
                }
                bool isDeleted = false;
                if(patientPayorTypes.count(x=>x.Patientid == regno) > 0)
                {
                    isDeleted = patientPayorTypes.Delete(x => x.Patientid == regno);
                   
                }

                patientPayorTypes.AddMultiples(listOfPayors.ToArray());

                //if (isDeleted)
                //{

                    patient.Patientid = regno;
                    var result = await ps.updatePatientInfo((Patient)patient);

                    if(result)
                    {
                        return Ok(BaseResponse.GetResponse(null, "success", "00"));
                    }
               // }
                return BadRequest(BaseResponse.GetResponse(null, "request failed to update data try again", "99"));
            }

            patient.Patientid = regno;
            var ispatientUpdated = await ps.updatePatientInfo((Patient)patient);

            if (ispatientUpdated)
            {
                return Ok(BaseResponse.GetResponse(null, "success", "00"));
            }

            return BadRequest(BaseResponse.GetResponse(null, "request failed to update data try again", "99"));

        }

        [Route(ApiRoutes.saveRegistrationLink)]
        [HttpPost]
        public async Task<IActionResult> SaveRegistrationLink([FromRoute] string link)
        {
            // string[] split_input = link.Split("_");
            var isFound = patientRepo.SaveRegistrationLink(link);
            if (isFound)
            {
                _reponse = BaseResponse.GetResponse(isFound, $"self registration link created", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(false, "self registration link created failed to create", "00");
            return Ok(_reponse);
        }


        [Route("api/Patient/searchForPatientToUpdate")]
        [HttpGet]
        public async Task<IActionResult> SearchForPatientToUpdate([FromQuery] string searchFilter, [FromQuery] string searchValue)
        {
            var result = await patientRepo.searchForPatientToUpdate(searchFilter, searchValue);

            if (result == null)
            {
                _reponse = BaseResponse.GetResponse(null, "no matched found", "99");
                return BadRequest(_reponse);
            }

            _reponse = BaseResponse.GetResponse(result, "success", "00");
            return Ok(_reponse);
        }

        [Route("api/Patient/registerPatientFromLink/{link}")]
        [HttpPost]
        public async Task<IActionResult> registerPatientFromLink([FromRoute] string link, [FromBody] PatientDTO dto)
        {

            var result = patientRepo.registerPatientFromLink(link, (Patient)dto);
            if (result != null)
            {
                string[] spliResult = result.Split(":");
                var resultOut = new
                {
                    PatientRegNumber = spliResult[0],
                    PatientFamilyNumber = spliResult[1]
                };
                _reponse = BaseResponse.GetResponse(resultOut, "patient registered", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "patient failed to register", "99");
            return BadRequest(_reponse);
        }

        [Route("api/Patient/checkLinkValidity/{link}")]
        [HttpGet]
        public async Task<IActionResult> checkLinkValidity([FromRoute] string link)
        {
            // string[] split_input = link.Split("_");
            var isFound = patientRepo.getRegistrationLinkStatus(link);
            if (isFound)
            {
                _reponse = BaseResponse.GetResponse(isFound, $"registration link is valid", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(false, "registration link is invalid or expire", "99");
            return Ok(_reponse);
        }

        [Route(ApiRoutes.isPatientExistBefore)]
        [HttpPost]
        public async Task<IActionResult> IsPatientExistBefore([FromBody] PatientLookUpDTO dto)
        {
            var isFound = ps.isPatientExist(dto.Firstname, dto.Lastname, dto.dob, dto.mobilephone, dto.email);
            if(isFound != null)
            {
                _reponse = BaseResponse.GetResponse(isFound, $"the following record already exist", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(false, "you can continue", "99");
            return Ok(_reponse);
        }



        [Route(ApiRoutes.registerDependant)]
        [HttpPost]
        public async Task<IActionResult> RegisterDependantData([FromQuery] string familyNumber, [FromBody] PatientDTO patient)
        {
            patient.IsDependant = true;
            var result = ps.AddDepentdantData(familyNumber, patient);
            if (result != null)
            {
                string spliResult = result;
                var resultOut = new
                {
                    PatientRegNumber = spliResult
                    
                };
                _reponse = BaseResponse.GetResponse(resultOut, "patient registered", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "patient failed to register", "99");
            return BadRequest(_reponse);
        }
        [Route(ApiRoutes.newPatientRegistration)]
        [HttpPost]
        public async Task<IActionResult> RegisterNewPatient([FromBody]PatientDTO patient)
        {
            patient.IsDependant = false;
            var result = ps.addNewPatient(patient);
            if(result != null)
            {
                string[] spliResult = result.Split(":");
                var resultOut = new
                {
                    PatientRegNumber = spliResult[0],
                    PatientFamilyNumber = spliResult[1]
                };

                //var listOfPayors = new List<PatientPayorTypes>();
                //foreach(string k in patient.payors)
                //{
                //    var current = new PatientPayorTypes()
                //    {
                //        Patientid = spliResult[0],
                //        Payor = k
                //    };

                //    listOfPayors.Add(current);
                //}

                if(patient.payors.Count > 0)
                {
                    var listOfPayors = new List<PatientPayorTypes>();
                    foreach(var k in patient.payors)
                    {
                        var current = k;
                        current.Patientid = resultOut.PatientRegNumber;
                        listOfPayors.Add(current);
                    }
                    patientPayorTypes.AddMultiples(listOfPayors.ToArray());
                }

                _reponse = BaseResponse.GetResponse(resultOut, "patient registered", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "patient failed to register", "99");
            return BadRequest(_reponse);
        }

        [Route("api/Patient/searchForDependant")]
        [HttpGet]
        public async Task<IActionResult> SearchForDependent([FromQuery] string searchFilter, [FromQuery] string searchValue)
        {
            var result = await patientRepo.SearchForDependeant(searchFilter, searchValue);
            
            if(result == null)
            {
                _reponse = BaseResponse.GetResponse(null, "no matched found", "99");
                return BadRequest(_reponse);
            }
            
            _reponse = BaseResponse.GetResponse(result, "success", "00");
            return Ok(_reponse);
        }

        //[Route("coderbytes")]
        //[HttpGet]
        //public async Task<IActionResult> GetCoderBytes()
        //{
        //    WebRequest req = WebRequest.Create("https://coderbyte.com/api/challenges/json/json-cleaning");
        //    WebResponse resp = req.GetResponse();

        //    var ss = resp.GetResponseStream();

        //    string result = "";
        //    StreamReader rs = new StreamReader(ss);
        //    string current = "";
        //    while((current = rs.ReadLine())  != null) {
        //        result += current;
        //    }

        //    string newResult = Regex. .Replace(result, "[(\\w+:), (\\w+:-), (\\w+:N/A)]");

          

        //    return Ok(result);
        //}
        
        [Route(ApiRoutes.searchForPatient)]
        [HttpGet]
        public async Task<IActionResult> SearchForPatient([FromRoute] string searchValue)
        {
            try
            {
                var returnedDataFromSearch = await patientRepo.SearchByValue(searchValue);
                BaseResponse responseOut = null;
                if(returnedDataFromSearch.Count() > 0)
                {
                    responseOut = BaseResponse.GetResponse(returnedDataFromSearch, $"searching for patient information with {searchValue}", "00");

                    //  patientRepo.Close();
                    return Ok(responseOut); 
                }
                responseOut = BaseResponse.GetResponse(null, "no match found", "99");
                return BadRequest(responseOut);

            }
            catch(Exception es)
            {
                return Content(es.Message, "application/json");

            }

        }
    }
}
