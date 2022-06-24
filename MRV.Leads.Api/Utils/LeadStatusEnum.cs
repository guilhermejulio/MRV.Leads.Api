using System.ComponentModel;

namespace MRV.Leads.Api.Utils;

public enum LeadStatusEnum
{
    [Description("Created")]
    Created = 1,
    [Description("Accepted")]
    Accepted = 2,
    [Description("Declined")]
    Declined = 3,
}