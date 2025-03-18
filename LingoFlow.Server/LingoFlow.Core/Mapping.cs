using LingoFlow.Core.Dto;
using LingoFlow.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LingoFlow.Core
{
    public static class Mapping
    {
        public static UserLoginDto MapToUserLoginDto(User user)
        {
            return new UserLoginDto { Id = user.Id, Name = user.Name, Email = user.Email, Password = user.Password };
        }
        public static ConversationDto MapToConversationDto(Conversation conversation)
        {
            return new ConversationDto { Id = conversation.Id, UserId = conversation.UserId, StartTime = conversation.StartTime,Status=conversation.Status, EndTime = conversation.EndTime, };
        }

        public static FeedbackDto MapFeedbackDto(Feedback feedback)
        {
            return new FeedbackDto { Id = feedback.Id, ConversationId = feedback.ConversationId, Comments = feedback.Comments, Score = feedback.Score };
        }
        public static SubjectDto MapToSubjectDto(Subject subject)
        {
            return new SubjectDto { Id = subject.Id, Name = subject.Name };
        }
        public static WordDto MapToWordDto(Word word)
        {
            return new WordDto { Id = word.Id, Name = word.Name };
        }
    }
}
