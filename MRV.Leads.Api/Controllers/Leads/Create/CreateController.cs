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
    public async Task<ActionResult<InviteResponse>> CreateLead(InviteRequestSet request)
    {
        decimal discount = 0;
        if (request.LeadPrice > 500)
        {
            discount = request.LeadPrice * (decimal)0.10;
            request.LeadPrice -= discount;
        }
        Lead lead = new Lead
        {
            Name = request.LeadFirstName,
            LastName = request.LeadLastName,
            Suburb = request.LeadSuburb,
            ZipCode = request.LeadZipCode,
            Category = request.LeadCategory,
            Description = request.LeadDescription,
            Price = request.LeadPrice,
            Discount = discount,
            PhoneNumber = request.LeadPhoneNumber,
            EmailAddress = request.LeadEmailAddress,
            Status = _context.LeadStatus.FirstOrDefault(l => l.Name == "Created"),
        };
        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();
        
        
        return Ok(new InviteResponse
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
            StatusId = lead.Status.Id,
            StatusName = lead.Status.Name
        });
    }
    
}