using E_Learning_Data.Entities;
using Microsoft.AspNetCore.Http;

namespace E_Learning_Service.Abstracts
{
    public interface ILessonService
    {
        // public Task<string> AddLessonAsync(string title, IFormFile videoFile, int order, int courseId);
        public Task<string> AddLessonAsync(Lessons lesson, IFormFile videoFile);
        public Task<string> EditLessonAsync(Lessons lesson, IFormFile videoFile);
        public Task<Lessons> GetLessonAsync(int lessonId);
        public Task<string> DeleteLessonAsync(int lessonId);
        public Task<Lessons> GetLessonByIdIncludingCourse(int id);
        public IQueryable<Lessons> GetLessonPaginatedIncludingCourse();
    }
}
