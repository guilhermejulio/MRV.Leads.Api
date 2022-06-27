using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.UpdateStatus;


public class UpdateStatusController : BaseController
{
    private readonly DataContext _context;

    public UpdateStatusController(DataContext context)
    {
        _context = context;
    }
    [HttpPut("[controller]/accept/{id}")]
    public async Task<ActionResult<AcceptResponse>> AcceptLead(int id)
    {
        var lead = await _context.Leads.FindAsync(id);
        if (lead == null)
        {
            return BadRequest("Lead not found");
        }
        var acceptedStatus = _context.LeadStatus.FirstOrDefault(l => l.Name == "Accepted");
        lead.Status = acceptedStatus;
        lead.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        return Ok(new AcceptResponse
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
            StatusId = acceptedStatus.Id,
            StatusName = acceptedStatus.Name,
        });
    }
    
    [HttpPut("[controller]/decline/{id}")]
    public async Task<ActionResult<Lead>> DeclineLead(int id)
    {
        var lead = await _context.Leads.FindAsync(id);
        if (lead == null)
        {
            return BadRequest("Lead not found");
        }
        var acceptedStatus = _context.LeadStatus.FirstOrDefault(l => l.Name == "Declined");
        lead.Status = acceptedStatus;
        lead.UpdatedAt = DateTime.Now;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}