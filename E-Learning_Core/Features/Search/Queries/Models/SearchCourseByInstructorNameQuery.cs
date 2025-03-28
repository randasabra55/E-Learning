﻿using E_Learning_Core.Features.Search.Queries.Results;
using E_Learning_Core.Wrapper;
using MediatR;


namespace E_Learning_Core.Features.Search.Queries.Models
{
    public class SearchCourseByInstructorNameQuery : IRequest<PaginatedResult<SearchResult>>
    {
        public string InstructorName { get; set; }
    }
}
