using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.ListAll;

public class ListAllController : BaseController
{
    private readonly DataContext _context;

    public ListAllController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("[controller]")]
    public async Task<ActionResult<List<Lead>>> Get()
    {
        return Ok(await _context.Leads
            .Join(_context.LeadStatus, lead => lead.Status.Id, status => status.Id,
                (lead, status) => new
                {
                    LeadId = lead.Id,
                    LeadFirstName = lead.Name,
                    LeadSuburb = lead.Suburb,
                    LeadZipCode = lead.ZipCode,
                    LeadCategory = lead.Category,
                    LeadDescription = lead.Description,
                    LeadPrice = lead.Price,
                    LeadCreatedAt = lead.CreatedAt,
                    LeadUpdatedAt = lead.UpdatedAt,
                    StatusId = status.Id,
                    StatusName = status.Name,
                }).ToListAsync());
    }
}