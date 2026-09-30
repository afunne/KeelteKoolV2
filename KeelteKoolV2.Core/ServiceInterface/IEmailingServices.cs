using KeelteKoolV2.Core.DTO;

namespace KeelteKoolV2.Core.ServiceInterface
{
    public interface IEmailingServices
    {
        void SendEmail(EmailDTO dto);
        void SendEmailToken(EmailTokenDTO dto, string token);
    }
}
