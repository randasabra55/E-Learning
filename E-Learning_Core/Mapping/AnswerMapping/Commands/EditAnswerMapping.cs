using E_Learning_Core.Features.Answers.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.AnswerMapping
{
    public partial class AnswerProfile
    {
        public void EditAnswerMapping()
        {
            CreateMap<EditAnswerCommand, QuizAnswers>();
        }
    }
}
