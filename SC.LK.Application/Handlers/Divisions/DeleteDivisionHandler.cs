using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Agents;
using SC.LK.Application.Domains.Requests.Divisions;
using SC.LK.Application.Domains.Responses.Divisions;
using SC.LK.Application.Handlers.Agents;
using SC.LK.Application.Handlers.Terminals;

namespace SC.LK.Application.Handlers.Divisions;

public class DeleteDivisionHandler: IRequestHandler<DeleteDivisionRequest, DeleteDivisionResponse>
{
    private readonly IRepository<DivisionEntity> _repositoryDivision;
    //Подключение IRCClient для проверки агента и терминала
    private readonly IRepositoryConfigurationServiceAdaptor _repositoryConfigurationServiceAdaptor;
    
    /// <summary>
    /// Удаление подразделения
    /// </summary>
    /// <param name="repositoryDivision"></param>
    public DeleteDivisionHandler(IRepository<DivisionEntity> repositoryDivision)
    {
        _repositoryDivision = repositoryDivision ?? throw new ArgumentException(nameof(repositoryDivision));
    }
    /// <summary>
    /// Удаление подразделения
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<DeleteDivisionResponse> Handle(DeleteDivisionRequest request, CancellationToken cancellationToken)
    {

        var division = _repositoryDivision
            .Get(x=>x.Id == request.DivisionId)
            .FirstOrDefault();
        
        //Проверка оставшихся агентов и терминалов
        var agent = _repositoryConfigurationServiceAdaptor.GetAgentsByDivisionId(request.DivisionId);
        var terminal = _repositoryConfigurationServiceAdaptor.GetTerminalsByDivisionIdAsync(request.DivisionId);

        if((terminal != null) || (agent != null))
        {
            return new DeleteDivisionResponse() { Success = false, ErrorMessage = "Есть агенты или терминалы."};
        }
        else
        {
            var res = _repositoryDivision.Remove(division);
            if (res != 0)
                return new DeleteDivisionResponse() { Success = true, Id = request.DivisionId };
            else
                return new DeleteDivisionResponse() { Success = false, ErrorMessage = MessageResource.FailedDeleteDivision };
        }
    }
}