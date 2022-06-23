namespace MRV.Leads.Api.Contracts.Entities;

public abstract class ListSet
{
    public int TotalPages { get; set; } = 1;
    public int TotalRows { get; set; } = 1;
    public int Offset { get; set; } = 1;
    public int? Limit { get; set; }
}