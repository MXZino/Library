namespace Library.Errors;

public class ErrorDetails
{
    public string Message { get; set; } = "Unspecified error occured. Please contact with administrator!";
    
    public string InnerException { get; set; }
    
    public string TraceId { get; set; }
    
    public string UrlPath { get; set; }
}