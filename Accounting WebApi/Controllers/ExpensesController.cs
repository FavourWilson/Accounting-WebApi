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
    [Route("api/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ExpensesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllExpenses()
        {
            try
            {
                var expenses = _repository.expenses.GetExpenses();
                _logger.LogInfo($"Returned all expenses from Database");

                var expensesResult = _mapper.Map<IEnumerable<ExpenseViewRepo>>(expenses);
                return Ok(expensesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetALLExpenses: {ex.Message}");
                return StatusCode(500, "Internal server Error");
            }
        }

        [HttpGet("{id}", Name ="ExpenseId")]
        public IActionResult GetExpenseById(Guid id)
        {
            try
            {
                var expense = _repository.expenses.GetExpensesById(id);
                if(expense is null)
                {
                    _logger.LogError($"Expense with id: {id}, hasn't been found in database");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Expense with id: {id}");
                    var expenseResult = _mapper.Map<ExpenseViewRepo>(expense);
                    return Ok(expenseResult);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside GetExpenseById: {ex.Message}");
                return StatusCode(500, "Internal server Error");
            }
        }
        [HttpPost]
        public IActionResult CreateExpense([FromBody] ExpenseCreateRepo expense)
        {
            try
            {
                if(expense is null)
                {
                    _logger.LogError("Expense sent by you is null");
                    return BadRequest("expense object is null");
                }

                var expenseEntity = _mapper.Map<Expenses>(expense);
                _repository.expenses.CreateExpenses(expenseEntity);
                _repository.save();

                var createdExpense = _mapper.Map<ExpenseViewRepo>(expenseEntity);
                return CreatedAtRoute("ExpenseId", new { Id = createdExpense.Id }, createdExpense);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside CreateExpense action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateExpense(Guid id, [FromBody] ExpenseUpdateRepo expense)
        {
            try
            {
                if(expense is null)
                {
                    _logger.LogError("Expense object sent from client is null.");
                    return BadRequest("Expense object is null");
                }

                var expenseEntity = _repository.expenses.GetExpensesById(id);
                if (expenseEntity is null)
                {
                    _logger.LogError($"Expense with id: {id}, hasn't been found in database.");
                    return NotFound();
                }

                _mapper.Map(expense, expenseEntity);

                _repository.expenses.UpdateExpenses(expenseEntity);
                _repository.save();

                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside UpdateExpense action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOwner(Guid id)
        {
            try
            {
                var expense = _repository.expenses.GetExpensesById(id);
                if (expense == null)
                {
                    _logger.LogError($"expense with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

              

                _repository.expenses.DeleteExpenses(expense);
                _repository.save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteExpense action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
