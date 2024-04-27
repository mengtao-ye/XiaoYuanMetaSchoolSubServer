using YSF;

namespace SubServer
{
    public class UdpHandlerMapper : BaseMap<short, IUdpRequestHandle>
    {
        protected override void Config()
        {
           
        }
        public void Init() 
        {
            Add((short)MetaSchoolRequestCode.SubServer, new UdpSubServerHandler(MainCenter.Instance.udpServer));
            Add((short)MetaSchoolRequestCode.MetaSchool, new UdpMetaSchoolHandler(MainCenter.Instance.udpServer));
        }
    }
}
