# E-Learning System - Clean Architecture, CQRS, and Advanced Features  

## Overview  
E-Learning System is a robust and scalable online learning platform designed using **Clean Architecture** principles and **CQRS (Command Query Responsibility Segregation)** for better performance and maintainability.
The system enables administrators, instructors, and students to interact efficiently while ensuring a modular and extensible codebase.

## Features  
### Authentication & Authorization  
- Secure user authentication using **JWT**.  
- Role-based access control (**Admin, Instructor, Student**) using **ASP.NET Core Identity**.  
- Restricted access to API endpoints using `[Authorize(Roles = "...")]`.  

### Course & Lesson Management  
- **Admins & Instructors** can create, update, and manage courses.  
- **Students** can enroll in courses and access lesson materials.  
- **Pagination & Filtering** for courses and lessons to improve performance.  

### Quiz & Assessment System  
- Instructors can create quizzes with multiple-choice questions.  
- Students can take quizzes, and the system auto-grades responses.  
- Students receive quiz results, Students can **submit feedback, ratings, and reviews** on courses.  

### Notifications & Certificates  
- Real-time notifications for **enrollments, course updates, and quiz results**.  
- Auto-generated **certificates** for students upon course completion.  

### CQRS & Clean Architecture  
- Implemented **CQRS** to separate read and write operations, improving performance.  
- Used **MediatR** for handling commands and queries efficiently.  
- **Repository Pattern** and **Unit of Work** to manage data persistence.  

### Advanced API Features  
- Implemented **Swagger** for API documentation.  
- **Exception handling middleware** for better error reporting.  
- Optimized **database queries with EF Core**.

 ### Optimized Performance:**  
  - All list-based responses (Quizzes, Courses, Users, Reviews, etc.) are paginated for better performance and scalability.**  

## 🏗 Tech Stack  
- **Back-End:** ASP.NET Core, C#, EF Core, MediatR, CQRS, Background Services  
- **Database:** SQL Server  
- **Security:** JWT, ASP.NET Core Identity  
- **Tools:** Git, Swagger, Postman  


