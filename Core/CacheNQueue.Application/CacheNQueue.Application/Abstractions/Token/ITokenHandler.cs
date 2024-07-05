using CacheNQueue.Application.Abstractions;

namespace Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenResponse CreateAccessToken(int minute);
    }
}
