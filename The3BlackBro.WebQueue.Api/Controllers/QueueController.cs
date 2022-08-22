using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using The3BlackBro.WebQueue.Service.Dto;
using The3BlackBro.WebQueue.Service.Dto.EntitiesDto.Creating;
using The3BlackBro.WebQueue.Domain.Interface.Repository;
using The3BlackBro.WebQueue.Domain.Interface.Service;
using System;

namespace The3BlackBro.WebQueue.Api.Controllers {
    [AllowAnonymous]
    [Route("api/queue")]
    public class QueueController : ControllerBase {
        private readonly ICurrentQueueService _queueService;

        public QueueController(ICurrentQueueService queueApp) {
            _queueService = queueApp;
        }

        /// <summary>
        /// Cria uma nova fila para o dia atual.
        /// </summary>
        /// <param name="queue">Dto de entrada para criação da fila</param>
        /// <returns></returns>
        [HttpPost("createQueue")]
        public IActionResult Post([FromBody] CreatingQueueDto queue) {
            try {
                var ret = _queueService.StartQueue(queue.ToEntity());
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recuperar todas as filas disponíveis.
        /// </summary>
        /// <param name="page">Número da página atual.</param>
        /// <param name="qtd">Quantidade de itens por página.</param>
        /// <returns></returns>
        [HttpGet("getAllQueues/{page}/{qtd}")]
        public IActionResult GetAll([FromRoute] int page, int qtd) {
            try {
                var ret = _queueService.GetAllCurrentQueues(page, qtd);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recuperar fila pelo Id.
        /// </summary>
        /// <param name="id">Id da fila.</param>
        /// <returns></returns>
        [HttpGet("getQueue/{id}")]
        public IActionResult GetById([FromRoute] int id) {
            try {
                var ret = _queueService.GetById(id);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Verifica se existe fila iniciada para a empresa.
        /// </summary>
        /// <param name="repository">Instância de repositório para fila.</param>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        [HttpGet("isThereQueueStarted/{companyId}")]
        public IActionResult IsThereQueueStarted([FromServices] ICurrentQueueRepository repository, [FromRoute] int companyId) {
            try {
                var ret = repository.IsThereQueueStarted(companyId);
                return Ok(new DefaultOutPutContainer() {
                    Valid = true,
                    Log = true
                }); 
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Finaliza uma fila para aquele dia.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <param name="userId">Id do usuário dono da fila ( e da empresa ).</param>
        /// <returns></returns>
        [HttpPut("finishQueue/{companyId}/{userId}")]
        public IActionResult Put([FromRoute] int companyId, int userId) {
            try {
                _queueService.FinishQueue(companyId, userId);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recupera todos os cliente da fila atual
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        [HttpGet("getAllCustumersInCurrentQueue/{companyId}")]
        public IActionResult GetAll([FromRoute] int companyId) {
            try {
                var ret = _queueService.GetAllCustumersInCurrentQueue(companyId);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recupera o último da fila
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        [HttpGet("getLastInCurrentQueue/{companyId}")]
        public IActionResult GetLastInCurrentQueue([FromRoute] int companyId) {
            try {
                var ret = _queueService.GetLastInCurrentQueue(companyId);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }
    }
}