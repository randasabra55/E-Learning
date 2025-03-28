using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Quizes.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Quizes.Commands.Handlers
{
    public class QuizCommandHandler : ResponseHandler,
                                    IRequestHandler<AddQuizCommand, Response<string>>,
                                    IRequestHandler<EditQuizCommand, Response<string>>,
                                    IRequestHandler<DeleteQuizCommand, Response<string>>
    {
        IMapper mapper;
        IQuizeService quizeService;
        public QuizCommandHandler(IMapper mapper, IQuizeService quizeService)
        {
            this.mapper = mapper;
            this.quizeService = quizeService;
        }
        public async Task<Response<string>> Handle(AddQuizCommand request, CancellationToken cancellationToken)
        {
            //var quize = new Quizzes();
            var quiz = mapper.Map<Quizzes>(request);
            var res = await quizeService.AddQuiz(quiz);
            if (res == "Success")
                return Success("Quiz Added Successfully");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await quizeService.GetQuizById(request.Id);
            if (quiz == null)
                return NotFound<string>("this quiz not found");
            //map
            var quizMapping = mapper.Map(request, quiz);
            var result = await quizeService.EditQuiz(quizMapping);
            if (result == "Success")
                return Success("Quiz updated successfully");
            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var result = await quizeService.DeleteQuiz(request.Id);
            if (result == "NotFound")
                return NotFound<string>("this quiz not found");
            else
                return Success("Deleted successfully");
        }
    }
}
