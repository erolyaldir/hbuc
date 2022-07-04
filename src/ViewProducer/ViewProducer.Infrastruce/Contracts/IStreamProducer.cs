
namespace ViewProducer.Infrastruce 
{
    public interface IStreamProducer
    {
        public void Connect();
        public Task<string> WriteToStream(string topicName,string text); 
    }
}
