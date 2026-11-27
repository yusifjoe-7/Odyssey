namespace Odyssey.Application.Exceptons;

public class UnkownRoleException : Exception
{
    public UnkownRoleException(string message) : base(message) { }
}
