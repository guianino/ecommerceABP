namespace ecommerce;

public struct ExceptionsEcommerce
{
    private const string Default = "Exception:";
    public const string ValidationException = $"{Default}400:ValidationException";

    public struct CostumersExceptions
    {
    public const string CostumerAlreadyExist = $"{Default}409:CostumerAlreadyExist";
    public const string DocumentNull = $"{Default}409:FileDocumentNotNull";
    
    }

}