using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.ListAll;


public class ListAllController : BaseController
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
    [HttpGet("[controller]")]
    public async Task<ActionResult<List<Lead>>> Get()
    {
        return Ok(leads);
    }
    
}