using CSProjeDemo1.Domain.Entities;
using CSProjeDemo1.Domain.Interfaces;

namespace CSProjeDemo1.Infrastructure.Repositories
{
    public class InMemoryMemberRepository : IMemberRepository
    {
        private readonly List<Member> _members;
        private int _lastMemberNumber = 0;

        public InMemoryMemberRepository()
        {
            _members = new List<Member>
            {
                new Member("M001", "John", "Doe", "john.doe@example.com", "555-0101"),
                new Member("M002", "Jane", "Smith", "jane.smith@example.com", "555-0102"),
                new Member("M003", "Michael", "Johnson", "michael.johnson@example.com", "555-0103"),
                new Member("M004", "Emily", "Brown", "emily.brown@example.com", "555-0104"),
                new Member("M005", "David", "Wilson", "david.wilson@example.com", "555-0105")
            };

            _lastMemberNumber = 5;
        }

        public Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return Task.FromResult(_members.AsEnumerable());
        }

        public Task<Member?> GetMemberByNumberAsync(string memberNumber)
        {
            return Task.FromResult(_members.FirstOrDefault(m => m.MemberNumber == memberNumber));
        }

        public Task<bool> AddMemberAsync(Member member)
        {
            _lastMemberNumber++;
            member.MemberNumber = $"M{_lastMemberNumber:D03}";
            _members.Add(member);
            return Task.FromResult(true);
        }

        public Task<bool> UpdateMemberAsync(Member member)
        {
            var index = _members.FindIndex(m => m.MemberNumber == member.MemberNumber);
            if (index == -1)
                return Task.FromResult(false);

            _members[index] = member;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteMemberAsync(string memberNumber)
        {
            var member = _members.FirstOrDefault(m => m.MemberNumber == memberNumber);
            if (member == null)
                return Task.FromResult(false);

            _members.Remove(member);
            return Task.FromResult(true);
        }
    }
} 