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
    public async Task<ActionResult<Lead>> AcceptLead(int id)
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

        return Ok(lead);
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

        return Ok(lead);
    }
    
}