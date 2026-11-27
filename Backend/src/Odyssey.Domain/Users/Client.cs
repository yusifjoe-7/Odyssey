using Odyssey.Domain.Support;

namespace Odyssey.Domain.Users;

public class Client : User
{
    public ICollection<Issue> OpendIssues {get; set;} = new List<Issue>();
}
