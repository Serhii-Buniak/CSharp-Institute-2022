namespace IdentityMicroService.BLL.Subscribers
{
    public interface ICountryEventProcessor
    {
        void ProcessEvent(string message);
    }
}