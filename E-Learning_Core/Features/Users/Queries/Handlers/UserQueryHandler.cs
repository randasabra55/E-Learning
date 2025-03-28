using AutoMapper;
using E_Learning_Core.Bases;
using E_Learning_Core.Features.Users.Queries.Models;
using E_Learning_Core.Features.Users.Queries.Results;
using E_Learning_Core.Wrapper;
using E_Learning_Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace E_Learning_Core.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
                                   IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>,
                                   IRequestHandler<GetUserPaginatedQuery, PaginatedResult<GetUserPaginatedList>>
    {
        IMapper mapper;
        UserManager<User> userManager;
        public UserQueryHandler(IMapper mapper, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.FirstOrDefault(u => u.Id == request.Id);
            if (user == null)
            {
                return NotFound<GetUserByIdResponse>("User not found");
            }
            //mapp
            var response = mapper.Map<GetUserByIdResponse>(user);
            return Success(response);
        }

        public async Task<PaginatedResult<GetUserPaginatedList>> Handle(GetUserPaginatedQuery request, CancellationToken cancellationToken)
        {
            var list = userManager.Users.AsQueryable();
            var paginateList = await mapper.ProjectTo<GetUserPaginatedList>(list)
                                     .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginateList;

        }

    }
}
