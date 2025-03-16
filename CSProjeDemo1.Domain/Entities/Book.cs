using CSProjeDemo1.Domain.Enums;

namespace CSProjeDemo1.Domain.Entities;

public abstract class Book
{
    public string ISBN { get; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
    public BookStatus Status { get; set; }
    public string Publisher { get; set; }
    public int PageCount { get; set; }
    public string? BorrowedByMemberNumber { get; set; }
    public abstract BookType BookType { get; }
    protected Book(string isbn, string title, string author, int publicationYear, string publisher, BookStatus status)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        Publisher = publisher;
        Status = status;
        BorrowedByMemberNumber = null;
    }
}
