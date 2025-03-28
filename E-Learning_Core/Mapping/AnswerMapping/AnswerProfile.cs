using AutoMapper;

namespace E_Learning_Core.Mapping.AnswerMapping
{
    public partial class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            AddAnswerMapping();
            EditAnswerMapping();
        }
    }
}
