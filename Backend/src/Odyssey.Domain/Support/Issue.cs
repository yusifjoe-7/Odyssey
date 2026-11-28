using System;
using Odyssey.Domain.Users;
using Odyssey.Domain.Users.Admins;

namespace Odyssey.Domain.Support;

public class Issue
{
    public Guid Id { get; set;}

    public string ClientUserName { get; set; }
    public Client clinet { get; set; }
    
    public string? AssignedAdminUserName { get; set; }
    public Admin? AssignedAdmin { get; set; }

    public IssueStatus issueStatus {get; set;} = IssueStatus.Open;
}
