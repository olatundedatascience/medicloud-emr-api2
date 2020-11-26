using medicloud.emr.api.DataContextRepo;
using medicloud.emr.api.DTOs;
using medicloud.emr.api.Entities;
using medicloud.emr.api.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace medicloud.emr.api.Controllers
{
    [Route(ApiRoutes.SetUp)]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private IBloodGroupRepo bloodGroupRepo;
        private ITitleRepo titleRepo;
        private BaseResponse _reponse;
        private IDataContextRepo<PatientType> patienTypeRepo;
        private IDataContextRepo<GenoType> genoTypeRepo;
        private IDataContextRepo<IdentificationMode> identificationModeRepo;
        private IDataContextRepo<Maritalstatus> maritalStatusRepo;
        private IDataContextRepo<Gender> genderRepo;
        private IDataContextRepo<HmoType> hmoRepo;
        private IDataContextRepo<HealthCareFacilitator> healthCareRepo;
        private IDataContextRepo<AccountCategory> accountCategoryRepo;
        private IDataContextRepo<Referral> referalRepo;
        private IDataContextRepo<LeadSource> leadSourceRepo;
        private IDataContextRepo<State> stateRepo;
        private IDataContextRepo<Sponsor> sponsorRepo;
        private IDataContextRepo<Provider> providerRepo;
        private IDataContextRepo<Country> countryRepo;
        private IDataContextRepo<Title> _titleRepo;
       // private ITitleRepo titleRepo;
        public SetupController(IBloodGroupRepo bloodGroupRepo,
                    ITitleRepo titleRepo)
        {
            this.bloodGroupRepo = bloodGroupRepo;
            this.titleRepo = titleRepo;
            _titleRepo = new DataContextRepo<Title>();
            countryRepo = new DataContextRepo<Country>();
            patienTypeRepo = new DataContextRepo<PatientType>();
            genoTypeRepo = new DataContextRepo<GenoType>();
            identificationModeRepo = new DataContextRepo<IdentificationMode>();
            maritalStatusRepo = new DataContextRepo<Maritalstatus>();
            genderRepo = new DataContextRepo<Gender>();
            leadSourceRepo = new DataContextRepo<LeadSource>();
            hmoRepo = new DataContextRepo<HmoType>();
            accountCategoryRepo = new DataContextRepo<AccountCategory>();
            referalRepo = new DataContextRepo<Referral>();
            healthCareRepo = new DataContextRepo<HealthCareFacilitator>();
            stateRepo = new DataContextRepo<State>();
            sponsorRepo = new DataContextRepo<Sponsor>();
            providerRepo = new DataContextRepo<Provider>();
        }


        #region provider
        [Route("addProvider")]
        [HttpPost]
        public async Task<IActionResult> addProvider([FromBody] Provider dto)
        {
            var provider = (Provider)dto;
            provider.CreatedAt = DateTime.Now;
            var addResult = providerRepo.AddNew(provider);
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateProvider/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateProvider([FromRoute] long id, [FromBody] Provider dto)
        {

            var getResult = providerRepo.GetSingle(x => x.Id == id);

            if (getResult != null)
            {
                getResult = dto;
                var updateResult = providerRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteProvider/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteProvider([FromRoute] long id)
        {


            var deleteResult = providerRepo.Delete(x => x.Id == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("getAllProvider")]
        [HttpGet]
        public async Task<IActionResult> getAllPorivder()
        {
            var allResult = providerRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getProviderById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getProviderById([FromRoute] long id)
        {

            var getResult = providerRepo.GetSingle(x => x.Id == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest(_reponse);
        }


        #endregion

        #region state
        [Route("addState")]
        [HttpPost]
        public async Task<IActionResult> addState([FromBody] StateDTO dto)
        {

            var addResult = stateRepo.AddNew(new State() { Statename = dto.Statename, Dateadded = DateTime.Now, Countryid = dto.Countryid });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateState/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateState([FromRoute] long id, [FromBody] StateDTO dto)
        {

            var getResult = stateRepo.GetSingle(x => x.Stateid == id);

            if (getResult != null)
            {
                getResult.Statename = dto.Statename;
                getResult.Countryid = dto.Countryid;
                var updateResult = stateRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteState/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteState([FromRoute] long id)
        {


            var deleteResult = stateRepo.Delete(x => x.Stateid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("getAllState")]
        [HttpGet]
        public async Task<IActionResult> getAllState()
        {
            var allResult = stateRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getStateById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getStateById([FromRoute] long id)
        {

            var getResult = stateRepo.GetSingle(x => x.Stateid == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest(_reponse);
        }

        #endregion

        #region Lead Source
        [Route("addLeadSource")]
        [HttpPost]
        public async Task<IActionResult> addLeadSource([FromBody] LeadSourceDTO dto)
        {

            var addResult = leadSourceRepo.AddNew(new LeadSource() { Leadname = dto.Leadname, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateLeadSource/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateLeadSource([FromRoute] long id, [FromBody] LeadSourceDTO dto)
        {

            var getResult = leadSourceRepo.GetSingle(x => x.Leadid == id);

            if (getResult != null)
            {
                getResult.Leadname = dto.Leadname;
                var updateResult = leadSourceRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteLeadSource/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteLeadSource([FromRoute] long id)
        {


            var deleteResult = leadSourceRepo.Delete(x => x.Leadid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("getAllLeadSource")]
        [HttpGet]
        public async Task<IActionResult> getAllLeadSource()
        {
            var allResult = leadSourceRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getLeadSourceById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getLeadSourceById([FromRoute] long id)
        {

            var getResult = leadSourceRepo.GetSingle(x => x.Leadid == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest(_reponse);
        }

        #endregion

        #region title operations
        //[Route(ApiRoutes.TitleOperations.getById)]
        //[HttpGet]
        //public async Task<IActionResult> GetTitleById([FromRoute] long id)
        //{
        //    var allResult = titleRepo.GetSingle(id);

        //    _reponse = BaseResponse.GetResponse(allResult, "success", "00");
        //    return Ok(_reponse);

        //}

        //[Route(ApiRoutes.TitleOperations.getAll)]
        //[HttpGet]
        //public async Task<IActionResult> GetAllTitles()
        //{
        //    var allResult = titleRepo.GetAll();

        //    _reponse = BaseResponse.GetResponse(allResult, "success", "00");
        //    return Ok(_reponse);

        //}
        //[Route(ApiRoutes.TitleOperations.addNew)]
        //[HttpPost]
        //public async Task<IActionResult> AddTitle([FromBody] Title dt)
        //{
        //    var addResult = titleRepo.AddNew(dt.Titlename);
        //    if (addResult)
        //    {
        //        _reponse = BaseResponse.GetResponse(null, "success", "00");
        //        return Ok(_reponse);
        //    }

        //    _reponse = BaseResponse.GetResponse(null, "failure", "99");
        //    return BadRequest(_reponse);
        //}

        //[Route(ApiRoutes.TitleOperations.updateExisting)]
        //[HttpPut]
        //public async Task<IActionResult> UpdateTitle([FromRoute] int id, [FromBody] Title dt)
        //{
        //    var updateResult = titleRepo.update(id, dt);
        //    if (updateResult)
        //    {
        //        _reponse = BaseResponse.GetResponse(null, "success", "00");
        //        return Ok(_reponse);
        //    }

        //    _reponse = BaseResponse.GetResponse(null, "failure", "99");
        //    return BadRequest(_reponse);
        //}

        //[Route(ApiRoutes.TitleOperations.deleteExisting)]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteTitle([FromRoute] int id)
        //{
        //    var deleteResult = bloodGroupRepo.Delete(id);
        //    if (deleteResult)
        //    {
        //        _reponse = BaseResponse.GetResponse(null, "success", "00");
        //        return Ok(_reponse);
        //    }

        //    _reponse = BaseResponse.GetResponse(null, "failure in deleting bloodgroup", "99");
        //    return BadRequest(_reponse);
        //}


        #endregion
        #region account category
        [Route("addAccountCategory")]
        [HttpPost]
        public async Task<IActionResult> addAccountCategory([FromBody] AccountCategoryDTO dtoBject)
        {

            var addResult = accountCategoryRepo.AddNew(new AccountCategory() { Accountcattype = dtoBject.Accountcattype, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateAccountCategory/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateAccountCategory([FromRoute] long id, [FromBody] AccountCategoryDTO dtoBject)
        {

            var getResult = accountCategoryRepo.GetSingle(x => x.Accountcatid == id);

            if (getResult != null)
            {
                getResult.Accountcattype = dtoBject.Accountcattype;
                var updateResult = accountCategoryRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteAccountCategory/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteAccountCategory([FromRoute] long id)
        {


            var deleteResult = accountCategoryRepo.Delete(x => x.Accountcatid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("getAllAccountCategory")]
        [HttpGet]
        public async Task<IActionResult> getAccountCategory()
        {
            var allResult = accountCategoryRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getAccountCategoryById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getAccountCategoryById([FromRoute] long id)
        {

            var getResult = accountCategoryRepo.GetSingle(x => x.Accountcatid == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest(_reponse);
        }

        #endregion

        #region country

        [Route("addCountry")]
        [HttpPost]
        public async Task<IActionResult> addCountry([FromBody] CountryDTO dto)
        {

            var addResult = countryRepo.AddNew(new Country() { Countryname   = dto.Countryname, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateCountry/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateCountry([FromRoute] long id, [FromBody] CountryDTO dto)
        {

            var getResult = countryRepo.GetSingle(x => x.Countryid == id);

            if (getResult != null)
            {
                getResult.Countryname = dto.Countryname;
                var updateResult = countryRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteCountry/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteCountry([FromRoute] long id)
        {


            var deleteResult = countryRepo.Delete(x => x.Countryid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("getAllCountry")]
        [HttpGet]
        public async Task<IActionResult> getAllCountry()
        {
            var allResult = countryRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getCountryById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getCountryById([FromRoute] long id)
        {

            var getResult = countryRepo.GetSingle(x => x.Countryid == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest();
        }

        #endregion
        #region referalType
        [Route("addReferalType")]
        [HttpPost]
        public async Task<IActionResult> addReferalType([FromBody] ReferalTypeDTO dto)
        {

            var addResult = referalRepo.AddNew(new Referral() { Reftype = dto.Reftype, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateReferalType/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateReferalType([FromRoute] long id, [FromBody] ReferalTypeDTO dto)
        {

            var getResult = referalRepo.GetSingle(x => x.Refid == id);

            if (getResult != null)
            {
                getResult.Reftype = dto.Reftype;
                var updateResult = referalRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteReferalType/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteReferalType([FromRoute] long id)
        {


            var deleteResult = referalRepo.Delete(x => x.Refid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("getAllReferalType")]
        [HttpGet]
        public async Task<IActionResult> getAllReferalType()
        {
            var allResult = referalRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getReferalTypeById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getReferalTypeById([FromRoute] long id)
        {

            var getResult = referalRepo.GetSingle(x => x.Refid == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest();
        }


        #endregion
        #region health care facilitator

        [Route("addHealthCareFacilitator")]
        [HttpPost]
        public async Task<IActionResult> addHealthCareFacilitator([FromBody] HealthCareFacilitatorDTO dto)
        {

            var addResult = healthCareRepo.AddNew(new HealthCareFacilitator() { Facilitatorname = dto.Facilitatorname, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateHealthcarFacilitator/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateHealthcarFacilitator([FromRoute] long id, [FromBody] HealthCareFacilitatorDTO dto)
        {

            var getResult = healthCareRepo.GetSingle(x => x.Facilitatorid == id);

            if (getResult != null)
            {
                getResult.Facilitatorname = dto.Facilitatorname;
                var updateResult = healthCareRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteHealthCareFacilitator/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteHealthCareFacilitator([FromRoute] long id)
        {


            var deleteResult = healthCareRepo.Delete(x => x.Facilitatorid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("getAllHealthCareFacilittator")]
        [HttpGet]
        public async Task<IActionResult> getAllHealthCareFacilittator()
        {
            var allResult = healthCareRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getHealthCareFacilitatorById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getHealthCareFacilitatorById([FromRoute] long id)
        {

            var getResult = healthCareRepo.GetSingle(x => x.Facilitatorid == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest();
        }


        #endregion

        #region hmoclass

        [Route("addHmoType")]
        [HttpPost]
        public async Task<IActionResult> addHmoType([FromBody] HmoTypeDTO dto)
        {

            var addResult = hmoRepo.AddNew(new HmoType() { Name = dto.Name, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateHmoType/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateHmoType([FromRoute] long id, [FromBody] HmoTypeDTO dto)
        {

            var getResult = hmoRepo.GetSingle(x => x.Id == id);

            if (getResult != null)
            {
                getResult.Name = dto.Name;
                var updateResult = hmoRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteHmoType/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteHmoType([FromRoute] long id)
        {


            var deleteResult = hmoRepo.Delete(x => x.Id == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("getAllHmoType")]
        [HttpGet]
        public async Task<IActionResult> getAllHmoType()
        {
            var allResult = hmoRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getHmoById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getHmoById([FromRoute] long id)
        {

            var getResult = hmoRepo.GetSingle(x => x.Id == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest();
        }

        #endregion

        #region genderSetUp
        [Route("addGender")]
        [HttpPost]
        public async Task<IActionResult> addGender([FromBody] GenderDTO dto)
        {

            var addResult = genderRepo.AddNew(new Gender() { Gendername = dto.Gendername, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("updateGender/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateGender([FromRoute] long id, [FromBody] GenderDTO dto)
        {

            var getResult = genderRepo.GetSingle(x => x.Genderid == id);

            if (getResult != null)
            {
                getResult.Gendername = dto.Gendername;
                var updateResult = genderRepo.Update(getResult);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("deleteGender/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteGender([FromRoute] long id)
        {


            var deleteResult = genderRepo.Delete(x => x.Genderid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("genderAllGender")]
        [HttpGet]
        public async Task<IActionResult> genderAllGender()
        {
            var allResult = genderRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getGenderById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getGenderById([FromRoute] long id)
        {

            var getResult = genderRepo.GetSingle(x => x.Genderid == id);
            if (getResult != null)
            {
                _reponse = BaseResponse.GetResponse(getResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest();
        }


        #endregion
        #region maritalStatusSetpUp
        [Route("addMaritalStatus")]
        [HttpPost]
        public async Task<IActionResult> addMaritalStatus([FromBody] MaritalStatusDTO dto)
        {

            var addResult = maritalStatusRepo.AddNew(new Maritalstatus() { Maritalstatusname = dto.Maritalstatusname, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("updateMaritalStatus/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateMaritalStatus([FromRoute] long id, [FromBody] MaritalStatusDTO dto)
        {

            var maritalStatus = maritalStatusRepo.GetSingle(x => x.Maritalstatusid == id);

            if (maritalStatus != null)
            {
                maritalStatus.Maritalstatusname = dto.Maritalstatusname;
                var updateResult = maritalStatusRepo.Update(maritalStatus);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("deleteMaritalStatus/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteMaritalStatus([FromRoute] long id)
        {


            var deleteResult = maritalStatusRepo.Delete(x => x.Maritalstatusid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("getAllMaritalStatus")]
        [HttpGet]
        public async Task<IActionResult> getAllMaritalStatus()
        {
            var allMaritalStatus = maritalStatusRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allMaritalStatus, "success", "00");
            return Ok(_reponse);

        }

        [Route("getMaritalStatus/{id}")]
        [HttpGet]
        public async Task<IActionResult> getMaritalStatus([FromRoute] long id)
        {

            var maritalStatus = maritalStatusRepo.GetSingle(x => x.Maritalstatusid == id);
            if (maritalStatus != null)
            {
                _reponse = BaseResponse.GetResponse(maritalStatus, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest(_reponse);
        }

        #endregion

        #region identificationSetUp
        [Route("addIdentification")]
        [HttpPost]
        public async Task<IActionResult> addIdentification([FromBody] IdentificationDTO dto)
        {

            var addResult = identificationModeRepo.AddNew(new IdentificationMode() { IdentificationModename = dto.IdentificationModename, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("updateIdentification/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateIdentification([FromRoute] long id, [FromBody] IdentificationDTO dto)
        {

            var identification = identificationModeRepo.GetSingle(x => x.IdentificationModeid == id);

            if (identification != null)
            {
                identification.IdentificationModename = dto.IdentificationModename;
                
                var updateResult = identificationModeRepo.Update(identification);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("deleteIdentification/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteIdentification([FromRoute] long id)
        {


            var deleteResult = identificationModeRepo.Delete(x => x.IdentificationModeid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("getAllIdentification")]
        [HttpGet]
        public async Task<IActionResult> getAllIdentification()
        {
            var allIdentification = identificationModeRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allIdentification, "success", "00");
            return Ok(_reponse);

        }

        [Route("getIdentificationById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getIdentificationById([FromRoute] long id)
        {

            var identification = identificationModeRepo.GetSingle(x => x.IdentificationModeid == id);
            if (identification != null)
            {
                _reponse = BaseResponse.GetResponse(identification, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest();
        }

        #endregion

        #region genoType

        [Route("addGenoType")]
        [HttpPost]
        public async Task<IActionResult> addGenoType([FromBody] GenotypeDTO dto)
        {

            var addResult = genoTypeRepo.AddNew(new GenoType() { Genotypename = dto.Genotypename, Dateadded = DateTime.Now });
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("updateGenoType/{id}")]
        [HttpPut]
        public async Task<IActionResult> updateGenoType([FromRoute] long id, [FromBody] GenotypeDTO dto)
        {

            var getGenoType = genoTypeRepo.GetSingle(x => x.Genotypeid == id);

            if (getGenoType != null)
            {
                getGenoType.Genotypename = dto.Genotypename;
                var updateResult = genoTypeRepo.Update(getGenoType);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(null, "success", "00");
                    return Ok(_reponse);
                }

            }


            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("deleteGenoType/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deleteGenoType([FromRoute] long id)
        {


            var deleteResult = genoTypeRepo.Delete(x => x.Genotypeid == id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest();
        }

        [Route("getAllGenoType")]
        [HttpGet]
        public async Task<IActionResult> getAllGenoType()
        {
            var allPatientType = genoTypeRepo.GetAll();

            _reponse = BaseResponse.GetResponse(allPatientType, "success", "00");
            return Ok(_reponse);

        }

        [Route("getGenoTypeById/{id}")]
        [HttpGet]
        public async Task<IActionResult> getGenoTypeById([FromRoute] long id)
        {

            var genoType = genoTypeRepo.GetSingle(x => x.Genotypeid == id);
            if (genoType != null)
            {
                _reponse = BaseResponse.GetResponse(genoType, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest(_reponse);
        }

        #endregion

        #region patientType
        [Route("getPatientTypeById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPatientTypeById([FromRoute] long id)
        {

            var patientType = patienTypeRepo.GetSingle(x => x.PatienttypeId == id);
            if (patientType != null)
            {
                _reponse = BaseResponse.GetResponse(patienTypeRepo, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failed", "99");
            return BadRequest(_reponse);
        }

        [Route("addPatientType")]
        [HttpPost]
        public async Task<IActionResult> AddPatientType([FromBody] PatientTypeDTO dto)
        {

            var addResult = patienTypeRepo.AddNew(new PatientType() { Name = dto.Name, Dateadded = DateTime.Now });
            if (addResult)
            {
                var patientTypeAdded = patienTypeRepo.GetSingle(x => x.Name == dto.Name);
                _reponse = BaseResponse.GetResponse(patientTypeAdded, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("updatePatientType/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePatientType([FromRoute] long id, [FromBody] PatientTypeDTO dto)
        {

            var GetPatientType = patienTypeRepo.GetSingle(x => x.PatienttypeId == id);

            if(GetPatientType != null)
            {
                GetPatientType.Name = dto.Name;
                var updateResult = patienTypeRepo.Update(GetPatientType);
                if (updateResult)
                {
                    _reponse = BaseResponse.GetResponse(new { 
                        id = GetPatientType.PatienttypeId,
                        name = GetPatientType.Name,
                        dateadded = GetPatientType.Dateadded
                    }, "success", "00");
                    return Ok(_reponse);
                }

            }
            

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("getAllPatientType")]
        [HttpGet]
        public async Task<IActionResult> GetAllPatientType()
        {
                var allPatientType = patienTypeRepo.GetAll().Select(x => new
                {
                    id = x.PatienttypeId,
                    name = x.Name,
                    dateadded = x.Dateadded
                });
            
                _reponse = BaseResponse.GetResponse(allPatientType, "success", "00");
                return Ok(_reponse);
          
        }

        [Route("deletePatientType/{id}")]
        [HttpDelete]
        public async Task<IActionResult> deletePatientType([FromRoute] long id)
        {

            
            var updateResult = patienTypeRepo.Delete(x=>x.PatienttypeId == id);
            if (updateResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        #endregion

        #region bloodgroup
        [Route("getBloodGroupById/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBloodbyId([FromRoute] long id)
        {

            var bloodGroup = bloodGroupRepo.GetSingle(id);
            if (bloodGroup != null)
            {
                _reponse = BaseResponse.GetResponse(bloodGroup, "success in fetching bloodgroup", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure in fetching bloodgroup", "99");
            return BadRequest(_reponse);
        }

        [Route("addBloodgroup")]
        [HttpPost]
        public async Task<IActionResult> AddBloodGroup([FromBody] BloodGroupDTO dt)
        {

            var addResult = bloodGroupRepo.AddNew(dt.Bloodgroupname);
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success adding bloodgroup", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure in adding bloodgroup", "99");
            return BadRequest(_reponse);
        }

        [Route("allBloodGroup")]
        [HttpGet]
        public async Task<IActionResult> AllBloodGroup()
        {

            var bloodGroups = bloodGroupRepo.GetAll();

            _reponse = BaseResponse.GetResponse(bloodGroups, "success updating bloodgroup", "00");
            return Ok(_reponse);

        }

        [Route("updateBloodGroup/{id})")]
        [HttpPut]
        public async Task<IActionResult> UpdateBloodGroup([FromRoute] int id, [FromBody] BloodGroupDTO dt)
        {
            var bloodGroupDto = (BloodGroup)dt;
            var addResult = bloodGroupRepo.update(id, bloodGroupDto);
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success updating bloodgroup", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure in updaing bloodgroup", "99");
            return BadRequest(_reponse);
        }

        [Route("deleteBloodGroup/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBloodGroup([FromRoute] int id)
        {
            var addResult = bloodGroupRepo.Delete(id);
            if (addResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success deleting bloodgroup", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure in deleting bloodgroup", "99");
            return BadRequest(_reponse);
        }

        #endregion


        #region title
        [Route("getTitle/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTitleById([FromRoute] long id)
        {
            var allResult = titleRepo.GetSingle(id);

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }

        [Route("getAllTitle")]
        [HttpGet]
        public async Task<IActionResult> GetAllTitles()
        {
            var allResult = titleRepo.GetAll().Select(x => new
            {
                id = x.Titleid,
                name = x.Titlename,
                dateadded = x.Dateadded
            });

            _reponse = BaseResponse.GetResponse(allResult, "success", "00");
            return Ok(_reponse);

        }
        [Route("addTitle")]
        [HttpPost]
        public async Task<IActionResult> AddTitle([FromBody] Title dt)
        {
            var addResult = titleRepo.AddNew(dt.Titlename);
            if (addResult)
            {
                var response = _titleRepo.GetSingle(x => x.Titlename == dt.Titlename);
                _reponse = BaseResponse.GetResponse(response, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("updateTitle/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTitle([FromRoute] int id, [FromBody] Title dt)
        {
            var updateResult = titleRepo.update(id, dt);
            if (updateResult)
            {
                _reponse = BaseResponse.GetResponse(updateResult, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure", "99");
            return BadRequest(_reponse);
        }

        [Route("deleteTitle/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTitle([FromRoute] int id)
        {
            var deleteResult = bloodGroupRepo.Delete(id);
            if (deleteResult)
            {
                _reponse = BaseResponse.GetResponse(null, "success", "00");
                return Ok(_reponse);
            }

            _reponse = BaseResponse.GetResponse(null, "failure in deleting bloodgroup", "99");
            return BadRequest(_reponse);
        }

        #endregion

    }
}
