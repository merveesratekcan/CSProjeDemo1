using System.Collections.Generic;
using System.Threading.Tasks;
using CSProjeDemo1.Domain.Entities;
using CSProjeDemo1.Domain.Enums;
using CSProjeDemo1.Domain.Interfaces;

namespace CSProjeDemo1.Application.Interfaces
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIsbnAsync(string isbn);
        Task<IEnumerable<Book>> GetAvailableBooksAsync();
        Task<IEnumerable<Book>> GetBorrowedBooksAsync();
        Task<bool> UpdateBookStatusAsync(string isbn, BookStatus newStatus);
        Task<IEnumerable<Book>> GetBooksByTypeAsync(BookType type);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
        Task<IEnumerable<IMember>> GetAllMembersAsync();
        Task<IMember> GetMemberByNumberAsync(string memberNumber);
        Task<bool> CreateMemberAsync(IMember member);
        Task<bool> UpdateMemberAsync(IMember member);
        Task<IEnumerable<Book>> GetMemberBorrowedBooksAsync(string memberNumber);
        Task<bool> LendBookAsync(string memberNumber, string isbn);
        Task<bool> ReturnBookAsync(string memberNumber, string isbn);
        Task<IEnumerable<Book>> GetBorrowedBooksByMemberAsync(string memberNumber);
    }
} 