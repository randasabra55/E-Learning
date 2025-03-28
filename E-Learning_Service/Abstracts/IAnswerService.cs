using E_Learning_Data.Entities;

namespace E_Learning_Service.Abstracts
{
    public interface IAnswerService
    {
        //public Task<string> AddAnswerAsync(QuizAnswers answer);
        public Task<string> AddAnswersAsync(int questionId, List<QuizAnswers> answers);
        public Task<string> EditAnswerAsync(QuizAnswers answer);
        public Task<string> DeleteAnswerAsync(int answerId);
        public IQueryable<QuizAnswers> GetAnswersAsync();
        public Task<QuizAnswers> GetAnswerByIdAsync(int answerId);
        //public Task<bool> IsTitleExistExcludeSelf(string title, int courseId);
    }
}
