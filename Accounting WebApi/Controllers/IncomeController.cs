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
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public IncomeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllIncomes()
        {
            try
            {
                var Incomes = _repository.income.GetIncomes();
                _logger.LogInfo($"Returned all Incomes from Database");

                var IncomesResult = _mapper.Map<IEnumerable<IncomeViewRepo>>(Incomes);
                return Ok(IncomesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetALLIncomes: {ex.Message}");
                return StatusCode(500, "Internal server Error");
            }
        }

        [HttpGet("{id}", Name = "IncomeId")]
        public IActionResult GetIncomeById(Guid id)
        {
            try
            {
                var Income = _repository.income.GetIncomeById(id);
                if (Income is null)
                {
                    _logger.LogError($"Income with id: {id}, hasn't been found in database");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Income with id: {id}");
                    var IncomeResult = _mapper.Map<IncomeViewRepo>(Income);
                    return Ok(IncomeResult);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside GetIncomeById: {ex.Message}");
                return StatusCode(500, "Internal server Error");
            }
        }
        [HttpPost]
        public IActionResult CreateIncome([FromBody] IncomeCreateRepo Income)
        {
            try
            {
                if (Income is null)
                {
                    _logger.LogError("Income sent by you is null");
                    return BadRequest("Income object is null");
                }

                var IncomeEntity = _mapper.Map<Income>(Income);
                _repository.income.CreateIncome(IncomeEntity);
                _repository.save();

                var createdIncome = _mapper.Map<IncomeViewRepo>(IncomeEntity);
                return CreatedAtRoute("IncomeId", new { Id = createdIncome.Id }, createdIncome);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside CreateIncome action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateIncome(Guid id, [FromBody] IncomeUpdateRepo Income)
        {
            try
            {
                if (Income is null)
                {
                    _logger.LogError("Income object sent from client is null.");
                    return BadRequest("Income object is null");
                }

                var IncomeEntity = _repository.income.GetIncomeById(id);
                if (IncomeEntity is null)
                {
                    _logger.LogError($"Income with id: {id}, hasn't been found in database.");
                    return NotFound();
                }

                _mapper.Map(Income, IncomeEntity);

                _repository.income.UpdateIncome(IncomeEntity);
                _repository.save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside UpdateIncome action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            try
            {
                var Income = _repository.income.GetIncomeById(id);
                if (Income == null)
                {
                    _logger.LogError($"Income with id: {id}, hasn't been found in db.");
                    return NotFound();
                }



                _repository.income.DeleteIncome(Income);
                _repository.save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteIncome action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
