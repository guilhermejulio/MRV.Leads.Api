using Microsoft.AspNetCore.Mvc;
using MRV.Leads.Api.Models;

namespace MRV.Leads.Api.Controllers.Leads.GetById;


public class GetByIdController : BaseController
{
    private readonly DataContext _context;

    public GetByIdController(DataContext context)
    {
        _context = context;
    }
    [HttpGet("[controller]/{id}")]
    public async Task<ActionResult<Lead>> Get(int id)
    {
        var lead = await _context.Leads.FindAsync(id);
        if (lead == null)
        {
            return BadRequest("Lead not found");
        }
        return Ok(lead);
    }
    
}