using E_Learning_Core.Features.Questions.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.QuestionMapping
{
    public partial class QuestionProfile
    {
        public void AddQuestionMapping()
        {
            CreateMap<AddQuestionCommand, QuizQuestions>();
        }
    }
}
