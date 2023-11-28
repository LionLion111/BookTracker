using System.Net;

namespace BookTracker.BusinessLogic.Exceptions.Base;

public abstract class ValidationException : BookTrackerException
{
    public ValidationException(string? message) : base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    public override string Description => "Invalid data provided";
}
