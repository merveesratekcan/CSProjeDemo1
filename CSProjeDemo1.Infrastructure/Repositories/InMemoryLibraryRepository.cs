using CSProjeDemo1.Domain.Entities;
using CSProjeDemo1.Domain.Enums;
using CSProjeDemo1.Domain.Interfaces;
using ILibraryRepository = CSProjeDemo1.Application.Interfaces.ILibraryRepository;

namespace CSProjeDemo1.Infrastructure.Repositories
{
    public class InMemoryLibraryRepository : ILibraryRepository
    {
        private readonly List<Book> _books;
        private readonly List<Member> _members;

        public InMemoryLibraryRepository()
        {
            _books = new List<Book>
            {
                // Science Books
                new ScienceBook("S001", "The Origin of Species", "Charles Darwin", 1859, "Scientific Press", BookStatus.Available, "Biology", "Evolution"),
                new ScienceBook("S002", "A Brief History of Time", "Stephen Hawking", 1988, "Bantam Books", BookStatus.Available, "Physics", "Cosmology"),
                new ScienceBook("S003", "The Selfish Gene", "Richard Dawkins", 1976, "Oxford Press", BookStatus.Available, "Biology", "Genetics"),
                new ScienceBook("S004", "The Double Helix", "James Watson", 1968, "Atheneum Press", BookStatus.Available, "Biology", "DNA"),
                new ScienceBook("S005", "Silent Spring", "Rachel Carson", 1962, "Houghton Mifflin", BookStatus.Available, "Environmental Science", "Ecology"),

                // Novel Books
                new NovelBook("N001", "1984", "George Orwell", 1949, "Secker and Warburg", BookStatus.Available, "Dystopian", "Modern"),
                new NovelBook("N002", "Pride and Prejudice", "Jane Austen", 1813, "T. Egerton", BookStatus.Available, "Romance", "Victorian"),
                new NovelBook("N003", "The Great Gatsby", "F. Scott Fitzgerald", 1925, "Scribner's", BookStatus.Available, "Literary Fiction", "Modern"),
                new NovelBook("N004", "One Hundred Years of Solitude", "Gabriel García Márquez", 1967, "Harper", BookStatus.Available, "Magical Realism", "Contemporary"),
                new NovelBook("N005", "To Kill a Mockingbird", "Harper Lee", 1960, "J. B. Lippincott", BookStatus.Available, "Southern Gothic", "Modern"),

                // History Books
                new HistoryBook("H001", "The Rise and Fall of the Third Reich", "William L. Shirer", 1960, "Simon & Schuster", BookStatus.Available, "20th Century", "Europe"),
                new HistoryBook("H002", "A People's History of the United States", "Howard Zinn", 1980, "Harper & Row", BookStatus.Available, "American History", "North America"),
                new HistoryBook("H003", "The Guns of August", "Barbara W. Tuchman", 1962, "Macmillan", BookStatus.Available, "World War I", "Europe"),
                new HistoryBook("H004", "SPQR: A History of Ancient Rome", "Mary Beard", 2015, "Profile Books", BookStatus.Available, "Ancient History", "Europe"),
                new HistoryBook("H005", "The Ottoman Empire", "Halil İnalcık", 1973, "Phoenix", BookStatus.Available, "Medieval History", "Middle East")
            };

            _members = new List<Member>
            {
                new Member("M001", "John", "Doe", "john@email.com", "5551234567"),
                new Member("M002", "Jane", "Smith", "jane@email.com", "5557654321"),
                new Member("M003", "Michael", "Johnson", "michael@email.com", "5559876543"),
                new Member("M004", "Emily", "Brown", "emily@email.com", "5553456789"),
                new Member("M005", "David", "Wilson", "david@email.com", "5552345678")
            };
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return Task.FromResult(_books.AsEnumerable());
        }

        public Task<Book> GetBookByIsbnAsync(string isbn)
        {
            return Task.FromResult(_books.FirstOrDefault(b => b.ISBN == isbn));
        }

        public Task<IEnumerable<Book>> GetAvailableBooksAsync()
        {
            return Task.FromResult(_books.Where(b => b.Status == BookStatus.Available));
        }

        public Task<IEnumerable<Book>> GetBorrowedBooksAsync()
        {
            return Task.FromResult(_books.Where(b => b.Status == BookStatus.Borrowed));
        }

        public Task<bool> UpdateBookStatusAsync(string isbn, BookStatus newStatus)
        {
            var book = _books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null) return Task.FromResult(false);
            
            book.Status = newStatus;
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Book>> GetBooksByTypeAsync(BookType type)
        {
            return Task.FromResult(_books.Where(b => b.BookType == type));
        }

        public Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
        {
            return Task.FromResult(_books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)));
        }

        public Task<IEnumerable<IMember>> GetAllMembersAsync()
        {
            return Task.FromResult(_members.AsEnumerable<IMember>());
        }

        public Task<IMember> GetMemberByNumberAsync(string memberNumber)
        {
            return Task.FromResult(_members.FirstOrDefault(m => m.MemberNumber == memberNumber) as IMember);
        }

        public Task<bool> CreateMemberAsync(IMember member)
        {
            if (_members.Any(m => m.MemberNumber == member.MemberNumber))
                return Task.FromResult(false);

            _members.Add(member as Member);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateMemberAsync(IMember member)
        {
            var index = _members.FindIndex(m => m.MemberNumber == member.MemberNumber);
            if (index == -1) return Task.FromResult(false);

            _members[index] = member as Member;
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Book>> GetMemberBorrowedBooksAsync(string memberNumber)
        {
            var member = _members.FirstOrDefault(m => m.MemberNumber == memberNumber);
            return member != null 
                ? Task.FromResult(member.BorrowedBooks.AsEnumerable())
                : Task.FromResult(Enumerable.Empty<Book>());
        }

        public Task<bool> LendBookAsync(string memberNumber, string isbn)
        {
            var member = _members.FirstOrDefault(m => m.MemberNumber == memberNumber);
            var book = _books.FirstOrDefault(b => b.ISBN == isbn);

            if (member == null || book == null || book.Status != BookStatus.Available)
                return Task.FromResult(false);

            book.Status = BookStatus.Borrowed;
            book.BorrowedByMemberNumber = memberNumber;
            member.BorrowedBooks.Add(book);
            return Task.FromResult(true);
        }

        public Task<bool> ReturnBookAsync(string memberNumber, string isbn)
        {
            var member = _members.FirstOrDefault(m => m.MemberNumber == memberNumber);
            var book = _books.FirstOrDefault(b => b.ISBN == isbn && b.Status == BookStatus.Borrowed && b.BorrowedByMemberNumber == memberNumber);
            
            if (member == null || book == null)
                return Task.FromResult(false);

            book.Status = BookStatus.Available;
            book.BorrowedByMemberNumber = null;
            member.BorrowedBooks.Remove(book);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Book>> GetBorrowedBooksByMemberAsync(string memberNumber)
        {
            var member = _members.FirstOrDefault(m => m.MemberNumber == memberNumber);
            return member != null 
                ? Task.FromResult(member.BorrowedBooks.AsEnumerable())
                : Task.FromResult(Enumerable.Empty<Book>());
        }
    }
} 