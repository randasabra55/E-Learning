using E_Learning_Data.Entities;
using E_Learning_Infrastructure.Abstracts;
using E_Learning_Infrastructure.Data;
using E_Learning_Service.Abstracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Learning_Service.Implementations
{
    public class LessonService : ILessonService
    {
        Context context;
        IWebHostEnvironment webHost;
        ILessonRepository lessonRepository;
        IHttpContextAccessor httpContextAccessor;

        public LessonService(Context context, IWebHostEnvironment webHost, ILessonRepository lessonRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.webHost = webHost;
            this.lessonRepository = lessonRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> AddLessonAsync(Lessons lesson, IFormFile videoFile)
        {
            //add vid
            var request = httpContextAccessor.HttpContext?.Request;
            if (request == null) return "Failed to get request context";
            var webRootPath = webHost.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            if (!Directory.Exists(webRootPath))
            {
                Directory.CreateDirectory(webRootPath);
            }
            var uploadsFolder = Path.Combine(webHost.WebRootPath, "uploads", "videos");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString().Substring(0, 5) + Path.GetExtension(videoFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await videoFile.CopyToAsync(stream);
            }

            var fileUrl = $"{request.Scheme}://{request.Host}/uploads/Images/{uniqueFileName}";

            lesson.VideoUrl = fileUrl;
            await lessonRepository.AddAsync(lesson);
            return "Success";
        }

        public async Task<string> DeleteLessonAsync(int lessonId)
        {
            var lesson = await lessonRepository.GetByIdAsync(lessonId);
            if (lesson == null)
                return "NotFound";
            await lessonRepository.DeleteAsync(lesson);
            return "Success";
            //throw new NotImplementedException();
        }

        public async Task<string> EditLessonAsync(Lessons lesson, IFormFile videoFile)
        {
            if (videoFile != null)
            {
                var request = httpContextAccessor.HttpContext?.Request;
                if (request == null) return "Failed to get request context";
                var oldFilePath = Path.Combine(webHost.WebRootPath, lesson.VideoUrl.TrimStart('/'));
                if (File.Exists(oldFilePath))
                    File.Delete(oldFilePath);
                var uploadsFolder = Path.Combine(webHost.WebRootPath, "uploads", "videos");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid().ToString().Substring(0, 5) + Path.GetExtension(videoFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await videoFile.CopyToAsync(stream);
                }
                var fileUrl = $"{request.Scheme}://{request.Host}/uploads/videos/{uniqueFileName}";

                lesson.VideoUrl = fileUrl;
            }

            await lessonRepository.UpdateAsync(lesson);

            return "Lesson updated successfully";
        }

        public async Task<Lessons> GetLessonAsync(int lessonId)
        {
            return await lessonRepository.GetByIdAsync(lessonId);
        }

        public async Task<Lessons> GetLessonByIdIncludingCourse(int id)
        {
            var lesson = await lessonRepository.GetTableNoTracking().Include(l => l.courses).FirstOrDefaultAsync(l => l.Id == id);
            return lesson;
        }

        public IQueryable<Lessons> GetLessonPaginatedIncludingCourse()
        {
            var lessons = lessonRepository.GetTableNoTracking().Include(l => l.courses).AsQueryable();
            return lessons;
        }
    }
}
