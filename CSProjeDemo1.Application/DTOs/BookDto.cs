using CSProjeDemo1.Domain.Enums;

namespace CSProjeDemo1.Application.DTOs
{

    public class BookDto
    {
        public required string ISBN { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public int PublicationYear { get; set; }
        public BookStatus Status { get; set; }
        public required string Publisher { get; set; }
        public int PageCount { get; set; }
        public required string BookType { get; set; }
        public bool IsAvailable { get; set; }
        public string? BorrowedByMemberNumber { get; set; }

        // Science 
        public string? ScientificField { get; set; }
        public string? ResearchArea { get; set; }

        // Novel 
        public string? Genre { get; set; }
        public string? LiteraryMovement { get; set; }

        // History 
        public string? Period { get; set; }
        public string? Region { get; set; }
    }

    public class ScienceBookDto : BookDto
    {
        public string ScientificField { get; set; }
        public string ResearchArea { get; set; }
    }

 
    public class NovelBookDto : BookDto
    {
        public string Genre { get; set; }
        public string LiteraryMovement { get; set; }
    }


    public class HistoryBookDto : BookDto
    {
        public string Period { get; set; }
        public string Region { get; set; }
    }
} 