using MagicOnion;
using MessagePack;

namespace Touch.Shared.Services
{
    /// <summary>
    /// Client -> Server API
    /// </summary>
    public interface IChatService : IService<IChatService>
    {
        UnaryResult<Nil> GenerateException(string message);
        UnaryResult<Nil> SendReportAsync(string message);
        
        UnaryResult<int> SumAsync(int x, int y);
    }
}
