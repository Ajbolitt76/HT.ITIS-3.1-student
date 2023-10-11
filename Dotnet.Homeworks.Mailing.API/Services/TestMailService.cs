using Dotnet.Homeworks.Mailing.API.Dto;
using Dotnet.Homeworks.Shared.Dto;

namespace Dotnet.Homeworks.Mailing.API.Services;

public class TestMailService : IMailingService
{
    public Task<Result> SendEmailAsync(EmailMessage emailDto)
    {
        return Task.FromResult(new Result(true));
    }
}