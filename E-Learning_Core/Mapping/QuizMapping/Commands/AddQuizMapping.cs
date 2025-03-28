using E_Learning_Core.Features.Quizes.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.QuizMapping
{
    public partial class QuizProfile
    {
        public void AddQuizMapping()
        {
            CreateMap<AddQuizCommand, Quizzes>();
        }
    }
}
