using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The3BlackBro.WebQueue.Service.Dto;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using System;

namespace The3BlackBro.WebQueue.Api.Controllers {
    [AllowAnonymous]
    [Route("api/dayBalance")]
    public class DayBalanceController : ControllerBase {
        private readonly IDayBalanceService _dayBalanceService;

        public DayBalanceController(IDayBalanceService dayBalanceService) {
            _dayBalanceService = dayBalanceService;
        }

        [HttpPost("withdraw/{companyId}/{value}")]
        public IActionResult Withdraw([FromRoute] int companyId, decimal value) {
            try {
                _dayBalanceService.Withdraw(companyId, value);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("deposit/{companyId}/{value}")]
        public IActionResult Deposit([FromRoute] int companyId, decimal value) {
            try {
                _dayBalanceService.Deposit(companyId, value);
                return Ok(new DefaultOutPutContainer() {
                    Valid = true,
                    Message = "Done"
                });
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("amount/{companyId}")]
        public IActionResult Amount([FromRoute] int companyId) {
            try {
                var ret = _dayBalanceService.DayAmount(companyId);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = companyId,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }
    }
}
