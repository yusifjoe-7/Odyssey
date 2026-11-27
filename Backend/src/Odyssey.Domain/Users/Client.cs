using Odyssey.Domain.Support;

namespace Odyssey.Domain.Users;

public class Client : User
{
    public string UserName {get; set;} // unique 
    public ICollection<Issue> OpendIssues {get; set;} = new List<Issue>();
}
