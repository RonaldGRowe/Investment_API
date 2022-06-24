using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestingAPI.Data;
using AutoMapper;
using InvestmentsAPI.DtoModels.Transaction;

namespace InvestingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly InvestmentContext _context;
        private readonly IMapper mapper;

        public TransactionController(InvestmentContext context)
        {
            _context = context;
            this.mapper = mapper;
        }

       
        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
          if (_context.Transactions == null)
          {
              return NotFound();
          }
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionCreateDto>> PostTransaction(TransactionCreateDto transactionDto)
        {
            var transaction = mapper.Map<Transaction>(transactionDto);
            if (transaction == null)
          {
              return Problem("Entity set 'InvestmentContext.Transactions'  is null.");
          }
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = transaction.TransactionId }, transaction);
        }

       

        private bool TransactionExists(int id)
        {
            return (_context.Transactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
