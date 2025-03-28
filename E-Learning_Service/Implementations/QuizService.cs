using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Service.Abstracts;

namespace E_Learning_Service.Implementations
{
    public class QuizService : IQuizeService
    {
        IQuizRepository quizRepository;
        public QuizService(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }
        public async Task<string> AddQuiz(Quizzes quiz)
        {
            await quizRepository.AddAsync(quiz);
            return "Success";
        }

        public async Task<string> DeleteQuiz(int quizId)
        {
            var quiz = await quizRepository.GetByIdAsync(quizId);
            if (quiz == null)
                return "NotFound";
            await quizRepository.DeleteAsync(quiz);
            return "Success";
        }

        public async Task<string> EditQuiz(Quizzes quiz)
        {
            await quizRepository.UpdateAsync(quiz);
            return "Success";
        }

        public async Task<Quizzes> GetQuizById(int quizId)
        {
            //return await quizRepository.GetByIdAsync(quizId);
            return await quizRepository.GetQuizByIdIncludeQuestionAsync(quizId);
        }

        public IQueryable<Quizzes> GetQuizzessAsync()
        {
            return quizRepository.GetQuizesQuerableAsync();
        }
    }
}
