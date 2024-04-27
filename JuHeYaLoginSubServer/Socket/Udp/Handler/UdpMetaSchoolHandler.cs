using System.Net;
using YSF;

namespace SubServer
{
    public class UdpMetaSchoolHandler : BaseUdpRequestHandle
    {
        public override short requestCode => (short)MetaSchoolRequestCode.MetaSchool;
        private MultiPlayerManager mMultiPlayerManager;
        public UdpMetaSchoolHandler(IUdpServer server) : base(server)
        {
            mMultiPlayerManager = new MultiPlayerManager();
        }
        protected override void ComfigActionCode()
        {
            Add((short)MetaSchoolUdpCode.HeartBeat, HeartBeat);
            Add((short)MetaSchoolUdpCode.SendPlayerData, SendPlayerData);
        }
        private byte[] SendPlayerData(byte[] data, EndPoint endPoint)
        {
            if (data.IsNullOrEmpty()) return BytesConst.FALSE_BYTES;
            long account = data.ToLong();
            long roomID = data.ToLong(8);
            byte[] datas = ByteTools.SubBytes(data,16);
            mMultiPlayerManager.ReceivePlayerData(account, roomID, datas, endPoint);
            return null;
        }


        private byte[] HeartBeat(byte[] data, EndPoint endPoint)
        {
            return BytesConst.TRUE_BYTES;
        }
    }
}
