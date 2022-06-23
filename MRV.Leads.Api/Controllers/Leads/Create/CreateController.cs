using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.Create;


public class CreateController : BaseController
{
    private static List<Lead> leads = new List<Lead>
    {
        new Lead
        {
            Id = Guid.NewGuid(),
            Name = "Gui",
            Suburb = "Ibirité",
            ZipCode = "324242",
            Category = "Developer",
            Description = "Web developer",
            Price = 52,
            Status = new LeadStatus(),
            CreatedAt = default,
            UpdatedAt = default
        }
    };
    [HttpPost("[controller]")]
    public async Task<ActionResult<List<Lead>>> CreateLead(Lead lead)
    {
        leads.Add(lead);
        return Ok(leads);
    }
    
}