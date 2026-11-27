namespace Odyssey.Application.Exceptons;

public class UserNameAlreadyExistsExeption : Exception
{
    public UserNameAlreadyExistsExeption(string message) : base(message) { }
}