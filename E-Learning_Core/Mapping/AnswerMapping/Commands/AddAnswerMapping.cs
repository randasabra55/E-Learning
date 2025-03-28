using E_Learning_Core.Features.Answers.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.AnswerMapping
{
    public partial class AnswerProfile
    {
        public void AddAnswerMapping()
        {
            //CreateMap<AddAnswerCommand, QuizAnswers>();
            CreateMap<AnswerDto, QuizAnswers>();

            CreateMap<AddAnswerCommand, List<QuizAnswers>>()
                .ConvertUsing((src, dest, context) =>
                    src.Answers.Select(answer => new QuizAnswers
                    {
                        AnswerText = answer.AnswerText,
                        IsCorrect = answer.IsCorrect,
                        QuestionId = src.QuestionId  // ربط كل إجابة بالسؤال المحدد
                    }).ToList());
        }
    }
}
