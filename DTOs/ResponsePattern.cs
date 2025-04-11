namespace RpgApi.DTOs;

public class ResponsePattern
{
    public string[] Messages { get; set; } = [];
    public object? ResponseObject { get; set; }

    public ResponsePattern(params string[] messages)
    {
        Messages = messages;
    }

    public ResponsePattern(object? responseObject, params string[] messages)
    {
        Messages = messages;
        ResponseObject = responseObject;
    }

    public ResponsePattern(object responseObject)
    {
        ResponseObject = responseObject;
    }
    
    public ResponsePattern()
    {
        
    }
}