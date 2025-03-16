using CSProjeDemo1.Application.DTOs;
using CSProjeDemo1.Domain.Enums;

namespace CSProjeDemo1.Application.Interfaces
{

    public interface ILibraryService
    {
      
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIsbnAsync(string isbn);
        Task<IEnumerable<BookDto>> GetAvailableBooksAsync();
        Task<IEnumerable<BookDto>> GetBorrowedBooksAsync();
        Task<BookDto> UpdateBookStatusAsync(string isbn, BookStatus status);
        Task<IEnumerable<BookDto>> GetBooksByTypeAsync(BookType type);
        Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(string author);
    }
} 