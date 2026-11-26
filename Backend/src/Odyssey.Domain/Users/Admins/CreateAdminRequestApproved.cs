namespace Odyssey.Domain.Users.Admins;

public class CreateAdminRequestApproved
{
    public int Id { get; set; }

    public int AdminId { get; set; }
    public Admin admin { get; set; }

    public string ApprovedWithCode {get; set;}
}
