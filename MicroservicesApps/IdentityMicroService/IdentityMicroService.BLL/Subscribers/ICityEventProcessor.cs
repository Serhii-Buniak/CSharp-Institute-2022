namespace IdentityMicroService.BLL.Subscribers;

public interface ICityEventProcessor
{
    void ProcessEvent(string message);
}