namespace EventMicroService.Domain.Common;

public interface IExternalEntity<EKey>
{
    public EKey ExternalId { get; set; }
}
