using SC.LK.Application.Domains.Dto;

namespace SC.LK.Application.Domains.Responses.Profile
{
    public class LoginResponse : BaseResponse
    {
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public Guid UserId { get; set; }

       
    }
}