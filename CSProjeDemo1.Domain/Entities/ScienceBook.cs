using CSProjeDemo1.Domain.Enums;

namespace CSProjeDemo1.Domain.Entities
{
    public class ScienceBook : Book
    {
        public string ScientificField { get; set; }
        public string ResearchArea { get; set; }

        public override BookType BookType => BookType.Science;

        public ScienceBook(string isbn, string title, string author, int publicationYear, string publisher, BookStatus status, string scientificField, string researchArea)
            : base(isbn, title, author, publicationYear, publisher, status)
        {
            ScientificField = scientificField;
            ResearchArea = researchArea;
        }
    }
} 