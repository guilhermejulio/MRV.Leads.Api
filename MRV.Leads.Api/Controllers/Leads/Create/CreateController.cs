using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.Create;


public class CreateController : BaseController
{
    private readonly DataContext _context;

    public CreateController(DataContext context)
    {
        _context = context;
    }
    [HttpPost("[controller]")]
    public async Task<ActionResult<List<Lead>>> CreateLead(RequestSet request)
    {
        Lead lead = new Lead
        {
            Name = request.LeadFirstName,
            LastName = request.LeadLastName,
            Suburb = request.LeadSuburb,
            ZipCode = request.LeadZipCode,
            Category = request.LeadCategory,
            Description = request.LeadDescription,
            Price = request.LeadPrice,
            PhoneNumber = request.LeadPhoneNumber,
            EmailAddress = request.LeadEmailAddress,
            Status = _context.LeadStatus.FirstOrDefault(l => l.Name == "Created"),
        };
        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();
        
        
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
                }).Where(l => l.StatusName == "Created").OrderByDescending(l => l.LeadCreatedAt).ToListAsync());
    }
    
}