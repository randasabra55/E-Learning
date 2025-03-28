using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Quizes.Commands.Models
{
    public class EditQuizCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
