using AutoMapper;
using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Dto;
using SC.LK.Application.Domains.Dto.BaseDto;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.User;
using SC.LK.Application.Domains.Responses.User;


namespace SC.LK.Application.Handlers.Profile;

public class GetAllUsersHandler: IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
{
    private readonly IRepository<ContractorEntity> _repositoryContractor;
    private readonly IMapper _mapper;
    
    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <param name="repositoryContractor"></param>
    public GetAllUsersHandler(IRepository<ContractorEntity> repositoryContractor, IMapper mapper)
    {
        _repositoryContractor = repositoryContractor ?? 
                                throw new ArgumentException(nameof(repositoryContractor));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));

    }

    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
    {
        var contractor = _repositoryContractor
            .GetWithInclude(x => x.Id == request.ContractorId,
                x => x.Users)
            .FirstOrDefault();
        var users = contractor?.Users
            .Where(x => x.Id != request.UserId && x.IsDelete != true)
            .ToList();

        if (users != null)
        {
            if (contractor != null)
            {
                var usersDto = _mapper.Map<List<BaseUserDto>>(users);
                return new GetAllUsersResponse()
                {
                    Success = true,
                    Users = usersDto
                };
            }
            else
                return new GetAllUsersResponse()
                {
                    Success = false,
                    ErrorMessage = MessageResource.FailedGetUser
                };
        }
        else
        {
            return new GetAllUsersResponse()
            {
                Success = true,
                Users = new List<BaseUserDto>()
            };
        }
    }
}