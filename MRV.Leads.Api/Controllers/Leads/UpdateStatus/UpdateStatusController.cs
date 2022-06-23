using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.UpdateStatus;


public class UpdateStatusController : BaseController
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
    
    private static List<LeadStatus> leadsStatus = new List<LeadStatus>
    {
        new LeadStatus
        {
            Id = Guid.NewGuid(),
            Name = "Created"
        },
        new LeadStatus
        {
            Id = Guid.NewGuid(),
            Name = "Accepted"
        },
        new LeadStatus
        {
            Id = Guid.NewGuid(),
            Name = "Declined"
        }
    };
    
    [HttpPut("[controller]/accept/{id}")]
    public async Task<ActionResult<Lead>> AcceptLead(Guid id)
    {
        var lead = leads.Find(x => x.Id == id);
        if (lead == null)
        {
            return BadRequest("Lead not found");
        }

        var newStatus = leadsStatus.Find(x => x.Name == "Accepted");
        lead.Status = newStatus;

        return Ok(lead);
    }
    
    [HttpPut("[controller]/decline/{id}")]
    public async Task<ActionResult<Lead>> DeclineLead(Guid id)
    {
        var lead = leads.Find(x => x.Id == id);
        if (lead == null)
        {
            return BadRequest("Lead not found");
        }

        var newStatus = leadsStatus.Find(x => x.Name == "Declined");
        lead.Status = newStatus;

        return Ok(lead);
    }
    
}