﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial.DAL;
using Parcial.DAL.Entities;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly DataBaseContext _context;


        public TicketController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateCategory(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync(); 
            }
          
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ticket);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditCategory(Guid? id, Ticket ticket)
        {
            try
            {
                if (id != ticket.Id) return NotFound("Ticket not found");

                ticket.UseDate = DateTime.Now;   

                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync(); 
            }
          
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ticket);
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(Guid? id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(c => c.Id == id);

            if (ticket == null) return NotFound();

            return Ok(ticket);
        }
    }
}
