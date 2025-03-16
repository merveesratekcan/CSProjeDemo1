using AutoMapper;
using CSProjeDemo1.Application.DTOs;
using CSProjeDemo1.Application.Interfaces;
using CSProjeDemo1.Domain.Entities;
using CSProjeDemo1.Domain.Enums;
using CSProjeDemo1.Domain.Interfaces;
using ILibraryRepository = CSProjeDemo1.Application.Interfaces.ILibraryRepository;

namespace CSProjeDemo1.Application.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public LibraryService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _libraryRepository.GetAllBooksAsync();
            return books.Select(book => MapBookToDto(book));
        }

        public async Task<BookDto> GetBookByIsbnAsync(string isbn)
        {
            var book = await _libraryRepository.GetBookByIsbnAsync(isbn);
            return book != null ? MapBookToDto(book) : null;
        }

        public async Task<IEnumerable<BookDto>> GetAvailableBooksAsync()
        {
            var books = await _libraryRepository.GetAvailableBooksAsync();
            return books.Select(book => MapBookToDto(book));
        }

        public async Task<IEnumerable<BookDto>> GetBorrowedBooksAsync()
        {
            var books = await _libraryRepository.GetBorrowedBooksAsync();
            return books.Select(book => MapBookToDto(book));
        }

        public async Task<BookDto> UpdateBookStatusAsync(string isbn, BookStatus newStatus)
        {
            var book = await _libraryRepository.GetBookByIsbnAsync(isbn);
            if (book == null)
                return null;

            await _libraryRepository.UpdateBookStatusAsync(isbn, newStatus);
            return MapBookToDto(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksByTypeAsync(BookType type)
        {
            var books = await _libraryRepository.GetBooksByTypeAsync(type);
            return books.Select(book => MapBookToDto(book));
        }

        public async Task<IEnumerable<BookDto>> GetBooksByAuthorAsync(string author)
        {
            var books = await _libraryRepository.GetBooksByAuthorAsync(author);
            return books.Select(book => MapBookToDto(book));
        }

        private BookDto MapBookToDto(Book book)
        {
            return book switch
            {
                ScienceBook scienceBook => _mapper.Map<ScienceBookDto>(scienceBook),
                NovelBook novelBook => _mapper.Map<NovelBookDto>(novelBook),
                HistoryBook historyBook => _mapper.Map<HistoryBookDto>(historyBook),
                _ => _mapper.Map<BookDto>(book)
            };
        }
    }
} 