using CSProjeDemo1.Domain.Entities;

namespace CSProjeDemo1.Domain.Interfaces
{
    public interface IMember
    {
        string MemberNumber { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        ICollection<Book> BorrowedBooks { get; }
        DateTime MembershipDate { get; set; }
        bool BorrowBook(Book book);
        bool ReturnBook(Book book);
        List<Book> ListBorrowedBooks();
    }
} 