using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Questions.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;


namespace E_Learning_Core.Features.Questions.Commands.Handlers
{
    public class QuestionCommandHandler : ResponseHandler,
                                      IRequestHandler<AddQuestionCommand, Response<string>>,
                                      IRequestHandler<EditQuestionCommand, Response<string>>,
                                      IRequestHandler<DeleteQuestionCommand, Response<string>>
    {
        IQuestionService questionService;
        IMapper mapper;
        public QuestionCommandHandler(IQuestionService questionService, IMapper mapper)
        {
            this.questionService = questionService;
            this.mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = mapper.Map<QuizQuestions>(request);
            var result = await questionService.AddQuestion(question);
            if (result == "Success")
                return Success("Added successfully");
            else return BadRequest<string>("Added failed");
        }

        public async Task<Response<string>> Handle(EditQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = await questionService.GetQuestionById(request.Id);
            if (question == null) return NotFound<string>();
            var questionMapper = mapper.Map(request, question);
            var result = await questionService.EditQuestion(questionMapper);

            if (result == "Success") return Success("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            var result = await questionService.DeleteQuestion(request.Id);
            if (result == "NotFound")
                return NotFound<string>("question not fount to delete it");
            return Success("Deleted successfully");
        }
    }
}
