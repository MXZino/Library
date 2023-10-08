using System.Net;

namespace Library.Errors.Abstract.Base;

public abstract class BaseAppException : Exception
{
    public virtual HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;

    public string Message { get; set; } = "Unspecified error occured. Please contact with administrator!";
    
    public Exception InnerException { get; set; }
}