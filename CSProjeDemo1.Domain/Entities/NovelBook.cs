using CSProjeDemo1.Domain.Enums;

namespace CSProjeDemo1.Domain.Entities
{
    public class NovelBook : Book
    {
        public string Genre { get; set; }
        public string LiteraryMovement { get; set; }

        public override BookType BookType => BookType.Novel;

        public NovelBook(string isbn, string title, string author, int publicationYear, string publisher, BookStatus status, string genre, string literaryMovement)
            : base(isbn, title, author, publicationYear, publisher, status)
        {
            Genre = genre;
            LiteraryMovement = literaryMovement;
        }
    }
} 