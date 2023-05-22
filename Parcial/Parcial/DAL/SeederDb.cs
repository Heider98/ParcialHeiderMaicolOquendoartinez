using Parcial.Controllers;
using Parcial.DAL.Entities;
using System.Diagnostics.Metrics;

namespace Parcial.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;
        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync() { 
        await _context.Database.EnsureCreatedAsync();
            await PopulateTicketsAsync();
        
        }

        private async Task PopulateTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 0; i <= 20; i++)
                {
                    _context.Tickets.Add(new Ticket
                    {
                        Id = new Guid(),
                        UseDate = null,
                        IsUsed = false,
                        EntranceGate = null    

                    }) ; 


                }
            }
            await _context.SaveChangesAsync();

        }
    }
}
