namespace Odyssey.Application.Exceptons;

public class EmailAlreadyExistsException : Exception
{
    public EmailAlreadyExistsException(string message) : base(message) { }
}
