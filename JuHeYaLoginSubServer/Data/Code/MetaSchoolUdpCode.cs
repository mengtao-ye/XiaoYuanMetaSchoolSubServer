namespace SubServer
{
    public enum MetaSchoolUdpCode : short
    {
        //SubServer
        MetaSchoolSubServerRegister = MetaSchoolRequestCode.SubServer +3,//校园部分分布式服务器注册
        MetaSchoolSubServerHeartBeat = MetaSchoolRequestCode.SubServer +4,//校园部分分布式服务器心跳包
        //基础数据
        HeartBeat = MetaSchoolRequestCode.MetaSchool + 1,//心跳包    
        SendPlayerData = MetaSchoolRequestCode.MetaSchool + 2,//发送玩家的数据
        SendOtherPlayerDataToSelf = MetaSchoolRequestCode.MetaSchool + 3,//发送其他玩家的数据给自己
    }
}
