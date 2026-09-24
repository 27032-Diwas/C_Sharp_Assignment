namespace AdvanceTopics.Tasks;

/// <summary>
/// Represents a book record.
/// </summary>
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
public record Book(string Title, string Author, string ISBN);
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter