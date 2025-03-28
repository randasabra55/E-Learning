namespace E_Learning_Service.Abstracts
{
    public interface IQuizUserService
    {
        public Task<int> GetStudentScoreAsync(int userId, int quizId);
    }
}
