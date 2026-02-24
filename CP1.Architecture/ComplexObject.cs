namespace CP1.Architecture;

/// <summary>
/// Standard wrapper object used by the backends (API/Minimal) and consumed by Web.
/// Mirrors the "ComplexObject" pattern used in class.
/// </summary>
public class ComplexObject
{
    public bool Success { get; set; }

    // Random identifier (kept to match the existing class pattern).
    public string Identifier => _uniqueIdentifier;
    private readonly string _uniqueIdentifier = Guid.NewGuid().ToString();

    public IEnumerable<object> Entities { get; set; } = new List<object>();

    public List<string> Errors { get; set; } = new();
}
