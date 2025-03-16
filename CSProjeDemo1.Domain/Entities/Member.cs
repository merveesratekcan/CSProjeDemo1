using CSProjeDemo1.Domain.Enums;
using CSProjeDemo1.Domain.Interfaces;

namespace CSProjeDemo1.Domain.Entities;

public class Member : IMember
{
    public string MemberNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public ICollection<Book> BorrowedBooks { get; private set; }
    public DateTime MembershipDate { get; set; }
    public Member(string memberNumber, string firstName, string lastName, string email, string phone)
    {
        MemberNumber = memberNumber;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        BorrowedBooks = new List<Book>();
        MembershipDate = DateTime.Now;
    }
    public bool BorrowBook(Book book)
    {
        if (book.Status != BookStatus.Available)
            return false;

        book.Status = BookStatus.Borrowed;
        BorrowedBooks.Add(book);
        return true;
    }
    public bool ReturnBook(Book book)
    {
        if (!BorrowedBooks.Contains(book))
            return false;

        book.Status = BookStatus.Available;
        BorrowedBooks.Remove(book);
        return true;
    }
    public List<Book> ListBorrowedBooks()
    {
        return BorrowedBooks.ToList();
    }
}
