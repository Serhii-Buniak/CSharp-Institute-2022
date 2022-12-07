namespace IdentityMicroService.BLL.Subscribers.Processor
{
    public interface ICountryEventProcessor
    {
        void ProcessEvent(string message);
    }
}