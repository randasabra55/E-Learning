using E_Learning_Service.Abstracts;
using E_Learning_Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace E_Learning_Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<IQuizeService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IEnrollmentService, EnrollmentService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<ICertificateService, CertificateService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IQuizEnrollmentService, QuizEnrollmentService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
            services.AddTransient<IQuizUserService, QuizUserService>();


            return services;
        }
    }
}
