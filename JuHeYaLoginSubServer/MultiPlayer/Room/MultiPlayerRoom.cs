using System.Collections.Generic;
using System.Net;
using System.Threading;
using YSF;

namespace SubServer
{
    public  class MultiPlayerRoom
    {
        private List<MultiPlayerData> mPlayerDataList;
        public List<MultiPlayerData> playerDataList { get { return mPlayerDataList; } }
        private Thread mCheckLostPlayerThread;
        private int mCheckTime = 1000;//单位为毫秒，即为一秒
        private int mCurTime;
        public MultiPlayerRoom()
        {
            mPlayerDataList = new List<MultiPlayerData>();
            mCheckLostPlayerThread = new Thread(CheckLostPlayer);
            mCheckLostPlayerThread.Start();
            mCurTime = 0;
        }

        private void CheckLostPlayer() 
        {
            while (true)
            {
                Thread.Sleep(mCheckTime);
                mCurTime++;
                lock (mPlayerDataList)
                {
                    for (int i = 0; i < mPlayerDataList.Count; i++)
                    {
                        if (mCurTime - mPlayerDataList[i].lastTime > 2)
                        {
                            Debug.Log("玩家:" + mPlayerDataList[i].account + "掉线了");
                            //该玩家掉线了
                            mPlayerDataList.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }
        }

        public void ReceivePlayerData(long account,byte[] data)
        {
            MultiPlayerData multiPlayerData = Find(account);
            if (multiPlayerData == null)
            {
                multiPlayerData = ClassPool<MultiPlayerData>.Pop();
                multiPlayerData.account = account;
                lock (mPlayerDataList)
                {
                    mPlayerDataList.Add(multiPlayerData);
                }
            }
            multiPlayerData.data = data;
            multiPlayerData.lastTime = mCurTime;
        }
        /// <summary>
        /// 将其他玩家的数据发送给我
        /// </summary>
        public void SendOtherDataToSelf(long selfAccount,EndPoint endPoint)
        {
            for (int i = 0; i < mPlayerDataList.Count; i++)
            {
                if (mPlayerDataList[i].account == selfAccount) continue;
                if (mPlayerDataList[i].data .IsNullOrEmpty()) continue;
                MainCenter.Instance.UdpSend(endPoint, (short)MetaSchoolUdpCode.SendOtherPlayerDataToSelf, mPlayerDataList[i].GetSendBytes());
            }    
        }

        public bool Contains(long account)
        {
            return Find(account) !=null;    
        }

        private MultiPlayerData Find(long account)
        {
            for (int i = 0; i < mPlayerDataList.Count; i++)
            {
                if (mPlayerDataList[i].account == account)
                    return mPlayerDataList[i];
            }
            return null;
        }
    }
}
