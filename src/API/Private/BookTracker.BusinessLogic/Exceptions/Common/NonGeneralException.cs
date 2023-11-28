using BookTracker.BusinessLogic.Exceptions.Base;
using System.Net;

namespace BookTracker.BusinessLogic.Exceptions.Common;

public class NonGeneralException : BookTrackerException
{
    public NonGeneralException(string? message = null)
    {

    }
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
    public override int Code => (int)CommonCode.NonGeneral;
    public override string Description => "Internal server error";
}
