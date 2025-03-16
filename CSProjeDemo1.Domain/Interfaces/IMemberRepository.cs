using CSProjeDemo1.Domain.Entities;

namespace CSProjeDemo1.Domain.Interfaces
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<Member?> GetMemberByNumberAsync(string memberNumber);
        Task<bool> AddMemberAsync(Member member);
        Task<bool> UpdateMemberAsync(Member member);
        Task<bool> DeleteMemberAsync(string memberNumber);
    }
} 