namespace MRV.Leads.Api.Models;

public class Lead
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Suburb { get; set; }
    public string ZipCode { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public LeadStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}