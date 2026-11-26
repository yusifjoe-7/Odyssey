using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Domain.Support;

public class Issue
{
    public int Id { get; set;}

    public int ClientId { get; set; }
    public Client clinet { get; set; }
    
    public int? AssignedAdminId { get; set; }
    public Admin? AssignedAdmin { get; set; }

    public IssueStatus issueStatus {get; set;} = IssueStatus.Open;
}
