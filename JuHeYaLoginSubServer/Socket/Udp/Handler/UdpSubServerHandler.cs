﻿using System.Net;
using YSF;

namespace SubServer
{
    public class UdpSubServerHandler : BaseUdpRequestHandle
    {
        public override short requestCode =>(short)MetaSchoolRequestCode.SubServer;
        public UdpSubServerHandler(IUdpServer server) : base(server)
        {

        }
        protected override void ComfigActionCode()
        {
            Add((short)MetaSchoolUdpCode.MetaSchoolSubServerRegister, LoginSubServerRegister);
            Add((short)MetaSchoolUdpCode.MetaSchoolSubServerHeartBeat, LoginSubServerHeartBeat);
        }
        private byte[] LoginSubServerHeartBeat(byte[] data, EndPoint endPoint)
        {
            
            return null;
        }
        private byte[] LoginSubServerRegister(byte[] data,EndPoint endPoint)
        {
            if (data.IsNullOrEmpty() || data.Length != 4) 
            {
                Debug.LogError("LoginSubServerRegister data error");
                return null;
            }
            int id = data.ToInt();
            if (id == 0) {
                Debug.LogError("LoginSubServerRegister data is zero");
                return null;
            }
            SystemData.SubServerID = id;
            SystemData.SubServerIDBytes = id.ToBytes();
            Debug.Log("分布式服务器注册成功："+id);
            MainCenter.Instance.controllerManager.Remove(ControllerType.RegisterMetaSchoolSubServer);
            MainCenter.Instance.controllerManager.Add(new MetaSchoolSubServerHeartBeatController(MainCenter.Instance.controllerManager));
            return null;
        }
    }
}
