using System.Threading.Tasks;
using Vote.Application.Dtos.Email;

namespace Vote.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest);
    }
}
