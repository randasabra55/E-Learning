using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Answers.Commands.Models;
using E_Learning_Data.Entities;
using E_Learning_Service.Abstracts;
using MediatR;

namespace E_Learning_Core.Features.Answers.Commands.Handlers
{
    public class AnswerCommandHandler : ResponseHandler,
                                      IRequestHandler<AddAnswerCommand, Response<string>>,
                                      IRequestHandler<EditAnswerCommand, Response<string>>,
                                      IRequestHandler<DeleteAnswerCommand, Response<string>>
    {
        IAnswerService answerService;
        IMapper mapper;
        public AnswerCommandHandler(IAnswerService answerService, IMapper mapper)
        {
            this.answerService = answerService;
            this.mapper = mapper;
        }

        /*public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = mapper.Map<QuizAnswers>(request);
            var result = await answerService.AddAnswerAsync(answer);
            if (result == "Added Successfully")
                return Success("Added successfully");
            else return BadRequest<string>("Added failed");
        }*/

        public async Task<Response<string>> Handle(EditAnswerCommand request, CancellationToken cancellationToken)
        {
            var answer = await answerService.GetAnswerByIdAsync(request.Id);
            if (answer == null) return NotFound<string>();
            var answerMapper = mapper.Map(request, answer);
            var result = await answerService.EditAnswerAsync(answerMapper);

            if (result == "Success") return Success("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
        {
            var result = await answerService.DeleteAnswerAsync(request.Id);
            if (result == "NotFound")
                return NotFound<string>("answer not fount to delete it");
            return Success("Deleted successfully");
        }

        public async Task<Response<string>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            var answers = mapper.Map<List<QuizAnswers>>(request.Answers);

            var result = await answerService.AddAnswersAsync(request.QuestionId, answers);

            if (result == "Added Successfully")
                return Success("Added successfully");
            else
                return BadRequest<string>("Addition failed");
        }
    }
}
