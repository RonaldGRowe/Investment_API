using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestingAPI.Data;
using AutoMapper;
using InvestmentsAPI.DtoModels.Account;

namespace InvestingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly InvestmentContext _context;
        private readonly IMapper mapper;

        public AccountController(InvestmentContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;

        }



        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountsGetDto>>> GetAccounts()
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }

            var account = await _context.Accounts.ToListAsync();
            var accountDto = mapper.Map<IEnumerable<AccountsGetDto>>(account);

            return Ok(accountDto);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountsGetDto>> GetAccount(int id)
        {
          if (_context.Accounts == null)
          {
              return NotFound();
          }
            var account = await _context.Accounts.FindAsync(id);
            
            if (account == null)
            {
                return NotFound();
            }
            var accountIdDto = mapper.Map<AccountsGetDto>(account);

            return accountIdDto;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, AccountEditDto accountDto)
        {
            accountDto.AccountId = id;
            var account = mapper.Map<Account>(accountDto);
            if (id != account.AccountId)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(AccountCreateDto accountDto)
        {
            var account = mapper.Map<Account>(accountDto);
            if (account == null)
          {
              return Problem("Entity set 'InvestmentContext.Accounts'  is null.");
          }
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.AccountId }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            if (_context.Accounts == null)
            {
                return NotFound();
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return (_context.Accounts?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}
