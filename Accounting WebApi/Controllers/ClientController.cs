using Accounting_WebApi.Contracts;
using Accounting_WebApi.Entities.DataTransferObjects.Create;
using Accounting_WebApi.Entities.DataTransferObjects.Update;
using Accounting_WebApi.Entities.DataTransferObjects.View;
using Accounting_WebApi.Entities.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_WebApi.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public ClientController(ILoggerManager logger, IRepositoryWrapper repository,IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            try
            {
                var clients = _repository.clients.GetAllClients();
                _logger.LogInfo($"Returned all clients from Database");

                var clientsResult = _mapper.Map<IEnumerable<ClientViewRepo>>(clients);
                return Ok(clientsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetALLClients: {ex.Message}");
                return StatusCode(500, "Internal server Error");
            }
        }

        [HttpGet("{id}", Name = "ClientId")]
        public IActionResult GetclientsById(Guid id)
        {
            try
            {
                var clients = _repository.clients.GetClientsById(id);
                if (clients is null)
                {
                    _logger.LogError($"clients with id: {id}, hasn't been found in database");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned clients with id: {id}");
                    var clientsResult = _mapper.Map<ClientViewRepo>(clients);
                    return Ok(clientsResult);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside GetclientsById: {ex.Message}");
                return StatusCode(500, "Internal server Error");
            }
        }
        [HttpPost]
        public IActionResult Createclients([FromBody] ClientsCreateRepo clients)
        {
            try
            {
                if (clients is null)
                {
                    _logger.LogError("clients sent by you is null");
                    return BadRequest("clients object is null");
                }

                var clientsEntity = _mapper.Map<Clients>(clients);
                _repository.clients.CreateClients(clientsEntity);
                _repository.save();

                var createdclients = _mapper.Map<ClientViewRepo>(clientsEntity);
                return CreatedAtRoute("ClientId", new { Id = createdclients.Id }, createdclients);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside Createclients action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult Updateclients(Guid id, [FromBody] ClientsUpdateRepo clients)
        {
            try
            {
                if (clients is null)
                {
                    _logger.LogError("clients object sent from client is null.");
                    return BadRequest("clients object is null");
                }

                var clientsEntity = _repository.clients.GetClientsById(id);
                if (clientsEntity is null)
                {
                    _logger.LogError($"clients with id: {id}, hasn't been found in database.");
                    return NotFound();
                }

                _mapper.Map(clients, clientsEntity);

                _repository.clients.UpdateClients(clientsEntity);
                _repository.save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside Updateclients action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            try
            {
                var clients = _repository.clients.GetClientsById(id);
                if (clients == null)
                {
                    _logger.LogError($"clients with id: {id}, hasn't been found in db.");
                    return NotFound();
                }



                _repository.clients.DeleteClients(clients);
                _repository.save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Deleteclients action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
