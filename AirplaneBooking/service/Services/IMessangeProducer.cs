namespace service.Services
{
    public interface IMessangeProducer
    {
        public void SendMessage<T>(T message);
        
    }
}