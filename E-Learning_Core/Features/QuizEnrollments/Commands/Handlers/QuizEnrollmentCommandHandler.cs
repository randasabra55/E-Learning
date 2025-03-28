using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.QuizEnrollments.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.QuizEnrollments.Commands.Handlers
{
    public class QuizEnrollmentCommandHandler : ResponseHandler,
                                             IRequestHandler<EnrollUserInQuizCommand, Response<string>>,
                                             IRequestHandler<AddUserAnswerCommand, Response<string>>
    {
        IMapper mapper;
        IQuizEnrollmentService QuizEnrollmentService;
        IUserAnswerService userAnswerService;
        public QuizEnrollmentCommandHandler(IMapper mapper, IQuizEnrollmentService quizEnrollmentService, IUserAnswerService userAnswerService)
        {
            this.mapper = mapper;
            this.QuizEnrollmentService = quizEnrollmentService;
            this.userAnswerService = userAnswerService;
        }
        public async Task<Response<string>> Handle(EnrollUserInQuizCommand request, CancellationToken cancellationToken)
        {

            var attemp = mapper.Map<UserQuizAttempts>(request);
            var result = await QuizEnrollmentService.AddAttempt(attemp);
            if (result == "Success")
                return Success("enrollment to quiz is success");
            return BadRequest<string>("failed, try again");
        }

        public async Task<Response<string>> Handle(AddUserAnswerCommand request, CancellationToken cancellationToken)
        {
            // var userAnswers = mapper.Map<List<UserQuizAnswers>>(request);
            // var result = await userAnswerService.AddUserAnswer(userAnswers);

            var a = mapper.Map<List<UserQuizAnswers>>(request.Answers);
            var result = await userAnswerService.AddUserAnswersAsync(request.UserQuizAttemptId, a);
            /*
             * var answers = mapper.Map<List<QuizAnswers>>(request.Answers);

            var result = await answerService.AddAnswersAsync(request.QuestionId, answers);
             */
            if (result == "Success")
                return Success("you submit your answers successfully");
            else return BadRequest<string>("failed to submit..");
        }
    }
}
