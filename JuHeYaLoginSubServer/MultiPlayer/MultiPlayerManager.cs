using System.Net;

namespace SubServer
{
    public class MultiPlayerManager
    {
        private MultiPlayerRoomManager mRoomManager;
        public MultiPlayerManager()
        {
            mRoomManager = new MultiPlayerRoomManager();
        }
        public void ReceivePlayerData(long account,long roomID,byte[] data,EndPoint endPoint)
        {
            mRoomManager.ReceivePlayerData(account,roomID,data,endPoint);
        }
    }
}
