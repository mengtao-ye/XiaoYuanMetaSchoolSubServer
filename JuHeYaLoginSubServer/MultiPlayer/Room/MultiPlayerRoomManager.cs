using System.Collections.Generic;
using System.Net;

namespace SubServer
{
    public class MultiPlayerRoomManager
    {
        private Dictionary<long, MultiPlayerRoom> mRoomDict;
        public MultiPlayerRoomManager()
        {
            mRoomDict = new Dictionary<long, MultiPlayerRoom>();
        }
        public void ReceivePlayerData(long account,long roomID,byte[] data,EndPoint point)
        {
            MultiPlayerRoom room = null;
            if (mRoomDict.ContainsKey(roomID))
            {
                room = mRoomDict[roomID];
            }
            else 
            {
                room = new MultiPlayerRoom();
                mRoomDict.Add(roomID,room);
            }
            room.ReceivePlayerData(account, data);
            room.SendOtherDataToSelf(account, point);
        }
    }
}
