using E_Learning_Core.Features.QuizEnrollments.Commands.Models;
using E_Learning_Data.Entities;

namespace E_Learning_Core.Mapping.QuizEnrollmentMapping
{
    public partial class QuizEnrollmentProfile
    {
        public void EnrollToQuizMapping()
        {
            CreateMap<EnrollUserInQuizCommand, UserQuizAttempts>();
        }
    }
}
