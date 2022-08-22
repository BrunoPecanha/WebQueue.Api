using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using The3BlackBro.WebQueue.Service.Dto;
using The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Creating;
using The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Updating;
using System;

namespace The3BlackBro.WebQueue.Api.Controllers
{
    /// <summary>
    /// Classe que trata da entrada de clientes no sistema.
    /// </summary>
    [AllowAnonymous]
    [Route("api/user")]
    public class UserController : ControllerBase {
        private readonly IUserService _service;
        private readonly IUserRepository _repository;

        /// <summary>
        /// Controller do usuário
        /// </summary>
        /// <param name="userApp">Parâmetro injetado pelo container de IoC.</param>
        public UserController(IUserService service, IUserRepository repository) {
            _service = service;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatingUserDto user) {
            try {
                _service.CreateNewUser(user.ToEntity());
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll(int companyId) {
            try {
                var ret = _repository.GetAllUsers(companyId);
                return Ok(ret);
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
                 var user = _repository.GetById(id);
                return Ok(user);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }


        [HttpPut]
        public IActionResult Put(UpdatingUserDto user) {
            try {
                _service.UpdateUser(user.ToEntity());
                return Ok();
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
                 _service.DeleteUser(id);
                return Ok();
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
