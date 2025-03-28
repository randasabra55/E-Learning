using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Service.Abstracts;

namespace E_Learning_Service.Implementations
{
    public class AnswerService : IAnswerService
    {
        IAnswerRepository answerRepository;
        IQuestionRepository questionRepository;
        public AnswerService(IAnswerRepository answerRepository, IQuestionRepository questionRepository)
        {
            this.answerRepository = answerRepository;
            this.questionRepository = questionRepository;
        }
        /*public async Task<string> AddAnswerAsync(QuizAnswers answer)
        {
            await answerRepository.AddAsync(answer);
            return "Added Successfully";
        }*/

        public async Task<string> AddAnswersAsync(int questionId, List<QuizAnswers> answers)
        {
            foreach (var answer in answers)
            {
                answer.QuestionId = questionId;
            }

            await answerRepository.AddRangeAsync(answers);
            return "Added Successfully";
        }

        public async Task<string> DeleteAnswerAsync(int answerId)
        {
            var course = await answerRepository.GetByIdAsync(answerId);
            if (course == null) return "NotFound";
            await answerRepository.DeleteAsync(course);
            return "Deleted successfully";
        }

        public async Task<string> EditAnswerAsync(QuizAnswers answer)
        {
            await answerRepository.UpdateAsync(answer);
            return "Success";
        }

        public async Task<QuizAnswers> GetAnswerByIdAsync(int answerId)
        {
            // var question = await questionRepository.GetByIdAsync(questionId);

            return await answerRepository.GetByIdAsync(answerId);
        }

        public IQueryable<QuizAnswers> GetAnswersAsync()
        {
            return answerRepository.GetAnswersQuerable();
        }
    }
}
