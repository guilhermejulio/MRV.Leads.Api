using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.GetById;


public class GetByIdController : BaseController
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
    [HttpGet("[controller]/{id}")]
    public async Task<ActionResult<Lead>> Get(Guid id)
    {
        var lead = leads.Find(x => x.Id == id);
        if (lead == null)
        {
            return BadRequest("Lead not found");
        }

        return Ok(lead);
    }
    
}