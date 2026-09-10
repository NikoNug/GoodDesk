using GoodDesk.DataAccess;
using GoodDesk.DataModel;
using GoodDesk.ViewModel.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace GoodDesk.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TicketController : ControllerBase
    {
        private readonly GoodDeskDBContext _context;

        public TicketController(GoodDeskDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var tickets = await _context.TBLMTickets
                .Include(t => t.Requester)
                .Include(t => t.AssignedTo)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Select(t => new VMTicketList
                {
                    ID = t.ID,
                    TicketNumber = t.TicketNumber,
                    Subject = t.Subject,
                    Requester = t.Requester.Username,
                    AssignedTo = t.AssignedTo != null ? t.AssignedTo.Username : null,
                    Category = t.Category.CategoryName,
                    Priority = t.Priority.PriorityName,
                    Status = t.Status.StatusName,
                    CreatedDate = t.CreatedDate
                }).ToListAsync();

            return Ok(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(VMTicketCreate request)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userIdClaim == null) return Unauthorized();

            var requesterId = int.Parse(userIdClaim);

            var categoryExists = await _context.TBLMCategories.AnyAsync(c => c.ID == request.CategoryID && !c.IsDeleted);

            if (!categoryExists) return BadRequest("Category not found.");

            var priorityExists = await _context.TBLMPriorities.AnyAsync(p => p.ID == request.PriorityID && p.IsActive);

            if (!priorityExists) return BadRequest("Priority not found.");

            var ticket = new TBLTTicket
            {
                TicketNumber = "TEMP",
                Subject = request.Subject,
                Description = request.Description,
                RequesterID = requesterId,
                CategoryID = request.CategoryID,
                PriorityID = request.PriorityID,
                StatusID = 1,
                CreatedDate = DateTime.UtcNow
            };

            _context.TBLMTickets.Add(ticket);

            await _context.SaveChangesAsync();

            ticket.TicketNumber = $"GD-{ticket.ID:D6}";

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTickets), new { id = ticket.ID }, ticket);
        }
    }
}
