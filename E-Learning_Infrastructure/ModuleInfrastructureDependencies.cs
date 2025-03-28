using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Implementations;
using E_Learning_Infrastructure.InfrastructureBases;
using Microsoft.Extensions.DependencyInjection;

namespace E_Learning_Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IOTPRepository, OTPRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<IQuizRepository, QuizRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<ICertificateRepository, CertificateRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IQuizEnrollmentRepository, QuizEnrollmentRepository>();
            services.AddTransient<IUserAnswerRepository, UserAnswerRepository>();


            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
