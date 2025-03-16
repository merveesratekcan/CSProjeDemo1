using CSProjeDemo1.Application.DTOs;

namespace CSProjeDemo1.Application.Interfaces
{

    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync();
        Task<MemberDto?> GetMemberByNumberAsync(string memberNumber);
        Task<bool> CreateMemberAsync(CreateMemberDto createMemberDto);
        Task<bool> UpdateMemberAsync(UpdateMemberDto updateMemberDto);
        Task<IEnumerable<BookDto>> GetMemberBorrowedBooksAsync(string memberNumber);
        Task<bool> BorrowBookAsync(string memberNumber, string isbn);
        Task<bool> ReturnBookAsync(string memberNumber, string isbn);
    }
} 