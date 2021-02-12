using MagicOnion;
using Touch.Shared.MessagePackObjects;
using System.Threading.Tasks;
using UnityEngine;

namespace Touch.Shared.Hubs
{
    /// <summary>
    /// CLient ->Server API
    /// </summary>
    public interface IGamingHub : IStreamingHub<IGamingHub, IGamingHubReceiver>
    {
        // 반환값은 `Task` or `Task<T>` 이어야 하고, 파라미터는 제약이 없다.
        Task<Player[]> JoinAsync(string roomName, string userName, Vector3 position, Quaternion rotation);
        Task LeaveAsync();
        Task MoveAsync(Vector3 position, Quaternion rotation);
    }

    /// <summary>
    /// Server ->Client API
    /// </summary>
    public interface IGamingHubReceiver
    {
        // 반환값은 `void` or `Task` 이어야 하고, 파라미터는 제약이 없다.
        void OnJoin(Player player);
        void OnLeave(Player player);
        void OnMove(Player player);
    }
}