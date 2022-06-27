using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.ListAllAccepted;

public class ListAllAcceptedController : BaseController
{
    private readonly DataContext _context;

    public ListAllAcceptedController(DataContext context)
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
                    LeadFullName= lead.FullName,
                    LeadSuburb = lead.Suburb,
                    LeadZipCode = lead.ZipCode,
                    LeadCategory = lead.Category,
                    LeadDescription = lead.Description,
                    LeadPhoneNumber = lead.PhoneNumber,
                    LeadEmailAddress = lead.EmailAddress,
                    LeadPrice = lead.Price,
                    LeadCreatedAt = lead.CreatedAt,
                    LeadUpdatedAt = lead.UpdatedAt,
                    StatusId = status.Id,
                    StatusName = status.Name,
                }).Where(l => l.StatusName == "Accepted").OrderByDescending(l => l.LeadCreatedAt).ToListAsync());
    }
}