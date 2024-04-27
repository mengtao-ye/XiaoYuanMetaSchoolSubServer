namespace SubServer
{
    public enum MetaSchoolRequestCode : short
    {
        SubServer = CommonConstData.REQUESTCODE_SPAN * 2,//共同数据相关请求
        MetaSchool = CommonConstData.REQUESTCODE_SPAN * 67,//校园数据
    }
}
