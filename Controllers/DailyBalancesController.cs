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
    public class DailyBalancesController : ControllerBase
    {
        private readonly PersonalFinanceManagementDBContext _context;

        public DailyBalancesController(PersonalFinanceManagementDBContext context)
        {
            _context = context;
        }

        // GET: api/DailyBalances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyBalance>>> GetDailyBalance()
        {
            return await _context.DailyBalance.ToListAsync();
        }

        // GET: api/DailyBalances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyBalance>> GetDailyBalance(int id)
        {
            var dailyBalance = await _context.DailyBalance.FindAsync(id);

            if (dailyBalance == null)
            {
                return NotFound();
            }

            return dailyBalance;
        }

        // PUT: api/DailyBalances/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyBalance(int id, DailyBalance dailyBalance)
        {
            if (id != dailyBalance.DailyId)
            {
                return BadRequest();
            }

            _context.Entry(dailyBalance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyBalanceExists(id))
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

        // POST: api/DailyBalances
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DailyBalance>> PostDailyBalance(DailyBalance dailyBalance)
        {
            _context.DailyBalance.Add(dailyBalance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyBalance", new { id = dailyBalance.DailyId }, dailyBalance);
        }

        // DELETE: api/DailyBalances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyBalance>> DeleteDailyBalance(int id)
        {
            var dailyBalance = await _context.DailyBalance.FindAsync(id);
            if (dailyBalance == null)
            {
                return NotFound();
            }

            _context.DailyBalance.Remove(dailyBalance);
            await _context.SaveChangesAsync();

            return dailyBalance;
        }

        private bool DailyBalanceExists(int id)
        {
            return _context.DailyBalance.Any(e => e.DailyId == id);
        }
    }
}
