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
    public async Task<ActionResult<Lead>> CreateLead(RequestSet request)
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
        
        
        return Ok(lead);
    }
    
}