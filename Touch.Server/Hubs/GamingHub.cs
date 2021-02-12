using MagicOnion.Server.Hubs;
using Touch.Shared.Hubs;
using Touch.Shared.MessagePackObjects;
using System;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;

namespace Touch.Server.Hubs
{
    // 서버 구현
    // StreamingHubBase<THub, TReceiver>, THub 를 구현한다.
    public class GamingHub : StreamingHubBase<IGamingHub, IGamingHubReceiver>, IGamingHub
    {
        // 이 클래스는 연결마다 인스턴스화 되기 때문에, 필드들은 연결의 범위에서 캐싱된다.
        IGroup room;
        Player self;
        private IInMemoryStorage<Player> storage;

        public async Task<Player[]> JoinAsync(string roomName, string userName, Vector3 position, Quaternion rotation)
        {

            Console.WriteLine("JoinAsync " + userName);

            self = new Player() { Name = userName, Position = position, Rotation = rotation };

            // Group은 많은 연결들을 묶을 수 있고, 이것은 메모리 저장소를 가지므로 그룹마다 어떠한 타입도 추가할 수 있다. 
            (room, storage) = await Group.AddAsync(roomName, self);

            // 서버->클라이언트로 브로드캐스팅 한다.
            Broadcast(room).OnJoin(self);

            return storage.AllValues.ToArray();
        }

        public async Task LeaveAsync()
        {
            await room.RemoveAsync(this.Context);
            Broadcast(room).OnLeave(self);
        }

        public async Task MoveAsync(Vector3 position, Quaternion rotation)
        {
            self.Position = position;
            self.Rotation = rotation;
            Broadcast(room).OnMove(self);
        }

    }
}
