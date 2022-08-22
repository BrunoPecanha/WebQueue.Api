using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using The3BlackBro.WebQueue.Service.Dto;
using The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Creating;
using The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Updating;
using The3BlackBro.WebQueue.Service.Properties;
using System;

namespace The3BlackBro.WebQueue.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/company")]
    public class CompanyController : ControllerBase {
        private readonly ICompanyService _service;
        private readonly ICompanyRepository _repository;

        public CompanyController(ICompanyService service, ICompanyRepository repository) {
            _service = service;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatingCompanyDto company) {
            try {
                _service.CreateNewCompany(company.ToEntity());

                return Ok(new DefaultOutPutContainer() {                   
                    Valid = true,
                    Message = $"{company.FantasyName} {Resources.mSucceedCreated}"
                });


            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() {
            try {
                var ret = _repository.GetAll();
                return Ok(new DefaultOutPutContainer() {
                    Valid = false,
                    Log = ret
                });
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id) {
            try {
                var ret = _repository.GetCompanyById(id);
                return Ok(new DefaultOutPutContainer() {
                    Valid = true,
                    Log = ret
                });
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public IActionResult Put(UpdatingCompanyDto company) {
            try {
                _service.UpdateCompany(company.ToEntity());
                return Ok(new DefaultOutPutContainer() {
                    Valid = true,
                    Message = Resources.mSuceedUpdated
                });
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            try {
                _service.RemoveCompany(id);

                return Ok(new DefaultOutPutContainer() {
                    Valid = true,
                    Message = Resources.mSuceedDeleted
                });

            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }
    }
}
