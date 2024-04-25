using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceManagementAPI.Models;

namespace PersonalFinanceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly PersonalFinanceManagementDBContext _context;

        public TransactionsController(PersonalFinanceManagementDBContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransaction()
        {
            
            return await _context.Transaction.ToListAsync();
        }
        
        // GET: api/Transactions/5
        [HttpGet("{transID}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int transID)
        {
            var transaction = await _context.Transaction.FindAsync(transID);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // GET: api/Transactions/users/5
        [HttpGet("/users/{userid}")]
        public async Task<ActionResult<List<Transaction>>> GetUserTransaction(int userid)
        {
            var transaction = await _context.Transaction
                .Where(t => t.UserId == userid)
                .ToListAsync();
               

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        } // GET: api/Transactions/users/5
        [HttpGet("/users/{userid}/summary")]
        public async Task<ActionResult<List<TransactionSummaryDtoResponse>>> GetUserTransactionSummary(int userid)
        {
            var transactionSummary = await _context.Transaction
                .Where(t => t.UserId == userid)
                .GroupBy(t => new { CategoryId = t.CategoryId ?? 0 })
                .Select(g => new TransactionSummaryDtoResponse
                {
                    CategoryId = g.Key.CategoryId,
                    CategoryName = _context.Category.FirstOrDefault(c => c.CategoryId == g.Key.CategoryId).CategoryName,
                    TotalSum = g.Sum(t => t.Amount ?? 0)
                })
                .ToListAsync();

            if (transactionSummary == null || transactionSummary.Any(ts => ts.CategoryName == null))
            {
                return NotFound();
            }

            return transactionSummary;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transactions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaction>> DeleteTransaction(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transaction.Remove(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
    }
}
