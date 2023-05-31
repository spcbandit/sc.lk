using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Notification;
using SC.LK.Application.Domains.Responses.Notification;

namespace SC.LK.Application.Handlers.Notification;

public class AddNotificationByContratorIdHandler:IRequestHandler<AddNotificationByContractorIdRequest,AddNotificationByContractorIdResponse>
{
    private readonly IRepository<NotificationEntity> _repository;
    
    public AddNotificationByContratorIdHandler(IRepository<NotificationEntity> repository)
    {
        _repository = repository;
        
    }

    public async Task<AddNotificationByContractorIdResponse> Handle(AddNotificationByContractorIdRequest request, CancellationToken cancellationToken)
    {
        Guid guid = Guid.NewGuid();
        
        var add = new NotificationEntity()
        {
            Id = guid,
            Expire = request.Expire,
            Header = request.Header,
            Importance = request.Importance,
            Read = request.Read,
            Text = request.Text,
            ContractorId = (Guid)request.ContractorId,
        };
        var save = _repository.Create(add);
        if (save != 0)
        {
            return new AddNotificationByContractorIdResponse() { Success = true, Id = guid };
        }

        return new AddNotificationByContractorIdResponse() { Success = false, ErrorMessage = "can't save"};
    }
}