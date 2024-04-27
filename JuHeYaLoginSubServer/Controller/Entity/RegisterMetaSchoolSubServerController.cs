using YSF;

namespace SubServer
{
    /// <summary>
    ///注册校园的分布式服务器
    /// </summary>
    public class RegisterMetaSchoolSubServerController : BaseController
    {
        public override ControllerType controllerType => ControllerType.RegisterMetaSchoolSubServer;
        public RegisterMetaSchoolSubServerController(IControllerManager controllerManager) : base(controllerManager)
        {

        }
        public override void Awake()
        {
            mControllerManager.center.UdpSendCenterServer((short)MetaSchoolUdpCode.MetaSchoolSubServerRegister, new byte[] { (byte)SubServerType.MetaSchoolServer });
        }
    }
}
