using MediatR;
using SC.LK.Application.Abstractions;
using SC.LK.Application.Abstractions.MailSender;
using SC.LK.Application.Domains.Entities;
using SC.LK.Application.Domains.Requests.Profile;
using SC.LK.Application.Domains.Responses.Profile;

namespace SC.LK.Application.Handlers.Profile;

public class SendCodeHandler:IRequestHandler<SendCodeRequest,SendCodeResponse>
{
    private readonly IRepository<UserEntity> _repositoryUser;
    private readonly IMailKit _mailKit; 
    private readonly Random _generateCode;
    
    /// <summary>
    /// Оправка кода
    /// </summary>
    /// <param name="repositoryUser"></param>
    /// <param name="mailKit"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public SendCodeHandler(IRepository<UserEntity> repositoryUser, IMailKit mailKit)
    {
        _repositoryUser = repositoryUser ?? throw new ArgumentNullException(nameof(repositoryUser));
        _mailKit = mailKit ?? throw new ArgumentNullException(nameof(mailKit));
        _generateCode = new Random();
    }
    
    /// <summary>
    /// Оправка кода
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SendCodeResponse> Handle(SendCodeRequest request, CancellationToken cancellationToken)
    {
        try{
            var user = _repositoryUser.Get(x => x.Login == request.Login && x.IsDelete != true).FirstOrDefault();

            if (user == null) 
                return new SendCodeResponse() {Success = false};

            user.AuthCode = _generateCode.Next(0, 1000000).ToString("D6");

            await _mailKit.SendMessage(request.Login, user.AuthCode);

            if (_repositoryUser.Update(user) != 0)
                return new SendCodeResponse() {Success = true};
            else
                return new SendCodeResponse() {Success = false};
        }
        catch (Exception e)
        {
            return new SendCodeResponse() {Success = false, ErrorMessage = e.StackTrace};
        }
    }
}