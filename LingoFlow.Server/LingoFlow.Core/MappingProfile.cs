using AutoMapper;
using LingoFlow.Core.Dto;
using LingoFlow.Core.Models;

namespace LingoFlow.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile() // קונסטרקטור
        {
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<Conversation, ConversationDto>().ReverseMap();
            CreateMap<Feedback, FeedbackDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Word, WordDto>().ReverseMap();
        }
    }
}
