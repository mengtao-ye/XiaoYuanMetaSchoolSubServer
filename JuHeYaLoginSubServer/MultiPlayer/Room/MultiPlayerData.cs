using YSF;

namespace SubServer
{
    public class MultiPlayerData : IPool
    {
        public bool isPop { get; set; }
        public long account;
        public byte[] data = null;
        public int lastTime;

        public MultiPlayerData()
        {
           
        }

        public byte[] GetSendBytes() 
        {
            return ByteTools.Concat(account.ToBytes(),data);    
        }

        public void PopPool() 
        {
            lastTime = 0;
        }
        public void PushPool() { }
        public void Recycle()
        {
            ClassPool<MultiPlayerData>.Push(this);
        }
    }
}
