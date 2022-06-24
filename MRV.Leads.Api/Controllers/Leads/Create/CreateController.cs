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
            Name = request.Name,
            Suburb = request.Suburb,
            ZipCode = request.ZipCode,
            Category = request.Category,
            Description = request.Description,
            Price = request.Price,
            Status = _context.LeadStatus.FirstOrDefault(l => l.Name == "Created"),
        };
        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();
        return Ok(lead);
    }
    
}