using AutoMapper;

namespace E_Learning_Core.Mapping.QuizEnrollmentMapping
{
    public partial class QuizEnrollmentProfile : Profile
    {
        public QuizEnrollmentProfile()
        {
            EnrollToQuizMapping();
            AddStudentAnswerMapping();
            GetScoreMapping();
        }
    }
}
