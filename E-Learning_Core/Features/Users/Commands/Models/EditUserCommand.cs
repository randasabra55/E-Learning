using E_Learning_Core.Bases;
using MediatR;

namespace E_Learning_Core.Features.Users.Commands.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public int YearExperiences { get; set; }
        public string Specialization { get; set; }
        //public string ProfileImage { get; set; }

    }
}
