using AutoMapper;
using CSProjeDemo1.Application.DTOs;
using CSProjeDemo1.Domain.Entities;
using CSProjeDemo1.Domain.Enums;

namespace CSProjeDemo1.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Book mappings
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.BookType, opt => opt.MapFrom(src => src.GetType().Name))
                .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.Status == BookStatus.Available));

            CreateMap<ScienceBook, ScienceBookDto>()
                .IncludeBase<Book, BookDto>()
                .ForMember(dest => dest.ScientificField, opt => opt.MapFrom(src => src.ScientificField))
                .ForMember(dest => dest.ResearchArea, opt => opt.MapFrom(src => src.ResearchArea));

            CreateMap<NovelBook, NovelBookDto>()
                .IncludeBase<Book, BookDto>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.LiteraryMovement, opt => opt.MapFrom(src => src.LiteraryMovement));

            CreateMap<HistoryBook, HistoryBookDto>()
                .IncludeBase<Book, BookDto>()
                .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Region));

            // Member mappings
            CreateMap<Member, MemberDto>();
            CreateMap<CreateMemberDto, Member>();
            CreateMap<UpdateMemberDto, Member>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
} 