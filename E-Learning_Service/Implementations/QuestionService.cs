using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Service.Abstracts;

namespace E_Learning_Service.Implementations
{
    public class QuestionService : IQuestionService
    {
        IQuestionRepository questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }
        public async Task<string> AddQuestion(QuizQuestions question)
        {
            await questionRepository.AddAsync(question);
            return "Success";
        }

        public async Task<string> DeleteQuestion(int questionId)
        {
            var question = await questionRepository.GetByIdAsync(questionId);
            if (question == null) return "NotFound";
            await questionRepository.DeleteAsync(question);
            return "Deleted successfully";
        }

        public async Task<string> EditQuestion(QuizQuestions question)
        {
            await questionRepository.UpdateAsync(question);
            return "Success";
        }

        public IQueryable<QuizQuestions> GetPaginatedQuestion()
        {
            return questionRepository.GetQuestionQuerableAsync();
        }

        public async Task<QuizQuestions> GetQuestionById(int questionId)
        {
            // return await questionRepository.GetByIdAsync(questionId);
            return await questionRepository.GetQuestionIncludingAnswersById(questionId);
        }
    }
}
