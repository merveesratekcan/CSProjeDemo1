using AutoMapper;
using CSProjeDemo1.Application.DTOs;
using CSProjeDemo1.Application.Interfaces;
using CSProjeDemo1.Domain.Entities;
using CSProjeDemo1.Domain.Enums;
using CSProjeDemo1.Domain.Interfaces;
using ILibraryRepository = CSProjeDemo1.Application.Interfaces.ILibraryRepository;

namespace CSProjeDemo1.Application.Services
{
    public class MemberService : CSProjeDemo1.Application.Interfaces.IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, ILibraryRepository libraryRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync()
        {
            var members = await _memberRepository.GetAllMembersAsync();
            return _mapper.Map<IEnumerable<MemberDto>>(members);
        }

        public async Task<MemberDto?> GetMemberByNumberAsync(string memberNumber)
        {
            var member = await _memberRepository.GetMemberByNumberAsync(memberNumber);
            return member != null ? _mapper.Map<MemberDto>(member) : null;
        }

        public async Task<bool> CreateMemberAsync(CreateMemberDto createMemberDto)
        {
            var member = _mapper.Map<Member>(createMemberDto);
            return await _memberRepository.AddMemberAsync(member);
        }

        public async Task<bool> UpdateMemberAsync(UpdateMemberDto updateMemberDto)
        {
            var member = await _memberRepository.GetMemberByNumberAsync(updateMemberDto.MemberNumber);
            if (member == null)
                return false;

            _mapper.Map(updateMemberDto, member);
            return await _memberRepository.UpdateMemberAsync(member);
        }

        public async Task<IEnumerable<BookDto>> GetMemberBorrowedBooksAsync(string memberNumber)
        {
            var books = await _libraryRepository.GetBorrowedBooksByMemberAsync(memberNumber);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<bool> BorrowBookAsync(string memberNumber, string isbn)
        {
            return await _libraryRepository.LendBookAsync(memberNumber, isbn);
        }

        public async Task<bool> ReturnBookAsync(string memberNumber, string isbn)
        {
            return await _libraryRepository.ReturnBookAsync(memberNumber, isbn);
        }

        public async Task<IEnumerable<BookDto>> GetBorrowedBooksByMemberAsync(string memberNumber)
        {
            var books = await _libraryRepository.GetBorrowedBooksByMemberAsync(memberNumber);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
} 