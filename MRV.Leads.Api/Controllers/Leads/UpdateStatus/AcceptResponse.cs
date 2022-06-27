namespace MRV.Leads.Api.Controllers.Leads.UpdateStatus;

public class AcceptResponse
{
    public int LeadId { get; set; }
    public string LeadFullName { get; set; }
    public string LeadSuburb { get; set; }
    public string LeadZipCode { get; set; }
    public string LeadCategory { get; set; }
    public string LeadDescription { get; set; }
    public string LeadPhoneNumber { get; set; }
    public string LeadEmailAddress { get; set; }
    public decimal LeadPrice { get; set; }
    public DateTime LeadCreatedAt { get; set; }
    public DateTime LeadUpdatedAt { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
}