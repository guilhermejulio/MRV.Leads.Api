using Microsoft.AspNetCore.Mvc;

namespace MRV.Leads.Api.Controllers.Leads.Statistics;

public class GetStatisticsController : BaseController
{
    private readonly DataContext _context;

    public GetStatisticsController(DataContext context)
    {
        _context = context;
    }
    [HttpGet("[controller]")]
    public async Task<ActionResult<Statistic>> Get()
    {
        Statistic statistic = new Statistic();
        statistic.AcceptedLeads = _context.Leads.Count(l =>
            l.Status.Id == (_context.LeadStatus.FirstOrDefault(l => l.Name == "Accepted").Id));
        statistic.RejectLeads = _context.Leads.Count(l =>
            l.Status.Id == (_context.LeadStatus.FirstOrDefault(l => l.Name == "Declined").Id));
        statistic.InviteLeads = _context.Leads.Count();

        return Ok(statistic);
    }
}