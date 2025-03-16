using CSProjeDemo1.Domain.Enums;

namespace CSProjeDemo1.Domain.Entities;

public class HistoryBook : Book
{
    public string Period { get; set; }
    public string Region { get; set; }
    public override BookType BookType => BookType.History;
    public HistoryBook(string isbn, string title, string author, int publicationYear, string publisher, BookStatus status, string period, string region)
        : base(isbn, title, author, publicationYear, publisher, status)
    {
        Period = period;
        Region = region;
    }
}
